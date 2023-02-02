using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public class Order
	{
		private int _orderNr { get; set; }
		private bool _isStudentOrder { get; set; }
		private List<MovieTicket> _movieTickets { get; set; }

		public Order(int orderNr, bool isStudentOrder)
		{
			this._orderNr = orderNr;
			this._isStudentOrder = isStudentOrder;
			_movieTickets = new List<MovieTicket>();
		}

		public int GetOrderNr()
		{
			return this._orderNr;
		}

		public void AddSeatReservations(MovieTicket movieTicket)
		{
			_movieTickets.Add(movieTicket);
		}

		public double CalculatePrice()
		{
			if (_isStudentOrder)
			{
				return CalculatePriceForStudent();
			}
			else 
			{
				return CalculatePriceForNonStudent();
			}
		}

		public void Export() 
		{ 
			
		}

		

		public double CalculatePriceForStudent()
		{
			List<MovieTicket> premiumTickets = new List<MovieTicket>();
			List<MovieTicket> normalTickets = new List<MovieTicket>();
			SplitMovieTicketsByPremiumAndNormal(premiumTickets, normalTickets);

			double price = 0;
			
			return price + GetTotalPriceOfTickets(premiumTickets) + GetTotalPriceOfTickets(normalTickets);
		}

		public double CalculatePriceForNonStudent()
		{
			List<MovieTicket> premiumTickets = new List<MovieTicket>();
			List<MovieTicket> normalTickets = new List<MovieTicket>();
			SplitMovieTicketsByPremiumAndNormal(premiumTickets, normalTickets);

			double price = 0;
			double discount = 1.0;
			int amountOfTickets = premiumTickets.Count() + normalTickets.Count();
			
			if (premiumTickets.Count() > 0)
			{
				DayOfWeek dayOfWeek = premiumTickets.First()._movieScreening._dateAndTime.DayOfWeek;
				if ((dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday) && amountOfTickets >= 6)
				{
					discount = 0.9;
				}
				price += (premiumTickets.First().GetPrice() + 3) * CalculateAmountOfTicketsToPayForNonStudent(premiumTickets.Count(), dayOfWeek);
			}
			if (normalTickets.Count() > 0)
			{
				DayOfWeek dayOfWeek = premiumTickets.First()._movieScreening._dateAndTime.DayOfWeek;
				if ((dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday) && amountOfTickets >= 6)
				{
					discount = 0.9;
				}
				price += (normalTickets.First().GetPrice() + 3) * CalculateAmountOfTicketsToPayForNonStudent(normalTickets.Count(), dayOfWeek);
			}

			return price * discount;
		}

		public void SplitMovieTicketsByPremiumAndNormal(List<MovieTicket> premiumTickets, List<MovieTicket> normalTickets)
		{
			foreach(MovieTicket movieTicket in _movieTickets) 
			{
				if (movieTicket.IsPremiumTicket())
				{
					premiumTickets.Add(movieTicket);
				}
				else
				{ 
					normalTickets.Add(movieTicket);
				}
			}
		}

		public int CalculateAmountOfTicketsToPayForStudent(int amountOfTickets)
		{
			if (amountOfTickets == 2)
			{
				return 1;
			}
			else
			{
				return amountOfTickets / 2 + 1;
			}
		}

		public int CalculateAmountOfTicketsToPayForNonStudent(int amountOfTickets, DayOfWeek dayOfWeek)
		{ 
			if(dayOfWeek == DayOfWeek.Monday 
				|| dayOfWeek == DayOfWeek.Tuesday  
				|| dayOfWeek == DayOfWeek.Wednesday  
				|| dayOfWeek == DayOfWeek.Thursday) 
			{
				if (amountOfTickets == 2)
				{
					return 1;
				}
				else
				{
					return amountOfTickets / 2 + 1;
				}
			}
			else 
			{
				return amountOfTickets;
			}
		}

		public double GetTotalPriceOfTickets(List<MovieTicket> movieTickets)
		{
			double totalPrice = 0.0;
			for (int i = 0; i < movieTickets.Count; i++)
			{
				if (i % 2 != 0)
				{
					double ticketPrice = movieTickets[i].GetPrice();
					if (movieTickets[i].IsPremiumTicket())
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
