using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MaratonaApp.Helpers
{

    public static class Settings
    {
        /// <summary>
        /// Current platform information
        /// </summary>
        private static ISettings AppSettings => CrossSettings.Current;

        /// <summary>
        /// User Identification key/value pair
        /// </summary>
        private const string UserIdKey = "userid";
        private static readonly string UserIdDefault = string.Empty;

        /// <summary>
        /// Authentication token key/value pair
        /// </summary>
        private const string AuthTokenKey = "authtoken";
        private static readonly string AuthTokenDefault = string.Empty;

        /// <summary>
        /// Public authentication token property
        /// </summary>
        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value); }
        }

        /// <summary>
        /// Public user identification property
        /// </summary>
        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserId, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserId, value); }
        }

        /// <summary>
        /// Store if user's already signed in
        /// </summary>
        public static bool isLoggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}