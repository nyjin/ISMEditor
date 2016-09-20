using CommandLine;
using CommandLine.Text;

namespace DeployFileEditor
{
    public class Options
    {
        [Option('p', "path", Required = true, HelpText = "Ism ���� ��ü ��θ� �����մϴ�.")]
        public string FilePath { get; set; }

        [Option('t', "filetype", Required = false, DefaultValue = 'i', HelpText = "���� �Ӽ��� �����մϴ�. Ism ���� : i, VDPROJ ���� : v")]
        public char FileType { get; set; }

        [Option('v', "version", Required = true, HelpText = "��� ������ �����մϴ�.")]
        public string Version { get; set; }

        [Option('k', "package", Required = false, HelpText = "��Ű�� �ڵ带 �����մϴ�. �������� ������ �ڵ� ���� �˴ϴ�.")]
        public string PackageCode { get; set; }

        [Option('d', "product", Required = false, HelpText = "��ǰ �ڵ带 �����մϴ�. �������� ������ �ڵ� ���� �˴ϴ�.")]
        public string ProductCode { get; set; }

        [Option("disable-package", Required = false, DefaultValue = false, HelpText = "��Ű�� �ڵ� ó�� ���θ� �����մϴ�.")]
        public bool DisablePackageCode { get; set; }

        [Option("disable-version", Required = false, DefaultValue = false, HelpText = "��� ���� ó�� ���θ� �����մϴ�.")]
        public bool DisableProductVersion { get; set; }

        [Option("disable-product", Required = false, DefaultValue = false, HelpText = "��ǰ �ڵ� ó�� ���θ� �����մϴ�.")]
        public bool DisableProductCode { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}