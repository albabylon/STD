namespace OOPFinalTask
{
    //Переопределение свойств
    public abstract class ProcessParticipantBase
    {
        public string Name { get; set; }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                if (!phoneNumber.Contains("+"))
                    return phoneNumber.Insert(0, "+");
                else
                    return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        protected ProcessParticipantBase(string name, string phoneNumber)
        {
            Name = name;
            this.phoneNumber = phoneNumber;
        }
    }

    public class Courier : ProcessParticipantBase
    {
        public bool IsDeliveried { get; set; }
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
