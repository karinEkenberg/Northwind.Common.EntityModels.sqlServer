using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Northwind.Common.DataContext.sqlServer
{
    public static class NorthwindContextExtensions
    {
        /// <summary>
        /// Adds NorthwindContext to the specified IServiceCollections. uses the SqlServer database provider.
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services,
             string connectionString = "Data Source= (localdb)/MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False")
        {
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(connectionString);

                options.LogTo(Console.WriteLine,
                    new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuted });
            });
            return services;
        }
    }
}
    
