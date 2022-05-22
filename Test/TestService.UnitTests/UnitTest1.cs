using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestService.UnitTests
{
    [TestClass]
    public class WebServiceTests
    {
        
        [TestMethod]
        public void isUser_PersonIsUser_ReturnTrue()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("testUser", "testPasswordUser");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void isUser_WrongName_ReturnFalse()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("","testPasswordUser");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void isUser_WrongPassword_ReturnFalse()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("testUser", "");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void isAdmin_PersonIsAdmin_ReturnTrue()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("testAdmin", "testPasswordAdmin");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void isAdmin_WrongName_ReturnFalse()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("", "testPasswordAdmin");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void isAdmin_WrongPassword_ReturnFalse()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.isUser("testAdmin", "");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void getUserByName_PersonExits_ReturnPK()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getUserByName("testUser");
            // Assert
            Assert.AreEqual(result, "testUser");
        }

        [TestMethod]
        public void getUserByName_WrongName_ReturnNULL()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getUserByName("");
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void getUserNameById_PersonExits_ReturnPK()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getUserNameById("testUser");
            // Assert
            Assert.AreEqual(result, "testUser");
        }

        [TestMethod]
        public void getUserNameById_WrongName_ReturnNULL()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getUserNameById("");
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void addUser_GoodConnection_AddAnUser()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            //  server.addUser("testUser", "testUser", "testUserPassword", "testUser@yahoo.com");
            var result = server.isUser("testUser", "testPasswordUser");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void updateUser_UpdateToAdmin_ChangeToAdmin()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.updateUser("testUser", "Admin");
            var result = server.isAdmin("testUser");
            server.updateUser("testUser", "User");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void updateUser_UpdateToUser_ChangeToUser()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.updateUser("testUser", "User");
            var result1 = server.isAdmin("testUser");
            var result2 = server.isUser("testUser", "testPasswordUser");
            // Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void updateUser_WrongRole_NoChange()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.updateUser("testUser", "");
            var result1 = server.isAdmin("testUser");
            var result2 = server.isUser("testUser", "testPasswordUser");

            // Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void getPassword_PersonExists_ReturnPassword()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getPassword("testUser", "testMailUser@yahoo.com");
            // Assert
            Assert.AreEqual("testPasswordUser", result);
        }

        [TestMethod]
        public void getPassword_WrongName_ReturnNull()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getPassword("", "testMailUser@yahoo.com");
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void getPassword_WrongMail_ReturnNull()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getPassword("userTest", "");
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void getCodeTaskByName_PersonExists_ReturnCodeTask()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.addTask("testUser", "testTaskRequirements", DateTime.Now, "testAdmin,", "testTaskName");
            var result = server.getCodeTaskByName("testTaskName");
            server.deleteTask("testTaskName");
            // Assert
            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void getCodeTaskByName_WrongName_ReturnCodeTask()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getCodeTaskByName("");
            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void getChatByCode_ChatEmpty_ReturnNull()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getChatByCode(2);
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void getChatByCode_WrongCodeChat_ReturnNull()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getChatByCode(-1);
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void getChatByUsers_WrongUser_ReturnNull()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            var result = server.getChatByUsers("Admin", "");
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void addFriend_GoodConnection_AddAFriend()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.addFriend("testUser", "User");
            var result = server.getChatByUsers("testUser", "User");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void deleteFriend_GoodConnection_DeleteAFriend()
        {
            // Arrange
            ServiceReference1.WebService1SoapClient server = new ServiceReference1.WebService1SoapClient();
            // Act
            server.deleteFriend("testUser", "User");
            var result = server.getChatByUsers("testUser", "User");

            // Assert
            Assert.IsNull(result);
        }

    }
}
