using System;

namespace ISMEditor
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string xpath) : base(xpath)
        {
            
        }
    }
}