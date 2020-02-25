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

    public class User
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public long ContactNumber { get; private set; }
        public User(string name, string gender, long contactNumber)
        {
            Name = name;
            Gender = gender;
            ContactNumber = contactNumber;
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
            string [] destInfos = File.ReadAllLines(Extension.Destinations);
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
    }
}
