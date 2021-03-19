using Microsoft.EntityFrameworkCore;
using PwcWeb.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        public DbSet<Message> Message { get; set; }
        public DbSet<SubwayHistory> SubwayHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Subway_HistoryMap());
        }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }


}
