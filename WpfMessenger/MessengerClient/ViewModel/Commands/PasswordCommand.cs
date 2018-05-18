using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MessengerClient.ViewModel.Commands
{
    class PasswordCommand : ICommand
    {
        private Action<string> _execute;

        public PasswordCommand(Action<string> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<string> passwords = ((List<object>)parameter).Select(pb => ((PasswordBox)pb).Password).ToList();
            if (passwords.First().Equals(passwords.Last()))
            {
                _execute(passwords.First());
            }
            else
            {
                throw new Exception("Пароли не совпадают");
            }
        }
    }
}