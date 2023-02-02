using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public class MovieTicket
	{
		private int _rowNr { get; set; }
		private int _seatNr { get; set; }
		private bool _isPremium { get; set; }
		public MovieScreening _movieScreening { get; set; }

		public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
		{
			this._rowNr = rowNr;
			this._seatNr = seatNr;
			this._isPremium = isPremium;
			this._movieScreening = movieScreening;
		}

		public bool IsPremiumTicket()
		{
			return this._isPremium;
		}

		public double GetPrice()
		{
			return _movieScreening.GetPricePerSeat();
		}


	}
}
