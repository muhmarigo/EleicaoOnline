using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace EleicaoOnline.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class TestBase : IDisposable
    {
        protected IServiceProvider Services { get; private set; }
        protected IWebHost webHost;

        public TestBase()
        {
          

        }

        public void Dispose()
        {

        }
    }
}
