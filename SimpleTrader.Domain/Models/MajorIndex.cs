﻿namespace SimpleTrader.Domain.Models
{
    public class MajorIndex
    {
        public double Price { get; set; }
        public double Changes { get; set; }
        public MajorIndexType Type { get; set; }
        public string IndexName { get; set; }
    }

    public enum MajorIndexType
    {
        DowJones, 
        Nasdaq,
        SP500
    }
}