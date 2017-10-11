namespace BashSoftProgram.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;

        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}
