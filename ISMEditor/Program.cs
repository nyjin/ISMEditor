using System;

namespace DeployFileEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine(options.GetUsage());
                return;
            }
            var processor = new DeployFileProcessor();
            processor.Run(options);
            Console.WriteLine($"파일 [{options.FilePath}] 버전 [{options.Version}]");
        }
    }
}
