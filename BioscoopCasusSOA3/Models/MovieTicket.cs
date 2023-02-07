using Newtonsoft.Json;

namespace BioscoopCasusSOA3.Models
{
	public class MovieTicket
	{
		[JsonProperty]
		private int _rowNr { get; set; }
		[JsonProperty]
		private int _seatNr { get; set; }
		[JsonProperty]
		private bool _isPremium { get; set; }
		[JsonProperty]
		public MovieScreening _movieScreening { get; set; }

		public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
		{
			_rowNr = rowNr;
			_seatNr = seatNr;
			_isPremium = isPremium;
			_movieScreening = movieScreening;
		}

		public bool IsPremiumTicket()
		{
			return this._isPremium;
		}

		public double GetPrice()
		{
			return _movieScreening.GetPricePerSeat();
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
