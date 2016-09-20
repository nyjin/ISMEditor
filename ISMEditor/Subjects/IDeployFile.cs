namespace DeployFileEditor.Subjects
{
    public interface IDeployFile
    {
        string Path { get; }
        void Load(string path);
        void Save();
        void ReplacePackageCode(string value);
        void ReplaceProductCode(string value);
        void ReplaceProductVersion(string value);
    }
}