using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinally1.Data
{
    public class SQLAsyncRepository
    {
        SQLiteAsyncConnection database;
        private SQLiteConnection db;

        public SQLAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            db = new SQLiteConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Models.BigTasks>();
        }
        public async Task<List<Models.BigTasks>> GetItemsAsync()
        {

            return await database.Table<Models.BigTasks>().ToListAsync();
        }
        public async Task<Models.BigTasks> GetItemAsync(int id)
        {
            return await database.GetAsync<Models.BigTasks>(id);
        }
        public List<Models.BigTasks> GetItems()
        {
            return db.Table<Models.BigTasks>().ToList();
        }
        public async Task<int> DeleteItemAsync(Models.BigTasks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Models.BigTasks item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
