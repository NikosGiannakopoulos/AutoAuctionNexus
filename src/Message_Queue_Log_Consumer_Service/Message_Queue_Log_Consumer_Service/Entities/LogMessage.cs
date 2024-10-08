﻿namespace Message_Queue_Log_Consumer_Service.Entities
{
    public class LogMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Source { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime Timestamp { get; set; }
    }
}