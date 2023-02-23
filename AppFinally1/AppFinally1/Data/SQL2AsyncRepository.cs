using AppFinally1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFinally1.Data
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
            await database.CreateTableAsync<SmallTasks>();
        }
        public async Task<List<SmallTasks>> GetItemsAsync()
        {
            return await database.Table<SmallTasks>().ToListAsync();

        }
        public async Task<SmallTasks> GetItemAsync(int id)
        {
            return await database.GetAsync<SmallTasks>(id);
        }
        public async Task<int> DeleteItemAsync(SmallTasks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(SmallTasks item)
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
            await database.CreateTableAsync<Punishments>();
        }
        public async Task<List<Punishments>> GetItemsAsync()
        {
            return await database.Table<Punishments>().ToListAsync();

        }
        public List<Punishments> GetItems()
        {
            return db.Table<Punishments>().ToList();

        }
        public async Task<Punishments> GetItemAsync(int id)
        {
            return await database.GetAsync<Punishments>(id);
        }
        public async Task<int> DeleteItemAsync(Punishments item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Punishments item)
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
            await database.CreateTableAsync<UrgentTasks>();
        }
        public async Task<List<UrgentTasks>> GetItemsAsync()
        {
            return await database.Table<UrgentTasks>().ToListAsync();

        }
        public async Task<UrgentTasks> GetItemAsync(int id)
        {
            return await database.GetAsync<UrgentTasks>(id);
        }
        public async Task<int> DeleteItemAsync(UrgentTasks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(UrgentTasks item)
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
            await database.CreateTableAsync<Achievments>();

        }
        public async Task<List<Achievments>> GetItemsAsync()
        {
            return await database.Table<Achievments>().ToListAsync();

        }
        public async Task<Achievments> GetItemAsync(int id)
        {
            return await database.GetAsync<Achievments>(id);
        }
        public async Task<int> DeleteItemAsync(Achievments item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Achievments item)
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
