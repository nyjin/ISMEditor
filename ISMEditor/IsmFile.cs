using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ISMEditor
{
    public class IsmFile
    {
        public string Path { get; set; }
        private readonly XDocument _document;

        public IsmFile(string path)
        {
            Path = path;
            _document = XDocument.Load(path);
        }

        public IsmFile(StreamReader reader)
        {
            _document = XDocument.Load(reader);
        }
        private string CreateGuid()
        {
            return Guid.NewGuid().ToString("B").ToUpper();
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

        public void ReplacePackageCode(string value = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                value = CreateGuid();
            }
            var ele = GetElement("/msi/summary/revnumber");
            ele.Value = value;
        }
        public void ReplaceProductCode(string value = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                value = CreateGuid();
            }
            ReplacePropertyValue("ProductCode", value);
        }
        public void ReplaceProductVersion(string value)
        {
            ReplacePropertyValue("ProductVersion", value);
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(Path))
            {
                throw new NullReferenceException("Path");
            }
            _document.Save(Path);
        }
    }
}