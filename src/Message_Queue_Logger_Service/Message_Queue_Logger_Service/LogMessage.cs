namespace Message_Queue_Logger_Service
{
    public class LogMessage
    {
        public string Source { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime Timestamp { get; set; }
    }
}