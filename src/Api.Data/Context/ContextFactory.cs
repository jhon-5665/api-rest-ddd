using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrações
            var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=dbApi2;Uid=root;Pwd=1234567";
            //var connectionString = "Server=.\\SQLEXPRESS2017;Initial Catalog=dbApi;MultipleActiveResultSets=true;User Id=sa;Password=1234567";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)),
                mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
            );
            //optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
