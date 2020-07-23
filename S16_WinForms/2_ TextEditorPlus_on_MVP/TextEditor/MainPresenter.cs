using System;
using System.IO;
using System.Windows.Forms;
using TextEditor.bl;

namespace TextEditor
{
    public class MainPresenter
    {
        private static int fileCount=1;
        private readonly IMainForm _view;
        private readonly IFileManager _manager;
        private readonly IMessagingService _messageService;
        private string _currentFilePath;
        public MainPresenter(IMainForm view, IFileManager manager, IMessagingService service)
        {
            _view = view;
            _manager = manager;
            _messageService = service;

            _view.SetSymbolCount(0);
            

            _view.ContentChanged += new EventHandler(_view_ContentChanged);
            _view.FileOpenClick += new EventHandler(_view_FileOpenClick);
            _view.FileSaveClick += new EventHandler(_view_FileSaveClick);
            _view.FileNewClick += new EventHandler(_view_FileNewClick);
            _view.FileSave += new EventHandler(_view_FileSave);

            
        }
        
        //Механизм создания файла
        void _view_FileNewClick(object sender, EventArgs e)
        {
            
            string tryName = Path.Combine(Directory.GetCurrentDirectory(), "NewFile" + MainPresenter.fileCount + ".txt");
            while (_manager.IsExist(tryName))
            {
                MainPresenter.fileCount++;
                tryName = Path.Combine(Directory.GetCurrentDirectory(), "NewFile" + MainPresenter.fileCount + ".txt");
            }
            _currentFilePath = tryName;
            _view.FldFilePath = tryName;
            _view.Content = "";
            _view.SetSymbolCount(0);
        }
        //Механизм сохранения файла
        void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;

                _manager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("Файл успешно сохранен!");         
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        void _view_FileSave(object sender, EventArgs e)
        {
            try 
            {
                string content = _view.Content;
                bool isSaved = _manager.IsSaved(_currentFilePath, content);
                if (!isSaved)
                {
                    if (_messageService.ShowMessageQuestion("Сохранить файл?") == DialogResult.OK)
                    {
                        _manager.SaveContent(content, _currentFilePath);
                        _messageService.ShowMessage("Файл успешно сохранен!");
                    }
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        //Механизм открытия файла
        void _view_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                bool isExist = _manager.IsExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует!");
                    return;
                }

                _currentFilePath = filePath;

                string content = _manager.GetContent(filePath);
                int count = _manager.GetSymbolCount(content);

                _view.Content = content;
                _view.SetSymbolCount(count);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        void _view_ContentChanged(object sender, EventArgs e)
        {
            string content = _view.Content;

            int count = _manager.GetSymbolCount(content);

            _view.SetSymbolCount(count);
        }
    }
}
