using MessengerServiceHost.Model;
using MessengerServiceHost.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Services
{
    public interface IMessengerServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Message(string message);
        [OperationContract(IsOneWay = true)]
        void Send(int groupId, List<ViewMessage> messages);
    }
}