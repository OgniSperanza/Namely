using Namely.Core.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Repository
{
    public class DbHelper
    {
        readonly SQLiteAsyncConnection _database;

        //public DbHelper()
        //{
        //    string dbPath = Path.Combine(Environment..GetFolderPath(Environment.SpecialFolder.Personal),
        //                     "NamelyDb-DEV.db3");
        //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);
        //    _database = newDb;
        //}


        public DbHelper(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<List<BabyName>> GetItemsAsync()
        {
            return _database.Table<BabyName>().ToListAsync();
        }

        public Task<List<BabyName>> GetAllNames()
        {
            return _database.QueryAsync<BabyName>("SELECT * FROM [NamelyDB]");
        }

        public Task<BabyName> GetItemAsync(int id)
        {
            return _database.Table<BabyName>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BabyName item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BabyName item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
