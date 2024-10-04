﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Roi
{
    public partial class CountryList
    {
       
            public Name Name { get; set; }
            public string Region { get; set; }
            public long Population { get; set; }

            public List<string> Capital { get; set; }
            public Flag Flags { get; set; }

            public string CapitalDisplay => Capital != null && Capital.Any() ? string.Join(", ", Capital) : "No capital";

         
            public string FlagImageUrl => Flags != null ? Flags.Png : null;
        }

        public class Flag
        {
            public string Png { get; set; }
            public string Svg { get; set; }
        }

        public class Name
        {
            public string Common { get; set; }

            public override string ToString()
            {
                return Common;
            }
        }
    }

