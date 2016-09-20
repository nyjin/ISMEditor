using CommandLine;
using CommandLine.Text;

namespace DeployFileEditor
{
    public class Options
    {
        [Option('p', "path", Required = true, HelpText = "Ism 파일 전체 경로를 지정합니다.")]
        public string FilePath { get; set; }

        [Option('t', "filetype", Required = false, DefaultValue = 'i', HelpText = "파일 속성을 지정합니다. Ism 파일 : i, VDPROJ 파일 : v")]
        public char FileType { get; set; }

        [Option('v', "version", Required = true, HelpText = "대상 버전을 지정합니다.")]
        public string Version { get; set; }

        [Option('k', "package", Required = false, HelpText = "패키지 코드를 지정합니다. 지정하지 않으면 자동 생성 됩니다.")]
        public string PackageCode { get; set; }

        [Option('d', "product", Required = false, HelpText = "제품 코드를 지정합니다. 지정하지 않으면 자동 생성 됩니다.")]
        public string ProductCode { get; set; }

        [Option("disable-package", Required = false, DefaultValue = false, HelpText = "패키지 코드 처리 여부를 지정합니다.")]
        public bool DisablePackageCode { get; set; }

        [Option("disable-version", Required = false, DefaultValue = false, HelpText = "대상 버전 처리 여부를 지정합니다.")]
        public bool DisableProductVersion { get; set; }

        [Option("disable-product", Required = false, DefaultValue = false, HelpText = "제품 코드 처리 여부를 지정합니다.")]
        public bool DisableProductCode { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}