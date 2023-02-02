using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
    public class MovieScreening
    {
		[JsonProperty]
		public DateTime _dateAndTime { get; set; }
		[JsonProperty]
		private double _pricePerSeat { get;  set; }
        [JsonProperty]
        private Movie _movie { get; set; }

		public MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
		{
			_dateAndTime = dateAndTime;
			_pricePerSeat = pricePerSeat;
			_movie = movie;
		}

		public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
