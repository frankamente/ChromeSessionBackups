using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ChromeSessionBackups
{
    public class DirectoryManager
    {
        private readonly PathsManager pathsManager;

        public DirectoryManager(PathsManager pathsManager)
        {
            this.pathsManager = pathsManager;
        }

        public void CreateAllDirectoriesIfNotExists()
        {
            CreateDirectoryIfNotExists(pathsManager.GetRootDirectory());
            CreateDirectoryIfNotExists(pathsManager.GetLastFolderDirectory());
            CreateDirectoryIfNotExists(pathsManager.GetPenultimateFolderDirectory());
            CreateDirectoryIfNotExists(pathsManager.GetAntepenultimateFolderDirectory());
        }

        private void CreateDirectoryIfNotExists(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        public bool ExistsBackupsInChromeFolder()
        {
            return ExistsBackupsInFolder(pathsManager.GetChromeFolderDirectory());
        }

        public bool ExistsBackupsInLastFolder()
        {
            return ExistsBackupsInFolder(pathsManager.GetLastFolderDirectory());
        }

        public bool ExistsBackupsInPenultimateFolder()
        {
            return ExistsBackupsInFolder(pathsManager.GetPenultimateFolderDirectory());
        }

        public bool ExistsBackupsInAntepenultimateFolder()
        {
            return ExistsBackupsInFolder(pathsManager.GetAntepenultimateFolderDirectory());
        }

        private bool ExistsBackupsInFolder(string folderPath)
        {
            return Directory.GetFiles(folderPath).Any();
        }

        public void MoveBackupFromChromeToLastFolder()
        {
            Debug.Assert(ExistsBackupsInChromeFolder());
            var initialPath = pathsManager.GetChromeFolderDirectory();
            var finalPath = pathsManager.GetLastFolderDirectory();
            CopyAllBackups(initialPath, finalPath);
        }

        public void MoveBackupFromLastToPenultimateFolder()
        {
            Debug.Assert(ExistsBackupsInLastFolder());
            var initialPath = pathsManager.GetLastFolderDirectory();
            var finalPath = pathsManager.GetPenultimateFolderDirectory();
            MoveAllBackups(initialPath, finalPath);
        }

        public void MoveBackupFromPenultimateToAntepenultimateFolder()
        {
            Debug.Assert(ExistsBackupsInPenultimateFolder());
            var initialPath = pathsManager.GetPenultimateFolderDirectory();
            var finalPath = pathsManager.GetAntepenultimateFolderDirectory();
            MoveAllBackups(initialPath, finalPath);
        }

        private void MoveAllBackups(string initialPath, string finalPath)
        {
            try
            {
                MoveFile(GetLastTabsFilenamePath(initialPath), GetLastTabsFilenamePath(finalPath));
                MoveFile(GetLastSessionFilenamePath(initialPath), GetLastSessionFilenamePath(finalPath));
                MoveFile(GetCurrentTabsFilenamePath(initialPath), GetCurrentTabsFilenamePath(finalPath));
                MoveFile(GetCurrentSessionFilenamePath(initialPath), GetCurrentSessionFilenamePath(finalPath));
            }
            catch (Exception)
            {
                Console.WriteLine("Please close chrome before execute program");
                Console.ReadLine();
            }
        }

        private void MoveFile(string initialPath, string finalPath)
        {
            File.Move(initialPath, finalPath);
        }

        private void CopyAllBackups(string initialPath, string finalPath)
        {
            try
            {
                CopyFile(GetLastTabsFilenamePath(initialPath), GetLastTabsFilenamePath(finalPath));
                CopyFile(GetLastSessionFilenamePath(initialPath), GetLastSessionFilenamePath(finalPath));
                CopyFile(GetCurrentTabsFilenamePath(initialPath), GetCurrentTabsFilenamePath(finalPath));
                CopyFile(GetCurrentSessionFilenamePath(initialPath), GetCurrentSessionFilenamePath(finalPath));
            }
            catch (Exception)
            {
                Console.WriteLine("Please close chrome before execute program");
                Console.ReadLine();
            }
        }

        private void CopyFile(string initialPath, string finalPath)
        {
            File.Copy(initialPath, finalPath);
        }

        private string GetCurrentTabsFilenamePath(string folderPath)
        {
            return GetFullFilenamePath(folderPath, pathsManager.GetCurrentTabsFileName());
        }

        private string GetCurrentSessionFilenamePath(string folderPath)
        {
            return GetFullFilenamePath(folderPath, pathsManager.GetCurrentSessionFileName());
        }

        private string GetLastTabsFilenamePath(string folderPath)
        {
            return GetFullFilenamePath(folderPath, pathsManager.GetLastTabsFileName());
        }

        private string GetLastSessionFilenamePath(string folderPath)
        {
            return GetFullFilenamePath(folderPath, pathsManager.GetLastSessionFileName());
        }

        private string GetFullFilenamePath(string folderPath, string filename)
        {
            return Path.Combine(folderPath, filename);
        }

        public void DeleteBackupsFromLastFolder()
        {
            Debug.Assert(ExistsBackupsInLastFolder());
            DeleteAllFilesFromFolder(pathsManager.GetLastFolderDirectory());
        }

        public void DeleteBackupFromPenultimateFolder()
        {
            Debug.Assert(ExistsBackupsInPenultimateFolder());
            DeleteAllFilesFromFolder(pathsManager.GetPenultimateFolderDirectory());
        }

        public void DeleteBackupFromAntepenultimateFolder()
        {
            Debug.Assert(ExistsBackupsInAntepenultimateFolder());
            DeleteAllFilesFromFolder(pathsManager.GetAntepenultimateFolderDirectory());
        }

        private void DeleteAllFilesFromFolder(string folderPath)
        {
            foreach (var file in new DirectoryInfo(folderPath).GetFiles()) file.Delete();
        }
    }
}