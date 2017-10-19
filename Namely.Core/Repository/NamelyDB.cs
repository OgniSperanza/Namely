using Namely.Core.Interface;
using Namely.Core.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Xamarin.Forms;

namespace Namely.Core.Repository
{
    //[Table("BabyNames")]
    public class NamelyDB
    {
        //[PrimaryKey, AutoIncrement, Column("_id")]
        //public int Id { get; set; }
        //[MaxLength(25)]
        //public string Name { get; set; }
        ////Don't know if this iformation needs to be stored locally.
        ////[MaxLength(500)]
        ////public string Meaning { get; set; }
        ////[MaxLength(500)]
        ////public string History { get; set; }
        ////[MaxLength(50)]
        ////public string Pronunciation { get; set; }
        ////[MaxLength(250)]
        ////public List<string> NickNames { get; set; }
        //[MaxLength(1)]
        //public int IsLiked { get; set; }
        //[MaxLength(50)]
        //public string LikeBy { get; set; }
        readonly SQLiteAsyncConnection database;

        public NamelyDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<BabyName>().Wait();
        }


    }
}
