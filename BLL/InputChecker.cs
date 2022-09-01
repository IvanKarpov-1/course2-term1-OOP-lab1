using System.Text.RegularExpressions;

namespace BLL
{
    public static class InputChecker
    {
        private static readonly string[] Rules = new[]
        { 
            @"(^[A-Z]{1}[a-z]+$)|(^[А-я]{1}[а-я]+$)", 
            @"^[1-6]{1}?",
            @"^[A-Z]{2}[0-9]{8}$",
            @"(^[0-9]{1,2}\.[0-9]{2})|(100\.00)",
            @"^[0-9]{8}$",
            @"^\$[0-9]{3}\,[0-9]{2}$",
            @"(^[YN|ТН]{1}$)|(^(Yes|No)|(Так|Ні){1}$)",
            @"^[0-9]{0,5}$",
            @"^[A-Z]:{1}(\\$|((\\[\s0-9A-Za-zА-Яа-я-_]+)+)\\$)",
            @"^\.[0-9A-Za-z]+$",
        };

        public static bool Check(string data, RulesForChecker typeOfRule)
        {
            var regex = new Regex(Rules[(int)typeOfRule]);
            return regex.IsMatch(data);
        }
    }
}
