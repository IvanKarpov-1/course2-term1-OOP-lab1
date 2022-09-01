using BLL;
using System.Globalization;

namespace PL
{
    internal static class InputData
    {
        public static string Name(string typeOfName)
        {
            return AskForData($"Введіть {typeOfName}:", RulesForChecker.NameAndCountry);
        }

        public static string Course()
        {
            return AskForData("Введіть курс (1-6):", RulesForChecker.Course);
        }

        public static string StudentId()
        {
            return AskForData("Ведіть ID студента (фомат: AB12345678):", RulesForChecker.StudentId);
        }

        public static double Gpa()
        {
            var formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return double.Parse(AskForData("Введіть середній бал студента (0.00 - 100.00):", RulesForChecker.Gpa), formatter);
        }

        public static string Country()
        {
            return AskForData("Введіть країну проживання:", RulesForChecker.NameAndCountry);
        }

        public static string NumberOfScoreBook()
        {
            return AskForData("Введіть номер залікової книжки (формат: 12345678):", RulesForChecker.NumberOfScoreBook);
        }

        public static string Salary()
        {
            return AskForData("Введіть зарплату (формат: $123,22):", RulesForChecker.Salary);
        }

        public static bool Diploma()
        {
            var valueString = AskForData("Чи має диплом? (T/F, Т/Н, Yes/No, Так/Ні):", RulesForChecker.Diploma);
            return valueString == "T" || valueString == "Т" || valueString == "Yes" || valueString == "Так";
        }

        public static int CountOfSubordinates()
        {
            return int.Parse(AskForData("Введіть кількість підлеглих (0-99999)", RulesForChecker.CountOfSubordinates));
        }

        public static string Path()
        {
            return AskForData("Введіть шлях для збереження даних (в кінці має стояти \"\\\"):", RulesForChecker.Path);
        }

        public static string FileName()
        {
            return AskForData("Введіть ім'я файлу (без розширення):", RulesForChecker.NameAndCountry);
        }

        public static string FileExtension()
        {
            return AskForData("Введіть розширення файлу (починаючи з крапки):", RulesForChecker.FileExtension);
        }

        private static string AskForData(string message, RulesForChecker ruleName)
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
