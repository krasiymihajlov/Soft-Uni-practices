﻿using System;

namespace _05.BorderControl
{
    public class Robot : INumber
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }

        public string Model { get; set; }

        public string ID { get; set; }
    }
}
