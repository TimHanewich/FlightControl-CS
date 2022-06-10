using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using System.Threading;

namespace FlightControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //Start the controller
            StatusLightController slc = new StatusLightController();
            Task.Run(() => slc.StartAsync()); //Run in another thread

            while (true)
            {
                Console.Write("Making it offline... ");
                FlightControl.Instance.SystemStatus = Status.Offline;
                Console.WriteLine("Offline!");
                Task.Delay(10000).Wait();
                Console.Write("Making it on standby... ");
                FlightControl.Instance.SystemStatus = Status.StandBy;
                Console.WriteLine("Standby!");
                Task.Delay(10000).Wait();
            }




        }
    }
}