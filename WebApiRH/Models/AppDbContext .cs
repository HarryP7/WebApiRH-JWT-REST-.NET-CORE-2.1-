using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiRH.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext > options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<LocalGroup> LocalGroup { get; set; }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<Voting> Voting { get; set; }
        public DbSet<Voted> Voted { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AdvertsReview> AdvertsReview { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<GroupChat> GroupChat { get; set; }
        public DbSet<Dialogue> Dialogue { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
