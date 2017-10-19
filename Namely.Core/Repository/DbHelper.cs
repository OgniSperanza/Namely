using Namely.Core.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Repository
{
    public class DbHelper
    {
        readonly SQLiteAsyncConnection database;
        public Task<List<BabyName>> GetItemsAsync()
        {
            return database.Table<BabyName>().ToListAsync();
        }

        public Task<List<BabyName>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<BabyName>("SELECT * FROM [NamelyDB] WHERE [Done] = 0");
        }

        public Task<BabyName> GetItemAsync(int id)
        {
            return database.Table<BabyName>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BabyName item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BabyName item)
        {
            return database.DeleteAsync(item);
        }
    }
}
