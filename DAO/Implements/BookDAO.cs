using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;
using LibraryItems;
using System.Data.Common;

namespace DAO.Implements
{
    public class BookDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private BookDAO() { }
        
        public BookDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }

        public void Add(LibraryItem entity)
        {
            if (!(entity is Book)) { return; }
            var book = (Book)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into BaseEntity(Name, Year, Author, Type) values('{0}', {1}, '{2}', '{3}');",
                    book.Name, book.Year, book.Author, "Book");
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("Delete from BaseEntity where Type='Book' and Id = {0};", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(LibraryItem entity)
        {
            if (!(entity is Book)) { return; }
            var book = (Book)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("Delete from BaseEntity where Type='Book' and Id = {0};", book.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LibraryItem entity)
        {
            if (!(entity is Book)) { return; }
            var book = (Book)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update BaseEntity set Name = '{0}', Year = {1}, Author = '{2}' where Id = {3};",
                    book.Name, book.Year, book.Author, book.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<LibraryItem> GetList()
        {
            List<LibraryItem> retList = new List<LibraryItem>();
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = "Select e.Id,e.Name, e.Year, e.Author  from BaseEntity e where e.Type = 'Book';";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Book((int)dr[0], dr[1].ToString(), (int)dr[2], dr[3].ToString()));
                    }
                }
            }
            return retList;
        }
    }
}
