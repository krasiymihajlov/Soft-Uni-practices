﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long allPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());
            double filteredPicture = Math.Ceiling((filterFactor / 100d) * allPictures);           
            double totalFilterTime = allPictures * filterTime;
            double totalUploadTime = filteredPicture * uploadTime;
            double totalTime = totalFilterTime + totalUploadTime;            
            TimeSpan dateFormat = TimeSpan.FromSeconds(totalTime);
            string allTime = dateFormat.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(allTime);            
        }
    }
}