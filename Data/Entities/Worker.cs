using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public WorkerRole Role { get; set; }
    }
}
