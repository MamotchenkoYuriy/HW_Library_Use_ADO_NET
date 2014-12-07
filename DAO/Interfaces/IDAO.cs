using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryItems;


namespace DAO.Interfaces
{
    public interface IDAO
    {
        void Add(LibraryItem entity);
        void Remove(int id);
        void Remove(LibraryItem entity);
        void Update(LibraryItem entity);
        List<LibraryItem> GetList();
    }
}
