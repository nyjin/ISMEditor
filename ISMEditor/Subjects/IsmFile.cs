using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DeployFileEditor.Subjects
{
    public class IsmFile : DeployFile
    {
        
        private XDocument _document;

        public IsmFile()
        {
        }

        public IsmFile(StreamReader reader)
        {
            _document = XDocument.Load(reader);
        }

        private XElement GetElement(string xpath)
        {
            var ele = _document.XPathSelectElements(xpath);
            if (ele == null)
            {
                throw new ElementNotFoundException(xpath);
            }
            return ele.FirstOrDefault();

        }
        private void ReplacePropertyValue(string elementName, string val)
        {
            var ele = GetElement("/msi/table[@name='Property']/row/td[text()='" + elementName + "']");
            var codeValue = ele.ElementsAfterSelf().FirstOrDefault();
            codeValue.Value = val;
        }

        protected override void ProcessReplacePackageCode(string value)
        {
            var ele = GetElement("/msi/summary/revnumber");
            ele.Value = value;
        }

        protected override void ProcessReplaceProductCode(string value)
        {
            ReplacePropertyValue("ProductCode", value);
        }

        protected override void ProcessReplaceProductVersion(string value)
        {
            ReplacePropertyValue("ProductVersion", value);
        }

        protected override void ProcessLoad(string path)
        {
            _document = XDocument.Load(path);
        }

        public override void Save()
        {
            if (string.IsNullOrEmpty(Path))
            {
                throw new NullReferenceException("Path");
            }
            _document.Save(Path);
        }
    }
}