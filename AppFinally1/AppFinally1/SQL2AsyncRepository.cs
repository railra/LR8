using AppFinally1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFinally1
{
    public class SQL2AsyncRepository
    {

        SQLiteAsyncConnection database;

        public SQL2AsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Models.SmallTasks>();
        }
        public async Task<List<Models.SmallTasks>> GetItemsAsync()
        {
            return await database.Table<Models.SmallTasks>().ToListAsync();

        }
        public async Task<Models.SmallTasks> GetItemAsync(int id)
        {
            return await database.GetAsync<Models.SmallTasks>(id);
        }
        public async Task<int> DeleteItemAsync(Models.SmallTasks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Models.SmallTasks item)
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
    public class SQL3AsyncRepository
    {
        SQLiteAsyncConnection database;
        private SQLiteConnection db;

        public SQL3AsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            db = new SQLiteConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Models.Punishments>();
        }
        public async Task<List<Models.Punishments>> GetItemsAsync()
        {
            return await database.Table<Models.Punishments>().ToListAsync();

        }
        public List<Models.Punishments> GetItems()
        {
            return db.Table<Models.Punishments>().ToList();

        }
        public async Task<Models.Punishments> GetItemAsync(int id)
        {
            return await database.GetAsync<Models.Punishments>(id);
        }
        public async Task<int> DeleteItemAsync(Models.Punishments item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Models.Punishments item)
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
    public class SQL4AsyncRepository
    {
        SQLiteAsyncConnection database;


        public SQL4AsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Models.UrgentTasks>();
        }
        public async Task<List<Models.UrgentTasks>> GetItemsAsync()
        {
            return await database.Table<Models.UrgentTasks>().ToListAsync();

        }
        public async Task<Models.UrgentTasks> GetItemAsync(int id)
        {
            return await database.GetAsync<Models.UrgentTasks>(id);
        }
        public async Task<int> DeleteItemAsync(Models.UrgentTasks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Models.UrgentTasks item)
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
    public class SQL5AsyncRepository
    {
        SQLiteAsyncConnection database;


        public SQL5AsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Models.Achievments>();

        }
        public async Task<List<Models.Achievments>> GetItemsAsync()
        {
            return await database.Table<Models.Achievments>().ToListAsync();

        }
        public async Task<Models.Achievments> GetItemAsync(int id)
        {
            return await database.GetAsync<Models.Achievments>(id);
        }
        public async Task<int> DeleteItemAsync(Models.Achievments item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Models.Achievments item)
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
