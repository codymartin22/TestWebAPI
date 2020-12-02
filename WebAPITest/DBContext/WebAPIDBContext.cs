using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;

namespace WebAPITest.DBContext
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options)
        {

        }
        public DbSet<ToDoLists> ToDoItems { get; set; }
    }
}
