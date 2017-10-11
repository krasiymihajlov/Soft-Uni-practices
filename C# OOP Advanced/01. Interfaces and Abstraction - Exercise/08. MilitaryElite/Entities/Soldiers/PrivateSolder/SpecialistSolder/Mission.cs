namespace _08.MilitaryElite.Entities.Soldiers.PrivateSolder.SpecialistSolder
{
    using System;
    using _08.MilitaryElite.Interfaces;

    public class Mission : IMission
    {
        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name { get; private set; }

        public string State { get; private set; }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
