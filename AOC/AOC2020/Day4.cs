using AOC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020
{
    class Day4
    {
        private TimeHelper timeHelper;
        private string[] input;
        private List<string> requiredFields;
        public Day4()
        {
            timeHelper = new TimeHelper();
            requiredFields = new List<string>(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" });
            input = ResourceReader.ReadResourceToStringArray(Properties.Resources.Day4, Environment.NewLine + Environment.NewLine);
            timeHelper.Start();
            Console.WriteLine(ValidPasswords().Count);
            timeHelper.Stop();
        }

        private List<string> ValidPasswords()
        {
            return input.Where(pass => requiredFields.All(field => pass.Contains(field)) && ValidatePasswordFields(pass)).ToList();
        }

        private bool ValidatePasswordFields(string password)
        {
            string[] eycolors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            
            string numRegexString = @"([0-9]+)";
            string colorRegex = @"([0-9 a-f]+)";
            Regex numRegex = new Regex(numRegexString);

            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (string field in requiredFields)
            {
                string fieldRegex = $"(?<={field}:).\\S+";
                values[field] = new Regex(fieldRegex).Match(password).Value;
            }
            int byr = Int32.Parse(values["byr"]);
            int iyr = Int32.Parse(values["iyr"]);
            int eyr = Int32.Parse(values["eyr"]);
            int hgt_num = Int32.Parse(numRegex.Match(values["hgt"]).Value);
            string hcl_val = new Regex(colorRegex).Match(values["hcl"]).Value;
            bool eyc = eycolors.Any(color => values["ecl"] == color);

            if ((byr >= 1920 && byr <= 2002) && (iyr >= 2010 && iyr <= 2020) && (eyr >= 2020 && eyr <= 2030) && 
                ((values["hgt"].Contains("cm") && hgt_num >= 150 && hgt_num <= 193) || (values["hgt"].Contains("in") && hgt_num >= 59 && hgt_num <= 76)) &&
                (hcl_val.Length == 6 && values["hcl"].Contains('#')) && eyc && values["pid"].Length == 9)
            {
                return true;
            }
            return false;
        }
    }
}
