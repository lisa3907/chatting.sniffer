using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Sniffer.Server
{
    [RunInstaller(true)]
    public partial class PmsInstaller : Installer
    {
        public PmsInstaller()
        {
            InitializeComponent();
        }
    }
}