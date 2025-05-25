using System.Linq;
using System.Windows;

namespace DemNew
{
    /// <summary>
    /// Логика взаимодействия для DelWin.xaml
    /// </summary>
    public partial class DelWin : Window
    {
        User544Entities db = new User544Entities();

        public DelWin()
        {
            InitializeComponent();
            LoadMan();
        }
        public void LoadMan()
        {
            vivod.ItemsSource = db.Managers.Select(m => new
            {
                m.Id,
                m.FIO,
                m.Email,
                m.Phone
            }).ToList();
        }

        private void Deletee_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedItem = vivod.SelectedItem;
            int id = selectedItem.Id;

            if (vivod.SelectedItem == null)
            {
                MessageBox.Show("Выберите менеджера для удаления");
                return;
            }

            var managerToDelete = db.Managers.FirstOrDefault(m => m.Id == id);
            if (managerToDelete != null)
            {
                db.Managers.Remove(managerToDelete);
                db.SaveChanges();
                LoadMan();
                MessageBox.Show("Менеджер успешно удален");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вышли из программы");
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new WinMan().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу просмотра менеджеров");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWin().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу добавления");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditWin().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу редактирования");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
            MessageBox.Show("Вы перешли на главную страницу");
        }

       
    }
}
