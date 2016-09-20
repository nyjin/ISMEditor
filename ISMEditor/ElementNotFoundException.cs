using System;

namespace DeployFileEditor
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string xpath) : base(xpath)
        {
            
        }
    }
}