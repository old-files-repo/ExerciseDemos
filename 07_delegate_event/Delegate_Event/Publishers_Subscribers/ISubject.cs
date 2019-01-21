using System.Collections.Generic;

namespace Publishers_Subscribers
{
    public interface ISubject
    {
        void RegisterObserver(object o);
        void RemoveObserver(object o);
        void NotifyObserver();
    }

    public class WeatherData : ISubject
    {
        private List<object> _objects;

        public WeatherData()
        {
            _objects = new List<object>();
        }

        public void RegisterObserver(object o)
        {
            _objects.Add(o);
        }

        public void RemoveObserver(object o)
        {
            if (_objects.Contains(o))
            {
                _objects.Remove(o);
            }
        }

        public void NotifyObserver()
        {
            _objects.ForEach(x =>
            {
                //x.update();
            });
        }

        public void MeasurementsChanged()
        {
            NotifyObserver();
        }

        public void SetMeasurements(float temp, float humiditiy, float pressure)
        {
            MeasurementsChanged();
        }
    }
}