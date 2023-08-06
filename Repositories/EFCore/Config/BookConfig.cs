using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Name = "Karagoz ve Hacivat", Price = 75 },
                new Book { Id = 2, Name = "Mesnevi", Price = 175 },
                new Book { Id = 3, Name = "Devlet", Price = 75 }
                );
        }
    }
}
