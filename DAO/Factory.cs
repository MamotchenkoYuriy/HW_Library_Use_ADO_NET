using DAO.Implements;
using DAO.Interfaces;
using LibraryItems;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Factory
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        static Factory factory = null;
        BookDAO bookDAO = null;
        JournalDAO journalDAO = null;

        private Factory()
        {
            var builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "YURIY-PC";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "LibraryDB";
            connectionString = builder.ConnectionString;
            provider = "System.Data.SqlClient";
        }

        public static Factory getInstanse()
        {
            if (factory != null)
            {
                return factory;
            }
            else
            {
                factory = new Factory();
                return factory;
            }
        }

        public BookDAO getBookDAO()
        {
            if (bookDAO != null) { return bookDAO; }
            else
            {
                bookDAO = new BookDAO(connectionString, provider);
                return bookDAO;
            }
        }


        public JournalDAO getJournalDAO()
        {
            if (journalDAO != null) { return journalDAO; }
            else
            {
                journalDAO = new JournalDAO(connectionString, provider);
                return journalDAO;
            }
        }

        public IDAO getDAO<T>()
        {
            if (typeof(T) == typeof(Book))
            {
                return getBookDAO();
            }
            else if (typeof(T) == typeof(Journal))
            {
                return getJournalDAO();
            }
            return null;
        }
    }
}
