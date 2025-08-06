using System;
using System.ComponentModel.DataAnnotations;
using TickerQ.Utilities.Enums;

namespace SchedulerEF.Entities
{
    public class JobExceptions
    {
        [Key] public int Id { get; set; }
        public Guid TickerId { get; set; }
        public TickerType TickerType { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
