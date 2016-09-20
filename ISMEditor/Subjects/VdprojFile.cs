using System.Text.RegularExpressions;

namespace DeployFileEditor.Subjects
{
    public class VdprojFile : DeployFile
    {
        private static readonly Regex RegexProductCode = new Regex(@"(?:\""ProductCode\""[\s*]=[\s*]\""8.){([\dA-Fa-f-]+)}", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex RegexPackageCode = new Regex(@"(?:\""PackageCode\""[\s*]=[\s*]\""8.){([\dA-Fa-f-]+)}", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex RegexProductVersion = new Regex(@"(?:\""ProductVersion\""[\s*]=[\s*]\""8:[0-9.]*\"")", RegexOptions.Compiled | RegexOptions.Multiline);
        private string _content;

        protected override void ProcessLoad(string path)
        {
            using (var sr = new System.IO.StreamReader(path))
            {
                _content = sr.ReadToEnd();
                sr.Close();
            }
        }

        public override void Save()
        {
            if (string.IsNullOrEmpty(_content)) return;
            using (var sw = new System.IO.StreamWriter(Path, false))
            {
                sw.Write(_content);
                sw.Close();
            }
        }

        private void ReplaceProperty(Regex regex, string replaceValue)
        {
            var match = regex.IsMatch(_content);
            _content = regex.Replace(_content, replaceValue);
        }

        protected override void ProcessReplacePackageCode(string value)
        {
            ReplaceProperty(RegexPackageCode, "\"PackageCode\" = \"8:" + value + "");
        }

        protected override void ProcessReplaceProductCode(string value)
        {
            ReplaceProperty(RegexProductCode, "\"ProductCode\" = \"8:" + value + "");
        }

        protected override void ProcessReplaceProductVersion(string value)
        {
            ReplaceProperty(RegexProductVersion, "\"ProductVersion\" = \"8:" + value + "\"");
        }
    }
}