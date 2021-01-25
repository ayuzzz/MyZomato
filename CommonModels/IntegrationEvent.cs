using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string EventName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
