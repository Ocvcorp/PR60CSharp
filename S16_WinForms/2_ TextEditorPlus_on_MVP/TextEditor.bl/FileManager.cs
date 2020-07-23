using System;
using System.IO;
using System.Text;

namespace TextEditor.bl
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(string filePath);
        bool IsSaved(string filePath, string fileContent);
        
    }
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        //проверка существования файла
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
        public bool IsSaved(string filePath, string fileContent)
        {
            if(IsExist(filePath))
            {
                if (fileContent == GetContent(filePath))
                    return true;
            }                
            return false;
        }
        //получить содержимое файла
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
        //сохранение содержимого файла
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }        
        //подсчет количества символов в содержимом
        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

    }
}
