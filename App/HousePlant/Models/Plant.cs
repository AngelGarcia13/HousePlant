using System;
using System.Collections.Generic;

namespace HousePlant.Models
{
    public class Plant
    {
        public string Name { get; set; }
        public string BotanicalName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public PlantCategory Category { get; set; }
        public IEnumerable<Reminder> Reminders { get; set; }
    }
}
