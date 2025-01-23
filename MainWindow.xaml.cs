using pr_22._101_loskutova_authorization.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_22._101_loskutova_authorization
{
        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {

                private readonly authorizationEntities1 _context;

                public MainWindow()
                {
                        InitializeComponent();
                        _context = new authorizationEntities1();
                }

                private void LoginButton_Click(object sender, RoutedEventArgs e)
                {
                        string login = loginTextBox.Text;
                        string password = passwordBox.Password;

                        var user = _context.User
                            .FirstOrDefault(u => u.login == login && u.password == password);

                        if (user != null)
                        {
                                string roleName = _context.Role
                                 .Where(r => r.IDRole == user.IDRole)
                                     .Select(r => r.Name)
                                       .FirstOrDefault();
                                resultTextBlock.Text = $"Добро пожаловать! Ваша роль: {roleName}";
                        }
                        else
                        {
                                resultTextBlock.Text = "Неверно введены логин или пароль!";
                        }
                }

                private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
                {

                }
        }
}
