using DAL;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BLL
{
    public class DataPresenter
    {
        private readonly DataStorage _dataStorage;

        public DataPresenter(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public string GetFullInfo()
        {
            return GetInfo(false);
        }

        public string GetConcretePersonInfo(string firstName, string lastName)
        {
            return GetInfo(true, firstName, lastName);
        }

        public static string TransformDataIntoGeneralView(string data)
        {
            var dataTransformed = string.Empty;
            var dataSplitted = data.Split(new[] { "}\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in dataSplitted)
            {
                var temp = Regex.Replace(element, @"{\s""|[{}"":;]", "").Split('\n');
                dataTransformed += $"{temp[0]}\n";

                for (var i = 1; i < temp.Length; i++)
                {
                    var temp2 = temp[i].Split();
                    dataTransformed += $"{temp2[0],-20} {temp2[1],-10}\n";
                }

                dataTransformed += "\n";
            }

            return dataTransformed;
        }

        private string GetInfo(bool isNeedSearch, string firstName = "", string lastName = "")
        {
            var data = string.Empty;

            foreach (var property in typeof(DataStorage).GetProperties())
            {
                var valuesFromPropertyArray = (Array)property.GetValue(_dataStorage);

                for (var i = 0; i < valuesFromPropertyArray.Length; i++)
                {
                    var singleValue = valuesFromPropertyArray.GetValue(i);
                    var typeOfValue = singleValue.GetType();

                    if (isNeedSearch)
                    {
                        if (!(typeOfValue.GetProperty("FirstName")?.GetValue(singleValue).ToString() == firstName &&
                              typeOfValue.GetProperty("LastName")?.GetValue(singleValue).ToString() == lastName))
                        {
                            continue;
                        }
                    }

                    data += $"{singleValue.ToString().Remove(0, 4)} ";
                    data += $"{typeOfValue.GetProperty("FirstName")?.GetValue(singleValue)}";
                    data += $"{typeOfValue.GetProperty("LastName")?.GetValue(singleValue)}\n";

                    foreach (var valuesProperty in typeOfValue.GetProperties(BindingFlags.Instance |
                                                                             BindingFlags.NonPublic |
                                                                             BindingFlags.Public | BindingFlags.Static).Reverse())
                    {
                        if (valuesProperty.PropertyType.IsArray == false)
                        {
                            data += $"{valuesProperty.Name,-20} {valuesProperty.GetValue(singleValue),-10}\n";
                        }
                    }

                    data += "\n";
                }
            }

            return data;
        }
    }
}