namespace BioscoopCasusSOA3.Models
{
	public interface IPriceCalculatorStrategy
	{
		public double GetTotalPriceOfTickets(List<MovieTicket> movieTickets);
	}
}
