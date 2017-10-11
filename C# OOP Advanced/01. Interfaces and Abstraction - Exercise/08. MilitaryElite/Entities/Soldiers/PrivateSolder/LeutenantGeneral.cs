namespace _08.MilitaryElite.Entities.Soldiers.PrivateSolder
{
    using _08.MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<ISoldier> solders) 
            : base(id, firstName, lastName, salary)
        {
            this.Solders = solders;
        }

        public IList<ISoldier> Solders { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Privates:");

            foreach (var solder in this.Solders)
            {
                sb.AppendLine("  " + solder.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
