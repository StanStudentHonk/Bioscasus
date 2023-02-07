using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public class RegularPriceCalculatorStrategy : IPriceCalculatorStrategy
	{
		public double GetTotalPriceOfTickets(List<MovieTicket> movieTickets)
		{
			double totalPrice = 0;

			for (int i = 0; i < movieTickets.Count; i++)
			{
				MovieTicket movieTicket = movieTickets[i];
				double ticketPrice = movieTicket.GetPrice();
				
				if (movieTicket.IsPremiumTicket())
				{
					ticketPrice += 3;
				}
				
				DayOfWeek dayOfWeek = movieTicket._movieScreening._dateAndTime.DayOfWeek;
				bool isWeekDay = dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Thursday;
				
				if ((isWeekDay && i % 2 == 0) || !isWeekDay)
				{
					totalPrice += ticketPrice;
				}
				
			
			}
			
		
			totalPrice = movieTickets.Count > 5 ? totalPrice += 0.9 : totalPrice;
			

			return totalPrice;
		}
	}
}
