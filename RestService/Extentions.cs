using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService
{
    public static class Extentions
    {
        public static bool IsTest(this IHostEnvironment env) => env.IsEnvironment("Test");
    }
}
