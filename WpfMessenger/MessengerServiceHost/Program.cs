using MessengerServiceHost.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(MessengerService)))
                {
                    host.Open();
                    Console.WriteLine("Служба {0} запущена на {1}", host.Description.Name, host.Description.Endpoints.First().Address);
                    Console.WriteLine("Для остановки службы {0} нажмите любую клавищу", host.Description.Name);
                    Console.ReadKey(true);
                    Console.WriteLine("Служба {0} остановлена", host.Description.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}