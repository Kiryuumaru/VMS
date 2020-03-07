using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Services
{
    public class Destination
    {
        public string Name { get; private set; }
        public long VisitCount { get; set; }
        public Destination(string name, long visitCount = 0)
        {
            Name = name;
            VisitCount = visitCount;
        }
    }
    public class History
    {
        public string UserName { get; private set; }
        public string Destination { get; private set; }
        public DateTime DateTime { get; private set; }
        public History(string userName, string destination, DateTime dateTime)
        {
            UserName = userName;
            Destination = destination;
            DateTime = dateTime;
        }
    }

    public class User
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public long ContactNumber { get; private set; }
        public int LeftFingerprintId { get; private set; }
        public int RightFingerprintId { get; private set; }
        public User(string id, string name, string gender, long contactNumber, int leftFingerprintId, int rightFingerprintId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            ContactNumber = contactNumber;
            LeftFingerprintId = leftFingerprintId;
            RightFingerprintId = rightFingerprintId;
        }
        public bool HasFingerId(int id)
        {
            return LeftFingerprintId == id || RightFingerprintId == id;
        }
    }

    public static class PartialDB
    {
        public static bool TryPassword(string pass)
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!File.Exists(Extension.Admin)) File.WriteAllText(Extension.Admin, "123123");
            return File.ReadAllText(Extension.Admin).Equals(pass);
        }

        public static Destination[] GetDestinations()
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!File.Exists(Extension.Destinations)) File.WriteAllText(Extension.Destinations, "");
            string[] destInfos = File.ReadAllLines(Extension.Destinations);
            List<Destination> dest = new List<Destination>();
            foreach (string info in destInfos)
            {
                string name = Extension.Helpers.GetValue(info, "name");
                long visitCount = Convert.ToInt64(Extension.Helpers.GetValue(info, "visit"));
                dest.Add(new Destination(name, visitCount));
            }
            return dest.ToArray();
        }

        public static void SetDestination(Destination destination)
        {
            List<Destination> destinations = new List<Destination>(GetDestinations());
            Destination oldDestination = destinations.FirstOrDefault(item => item.Name.Equals(destination.Name));
            if (oldDestination != null)
            {
                destinations.Remove(oldDestination);
            }
            destinations.Add(destination);
            string blob = "";
            foreach (Destination d in destinations)
            {
                string subBlob = Extension.Helpers.SetValue("", "name", d.Name);
                subBlob = Extension.Helpers.SetValue(subBlob, "visit", d.VisitCount.ToString());
                blob += subBlob + Environment.NewLine;
            }
            File.WriteAllText(Extension.Destinations, blob);
        }

        public static void DeleteDestination(string name)
        {
            List<Destination> destinations = new List<Destination>(GetDestinations());
            Destination oldDestination = destinations.FirstOrDefault(item => item.Name.Equals(name));
            if (oldDestination != null)
            {
                destinations.Remove(oldDestination);
                string blob = "";
                foreach (Destination d in destinations)
                {
                    string subBlob = Extension.Helpers.SetValue("", "name", d.Name);
                    subBlob = Extension.Helpers.SetValue(subBlob, "visit", d.VisitCount.ToString());
                    blob += subBlob + Environment.NewLine;
                }
                File.WriteAllText(Extension.Destinations, blob);
            }
        }

        public static History[] GetHistory()
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!File.Exists(Extension.History)) File.WriteAllText(Extension.History, "");
            string[] historyInfos = File.ReadAllLines(Extension.History);
            List<History> hist = new List<History>();
            foreach (string info in historyInfos)
            {
                string name = Extension.Helpers.GetValue(info, "name");
                string dest = Extension.Helpers.GetValue(info, "dest");
                DateTime time = Extension.Helpers.DecodeDateTime(Extension.Helpers.GetValue(info, "time"));
                hist.Add(new History(name, dest, time));
            }
            return hist.ToArray();
        }

        public static void AddHistory(History history)
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!File.Exists(Extension.History)) File.WriteAllText(Extension.History, "");
            List<string> historyInfos = new List<string>(File.ReadAllLines(Extension.History));
            string blob = "";
            blob = Extension.Helpers.SetValue(blob, "name", history.UserName);
            blob = Extension.Helpers.SetValue(blob, "dest", history.Destination);
            blob = Extension.Helpers.SetValue(blob, "time", Extension.Helpers.EncodeDateTime(history.DateTime));
            historyInfos.Insert(0, blob);
            File.WriteAllLines(Extension.History, historyInfos);
        }

        public static void ClearHistory()
        {
            File.WriteAllText(Extension.History, "");
        }

        public static User[] GetUsers()
        {
            if (!Directory.Exists(Extension.AssetsDir)) Directory.CreateDirectory(Extension.AssetsDir);
            if (!File.Exists(Extension.Users)) File.WriteAllText(Extension.Users, "");
            string[] userInfos = File.ReadAllLines(Extension.Users);
            List<User> users = new List<User>();
            foreach (string info in userInfos)
            {
                string id = Extension.Helpers.GetValue(info, "id");
                string name = Extension.Helpers.GetValue(info, "name");
                string gender = Extension.Helpers.GetValue(info, "gender");
                long contactNumber = Convert.ToInt64(Extension.Helpers.GetValue(info, "contact_number"));
                int left = Convert.ToInt32(Extension.Helpers.GetValue(info, "left"));
                int right = Convert.ToInt32(Extension.Helpers.GetValue(info, "right"));
                users.Add(new User(id, name, gender, contactNumber, left, right));
            }
            return users.ToArray();
        }

        public static int GetNextLeftFingerprintId()
        {
            int lastId = 0;
            foreach (User user in GetUsers())
            {
                if (user.RightFingerprintId >= lastId) lastId = user.RightFingerprintId;
            }
            return lastId + 1;
        }

        public static int GetNextRightFingerprintId()
        {
            int lastId = 0;
            foreach (User user in GetUsers())
            {
                if (user.RightFingerprintId >= lastId) lastId = user.RightFingerprintId;
            }
            return lastId + 2;
        }

        public static void SetUser(User user)
        {
            List<User> users = new List<User>(GetUsers());
            User oldUser = users.FirstOrDefault(item => item.Id.Equals(user.Id));
            if (oldUser != null)
            {
                users.Remove(oldUser);
            }
            users.Add(user);
            string blob = "";
            foreach (User u in users)
            {
                string subBlob = Extension.Helpers.SetValue("", "id", u.Id.ToString());
                subBlob = Extension.Helpers.SetValue(subBlob, "name", u.Name);
                subBlob = Extension.Helpers.SetValue(subBlob, "gender", u.Gender);
                subBlob = Extension.Helpers.SetValue(subBlob, "contact_number", u.ContactNumber.ToString());
                subBlob = Extension.Helpers.SetValue(subBlob, "left", u.LeftFingerprintId.ToString());
                subBlob = Extension.Helpers.SetValue(subBlob, "right", u.RightFingerprintId.ToString());
                blob += subBlob + Environment.NewLine;
            }
            File.WriteAllText(Extension.Users, blob);
        }

        public static void DeleteUser(string id)
        {
            List<User> users = new List<User>(GetUsers());
            User oldUser = users.FirstOrDefault(item => item.Id.Equals(id));
            if (oldUser != null)
            {
                users.Remove(oldUser);
                string blob = "";
                foreach (User u in users)
                {
                    string subBlob = Extension.Helpers.SetValue("", "id", u.Id.ToString());
                    subBlob = Extension.Helpers.SetValue(subBlob, "name", u.Name);
                    subBlob = Extension.Helpers.SetValue(subBlob, "gender", u.Gender);
                    subBlob = Extension.Helpers.SetValue(subBlob, "contact_number", u.ContactNumber.ToString());
                    subBlob = Extension.Helpers.SetValue(subBlob, "left", u.LeftFingerprintId.ToString());
                    subBlob = Extension.Helpers.SetValue(subBlob, "right", u.RightFingerprintId.ToString());
                    blob += subBlob + Environment.NewLine;
                }
                File.WriteAllText(Extension.Users, blob);
            }
        }

        public static void ClearData()
        {
            File.WriteAllText(Extension.Destinations, "");
            File.WriteAllText(Extension.Users, "");
            File.WriteAllText(Extension.History, "");
            Biometric.Flash();
        }
    }
}
