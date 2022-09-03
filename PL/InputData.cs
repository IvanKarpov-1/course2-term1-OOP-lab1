using BLL;
using System.Globalization;

namespace PL
{
    internal static class InputData
    {
        public static string Name(string typeOfName)
        {
            return AskForData($"Введіть {typeOfName}:", NameOfRulesForChecker.NameAndCountry);
        }

        public static string Course()
        {
            return AskForData("Введіть курс (1-6):", NameOfRulesForChecker.Course);
        }

        public static string StudentId()
        {
            return AskForData("Ведіть ID студента (фомат: AB12345678):", NameOfRulesForChecker.StudentId);
        }

        public static double Gpa()
        {
            var formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return double.Parse(AskForData("Введіть середній бал студента (0.00 - 100.00):", NameOfRulesForChecker.Gpa),
                formatter);
        }

        public static string Country()
        {
            return AskForData("Введіть країну проживання:", NameOfRulesForChecker.NameAndCountry);
        }

        public static string NumberOfScoreBook()
        {
            return AskForData("Введіть номер залікової книжки (формат: 12345678):", NameOfRulesForChecker.NumberOfScoreBook);
        }

        public static string Salary()
        {
            return AskForData("Введіть зарплату (формат: $123,22):", NameOfRulesForChecker.Salary);
        }

        public static bool Diploma()
        {
            var valueString = AskForData("Чи має диплом? (T/F, Т/Н, Yes/No, Так/Ні):", NameOfRulesForChecker.Diploma);
            return valueString == "T" || valueString == "Т" || valueString == "Yes" || valueString == "Так";
        }

        public static int CountOfSubordinates()
        {
            return int.Parse(AskForData("Введіть кількість підлеглих (0-99999)", NameOfRulesForChecker.CountOfSubordinates));
        }

        public static string Path()
        {
            return AskForData("Введіть шлях для збереження даних (в кінці має стояти \"\\\"):", NameOfRulesForChecker.Path);
        }

        public static string FileName()
        {
            return AskForData("Введіть ім'я файлу (без розширення):", NameOfRulesForChecker.NameAndCountry);
        }

        public static string FileExtension()
        {
            return AskForData("Введіть розширення файлу (починаючи з крапки):", NameOfRulesForChecker.FileExtension);
        }

        private static string AskForData(string message, NameOfRulesForChecker ruleName)
        {
            var text = ConsoleMenu.ReadItem(message);
            do
            {
                if (InputChecker.Check(text, ruleName) == false)
                {
                    ConsoleMenu.ReadItemError();
                    text = ConsoleMenu.ReadItem();
                    continue;
                }

                break;
            } while (true);

            return text;
        }
    }
}