using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.Configuration
{
    public class AppManager
    {
        private static AppSettings appSettings;
        private static bool currentRole { get; set; }

        public static bool getCurrentRole()
        {
            return currentRole;
        }
        public static void setCurrentRole(bool role)
        {
            currentRole = role;
        }
        public static AppSettings GetAppsetting()
        {
            var currentDir = Environment.CurrentDirectory;
            var path = currentDir + @"\Configuration\appsettings.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                try
                {
                    appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
                }
                catch (Exception ex)
                {

                }
            }
            return appSettings;
        }
    }

    public class AppSettings
    {
        public AdminAccount AdminAccount { get; set; }
    }
     public class AdminAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
