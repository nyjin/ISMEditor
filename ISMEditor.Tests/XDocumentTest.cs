using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using NUnit.Framework;

namespace ISMEditor.Tests
{
    [TestFixture]
    public class XDocumentTest
    {
        private XDocument _document;

        [SetUp]
        public void Initialize()
        {
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("ISMEditor.Tests.Resource.SightProServer.Deploy.ism"))
            {
                using (var sr = new StreamReader(s))
                {
                    _document = XDocument.Load(sr);
                }
            }
        }

        [Test]
        public void TestThatReplacePackageCode()
        {
            var code = _document.XPathSelectElements("/msi/summary/revnumber").FirstOrDefault();
            code.Value = CreateGuid();
        }

        [Test]
        public void TestThatReplaceProductCode()
        {
            ReplacePropertyValue("ProductCode", CreateGuid());
        }

        

        [Test]
        public void TestThatReplaceProductVersion()
        {
            ReplacePropertyValue("ProductVersion", "2.1.1.0");
        }

        public string CreateGuid()
        {
            return Guid.NewGuid().ToString("B").ToUpper();
        }
        private void ReplacePropertyValue(string elementName, string val)
        {
            var ele = _document.XPathSelectElements("/msi/table[@name='Property']/row/td[text()='" + elementName + "']");
            var codeName = ele.FirstOrDefault();
            var codeValue = codeName.ElementsAfterSelf().FirstOrDefault();
            codeValue.Value = val;
        }
    }
}
