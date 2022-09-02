using System;

namespace DAL
{
    public class DataStorage
    {
        public Student[] Students { get; private set; }
        public McdonaldsWorker[] McdonaldsWorkers { get; private set; }
        public Manager[] Managers { get; private set; }

        public DataStorage()
        {
            SetEmpty();
        }

        public void SetEmpty()
        {
            Students = Array.Empty<Student>();
            McdonaldsWorkers = Array.Empty<McdonaldsWorker>();
            Managers = Array.Empty<Manager>();
        }

        public void Add(Person entity)
        {
            var thisProperties = GetType().GetProperties();

            foreach (var property in thisProperties)
            {
                if (property.PropertyType != entity.GetType().MakeArrayType()) continue;
                var array = (Array)property.GetValue(this);
                var typeOfArrayElements = array.GetType().GetElementType();
                var newArray = Array.CreateInstance(typeOfArrayElements, array.Length + 1);
                Array.Copy(array, newArray, Math.Min(array.Length, newArray.Length));
                array = newArray;
                array.SetValue(entity, array.Length - 1);
                property.SetValue(this, array);
                break;
            }
        }
    }
}