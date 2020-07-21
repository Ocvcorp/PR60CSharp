/*
Класс№1 – DataExtractor – получает данные (текст с почтовыми адресами и именами) и генерит событие о получении.
Класс№2 – DataReceiver1 (Принимает в конструктор объект DataExtractor. Подписывается на событие и обновляет собственное поле 
(почтовые адреса) в обработчике события полученными данными.
Класс№3 – DataReceiver2 -//- класс берет имена 
Запустить работу трех классов через Main 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class DataExtractor
    {
        public string TextData { get; }
        public event EventHandler RecieveEvent;
        public DataExtractor(string inputText)
        {
            TextData = inputText;
        }
        public void OnRecieveEvent()
        {
            RecieveEvent?.Invoke(this, EventArgs.Empty);
        }
    }
    public class DataReceiver1
    {
        DataExtractor dataExtractor;
        List<string> Emails;
        public DataReceiver1(DataExtractor dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }
        public void Handler(object sender, EventArgs e)
        {
            string text = dataExtractor.TextData;
            Regex regex = new Regex(@"\w*\@\w*\.\w*", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                Emails = new List<string>(matches.Count);
                foreach (Match match in matches)
                {
                    Emails.Add(match.Value);
                }
            }
        }
        public void PrintEmails()
        {
            if (Emails.Count > 0)
            {
                Console.WriteLine("E-mails:");
                foreach (string email in Emails)
                {
                    Console.WriteLine(email);
                }
            }
            else
                Console.WriteLine("No e-mails found");
        }
    }
    class DataReceiver2
    {
        DataExtractor dataExtractor;
        List<string> Names;
        public DataReceiver2(DataExtractor dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }
        public void Handler(object sender, EventArgs e)
        {
            string text = dataExtractor.TextData;
            Regex regex = new Regex(@"[A-Z]\w*\s?");
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                Names = new List<string>(matches.Count);
                foreach (Match match in matches)
                {
                    Names.Add(match.Value);
                }
            }
        }
        public void PrintNames()
        {
            if (Names?.Count > 0)
            {
                Console.WriteLine("Names:");
                foreach (string name in Names)
                {
                    Console.WriteLine(name);
                }
            }
            else
                Console.WriteLine("No names found");
        }
        public class Program
        {
            public static void Main()
            {
                string str = "ghTom gfhf Abrots@yandex.ru Anton simpo@google.com dfdsfsfsfdf Syndy";
                Console.WriteLine($"Input string\n{str}\n");
                DataExtractor dataExtractor = new DataExtractor(str);
                DataReceiver1 emailReceiver = new DataReceiver1(dataExtractor);
                DataReceiver2 nameReceiver = new DataReceiver2(dataExtractor);
                dataExtractor.RecieveEvent += emailReceiver.Handler;
                dataExtractor.RecieveEvent += nameReceiver.Handler;
                dataExtractor.OnRecieveEvent();
                emailReceiver.PrintEmails();
                Console.WriteLine();
                nameReceiver.PrintNames();
            }
        }
    }
}
