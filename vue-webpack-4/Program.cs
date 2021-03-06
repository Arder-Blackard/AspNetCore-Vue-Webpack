﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace vue_webpack_4
{
    public class Program
    {
        public static void Main( string[] args )
        {
            CreateWebHostBuilder( args ).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder( string[] args )
        {
            return Host.CreateDefaultBuilder( args )
                       .ConfigureWebHostDefaults( web =>
                       {
                           web.UseStartup<Startup>()
                              .ConfigureKestrel( options => { } );
                       } )
                       .ConfigureLogging( log => log.AddConsole() );
                ;
        }
    }
}
