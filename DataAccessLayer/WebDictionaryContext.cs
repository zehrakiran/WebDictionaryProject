using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class WebDictionaryContext:DbContext
    {
        public WebDictionaryContext(DbContextOptions<WebDictionaryContext> options) : base(options)
        {

        }
        public DbSet<Words> words { get; set; }
    }
}
