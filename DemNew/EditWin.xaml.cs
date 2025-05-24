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
    /// Логика взаимодействия для EditWin.xaml
    /// </summary>
    public partial class EditWin : Window
    {
        User544Entities db = new User544Entities();
        public EditWin()
        {
            InitializeComponent();
            LoadMan();
        }
        public void LoadMan()
        {
            vivod.ItemsSource = db.Managers.ToList();
        }


        private void vivod_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Email")
            {
                MessageBox.Show("Email нельзя изменить напрямую. Создайте нового пользователя.");
                e.Cancel = true; 
                return;
            }

            db.SaveChanges();
            MessageBox.Show("Изменения сохранены");
        }



        private void vivod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Все изменения сохранены");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                LoadMan(); 
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
            MessageBox.Show("вы перешли на главную страницу");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditWin().Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWin().Show();
            Close();
            MessageBox.Show("Вы перешли на страницу добавления");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new DelWin().Show();
            Close();
            MessageBox.Show("Вы перешли на страницу удаления");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вышли из программы");
            Close();
        }
    }
}
