using DAL;
using System;

namespace BLL
{
    public class CreateEntity
    {
        private readonly DataStorage _dataStorage;
        private readonly Type[] _persons =
        {
            typeof(Student),
            typeof(McdonaldsWorker),
            typeof(Manager)
        };

        public CreateEntity(DataStorage dataStorage) => _dataStorage = dataStorage;

        public void Create(EntitiesType entityType, object[] parameters)
        {
            _dataStorage.Add((Person)Activator.CreateInstance(_persons[(int)entityType], parameters));
        }
    }
}
