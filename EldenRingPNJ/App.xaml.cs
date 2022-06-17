using EldenRing.Logic.DataAccess;
using EldenRing.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EldenRingPNJ
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {

        }
    }
    }