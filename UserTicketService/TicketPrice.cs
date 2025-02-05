namespace UserTicketService.MoqTest
{
    public class TicketPrice
    {
        ITicketService ticketService;
        public TicketPrice(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public int MakeTicketPrice(int ticketId)
        {
            return ticketService.GetTicketPrice(ticketId);
        }
    }
}
