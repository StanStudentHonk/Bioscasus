using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public interface IPriceCalculatorStrategy
	{
		public double GetTotalPriceOfTickets(List<MovieTicket> movieTickets);
	}
}
