using MessengerServiceHost.Model;
using MessengerServiceHost.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerServiceHost.Services
{
    [ServiceContract(CallbackContract = typeof(IMessengerServiceCallback))]
    public interface IMessengerService
    {
        [OperationContract(IsOneWay = true)]
        void Register(User user);
        [OperationContract]
        int Identify(string login, byte[] hash);
        [OperationContract(IsOneWay = true)]
        void Connect(int userId);
        [OperationContract]
        void Disconnect(int userId);
        [OperationContract]
        List<ViewGroup> GetGroups(int userId);
        [OperationContract]
        List<ViewMessage> GetMessages(int groupId);
        [OperationContract]
        List<ViewGroup> SearchGroups(int userId, string search);
        [OperationContract]
        List<ViewUser> SearchUsers(int userId, string search);
        [OperationContract(IsOneWay = true)]
        void SendMessage(ViewMessage message);
    }
}