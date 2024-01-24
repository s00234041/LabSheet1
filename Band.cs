﻿using LabSheet1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Labsheet1
{
    public abstract class Band : IComparable
    {
        //Prop
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string Members { get; set; }

        public List<Album> AlbumList {  get; set; } 


        //Constructors
        public Band(string bandname, int yearFormed, string members)
        {
            BandName = bandname;
            YearFormed = yearFormed;
            Members = members;

            AlbumList = new List<Album>();
        }

        public Band():this("Unknown", 1960, "Unknown") { }


        //Methods
        public override string ToString()
        {
            return BandName;
        }

        public int CompareTo(object obj)
        {
            Band otherband = obj as Band;
            return this.BandName.CompareTo(otherband.BandName);
        }
    }

    public class RockBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Rock Band";
        }
    }

    public class PopBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Pop Band";
        }
    }

    public class IndieBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Indie Band";
        }
    }
}