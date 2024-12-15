using System;

namespace ExceptionsDelegateEventsFinalTask
{
    public class ExeptionsTask1
    {
        public class NotUniqElemenToAddException : Exception
        {
            public string ElementName { get; set; }

            public NotUniqElemenToAddException()
            {

            }
            public NotUniqElemenToAddException(string message) : base(message)
            {
                
            }

            public NotUniqElemenToAddException(string message, string elementName) : this(message)
            {
                ElementName = elementName;
            }
        }
    }
}
