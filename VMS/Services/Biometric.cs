using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortLib;

namespace VMS.Services
{
    public static class Biometric
    {
        private static SerialPortInput sp;
        private static Action<string> onGet;
        private static Action onSetFinger1;
        private static Action onSetFinger2;
        private static Action onSetError;
        public static string Port { get; private set; } = "";
        public static bool Connected { get; private set; } = false;

        public static void Init(string port)
        {
            sp = new SerialPortInput();
            sp.ConnectionStatusChanged += (s, e) => Connected = e.Connected;
            sp.MessageReceived += (s, e) =>
            {
                string msg = Encoding.Default.GetString(e.Data);
                switch (msg)
                {
                    case "OK1\r\n":
                        onSetFinger1?.Invoke();
                        break;
                    case "OK2\r\n":
                        onSetFinger2?.Invoke();
                        break;
                    case "ERR\r\n":
                        onSetError?.Invoke();
                        break;
                    default:
                        onGet?.Invoke(msg.Replace("\r\n", ""));
                        break;
                }
                Console.WriteLine("Received message: " +  msg);
            };
            Port = port;
            sp.SetPort(port, 9600);
            sp.Connect();
            Standby();
            Application.ApplicationExit += delegate
            {
                sp.Disconnect();
            };
        }

        public static void Set(int id, Action onFinger1, Action onFinger2, Action onError)
        {
            try
            {
                onSetFinger1 = onFinger1;
                onSetFinger2 = onFinger2;
                onSetError = onError;
                sp.SendMessage(Encoding.Default.GetBytes(id.ToString()));
            }
            catch
            {
                onError.Invoke();
            }
        }

        public static void Get(Action<string> onIdentify)
        {
            onGet = onIdentify;
            sp.SendMessage(Encoding.Default.GetBytes("-1"));
        }

        public static void Standby()
        {
            sp.SendMessage(Encoding.Default.GetBytes("0"));
        }

        public static void Flash()
        {
            sp.SendMessage(Encoding.Default.GetBytes("-2"));
        }
    }
}
