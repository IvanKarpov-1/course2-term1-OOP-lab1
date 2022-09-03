using DAL;
using System;

namespace BLL
{
    public class EntityCreator
    {
        private readonly DataStorage _dataStorage;

        private readonly Type[] _persons =
        {
            typeof(Student),
            typeof(McdonaldsWorker),
            typeof(Manager)
        };

        public EntityCreator(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public void Create(EntitiesType entityType, object[] parameters)
        {
            _dataStorage.Add((Person)Activator.CreateInstance(_persons[(int)entityType], parameters));
        }
    }
}