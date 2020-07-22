/*
Класс№1 – DataExtractor – получает данные и генерит событие о получении данных.
DataExtractor получает данные из тестового файла, ищет формат <Header><Length><Body>
Класс№2 – DataReceiver (Принимает в конструктор объект DataExtractor. Подписывается на событие и обновляет собственное поле в обработчике события полученными данными.
Логику DataExtractor() запустить в отдельном Task.
В Main реализовать отмену Task по кодовому символу, вводимому со с консоли.

 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DataExtractor
    {
        private string filePath;
        public List<string> extractedData;
        public event EventHandler DataExtracting;
        public DataExtractor(string filePath)
        {
            this.filePath = filePath; 
                  
        }
        public void ExtractInfo(Object ct)
        {           
            StreamReader streamReader= new StreamReader(filePath);
            Regex regex = new Regex(@"<Header>(.*)<Length>(.*)<Body>");
            Match match;
            GroupCollection groups;
            extractedData = new List<string>();
            string line;
            
            CancellationToken cancellationToken = (CancellationToken)ct;
            cancellationToken.ThrowIfCancellationRequested();

            while (!streamReader.EndOfStream)
            {                
                if(cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Получен запрос на отмену задачи");
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Thread.Sleep(500);
                line = streamReader.ReadLine();
                match = regex.Match(line);
                if(match.Success)
                {
                    groups = match.Groups;
                    extractedData.Add(groups[1].Value+" "+ groups[2].Value);
                    
                } 
                DataExtracting(this,new EventArgs());
            }
            streamReader.Close();     
        }


    }
    class DataReceiver
    {
        public DataExtractor dataExtractor;
        public DataReceiver(DataExtractor dataEx)
        {
            dataExtractor=dataEx;
        }
        private string innerField="";
        public void OnDataExtracting(object sender, EventArgs args)
        {
            if (dataExtractor.extractedData.Count > 0)
            {
                innerField = dataExtractor.extractedData.Last();
                Console.WriteLine(innerField);
            }
            else
            {
                Console.WriteLine("no found");
            }
        }
   }

    class Program
    {
        static void Main(string[] args)
        {
            DataExtractor dataExtractor = new DataExtractor("1.txt");
            DataReceiver dataReceiver= new DataReceiver(dataExtractor);
            dataExtractor.DataExtracting += dataReceiver.OnDataExtracting;
            CancellationTokenSource cancelTokSrc = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(dataExtractor.ExtractInfo, cancelTokSrc.Token, cancelTokSrc.Token);
            Console.WriteLine("\nНажмите \"Y\" для отмены\n");
            //Thread.Sleep(7500);
            try
            {
                if (Console.ReadKey().Key == ConsoleKey.Y)
                    cancelTokSrc.Cancel();
                task.Wait();
            }
            catch (AggregateException exc)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nЗадача отменена\n");
            }
            finally
            {
                task.Dispose();
                cancelTokSrc.Dispose();
            }
            Console.WriteLine("Метод Main завершен");
        }
    }
}
