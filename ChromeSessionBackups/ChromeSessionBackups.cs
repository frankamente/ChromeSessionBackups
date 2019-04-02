namespace ChromeSessionBackups
{
    public class ChromeSessionBackups
    {
        private readonly DirectoryManager directoryManager;

        public ChromeSessionBackups(DirectoryManager directoryManager)
        {
            this.directoryManager = directoryManager;
        }

        public void CreateChromeBackups()
        {
            MovePenultimateBackupsToAntepenultimateFolderIfExist();
            MoveLastBackupsToPenultimateFolderIfExist();
            CopyChromeBackupsToLastFolderIfExist();
        }

        private void CopyChromeBackupsToLastFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInChromeFolder()) return;

            DeleteBackupsFromLastFolderIfExist();
            directoryManager.MoveBackupFromChromeToLastFolder();
        }

        private void DeleteBackupsFromLastFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInLastFolder()) return;

            directoryManager.DeleteBackupsFromLastFolder();
        }

        private void MoveLastBackupsToPenultimateFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInLastFolder()) return;

            DeleteBackupsFromPenultimateFolderIfExist();
            directoryManager.MoveBackupFromLastToPenultimateFolder();
        }

        private void MovePenultimateBackupsToAntepenultimateFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInPenultimateFolder()) return;

            DeleteBackupsFromAntepenultimateFolderIfExist();
            directoryManager.MoveBackupFromPenultimateToAntepenultimateFolder();
        }

        private void DeleteBackupsFromPenultimateFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInPenultimateFolder()) return;

            directoryManager.DeleteBackupFromPenultimateFolder();
        }

        private void DeleteBackupsFromAntepenultimateFolderIfExist()
        {
            if (!directoryManager.ExistsBackupsInAntepenultimateFolder()) return;

            directoryManager.DeleteBackupFromAntepenultimateFolder();
        }
    }
}