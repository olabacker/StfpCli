using Spectre.Console.Cli;
using System;

namespace SftpCli
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandApp();

            app.Configure(config =>
            {
                config.AddCommand<UploadCommand>("upload");

                config.AddCommand<DownloadCommand>("download");
            });

            return app.Run(args);
        }
    }
}
