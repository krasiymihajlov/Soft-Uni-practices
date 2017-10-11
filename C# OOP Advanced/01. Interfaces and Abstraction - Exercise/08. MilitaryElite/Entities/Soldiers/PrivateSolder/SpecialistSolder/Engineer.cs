namespace _08.MilitaryElite.Entities.Soldiers.PrivateSolder.SpecialistSolder
{
    using System.Collections.Generic;
    using _08.MilitaryElite.Interfaces;
    using System.Text;
    using System;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IRepair> parts) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Parts = parts;
        }

        public IList<IRepair> Parts { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Repairs:");
            sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Parts)}");

            return sb.ToString().Trim();
        }
    }
}
