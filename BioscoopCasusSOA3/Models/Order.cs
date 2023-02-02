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
			//todo: implement method
			return 1.0;
		}

		public void Export() 
		{ 
			
		}

	}
}
