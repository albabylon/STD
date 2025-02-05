using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTicketService.MoqTest;

namespace UserTicketService.TestMoq_TDD_IntegrTest
{
    [TestFixture]
    public class TicketServiceIntegrationTests
    {
        [Test]
        public void SaveTicketMustAddTicketInBase()
        {
            // тест интеграционный так как:
            // 1 - из названия ...InBase - используется реальная база
            // 2 - нету Moq объектов
            // 3 - удаляем тестовые данные из базы ticketServiceTest.DeleteTicket(newTicket);
            // 4 - имя класса

            var ticketServiceTest = new TicketService();
            var newTicket = new Ticket(300, "Test ticket", 1000);

            ticketServiceTest.SaveTicket(newTicket);

            var allTicketsAfterAddingNewTicket = ticketServiceTest.GetAllTickets();
            CollectionAssert.Contains(allTicketsAfterAddingNewTicket, newTicket);

            ticketServiceTest.DeleteTicket(newTicket);

            var allTicketsAfterDeletingNewTicket = ticketServiceTest.GetAllTickets();
            CollectionAssert.DoesNotContain(allTicketsAfterDeletingNewTicket, newTicket);
        }
    }
}
