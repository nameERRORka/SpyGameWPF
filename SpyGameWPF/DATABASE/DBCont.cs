﻿using SpyGameWPF.DATABASE;
using SpyGameWPF.DATABASE.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyGameWPF.BLOCKS
{
    public class DBCont : DbContext
    {
        public DBCont() : base("DBConnecter")
        {
        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Characters> Characters { get; set; }
    }
}
