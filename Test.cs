using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using System.Device.Pwm;

namespace FlightControl
{
    public class Test
    {
        public static async Task RunTestAsync()
        {
            int Motor1A = 24;
            int Motor1B = 23;
            int Motor1E = 25;

            //Set up
            GpioController gpio = new GpioController();
            gpio.OpenPin(Motor1A, PinMode.Output);
            gpio.OpenPin(Motor1B, PinMode.Output);
            gpio.OpenPin(Motor1E, PinMode.Output);

            //Go forward
            Console.Write("Going forward... ");
            gpio.Write(Motor1A, PinValue.High);
            gpio.Write(Motor1B, PinValue.Low);
            gpio.Write(Motor1E, PinValue.High);
            await Task.Delay(3000);
            Console.WriteLine("Done");
            
            //Stop
            Console.Write("Stopping... ");
            gpio.Write(Motor1E, PinValue.Low);
            Console.WriteLine("Stopped!");

            //Dump
            Console.Write("Dumping... ");
            gpio.ClosePin(Motor1A);
            gpio.ClosePin(Motor1B);
            gpio.ClosePin(Motor1E);
            Console.WriteLine("Dumped!");
        }
    
        public static async Task TestBuzzerAsync()
        {
            int pin = 8;
            int freq = 523;

            System.Device.Pwm.PwmChannel c = PwmChannel.Create(0, pin, freq, 0.5);
            c.Start();

            await Task.Delay(3000);

            c.Stop();
            c.Dispose();
            
        }
    }
}