using MahApps.Metro.Controls;
using MessengerClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
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

namespace MessengerClient
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        private LoginViewModel _viewModel = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                DataContext = _viewModel;
                _viewModel.WindowClosed += () => Close();
                _viewModel.MessageEvent += (m) => tbMessage.Text = m;
            };
        }

        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
            stackPanel1.Visibility = Visibility.Collapsed;
            tbMessage.Text = string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
            stackPanel1.Visibility = Visibility.Visible;
        }

        private void butRegister_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
            stackPanel1.Visibility = Visibility.Visible;
            tbMessage.Text = string.Empty;
        }
    }
}