using System;
using System.IO;

namespace Exercicio.Dez
{
    class Program
    {
        private readonly static FileSystemWatcher _watcher = new FileSystemWatcher();

        static void Main(string[] args)
        {
            ListenToBankReturnFiles();
        }

        private static void ListenToBankReturnFiles()
        {
            _watcher.Path = GetConfigFolder();
            _watcher.Filter = "*.RET";
            _watcher.Created += OnCreated;
            _watcher.EnableRaisingEvents = true;

            new System.Threading.AutoResetEvent(false).WaitOne();
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"O arquivo de retorno bancário {e.Name} foi recebido!");
        }

        public static string GetConfigFolder() => AppDomain.CurrentDomain.BaseDirectory;
    }
}
