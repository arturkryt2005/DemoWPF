using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemNew
{
    /// <summary>
    /// Логика взаимодействия для WinMan.xaml
    /// </summary>
    public partial class WinMan : Window
    {
        public WinMan()
        {
            InitializeComponent();
            User544Entities db = new User544Entities();
            var man = db.Managers.Select(m=> new
            {
                m.FIO
            }).ToList();

            vivod.ItemsSource = man;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
            MessageBox.Show("Вы перешли назад");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditWin().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу редактирования");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new DelWin().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу удаления");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выход из системы");
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWin().Show();
            this.Close();
            MessageBox.Show("Вы перешли на страницу добавления");
        }
    }
}
