using System;

namespace ChromeBackups
{
    public class PathsManager
    {
        private const string LAST_FOLDER = "1-Last";
        private const string PENULTIMATE_FOLDER = "2-Penultimate";
        private const string ANTEPENULTIMATE_FOLDER = "3-Antepenultimate";
        private const string CURRENT_SESSION_FILE_NAME = "Current Session";
        private const string CURRENT_TABS_FILE_NAME = "Current Tabs";
        private const string LAST_SESSION_FILE_NAME = "Last Session";
        private const string LAST_TABS_FILE_NAME = "Last Tabs";

        private static readonly string ChromeDirectory =
            $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Google\\Chrome\\User Data\\Default";

        private static readonly string RootDirectory =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/ChromeSession";

        public string GetRootDirectory()
        {
            return RootDirectory;
        }

        private string GetSubDirectory(string subdirectory)
        {
            return $"{RootDirectory}/{subdirectory}";
        }

        public string GetLastFolderDirectory()
        {
            return GetSubDirectory(LAST_FOLDER);
        }

        public string GetPenultimateFolderDirectory()
        {
            return GetSubDirectory(PENULTIMATE_FOLDER);
        }

        public string GetAntepenultimateFolderDirectory()
        {
            return GetSubDirectory(ANTEPENULTIMATE_FOLDER);
        }

        public string GetCurrentTabsFileName()
        {
            return CURRENT_TABS_FILE_NAME;
        }

        public string GetCurrentSessionFileName()
        {
            return CURRENT_SESSION_FILE_NAME;
        }

        public string GetLastTabsFileName()
        {
            return LAST_TABS_FILE_NAME;
        }

        public string GetLastSessionFileName()
        {
            return LAST_SESSION_FILE_NAME;
        }

        public string GetChromeFolderDirectory()
        {
            return ChromeDirectory;
        }
    }
}