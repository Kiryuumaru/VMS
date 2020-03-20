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
        // Serial input port for biometric
        private static SerialPortInput sp;

        private static Action<string> onGet;
        // Event handler for finger set success and error
        private static Action onSetFinger1;
        private static Action onSetFinger2;
        private static Action onSetFinger3;
        private static Action onSetError;

        public static string Port { get; private set; } = "";
        public static bool Connected { get; private set; } = false;

        // Initialize biometric on serial port
        public static void Init(string port)
        {
            sp = new SerialPortInput();
            // Serial connection event handler
            sp.ConnectionStatusChanged += (s, e) => Connected = e.Connected;
            // Serial message event handler
            sp.MessageReceived += (s, e) =>
            {
                // Decode message
                string msg = Encoding.Default.GetString(e.Data);
                // Classify each message for each event handlers
                switch (msg)
                {
                    case "OK1\r\n":
                        onSetFinger1?.Invoke();
                        break;
                    case "OK2\r\n":
                        onSetFinger2?.Invoke();
                        break;
                    case "OK3\r\n":
                        onSetFinger3?.Invoke();
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
            // Initialize port with 9600 baud rate
            sp.SetPort(port, 9600);
            // Start serial communication
            sp.Connect();
            // Set biometric on standby state
            Standby();
            // Disconnect biometric on application exit
            Application.ApplicationExit += delegate
            {
                sp.Disconnect();
            };
        }

        // Finger save method
        public static void Set(int id, Action onFinger1, Action onFinger2, Action onFinger3, Action onError)
        {
            try
            {
                onSetFinger1 = onFinger1;
                onSetFinger2 = onFinger2;
                onSetFinger3 = onFinger3;
                onSetError = onError;
                sp.SendMessage(Encoding.Default.GetBytes(id.ToString()));
            }
            catch
            {
                onError.Invoke();
            }
        }

        // Finger classify method
        public static void Get(Action<string> onIdentify)
        {
            onGet = onIdentify;
            sp.SendMessage(Encoding.Default.GetBytes("-1"));
        }

        // Biometric standby method
        public static void Standby()
        {
            sp.SendMessage(Encoding.Default.GetBytes("0"));
        }

        // Clear biometric data
        public static void Flash()
        {
            sp.SendMessage(Encoding.Default.GetBytes("-2"));
        }
    }
}
