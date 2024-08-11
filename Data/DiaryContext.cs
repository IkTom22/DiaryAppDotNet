using Microsoft.EntityFrameworkCore;

namespace Diary.Models
{
    public class DiaryContext : DbContext
    {
        public DiaryContext(DbContextOptions<DiaryContext> options) : base(options)
        {
        }

        public DbSet<DiaryEntry> DiaryEntries {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    Id = 1,
                    Title = "Test 1", 
                    Content = "This is a seed data Test 1 content",
                    Created = DateTime.Now
                },
                new DiaryEntry {
                    Id = 2, 
                    Title = "Went Hiking",
                    Content = "WEnt hiking with Joe",
                    Created = DateTime.Now
                },
                new DiaryEntry {
                    Id = 3, 
                    Title = "Went Swimming",
                    Content = "Went swimming with Miffy",
                    Created = DateTime.Now
                }
            );
        }
    }
}




// using Microsoft.EntityFrameworkCore;

// namespace Diary.Models
// {
//     public class DiaryContext : DbContext
//     {
//         public DbSet<DiaryEntry> DiaryEntries { get; set; }

//         // Primary constructor with DbContextOptions
//         public DiaryContext(DbContextOptions<DiaryContext> options) : base(options) {}

//         // Optionally, you can remove the OnConfiguring method if options are passed correctly
//         // through the DI container or design-time factory.
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
//                 optionsBuilder.UseSqlite("Data Source=database.db");
//             }
//         }
//     }
// }
