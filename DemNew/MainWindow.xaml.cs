using System.Linq;
using System.Windows;

namespace DemNew
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вход в аккаунт при нажатии на кнопку войти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (text.Text == "")
            {
                MessageBox.Show("Введите почту");
                return;

            }

            if (passw.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            User544Entities db = new User544Entities();

            bool emailExists = db.Managers.Any(m => m.Email == text.Text);

            if (emailExists)
            {
                var man = db.Managers.FirstOrDefault(m => m.Email == text.Text && m.Password == passw.Text);
                if (man != null)
                {
                    new WinMan().Show();
                    this.Close();
                    MessageBox.Show("Вы перешли на страницу пользователя");
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(passw.Text))
                {
                    MessageBox.Show("Неверная почта и пароль");
                }
                else
                {
                    MessageBox.Show("Неверная почта");
                }
            }
        }
    }
}