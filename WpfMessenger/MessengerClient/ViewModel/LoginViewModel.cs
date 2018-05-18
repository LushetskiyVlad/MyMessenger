using MessengerClient.MessengerServiceReference;
using MessengerClient.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessengerClient.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged, MessengerServiceReference.IMessengerServiceCallback
    {
        private MessengerServiceClient _serviceClient;
        private User _user = new User();
        private string _login;

        private bool _isLoaded;

        #region Commands

        //private Command _checkBoxChecked;
        private Command _loginCommand;
        private PasswordCommand _registerCommand;

        public LoginViewModel()
        {
            _serviceClient = new MessengerServiceClient(new InstanceContext(this));
            //_user = new User();
        }

        //public Command ChechBoxCheched
        //{
        //    get
        //    {
        //        return _checkBoxChecked ??
        //            (
        //            _checkBoxChecked = new Command(obj =>
        //            {
                        
        //            }));
        //    }
        //}
        public Command LoginCommand
        {
            get
            {
                return _loginCommand ??
                    (
                    _loginCommand = new Command(obj =>
                    {
                        PasswordBox pb = obj as PasswordBox;
                        LoginClick(pb.Password);
                    }));
            }
        }
        public PasswordCommand RegisterCommand
        {
            get
            {
                return _registerCommand ??
                    (
                    _registerCommand = new PasswordCommand(pass =>
                    {
                        RegisterClick(pass);
                    }));
            }
        }

        #endregion

        public event Action WindowClosed;
        public event Action<string> MessageEvent;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
            set
            {
                if (_isLoaded != value)
                {
                    _isLoaded = value;
                    OnPropertyChanged("IsLoaded");
                }
            }
        }

        private async void LoginClick(string password)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Login) &&
                    !string.IsNullOrWhiteSpace(password))
                {
                    IsLoaded = true;
                    MessengerServiceReference.MessengerServiceClient proxy =
                        new MessengerServiceReference.MessengerServiceClient(new InstanceContext(this));

                    var md5 = new MD5CryptoServiceProvider();
                    byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(password.Trim()));

                    int id = await _serviceClient.IdentifyAsync(Login.Trim(), hash);

                    IsLoaded = false;
                    if (id != -1)
                    {
                        MainWindow mainWindow = new MainWindow(id);
                        mainWindow.Show();

                        this.WindowClosed();
                    }
                    else
                    {
                        MessageEvent("Неверный логин и/или пароль!");
                    }
                }
                else
                {
                    MessageEvent("Заполните все поля!");
                }
            }
            catch (EndpointNotFoundException)
            {
                MessageEvent("Нет соединения с сервером!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsLoaded = false;
            }
        }

        private async void RegisterClick(string password)
        {
            try
            {
                if (CheckUserInfo(_user))
                {
                    IsLoaded = true;
                    MessengerServiceReference.MessengerServiceClient proxy =
                        new MessengerServiceReference.MessengerServiceClient(new InstanceContext(this));

                    var md5 = new MD5CryptoServiceProvider();
                    byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(password.Trim()));

                    User.Password = hash;

                    await _serviceClient.RegisterAsync(User);
                    IsLoaded = false;
                }
                else
                {
                    MessageEvent("Заполните все поля!");
                }
            }
            catch (EndpointNotFoundException)
            {
                MessageEvent("Нет соединения с сервером!");
            }
            catch (Exception ex)
            {
                MessageEvent(ex.Message);
            }
            //finally
            //{
            //    IsLoaded = false;
            //}
        }

        private bool CheckUserInfo(User user)
        {
            return !(string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName)) || string.IsNullOrWhiteSpace(user.Phone) ||
                string.IsNullOrWhiteSpace(user.Email);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
            //if (MessageEvent != null)
            //{
            //    MessageEvent(message);
            //}
        }

        public void Send(int groupId, List<ViewMessage> messages)
        {
            throw new NotImplementedException();
        }

        //public void Message1(List<Group> groups)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(List<ViewGroup> groups)
        //{
        //    throw new NotImplementedException();
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}