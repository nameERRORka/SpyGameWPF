using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyGameWPF.DATABASE.Tables
{
    public class Characters
    {
        public int ID {  get; set; }
        public string Charname { get; set; }
        public bool Alive { get; set; }
    }
}
