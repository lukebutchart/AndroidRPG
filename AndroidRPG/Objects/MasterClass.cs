using System;
using SQLite;

namespace AndroidRPG.Objects
{
    class MasterClass
    {
        [PrimaryKey, AutoIncrement]
        public long ID { get; set; }
        public String Name { get; set; }
        public int ImageResourceId { get; set; }
        public bool Existence { get; set; } = false;
    }
}