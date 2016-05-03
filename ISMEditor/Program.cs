using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace ISMEditor
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
            var file = new IsmFile(options.FilePath);
            file.ReplaceProductVersion(options.Version);
            file.ReplacePackageCode(options.PackageCode);
            file.ReplaceProductCode(options.ProductCode);
            file.Save();

            Console.WriteLine($"파일 [{options.FilePath}] 버전 [{options.Version}]");
        }
    }

    internal class Options
    {
        [Option('p', "path", Required = true, HelpText = "Ism 파일 전체 경로를 지정합니다.")]
        public string FilePath { get; set; }

        [Option('v', "version", Required = true, HelpText = "대상 버전을 지정합니다.")]
        public string Version { get; set; }

        [Option('k', "package", Required = false, HelpText = "패키지 코드를 지정합니다.")]
        public string PackageCode { get; set; }

        [Option('d', "product", Required = false, HelpText = "제품 코드를 지정합니다.")]
        public string ProductCode { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
