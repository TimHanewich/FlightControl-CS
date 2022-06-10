using System;
using System.Threading;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace FlightControl
{
    public class StatusLightController
    {
        public async Task StartAsync()
        {
            GpioController gpio = new GpioController();
            int pin = 18;
            gpio.OpenPin(pin, PinMode.Output);

            while (true)
            {
                if (FlightControl.Instance.SystemStatus == Status.Offline)
                {
                    gpio.Write(pin, PinValue.High);
                    await Task.Delay(500);
                    gpio.Write(pin, PinValue.Low);
                    await Task.Delay(500);
                }
                else if (FlightControl.Instance.SystemStatus == Status.StandBy)
                {
                    gpio.Write(pin, PinValue.High);
                    await Task.Delay(50);
                    gpio.Write(pin, PinValue.Low);
                    await Task.Delay(50);
                    gpio.Write(pin, PinValue.High);
                    await Task.Delay(50);
                    gpio.Write(pin, PinValue.Low);
                    await Task.Delay(2500);
                }
            }

        }
    }
}