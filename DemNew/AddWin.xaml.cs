﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemNew
{
    /// <summary>
    /// Логика взаимодействия для AddWin.xaml
    /// </summary>
    public partial class AddWin : Window
    {
        User544Entities db = new User544Entities();

        public AddWin()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFIO.Text))
                {
                    MessageBox.Show("Введите ФИО менеджера");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Введите Email менеджера");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("Введите пароль");
                    return;
                }

                if (db.Managers.Any(m => m.Email == txtEmail.Text))
                {
                    MessageBox.Show("Менеджер с таким Email уже существует");
                    return;
                }

                if (dpDateOfBirth.SelectedDate == null)
                {
                    MessageBox.Show("Укажите дату рождения");
                    return;
                }

                if (dpDateOfBirth.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Дата рождения не может быть в будущем");
                    return;
                }                

                var newManager = new Managers
                {
                    FIO = txtFIO.Text,
                    Pole = (cmbGender.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Email = txtEmail.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate?.ToString("yyyy-MM-dd"),
                    Country = txtCountry.Text,
                    Phone = txtPhone.Text,
                    Post = txtPost.Text,
                    Stage = txtStage.Text,
                    Password = txtPassword.Password,
                    Photo = txtPhoto.Text
                };

                db.Managers.Add(newManager);
                db.SaveChanges();

                MessageBox.Show("Менеджер успешно добавлен");
                new WinMan().Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении менеджера: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            MessageBox.Show("Вы перешли на главную страницу");
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditWin().Show();
            MessageBox.Show("Вы перешли на страницу редактирования");
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new DelWin().Show();
            MessageBox.Show("Вы перешли на страницу удаления");
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вышли из системы");
            Close();
        }
    }
}
