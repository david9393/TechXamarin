using CommonShared.Dependencies.EntityFrameworkCore;
using Constants.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TechnicalTest.Classes.EntityFrameworkCore
{
    public class EntityFrameworkCoreDependency : IEntityFrameworkCoreDependency
    {
        public string GetDatabasePath()
        {
            String databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", DatabaseSettings.DATABASE_NAME); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseSettings.DATABASE_NAME);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            return databasePath;
        }
    }
}
