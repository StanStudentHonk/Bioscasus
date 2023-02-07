using Newtonsoft.Json;
using System.Reflection;

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