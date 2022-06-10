using System;

namespace FlightControl
{
    public class FlightControl
    {   
        //INSTANCE OF IT (to be used)
        public static FlightControl Instance {get; set;} = new FlightControl();
        
        public Status SystemStatus {get; set;}
    }
}