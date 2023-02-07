using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public class StudentPriceCalculatorStrategy : IPriceCalculatorStrategy
	{
		public double GetTotalPriceOfTickets(List<MovieTicket> movieTickets)
		{
			double totalPrice = 0;

			for (int i = 0; i < movieTickets.Count; i++)
			{
				if (i % 2 == 0 )
				{
					MovieTicket movieTicket = movieTickets[i];
					double ticketPrice = movieTicket.GetPrice();
					if (movieTicket.IsPremiumTicket())
					{
						ticketPrice += 2;
					}
					totalPrice += ticketPrice;
				}
			}
			

			return totalPrice;
		}
	}
}
