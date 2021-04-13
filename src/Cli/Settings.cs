using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SftpCli
{
    public class SftpSettings : CommandSettings
    {
        [CommandArgument(0, "<IpAddress>")]
        public string IpAddress { get; set; }

        [CommandArgument(2, "<User>")]
        public string User { get; set; }

        [CommandArgument(3, "<Pass>")]
        public string Password { get; set; }

        [CommandArgument(4, "<LocalPath>")]
        public string LocalPath { get; set; }

        [CommandArgument(5, "<LocalPath>")]
        public string RemotePath { get; set; }
    }
}
