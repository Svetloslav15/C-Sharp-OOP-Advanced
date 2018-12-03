namespace _06.TrafficLights
{
    using System;
    
    public class TrafficLight
    {
        public Signal signal;
        public TrafficLight(string signal)
        {
            this.signal = (Signal)Enum.Parse(typeof(Signal), signal);
        }

        public void Update()
        {
            int lastSignal = (int)this.signal;
            this.signal = (Signal)(++lastSignal % Enum.GetNames(typeof(Signal)).Length);
        }
    }
}
