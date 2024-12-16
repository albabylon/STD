using System;

namespace ExceptionsDelegateEventsFinalTask
{
    public class TaskExeptions
    {
        public class NotUniqElemenToAddException : Exception
        {
            public string ElementName { get; }

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
