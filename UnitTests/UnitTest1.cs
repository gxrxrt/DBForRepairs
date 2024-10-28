using DataBaseLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;


namespace WindowsFormsApp1.Tests
{
    [TestClass]
    public class DBTests
    {
        private DB db;

        [TestInitialize]
        public void Setup()
        {
            db = new DB();
        }

        [TestMethod]
        public void TestOpenConnection()
        {
            db.openConnection();
            Assert.AreEqual(ConnectionState.Open, db.GetConnection().State);
            db.closeConnection();
        }

        [TestMethod]
        public void TestCloseConnection()
        {
            db.openConnection();
            db.closeConnection();
            Assert.AreEqual(ConnectionState.Closed, db.GetConnection().State);
        }
    }

    [TestClass]
    public class SearchRepReqTests
    {
        private SearchRepReq searchForm;

        [TestInitialize]
        public void Setup()
        {
            searchForm = new SearchRepReq();
        }

        [TestMethod]
        public void TestLoadMasters()
        {
            // Assuming the LoadMasters function is public
            searchForm.LoadMasters();
            Assert.IsTrue(searchForm.comboBoxMasters.Items.Count > 0);
        }

        [TestMethod]
        public void TestLoadClients()
        {
            // Assuming the LoadClients function is public
            searchForm.LoadClients();
            Assert.IsTrue(searchForm.comboBoxClients.Items.Count > 0);
        }

        [TestMethod]
        public void TestSearchRepairRequests()
        {
            // Assuming the buttonSearch_Click function is public and returns data.
            searchForm.buttonSearch_Click(null, null);
            Assert.IsTrue(searchForm.dataGridViewResults.Rows.Count > 0);
            // Additional assertions can be made based on expected results.
        }
    }
}
