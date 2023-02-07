﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models
{
	public class Order
	{
		[JsonProperty]
		private int _orderNr { get; set; }
		[JsonProperty]
		private bool _isStudentOrder { get; set; }
		[JsonProperty]
		private List<MovieTicket> _movieTickets { get; set; }

		private IPriceCalculatorStrategy PriceCalculatorStrategy { get; set; }

		public Order(int orderNr, bool isStudentOrder, IPriceCalculatorStrategy priceCalculatorStrategy)
		{
			this._orderNr = orderNr;
			this._isStudentOrder = isStudentOrder;
			_movieTickets = new List<MovieTicket>();
			PriceCalculatorStrategy = priceCalculatorStrategy;	
		}

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

		public void SetPriceCalculatorStrategy(IPriceCalculatorStrategy priceCalculatorStrategy)
		{
			PriceCalculatorStrategy = priceCalculatorStrategy;
		}

		public void AddSeatReservations(MovieTicket movieTicket)
		{
			_movieTickets.Add(movieTicket);
		}


		public double GetTotalPriceOfTickets()
		{
			//double totalPrice = 0.0;
			//for (int i = 0; i < _movieTickets.Count; i++)
			//{
			//	MovieTicket movieTicket = _movieTickets[i];
			//	double ticketPrice = movieTicket.GetPrice();
			//	DayOfWeek dayOfWeek = movieTicket._movieScreening._dateAndTime.DayOfWeek;
			//	if (i % 2 == 0 || !this._isStudentOrder && !(dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Thursday))
			//	{
			//		if (movieTicket.IsPremiumTicket())
			//		{
			//			ticketPrice += this._isStudentOrder ? 2 : 3;
			//		}
			//		totalPrice += ticketPrice;
			//	}
			//}
			//if (!this._isStudentOrder)
			//{
			//	totalPrice = this._movieTickets.Count > 5 ? totalPrice += 0.9 : totalPrice;
			//}
			//return totalPrice;
			return PriceCalculatorStrategy.GetTotalPriceOfTickets(_movieTickets);
		}

		public void Export(TicketExportFormat exportFormat)
		{
			if (exportFormat == TicketExportFormat.PLAINTEXT)
			{
				string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "orderTextFormat.txt");


				using (StreamWriter sw = File.CreateText(path))
				{
					sw.WriteLine(JsonConvert.SerializeObject(this));
				}
			}
            else
            {
				string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "orderJsonFormat.json");

				using (StreamWriter sw = File.CreateText(path))
				{
					sw.WriteLine(JsonConvert.SerializeObject(this));
				}
			}			
		}
	}
}