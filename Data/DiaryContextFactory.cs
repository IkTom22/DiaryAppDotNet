using Diary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Diary.Database
{
    public class DiaryContextFactory : IDesignTimeDbContextFactory<DiaryContext>
    {
        public DiaryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DiaryContext>();
            optionsBuilder.UseSqlite("Data Source=database.db");

            return new DiaryContext(optionsBuilder.Options);
        }
    }
}
