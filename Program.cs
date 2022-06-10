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
            
            //Set status
            FlightControl.Instance.SystemStatus = Status.StandBy;
            
            //Start the controller
            StatusLightController slc = new StatusLightController();
            Task.Run(() => slc.StartAsync()); //Run in another thread

            while (true)
            {
                Console.Write("FC>");
                string? cmd = Console.ReadLine();
                if (cmd != null)
                {
                    if (cmd == "exit")
                    {
                        return;
                    }
                    else if (cmd == "status offline")
                    {
                        FlightControl.Instance.SystemStatus = Status.Offline;
                        Console.WriteLine("Status set to Offline");
                    }
                    else if (cmd == "status standby")
                    {
                        FlightControl.Instance.SystemStatus = Status.StandBy;
                        Console.WriteLine("Status set to StandBy");
                    }
                    else
                    {
                        Console.WriteLine("I got not understand that command!");
                    }
                }
            }




        }
    }
}