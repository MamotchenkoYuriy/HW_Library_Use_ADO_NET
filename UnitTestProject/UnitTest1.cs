using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Implements;
using DAO.Interfaces;
using DAO;
using LibraryItems;
using System.Linq;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        #region Тесты для класса Book

        [TestMethod]
        public void Test_BookDAO_GetList_Method()
        {
            var listBooks = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBooks);
        }

        [TestMethod]
        public void Test_BookDAO_Add_Method()
        {
            var listBooks = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBooks);
            Factory.getInstanse().getBookDAO().Add(new Book() { Name = "TestName", Author = "TestAuthor", Year = 2014 });
            var updatedListBooks = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBooks);
            Assert.IsNotNull(updatedListBooks);
            Assert.AreEqual(listBooks.Count + 1, updatedListBooks.Count);
        }

        [TestMethod]
        public void Test_BookDAO_RemoveById_Method()
        {
            var listBook = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBook); // не пустол ли список журналов
            Factory.getInstanse().getBookDAO().Add(new Book() { Name = "TestName", Author = "Test", Year = 2014 });
            Factory.getInstanse().getBookDAO().Remove(listBook[listBook.Count - 1].Id);
            var updatedListBook = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(updatedListBook);
            Assert.AreEqual(listBook.Count, updatedListBook.Count);
        }

        [TestMethod]
        public void Test_BookDAO_Remove_Method()
        {
            var listBook = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBook); // не пустол ли список журналов
            Factory.getInstanse().getBookDAO().Add(new Book() { Name = "TestName", Author = "Test", Year = 2014 });
            Factory.getInstanse().getBookDAO().Remove(listBook[listBook.Count - 1]);
            var updatedListBook = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(updatedListBook);
            Assert.AreEqual(listBook.Count, updatedListBook.Count);
        }

        [TestMethod]
        public void Test_BookDAO_Update_Method()
        {
            var listBook = Factory.getInstanse().getBookDAO().GetList();
            Assert.IsNotNull(listBook); // не пустол ли список журналов
            var entity = (Book)listBook[0];
            entity.Name = "Changed Name";
            entity.Year = 11111;
            entity.Author = "Changed Author";
            Factory.getInstanse().getBookDAO().Update(entity);
            var entityFromDB = (Book)Factory.getInstanse().getBookDAO().GetList().Where(m => m.Name == "Changed Name").FirstOrDefault();
            Assert.IsNotNull(entityFromDB);
            entityFromDB.Name = "Test";
            entityFromDB.Year = 2014;
            entityFromDB.Author = "Test";
            Factory.getInstanse().getJournalDAO().Update(entity);
        }



        #endregion


        #region Тесты для класса Journal
        [TestMethod]
        public void Test_LournalDAO_GetList_Method()
        {
            var listJournals = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listJournals);
        }

        [TestMethod]
        public void Test_JournalDAO_Add_Method()
        {
            var listBooks = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listBooks);
            Factory.getInstanse().getJournalDAO().Add(new Journal() { Name = "TestName", Number= 123456, Year = 2014 });
            var updatedListBooks = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listBooks);
            Assert.IsNotNull(updatedListBooks);
            Assert.AreEqual(listBooks.Count + 1, updatedListBooks.Count);
        }

        [TestMethod]
        public void Test_JournalDAO_RemoveById_Method()
        {
            var listJournal = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listJournal); // не пустол ли список журналов
            Factory.getInstanse().getJournalDAO().Add(new Journal() { Name = "TestName", Number = 123456, Year = 2014 });
            Factory.getInstanse().getJournalDAO().Remove(listJournal[listJournal.Count - 1].Id);
            var updatedListJournal = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(updatedListJournal);
            Assert.AreEqual(listJournal.Count, updatedListJournal.Count);
        }

        [TestMethod]
        public void Test_JournalDAO_Remove_Method()
        {
            var listJournal = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listJournal); // не пустол ли список журналов
            Factory.getInstanse().getJournalDAO().Add(new Journal() { Name = "TestName", Number = 123456, Year = 2014 });
            Factory.getInstanse().getJournalDAO().Remove(listJournal[listJournal.Count - 1]);
            var updatedListJournal = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(updatedListJournal);
            Assert.AreEqual(listJournal.Count, updatedListJournal.Count);
        }

        [TestMethod]
        public void Test_JournalDAO_Update_Method()
        {
            var listJournal = Factory.getInstanse().getJournalDAO().GetList();
            Assert.IsNotNull(listJournal); // не пустол ли список журналов
            var entity = (Journal)listJournal[0];
            entity.Name = "Changed Name";
            entity.Year = 11111;
            entity.Number = 11111;
            Factory.getInstanse().getJournalDAO().Update(entity);
            var entityFromDB = (Journal)Factory.getInstanse().getJournalDAO().GetList().Where(m => m.Name == "Changed Name").FirstOrDefault();
            Assert.IsNotNull(entityFromDB);
            entityFromDB.Name = "Test";
            entityFromDB.Year = 2014;
            entityFromDB.Number = 123456;
            Factory.getInstanse().getJournalDAO().Update(entity);
        }



        #endregion
    }
}
