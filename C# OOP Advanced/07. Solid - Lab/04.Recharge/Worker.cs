﻿namespace _04.Recharge
{
    using _04.Recharge.Interfaces;

    public abstract class Worker 
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}