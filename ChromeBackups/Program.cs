namespace ChromeBackups
{
    internal class Program
    {
        private readonly ChromeSessionBackups chromeSessionBackup;
        private readonly DirectoryManager directoryManager;

        private Program()
        {
            directoryManager = new DirectoryManager(new PathsManager());
            chromeSessionBackup = new ChromeSessionBackups(directoryManager);
        }

        private static void Main(string[] args)
        {
            var program = new Program();
            program.CreateAllDirectoriesIfNotExists();
            program.CreateChromeSessionBackup();
        }

        private void CreateChromeSessionBackup()
        {
            chromeSessionBackup.CreateChromeBackups();
        }

        private void CreateAllDirectoriesIfNotExists()
        {
            directoryManager.CreateAllDirectoriesIfNotExists();
        }
    }
}