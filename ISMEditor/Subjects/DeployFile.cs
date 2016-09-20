using System;

namespace DeployFileEditor.Subjects
{
    public abstract class DeployFile : IDeployFile
    {
        public string Path { get; protected set; }

        protected string CreateGuid()
        {
            return Guid.NewGuid().ToString("B").ToUpper();
        }

        public virtual void ReplacePackageCode(string value)
        {
            ProcessReplacePackageCode(FillGuid(value));
        }

        public virtual void ReplaceProductCode(string value)
        {
            ProcessReplaceProductCode(FillGuid(value));
        }

        public virtual void ReplaceProductVersion(string value)
        {
            ProcessReplaceProductVersion(value);
        }

        protected abstract void ProcessReplacePackageCode(string value);
        protected abstract void ProcessReplaceProductCode(string value);
        protected abstract void ProcessReplaceProductVersion(string value);

        protected string FillGuid(string value)
        {
            var result = value;
            if (string.IsNullOrEmpty(result))
                result = CreateGuid();
            return result;
        }
        

        public virtual void Load(string path)
        {
            Path = path;
            ProcessLoad(path);
        }

        protected abstract void ProcessLoad(string path);

        public abstract void Save();
    }
}