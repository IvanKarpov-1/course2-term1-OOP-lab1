using IOStream;
using System;
using System.Linq;
using System.Reflection;

namespace DAL
{
    public class DataSaver : IDisposable
    {
        public void Save(DataStorage dataStorage)
        {
            var data = "";

            foreach (var property in typeof(DataStorage).GetProperties())
            {
                var valuesFromPropertyArray = (Array)property.GetValue(dataStorage);

                for (var i = 0; i < valuesFromPropertyArray.Length; i++)
                {
                    var singleValue = valuesFromPropertyArray.GetValue(i);
                    var typeOfValue = singleValue.GetType();

                    data += $"{singleValue.ToString().Remove(0, 4)} ";
                    data += $"{typeOfValue.GetProperty("FirstName")?.GetValue(singleValue)}";
                    data += $"{typeOfValue.GetProperty("LastName")?.GetValue(singleValue)}\n";
                    data += "{ ";

                    foreach (var valuesProperty in typeOfValue.GetProperties(BindingFlags.Instance |
                                                                             BindingFlags.NonPublic |
                                                                             BindingFlags.Public | BindingFlags.Static).Reverse())
                    {
                        if (valuesProperty.PropertyType.IsArray == false)
                        {
                            data += $"\"{valuesProperty.Name}\": \"{valuesProperty.GetValue(singleValue)}\",\n";
                        }
                    }

                    data += "};\n";
                    data = data.Replace(",\n};", "};");
                }
            }

            using (var fileWriter = new FileWriter())
            {
                fileWriter.Write(data, false);
            }
        }

        public void Dispose()
        {
        }
    }
}