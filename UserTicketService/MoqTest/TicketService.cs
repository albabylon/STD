using System;
using System.Collections.Generic;
using System.Linq;

namespace UserTicketService.MoqTest
{
    public class TicketService : ITicketService
    {
        public int GetTicketPrice(int ticketId)
        {
            var ticket = FakeBaseData.FirstOrDefault(t => t.Id == ticketId);
            return (ticket is null) ?
               throw new TicketNotFoundException() : ticket.Price;
        }

        private IEnumerable<Ticket> FakeBaseData
        {
            get
            {
                return new List<Ticket>
                {
                    new Ticket(1, "Москва - Санкт-Петербург", 3500),
                    new Ticket(2, "Челябинск - Магадан", 3500),
                    new Ticket(3, "Норильск - Уфа", 3500)
                };
            }
        }

        //2 шаг TDD - пишем быстро метод GetTicket() и запускаем тест
        //public Ticket GetTicket(int ticketId)
        //{
        //    return new Ticket(1, "", 1);
        //}

        //3 шаг TDD - пишем норм метод GetTicket() и запускаем тест
        public Ticket GetTicket(int ticketId)
        {
            var ticket = FakeBaseData.FirstOrDefault(t => t.Id == ticketId);
            return (ticket is null) ?
              throw new TicketNotFoundException() : ticket;
        }
    }

    public class TicketNotFoundException : Exception
    {

    }
}
