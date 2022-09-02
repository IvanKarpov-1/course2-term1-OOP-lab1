using IOStream;
using System;
using System.Linq;

namespace BLL
{
    public static class SpecialSearcher
    {
        public static void Start(ref string matches, ref int count)
        {
            string rawData;
            var studentsData = new string[] { };
            var searchedData = string.Empty;

            using (var fileReader = new FileReader())
            {
                rawData = fileReader.Read();
            }

            var rawDataSplitted = rawData.Split(new[] { ";\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in rawDataSplitted)
            {
                if (element.Split()[0] != "Student") continue;

                studentsData = studentsData.Append(element).ToArray();
            }

            foreach (var element in studentsData)
            {
                if ((element.Contains("\"Country\": \"Ukraine\"") || element.Contains("\"Country\": \"Україна\"")) &&
                    element.Contains("\"Course\": \"3\""))
                {
                    searchedData += $"{element}\n";
                    count++;
                }
            }

            matches = DataPresenter.TransformDataIntoGeneralView(searchedData);
        }
    }
}