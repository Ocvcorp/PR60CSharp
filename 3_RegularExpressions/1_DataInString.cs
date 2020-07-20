/*
Задание на регулярные выражения
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class lec9_11
    {
        static void Main()
        {
            string inputString;
            string regString;
            //9. Используя регулярные выражения найти все вхождения даты в строке
            inputString = "feahofha  fhoshf in 31 September 2014 to 31 December 2014, adding to the sign fhdlakadf​";
            regString = @"(\d{2}\s+\w+\s+\d{4})";
            Console.WriteLine("Dates in sequence: "+inputString);
            MatchFind(inputString,regString);

            //10. Найти все слова в строке, начинающиеся с подстроки «теле»​
            inputString = "Телепузики играли с телевизором. Их заметили с телевышки и позвонили по телефону. Оператор ТЕЛЕ2​";
            regString = @"(теле\w+)";
            Console.WriteLine("Слова, начинающиеся с \"теле\" в тексте: " + inputString);
            MatchFind(inputString, regString);

            //11. Записать регулярные выражения для поиска дат
            string ouputStr;
            ouputStr = "30-June-17: " +
                    MounthsFindVar1("30-June-17", @"(\d{2})-(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\w*-(\d{2})");
            Console.WriteLine(ouputStr);
            ouputStr = "September 30, 2012: " +
                    MounthsFindVar2("September 30, 2012", @"(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\w*\s(\d{2}),\s(\d{4})");
            Console.WriteLine(ouputStr);
            string d="", m, y;
            ouputStr = "31/12/2010: ";
            if (MounthsFindVar0("31/12/2010", @"(\d{2})\/(\d{2})\/(\d{2,4})", out d, out d1, out m, out m1, out y))
            {
                DateTime date = new DateTime(Convert.ToInt32(y), Convert.ToInt32(m), Convert.ToInt32(d));
                Console.WriteLine(ouputStr + date.ToString("dd MMM yy"));
            }
            else
            {
                Console.WriteLine(ouputStr+d);
            }
			//Периоды
			string d2, m2;
			ouputStr = "CURRENT PERIOD (01/01-31/12/2013): ";
            if (PeriodFindVar0("CURRENT PERIOD (01/01-31/12/2013)", @"(\d{2})\/(\d{2})-(\d{2})\/(\d{2})\/(\d{2,4})", out d, out m, out y))
            {
                DateTime date1 = new DateTime(Convert.ToInt32(y), Convert.ToInt32(m), Convert.ToInt32(d));
				DateTime date2 = new DateTime(Convert.ToInt32(y), Convert.ToInt32(m1), Convert.ToInt32(d1));
                Console.WriteLine(ouputStr + date1.ToString("dd MMM yy")+"-"+date2.ToString("dd MMM yy"));
            }
            else
            {
                Console.WriteLine(ouputStr+d);
            }
			ouputStr = "January 1 - September 30, 2012: " +
                    MounthsFindVar2("January 1 - September 30, 2012", @"(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\w*\s(\d{2}),\s(\d{4})");
            Console.WriteLine(ouputStr);
			
            Console.ReadKey();
			
        }

        static void MatchFind(string inputString, string regString)
        {
            Regex regDate = new Regex(regString, RegexOptions.IgnoreCase);
            MatchCollection matches = regDate.Matches(inputString);
            
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    Console.WriteLine(m.Value);
                }
            }
            else
            {
                Console.WriteLine("No matching found");
            }
        }
        static bool MounthsFindVar0(string inputString, string regString, out string day, out string mounth, out string year)
        {
            bool result = false;
            day="Nothing found";
            mounth = "";
            year = "";
            Regex regDate = new Regex(regString, RegexOptions.IgnoreCase);
            MatchCollection matches = regDate.Matches(inputString);
            if (matches[0].Groups.Count == 4)
            {
                day = matches[0].Groups[1].Value;
                mounth = matches[0].Groups[2].Value;
                year=matches[0].Groups[3].Value;
                result = true;
            }
            return result;
        }
		static bool PeriodFindVar0(string inputString, string regString, 
									out string day1, out string day2, out string mounth1, out string mounth2, out string year)
        {
            bool result = false;
            day="Nothing found";
            mounth = "";
            year = "";
            Regex regDate = new Regex(regString, RegexOptions.IgnoreCase);
            MatchCollection matches = regDate.Matches(inputString);
            if (matches[0].Groups.Count == 6)
            {
                day1 = matches[0].Groups[1].Value;
				day2 = matches[0].Groups[3].Value;
                mounth1 = matches[0].Groups[2].Value;
				mounth2 = matches[0].Groups[4].Value;
                year=matches[0].Groups[5].Value;
                result = true;
            }
            return result;
        }
        static string MounthsFindVar1(string inputString, string regString)
        {
            string result = "Nothing found";
            Dictionary<string, string> mounths = new Dictionary<string, string>(12);
            mounths.Add("jan", "01");
            mounths.Add("feb", "02");
            mounths.Add("mar", "03");
            mounths.Add("apr", "04");
            mounths.Add("may", "05");
            mounths.Add("jun", "06");
            mounths.Add("jul", "07");
            mounths.Add("aug", "08");
            mounths.Add("sep", "09");
            mounths.Add("oct", "10");
            mounths.Add("nov", "11");
            mounths.Add("dec", "12");
            Regex regDate = new Regex(regString, RegexOptions.IgnoreCase);
            MatchCollection matches = regDate.Matches(inputString);
            if (matches[0].Groups.Count == 4)
            {                
                result = matches[0].Groups[1].Value +"-"+ mounths[matches[0].Groups[2].Value.ToLower()]+"-"+ matches[0].Groups[3].Value;               
            }
			if (matches[0].Groups.Count == 5)
            {                
                result = matches[0].Groups[1].Value +"-"+ mounths[matches[0].Groups[2].Value.ToLower()];               
            }
            return result;
        }
        static string MounthsFindVar2(string inputString, string regString)
        {
            string result = "Nothing found";
            Dictionary<string, string> mounths = new Dictionary<string, string>(12);
            mounths.Add("jan", "01");
            mounths.Add("feb", "02");
            mounths.Add("mar", "03");
            mounths.Add("apr", "04");
            mounths.Add("may", "05");
            mounths.Add("jun", "06");
            mounths.Add("jul", "07");
            mounths.Add("aug", "08");
            mounths.Add("sep", "09");
            mounths.Add("oct", "10");
            mounths.Add("nov", "11");
            mounths.Add("dec", "12");
            Regex regDate = new Regex(regString, RegexOptions.IgnoreCase);
            MatchCollection matches = regDate.Matches(inputString);
            if (matches[0].Groups.Count == 4)
            {
                result = matches[0].Groups[2].Value + "-" + mounths[matches[0].Groups[1].Value.ToLower()] + "-" + matches[0].Groups[3].Value;
            }
			if (matches[0].Groups.Count == 6)
            {
                result = matches[0].Groups[2].Value + " " + mounths[matches[0].Groups[1].Value.ToLower()] + " " + matches[0].Groups[5].Value + 
						 "-"+matches[0].Groups[4].Value + " " + mounths[matches[0].Groups[3].Value.ToLower()] + " " + matches[0].Groups[5].Value;
            }
            return result;
        }
    }
}
