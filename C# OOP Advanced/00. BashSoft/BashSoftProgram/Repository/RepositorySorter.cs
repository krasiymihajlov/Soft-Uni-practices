﻿namespace BashSoftProgram.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoftProgram.IO;
    using BashSoftProgram.StaticData;
    using Contracts.Repository.RepositoryFilter;
    
    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(
            Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(studentsMarks
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsMarks
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> kvp in studentsSorted)
            {
                OutputWriter.PrintStudent(kvp);
            }
        }
    }
}