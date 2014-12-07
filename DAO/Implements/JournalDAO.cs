using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;
using LibraryItems;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace DAO.Implements
{
    public class JournalDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private JournalDAO()
        {

        }

        public JournalDAO(string connectionString, string provider)
        {
            this.provider = provider;
            this.connectionString = connectionString;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(LibraryItem entity)
        {
            if (!(entity is Journal)) { return; }
            var journal = (Journal)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into BaseEntity(Name, Year, Number, Type) values('{0}', {1}, {2}, '{3}');",
                    journal.Name, journal.Year, journal.Number, "Journal");
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
                cmd.CommandText = String.Format("Delete from BaseEntity where Type='Journal' and Id = {0};", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(LibraryItem entity)
        {
            if (!(entity is Journal)) { return; }
            var journal = (Journal)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("Delete from BaseEntity where Type='Journal' and Id = {0};", journal.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LibraryItem entity)
        {
            if (!(entity is Journal)) { return; }
            var journal = (Journal)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update BaseEntity set Name = '{0}', Year = {1}, Number = '{2}' where Id = {3};",
                    journal.Name, journal.Year, journal.Number, journal.Id);
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
                cmd.CommandText = "Select e.Id,e.Name, e.Year, e.Number  from BaseEntity e where e.Type = 'Journal';";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Journal((int)dr[0], dr[1].ToString(), (int)dr[2], (int)dr[3]));
                    }
                }
            }
            return retList;
        }
    }
}
