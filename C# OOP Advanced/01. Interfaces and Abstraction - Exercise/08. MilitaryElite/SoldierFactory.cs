namespace _08.MilitaryElite
{
    using _08.MilitaryElite.Entities.Soldiers;
    using _08.MilitaryElite.Entities.Soldiers.PrivateSolder;
    using _08.MilitaryElite.Entities.Soldiers.PrivateSolder.SpecialistSolder;
    using _08.MilitaryElite.Interfaces;
    using System.Collections.Generic;

    public class SoldierFactory
    {
        private SoldierFactory()
        {
        }

        public static Private GetPrivate(string id, string firstName, string lastName, double salary)
        {
            return new Private(id, firstName, lastName, salary);
        }

        public static LeutenantGeneral GetLeutenantGeneral(string id, string firsName, string lastName, double salary, IList<ISoldier> solders)
        {
            return new LeutenantGeneral(id, firsName, lastName, salary, solders);
        }

        public static Engineer GetLeutenantGeneral(string id, string firsName, string lastName, double salary, string corps, IList<IRepair> parts)
        {
            return new Engineer(id, firsName, lastName, salary, corps, parts);
        }

        public static Engineer GetEngineer(string id, string firsName, string lastName, double salary, string corps, IList<IRepair> parts)
        {
            return new Engineer(id, firsName, lastName, salary, corps, parts);
        }

        public static Commando GetCommando(string id, string firsName, string lastName, double salary, string corps, IList<IMission> missions)
        {
            return new Commando(id, firsName, lastName, salary, corps, missions);
        }

        public static Spy GetSpy(string id, string firsName, string lastName, int codeNumber)
        {
            return new Spy(id, firsName, lastName, codeNumber);
        }
    }
}
