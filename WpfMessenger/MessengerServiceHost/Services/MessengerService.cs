using MessengerServiceHost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.Entity;
using System.Text;
using MessengerServiceHost.Model.View;

namespace MessengerServiceHost.Services
{
    public class MessengerService : IMessengerService
    {
        private Dictionary<IMessengerServiceCallback, User> _clients
            = new Dictionary<IMessengerServiceCallback, User>();

        public void Register(User user)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
            using (MessengerContext context = new MessengerContext())
            {
                if (context.Users.ToList().Exists(u => u.Login == user.Login))
                {
                    throw new Exception("Пользователь с таким логином уже существует!");
                }
                else if (context.Users.ToList().Exists(u => u.Email == user.Email))
                {
                    throw new Exception("Пользователь с таким адресом электронной почты уже существует!");
                }
                else if (context.Users.ToList().Exists(u => u.Phone == user.Phone))
                {
                    throw new Exception("Пользователь с таким номером мобильного телефона уже существует!");
                }
                context.Users.Add(user);
                context.SaveChanges();
            }
            callback.Message("Регистрация прошла успешно!");
        }

        public int Identify(string login, byte[] hash)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
            if (_clients.FirstOrDefault(c => c.Value.Login == login).Value != null)
            {
                throw new Exception("Такой пользователь уже в системе!");
            }
            using (MessengerContext context = new MessengerContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == hash);
                if (user != null)
                {
                    return user.UserId;
                }
            }
            return -1;
        }

        public void Connect(int userId)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
            using (MessengerContext context = new MessengerContext())
            {
                var user = context.Users.Include(u => u.Groups).FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    _clients.Add(callback, user);
                }
            }
            //callback.Update(GetGroups(userId));
        }

        public void Disconnect(int userId)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
            User user = _clients[callback];
            if (user != null && user.UserId == userId)
            {
                _clients.Remove(callback);
            }
        }

        public void SendMessage(ViewMessage message)
        {
            using (MessengerContext context = new MessengerContext())
            {
                message.DispatchTime = DateTime.Now;
                Message m = (Message)message;
                context.Messages.Add(m);
                context.SaveChanges();
            }

            int groupId = message.GroupId;
            List<ViewMessage> messages = GetMessages(groupId);

            _clients.Where(c => c.Value.Groups
                    .FirstOrDefault(g => g.GroupId == groupId) != null)
                    .ToList().ForEach(a => a.Key.Send(groupId, messages));
        }

        public List<ViewGroup> GetGroups(int userId)
        {
            using (MessengerContext context = new MessengerContext())
            {
                //var user = context.Users.Include(u => u.Groups)
                //    .FirstOrDefault(u => u.UserId == userId);

                return context.Users.Where(u => u.UserId == userId).Include("Groups")
                        .SelectMany(u => u.Groups)
                        .Include(g => g.Users)
                        .Include(g => g.Messages.Select(gm => gm.Content))
                        .ToList().Select(g =>
                        new ViewGroup
                        {
                            GroupId = g.GroupId,
                            Image = g.Image,
                            Name = g.Name,
                            Participants = g.Participants,
                            Users = g.Users.ToList().Select(u => (ViewUser)u).ToList(),
                            Messages = g.Messages.ToList().Select(m => (ViewMessage)m).ToList()
                        }).ToList();
            }
        }

        public List<ViewMessage> GetMessages(int groupId)
        {
            using (MessengerContext context = new MessengerContext())
            {
                return context.Messages
                        .Include(m => m.Content)
                        .Include(m => m.User)
                        .ToList().Where(m => m.GroupId == groupId).ToList()
                        .Select(m => (ViewMessage)m).ToList();
            }
        }

        public List<ViewGroup> SearchGroups(int Id, string search)
        {
            using (MessengerContext context = new MessengerContext())
            {
                User u = context.Users.Include("Groups").FirstOrDefault(a => a.UserId == Id);
                if (!string.IsNullOrWhiteSpace(search) && u != null)
                {
                    return u.Groups.Where
                        (a => a.Name.Contains(search) ||
                            a.Users.Any
                                (b => b.FirstName.Contains(search) ||
                                    b.LastName.Contains(search))).ToList().Select(g => (ViewGroup)g).ToList();
                }
                return null;
            }
        }

        public List<ViewUser> SearchUsers(int Id, string search)
        {
            using (MessengerContext context = new MessengerContext())
            {
                var users = context.Users
                     .Where(u => u.FirstName.Contains(search) ||
                     u.LastName.Contains(search) || u.Phone.Contains(search) ||
                     u.Email.Contains(search))
                     .ToList().Select(a => (ViewUser)a).ToList();

                if (!string.IsNullOrWhiteSpace(search) && users != null)
                {
                    return users;
                }
                return null;
            }
        }
    }
}