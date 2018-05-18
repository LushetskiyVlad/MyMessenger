using MessengerClient.MessengerServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerClient.ViewModel
{
    class MessengerViewModel : INotifyPropertyChanged, MessengerServiceReference.IMessengerServiceCallback
    {
        private MessengerServiceClient _serviceClient;
        private ObservableCollection<ViewGroup> _groups;
        private ObservableCollection<ViewUser> _foundUsers;
        private ObservableCollection<ViewMessage> _messages;
        private ViewGroup _selectedGroup;

        private int _userId;
        private int _selectedTabIndex;
        private string _searchText;

        //private Command _writeMessageCommand;

        private Command _sendMessageCommand;

        public ObservableCollection<ViewGroup> Groups
        {
            get
            {
                return _groups;
            }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged("Groups");
                }
            }
        }

        public ObservableCollection<ViewMessage> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                    OnPropertyChanged("Messages");
                }
            }
        }

        public ObservableCollection<ViewUser> FoundUsers
        {
            get
            {
                return _foundUsers;
            }
            set
            {
                if (_foundUsers != value)
                {
                    _foundUsers = value;
                    OnPropertyChanged("FoundUsers");
                }
            }
        }

        public ViewGroup SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                    OnPropertyChanged("SelectedGroup");
                    Messages = new ObservableCollection<ViewMessage>(_selectedGroup.Messages);
                }
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged("SearchText");
                    SearchUsers(_searchText);
                    if (string.IsNullOrEmpty(_searchText))
                    {
                        SelectedTabIndex = 0;
                    }
                }
            }
        }

        public int SelectedTabIndex
        {
            get
            {
                return _selectedTabIndex;
            }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    OnPropertyChanged("SelectedTabIndex");
                }
            }
        }

        public Command SendMessageCommand
        {
            get
            {
                return _sendMessageCommand ??
                    (
                    _sendMessageCommand = new Command(obj =>
                    {

                        var message = new ViewMessage
                        {
                            FromId = _userId,
                            GroupId = SelectedGroup.GroupId,
                            Content = new ViewMessageContent { Text = obj as string }
                        };
                        Messages.Add(message);
                        _serviceClient.SendMessageAsync(message);
                    }));
            }
        }

        //internal Command WriteMessageCommand
        //{
        //    get
        //    {
        //        return _writeMessageCommand??;
        //    }
        //}

        private async void SearchUsers(string searchText)
        {
            try
            {
                var users = await _serviceClient.SearchUsersAsync(_userId, searchText);
                FoundUsers = users != null ? new ObservableCollection<ViewUser>(users) : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MessengerViewModel(int userId)
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                _serviceClient = new MessengerServiceClient(context);
                _userId = userId;
                _serviceClient.ConnectAsync(_userId);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Refresh()
        {
            Groups = new ObservableCollection<ViewGroup>(_serviceClient.GetGroups(_userId));
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Message([MessageParameter(Name = "message")] string message1)
        {
            throw new NotImplementedException();
        }

        public void Send(int groupId, List<ViewMessage> messages)
        {
            Groups.FirstOrDefault(g => g.GroupId == groupId).Messages = messages;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}