using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace TextEditor
{
    //presenter
    public interface IMainForm
    {
        string FilePath { get; }
        string FldFilePath { set; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileSave;
        event EventHandler FileNewClick;
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
        
    }
    public partial class MainForm : Form, IMainForm
    {
        private int keyWordPosition = 0;
        public MainForm()
        {
            InitializeComponent();
            styleComboBox.SelectedIndex = 0;
            fldContent.Font = new Font(styleComboBox.SelectedItem.ToString(), (float)numFont.Value);
            this.FormClosing += new FormClosingEventHandler(mainForm_FormClosing);
            this.Load += new EventHandler(butNewFile_Click);
            butNewFile.Click += new EventHandler(butNewFile_Click);
            butOpenFile.Click += new EventHandler(butOpenFile_Click);
            butSaveFile.Click += new EventHandler(butSaveFile_Click);
            fldContent.TextChanged += new EventHandler(fldContent_TextChanged);
            butSelectFile.Click += new EventHandler(butSelectFile_Click);
            numFont.ValueChanged+=new EventHandler(numFont_ValueChanged);
            styleComboBox.SelectedValueChanged += new EventHandler(numFont_ValueChanged);
            findKWordButton.Click += new EventHandler(findKWord_Click);
            keyWordTextBox.TextChanged += new EventHandler(keyWord_TextChanged);
            
        }
        #region Проброс событий
        

        private void mainForm_FormClosing(object sender, EventArgs e)
        {
            if (FileSave != null) FileSave(this, EventArgs.Empty);
        }
        private void butNewFile_Click(object sender, EventArgs e)
        {
            if (FileNewClick != null) FileNewClick(this, EventArgs.Empty);
        }
        void butOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        void butSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        void fldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm
        public string FilePath
        {
            get{ return fldFilePath.Text;}
        }
        public string FldFilePath
        {
            set { fldFilePath.Text = value; }
        }
        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }
        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }
        public event EventHandler FileNewClick;
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        public event EventHandler FileSave;
        #endregion


        

        //Обработчик клика на кнопке "Выбрать"
        private void butSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        
        //Обработчик изменения размера шрифта и стиля
        private void numFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font(styleComboBox.SelectedItem.ToString(), (float)numFont.Value);
        }

        //Обработчик преобразования контента по ключевому слову
        private void findKWord_Click(object sender, EventArgs e)
        {
            
            string keyword = keyWordTextBox.Text;
            int wordStartIndex = (fldContent.Text).IndexOf(keyword, keyWordPosition);
            if (wordStartIndex != -1)
            {
                fldContent.SelectionStart = wordStartIndex;
                fldContent.SelectionLength = keyword.Length;
                fldContent.Focus();
                keyWordPosition = wordStartIndex + keyword.Length;
                if (keyWordPosition >= fldContent.Text.Length)
                    keyWordPosition = 0;
            }
            else
                keyWordPosition = 0;
        }
        //Обработчик изменения текста в поле ключевого слова
        private void keyWord_TextChanged(object sender, EventArgs e)
        {
            keyWordPosition = 0;
        }
    }
}
