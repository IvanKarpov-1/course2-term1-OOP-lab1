using System.Text.RegularExpressions;

namespace BLL
{
    public static class InputChecker
    {
        private static readonly string[] Rules = new[]
        {
            @"(^[A-Z]{1}[a-z]+$)|(^[А-я]{1}[а-я]+$)",               // NameAndCountry
            @"^[1-6]{1}?",                                          // Course
            @"^[A-Z]{2}[0-9]{8}$",                                  // StudentId
            @"(^[0-9]{1,2}\.[0-9]{2})|(100\.00)",                   // Gpa
            @"^[0-9]{8}$",                                          // NumberOfScoreBook
            @"^\$[0-9]{3}\,[0-9]{2}$",                              // Salary                  
            @"(^[YN|ТН]{1}$)|(^(Yes|No)|(Так|Ні){1}$)",             // Diploma
            @"^[0-9]{0,5}$",                                        // CountOfSubordinates
            @"^[A-Z]:{1}(\\$|((\\[\s0-9A-Za-zА-Яа-я-_]+)+)\\$)",    // Path
            @"^\.[0-9A-Za-z]+$"                                     // FileExtension
        };

        public static bool Check(string data, NameOfRulesForChecker typeOfRule)
        {
            var regex = new Regex(Rules[(int)typeOfRule]);
            return regex.IsMatch(data);
        }
    }
}