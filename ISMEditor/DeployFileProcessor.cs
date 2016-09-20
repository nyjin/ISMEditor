using DeployFileEditor.Subjects;

namespace DeployFileEditor
{
    public class DeployFileProcessor
    {
        public void Run(Options options)
        {
            var fileType = options.FileType.ToString().ToUpper();
            IDeployFile file;
            if (fileType == "I")
            {
                file = new IsmFile();
            }
            else
            {
                file = new VdprojFile();
            }
            file.Load(options.FilePath);
            if (!options.DisableProductVersion)
                file.ReplaceProductVersion(options.Version);
            if (!options.DisablePackageCode)
                file.ReplacePackageCode(options.PackageCode);
            if (!options.DisableProductCode)
                file.ReplaceProductCode(options.ProductCode);
            file.Save();
        }
    }
}