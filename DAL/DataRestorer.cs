using IOStream;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DAL
{
    public class DataRestorer : IDisposable
    {
        public void Restore(ref DataStorage dataStorage)
        {
            string data;

            using (var fileReader = new FileReader())
            {
                data = fileReader.Read();
            }

            var dataSplitted = data.Split(new[] { ";\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in dataSplitted)
            {
                var obj = Activator.CreateInstance(null, "DAL." + element.Split()[0]).Unwrap();
                var elementSplitted = element.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var regex = new Regex(@"(?<="")([\s\S^]+)((?="",)|(?=""))");

                foreach (var el in elementSplitted)
                {
                    if (regex.IsMatch(el) == false) continue;
                    var temp = regex.Match(el).Value.Replace("\": \"", " ").Split(' ');
                    var type = obj.GetType().GetProperty(temp[0])?.PropertyType;
                    var convertedValue = Convert.ChangeType(temp[1], type, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                    obj.GetType().GetProperty(temp[0])?.SetValue(obj, convertedValue);
                }

                dataStorage.Add((Person)obj);
            }
        }

        public void Dispose() { }
    }
}
