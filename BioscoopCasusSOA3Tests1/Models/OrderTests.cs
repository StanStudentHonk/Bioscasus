using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopCasusSOA3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasusSOA3.Models.Tests
{
	[TestClass()]
	public class OrderTests
	{
		[TestMethod()]
		public void GetTotalPriceOf_5_NonPremiumTickets_ForStudentOrder()
		{
			bool isStudentOrder = true;
			bool isPremium = false;
			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(DateTime.Now, 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new StudentPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 15.0;


			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_5_PremiumTickets_ForStudentOrder()
		{
			bool isStudentOrder = true;
			bool isPremium = true;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(DateTime.Now, 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new StudentPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 21.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_5_NonPremiumTickets_ForNonStudentOrder_OnWeekDay()
		{
			bool isStudentOrder = false;
			bool isPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 2), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 15.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_5_NonPremiumTickets_ForNonStudentOrder_OnNonWeekDay()
		{
			bool isStudentOrder = false;
			bool isPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 25.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_5_PremiumTickets_ForNonStudentOrder_OnWeekDay()
		{
			bool isStudentOrder = false;
			bool isPremium = true;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 2), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 24.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_5_PremiumTickets_ForNonStudentOrder_OnNonWeekDay()
		{
			bool isStudentOrder = false;
			bool isPremium = true;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isPremium, movieScreening);
			var movieTicket3 = new MovieTicket(1, 3, isPremium, movieScreening);
			var movieTicket4 = new MovieTicket(1, 4, isPremium, movieScreening);
			var movieTicket5 = new MovieTicket(1, 5, isPremium, movieScreening);

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket3);
			order.AddSeatReservations(movieTicket4);
			order.AddSeatReservations(movieTicket5);

			var result = order.GetTotalPriceOfTickets();
			var expected = 40.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForStudentOrder_WherePremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = true;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);
			

			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new StudentPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);
			

			var result = order.GetTotalPriceOfTickets();
			var expected = 7.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForStudentOrder_WhereNonPremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = true;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);


			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new StudentPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket1);


			var result = order.GetTotalPriceOfTickets();
			var expected = 5.0;

			Assert.AreEqual(expected, result);
		}
		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForNonStudentOrder_OnAWeekDay_WherePremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = false;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 2), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);


			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);


			var result = order.GetTotalPriceOfTickets();
			var expected = 8.0;

			Assert.AreEqual(expected, result);
		}
		
		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForNonStudentOrder_OnAWeekDay_WhereNonPremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = false;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 2), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);


			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket1);


			var result = order.GetTotalPriceOfTickets();
			var expected = 5.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForNonStudentOrder_OnANonWeekDay_WherePremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = false;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);


			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket1);
			order.AddSeatReservations(movieTicket2);


			var result = order.GetTotalPriceOfTickets();
			var expected = 13.0;

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void GetTotalPriceOf_2_MixedTickets_ForNonStudentOrder_OnANonWeekDay_WhereNonPremiumTicketIsFirstInArray()
		{
			bool isStudentOrder = false;
			bool isPremium = true;
			bool isNotPremium = false;

			var movie = new Movie("Stan en de 3 musketiers");
			var movieScreening = new MovieScreening(new DateTime(2023, 2, 3), 5.0, movie);
			var movieTicket1 = new MovieTicket(1, 1, isPremium, movieScreening);
			var movieTicket2 = new MovieTicket(1, 2, isNotPremium, movieScreening);


			var order = new Order(69420, isStudentOrder);
			order.SetPriceCalculatorStrategy(new RegularPriceCalculatorStrategy());
			order.AddSeatReservations(movieTicket2);
			order.AddSeatReservations(movieTicket1);


			var result = order.GetTotalPriceOfTickets();
			var expected = 13.0;

			Assert.AreEqual(expected, result);
		}
	}
}