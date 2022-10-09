using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Services
{
    public class ReloadService
    {
        private readonly string[] _args;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public ReloadService(string[] args, IHostApplicationLifetime applicationLifetime)
        {
            _args = args;
            _applicationLifetime = applicationLifetime;
        }

        public void Reaload()
        {
            Console.WriteLine("Пока не работает");
            _applicationLifetime.StopApplication();
        }
    }
}
