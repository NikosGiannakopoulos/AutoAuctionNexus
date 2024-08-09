namespace Message_Queue_Logger
{
    public class LogMessage
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime Timestamp { get; set; }
    }
}