using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
    public class MovieScreening
    {
        private DateTime _dateAndTime { get; set; }
        private double _pricePerSeat { get;  set; }
        private Movie _movie { get; set; }

        public MovieScreening(DateTime dateAndTime, double pricePerSeat)
        {
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }
    }
}
