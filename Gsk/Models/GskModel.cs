using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Models
{
    public class GskModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }
    public class GskDBContext : DbContext
    {
        public DbSet<GskModel> Medicine { get; set; }
    }

}