namespace Publishers_Subscribers
{
    public interface IObserver
    {
        void Update(float temp, float humiditiy, float pressure);
    }

    public class CurrentConditionsDisplay : IObserver
    {
        private readonly ISubject _weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
        }

        public void Update(float temp, float humiditiy, float pressure)
        {
            throw new System.NotImplementedException();
        }
    }
}