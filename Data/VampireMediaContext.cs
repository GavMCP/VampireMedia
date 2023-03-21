using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Models;

namespace VampireMedia.Data
{
    public class VampireMediaContext : DbContext
    {
        public VampireMediaContext (DbContextOptions<VampireMediaContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesModel> Movies { get; set; } = default!;

        public DbSet<BooksModel> BooksModel { get; set; } = default!;

        public DbSet<WishlistModel> WishlistModel { get; set; } = default!;

        public DbSet<ListTodoModel> ListTodoModel { get; set; } = default!;
    }
}
