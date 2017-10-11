namespace _08.MilitaryElite
{
    using _08.MilitaryElite.Entities.Soldiers.PrivateSolder.SpecialistSolder;
    using _08.MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<ISoldier> army = new List<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                string soldier = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];

                switch (soldier)
                {
                    case "Private":
                        double salary = double.Parse(tokens[4]);
                        army.Add(SoldierFactory.GetPrivate(id, firstName, lastName, salary));
                        break;
                    case "LeutenantGeneral":
                        salary = double.Parse(tokens[4]);
                        IList<ISoldier> privates = ExtractPrivates(tokens.Skip(5).ToList(), army);
                        army.Add(SoldierFactory.GetLeutenantGeneral(id, firstName, lastName, salary, privates));
                        break;
                    case "Engineer":
                        salary = double.Parse(tokens[4]);
                        string corps = tokens[5];
                        if (corps != "Airforces" && corps != "Marines")
                        {
                            break;
                        }
                        IList<IRepair> repairs = ExtractRepair(tokens.Skip(6).ToList(), army);
                        army.Add(SoldierFactory.GetEngineer(id, firstName, lastName, salary, corps, repairs));
                        break;
                    case "Commando":
                        salary = double.Parse(tokens[4]);
                        corps = tokens[5];
                        if (corps != "Airforces" && corps != "Marines")
                        {
                            break;
                        }
                        IList<IMission> missions = ExtractMission(tokens.Skip(6).ToList(), army);
                        army.Add(SoldierFactory.GetCommando(id, firstName, lastName, salary, corps, missions));
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(tokens[4]);
                        army.Add(SoldierFactory.GetSpy(id, firstName, lastName, codeNumber));
                        break;
                    default:
                        break;
                }
            }

            foreach (var solder in army)
            {
                Console.WriteLine(solder);
            }
        }

        private static IList<IRepair> ExtractRepair(List<string> repairs, List<ISoldier> army)
        {
            List<IRepair> list = new List<IRepair>();

            for (int i = 0; i < repairs.Count - 1; i += 2)
            {               
                list.Add(new Repair(repairs[i], int.Parse(repairs[i + 1])));
            }

            return list;
        }

        private static IList<IMission> ExtractMission(List<string> missions, List<ISoldier> army)
        {
            List<IMission> list = new List<IMission>();

            for (int i = 0; i < missions.Count - 1; i += 2)
            {
                if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
                {
                    continue;
                }

                list.Add(new Mission(missions[i], missions[i + 1]));
            }

            return list;
        }

        private static IList<ISoldier> ExtractPrivates(IList<string> privateId, List<ISoldier> army)
        {
            List<ISoldier> list = new List<ISoldier>();

            foreach (var id in privateId)
            {
                list.Add(army.First(s => s.ID == id));
            }

            return list;
        }
    }
}
