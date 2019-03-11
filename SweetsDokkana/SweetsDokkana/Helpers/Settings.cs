using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace SweetsDokkana.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserId
        {
            get => AppSettings.GetValueOrDefault(nameof(UserId), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UserId), value);

        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);

        }
    }
}
