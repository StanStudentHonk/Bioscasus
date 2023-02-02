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
		private MovieScreening _movieTicket { get; set; }

		public MovieTicket(int rowNr, int seatNr, bool isPremium)
		{
			this._rowNr = rowNr;
			this._seatNr = seatNr;
			this._isPremium = isPremium;
		}

		public bool IsPremiumTicket()
		{
			return this._isPremium;
		}

		public double GetPrice()
		{
			//TODO: IMPLEMENT METHOD ACCORDING TO DOCUMENT (Zie word bestand)
			return 1.0;
		}


	}
}
