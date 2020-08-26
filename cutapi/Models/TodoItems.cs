using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int BaseLength { get; set; }
        public List<Length> CutLength { get; set; }
    }
    public class Length
    {
        public int Id { get; set; }
        public int NumberOfItems { get; set; }
        public int CutLength { get; set; }
    }

    public class SplitLength
    {
        public int Length { get; set; }
        public bool IsCalculated { get; set; }
    }

    public class CutResult
    {
        public int BaseLength { get; set; }
        public int WasteLength { get; set; }
        public List<int> CutLengths { get; } = new List<int>();
    }
}