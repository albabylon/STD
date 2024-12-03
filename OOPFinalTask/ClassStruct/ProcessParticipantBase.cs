using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalTask
{
    public abstract class ProcessParticipantBase
    {
        public string Name { get; set; }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (!phoneNumber.Contains("+"))
                    phoneNumber = value;
                else
                    phoneNumber = value.Replace("+", "");
            }
        }

        protected ProcessParticipantBase(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    public class Courier : ProcessParticipantBase
    {
        public bool IsDeliveried {  get; set; }
        public Courier(string name, string phoneNumber) : base(name, phoneNumber)
        {

        }
    }

    public class Sender : ProcessParticipantBase
    {
        public bool IsSended { get; set; }
        public Sender(string name, string phoneNumber) : base(name, phoneNumber)
        {

        }
    }

    public class Recipient : ProcessParticipantBase
    {
        public bool IsReceived { get; set; }
        public Recipient(string name, string phoneNumber) : base(name, phoneNumber)
        {

        }
    }
}
