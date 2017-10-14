using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Repository
{
    [Table("BabyNames")]
    public class NamelyDB : ISQLitePlatform
    {
        public NamelyDB(string dbPath)
        {
            var database = new SQLiteConnection(this, dbPath);
        }

        public ISQLiteApi SQLiteApi => throw new NotImplementedException();

        public IStopwatchFactory StopwatchFactory => throw new NotImplementedException();

        public IReflectionService ReflectionService => throw new NotImplementedException();

        public IVolatileService VolatileService => throw new NotImplementedException();

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        //Don't know if this iformation needs to be stored locally.
        //[MaxLength(500)]
        //public string Meaning { get; set; }
        //[MaxLength(500)]
        //public string History { get; set; }
        //[MaxLength(50)]
        //public string Pronunciation { get; set; }
        //[MaxLength(250)]
        //public List<string> NickNames { get; set; }
        [MaxLength(1)]
        public int IsLiked { get; set; }
        [MaxLength(50)]
        public string LikeBy { get; set; }
    }
}


//public class NamelyDB
//{

//}