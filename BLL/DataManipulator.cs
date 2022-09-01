using DAL;

namespace BLL
{
    public class DataManipulator
    {
        private DataStorage _dataStorage;

        public DataManipulator(DataStorage dataStorage) => _dataStorage = dataStorage;

        public void Save()
        {
            using (var dataSaver  = new DataSaver())
            {
                dataSaver.Save(_dataStorage);
            }
        }

        public void Restore()
        {
            using (var dataRestorer = new DataRestorer())
            {
                dataRestorer.Restore(ref _dataStorage);
            }
        }
    }
}
