using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DB
{
    internal interface IDbContextFact
    {
    }

    public class test
    {
        IDbContextFactory<AppDBContext> factory;

        public test()
        {
           var db= factory.CreateDbContext();
            
        }
    }
}
