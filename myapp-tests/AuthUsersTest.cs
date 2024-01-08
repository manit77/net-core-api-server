using myapp;
using myapp.orm;
using System.Diagnostics;

namespace myapp_tests
{
    [TestClass]
    public class AuthUsersTest
    {
        [TestMethod]
        public void TestAuthUsers()
        {
            //set static DB
            var mockDB = new MockDB();
            DataAccess.DB = mockDB;

            var testdata = new myapp.AuthUsers();
            testdata.Id = 1;
            testdata.UserName = "user1";
            testdata.Email = "user1@email.com";
            testdata.IsActive = true;
            testdata.UpdatePassword("password");

            mockDB.Data.Add(testdata);

            myapp.AuthUsers authUser = new myapp.AuthUsers();
            var (rv, errors) = authUser.GetByUserName("username");
            Assert.IsNotNull(rv);

            (rv, errors)  = authUser.Validate();
            Debug.WriteLine(errors.ToString());
            Assert.IsTrue(rv);
            
            
            rv = authUser.Save(1);
            Assert.IsTrue(rv);

        }
    }
}