using System.Windows.Forms;

namespace TextEditor
{
    public interface IMessagingService
    {
        DialogResult ShowMessageQuestion(string message);
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
    }
    //Презентор выводит сообщения при помощи этого класса
    public class MessageService : IMessagingService
    {
        public DialogResult ShowMessageQuestion(string message)
        {
            return MessageBox.Show(message, "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
