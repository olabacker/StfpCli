using Renci.SshNet;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace SftpCli
{
    public class UploadCommand : SftpCommand
    {
        public override int Execute(CommandContext context, SftpSettings settings)
        {
            try
            {
                var fileStream = new FileStream(settings.LocalPath, FileMode.Open);
                UseClient(settings, a => a.UploadFile(fileStream, settings.RemotePath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return 1;
            }

            return 0;
        }
    }

    public abstract class SftpCommand : Command<SftpSettings>
    {
        protected static void UseClient(SftpSettings settings, Action<SftpClient> action)
        {
            var connectionInfo = new ConnectionInfo(settings.IpAddress, settings.User, new PasswordAuthenticationMethod(settings.User, settings.Password));
            using var client = new SftpClient(connectionInfo);
            client.Connect();

            action(client);
        }

    }


    public class DownloadCommand : SftpCommand
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] SftpSettings settings)
        {
            try
            {
                var fileStream = new FileStream(settings.LocalPath, FileMode.OpenOrCreate);
                UseClient(settings, a => a.DownloadFile(settings.RemotePath, fileStream));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return 1;
            }

            return 0;
        }
    }
}
