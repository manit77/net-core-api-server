using myapp.orm;

namespace myapp_tests
{
    [TestClass]
    public class AuthUsersTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //set static DB
            var mockDB = new MockDB();
            DataAccess.DB = mockDB;

            mockDB.Data.Add(new AuthUsers());

            myapp.AuthUsers authUsers = new myapp.AuthUsers();
            var (rv, errors) =  authUsers.GetByUserName("username");
            Assert.IsTrue(rv);
        }
    }
}