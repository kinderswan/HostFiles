using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.HostFiles.Model.Models;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;
using Epam.HostFiles.Core;
using Epam.HostFiles.Core.Repository;
using Epam.HostFiles.Core.Infrastructure;

namespace Epam.HostFiles.Tests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void UserRepository_ShouldReturnUpdatedUser()
        {
            var userToChange = new UserInfo
            {
                UserInfoId = 1,
                Login = "login1",
                Name = "name1",
                Password = "password1"
            };

            var dbData = new List<UserInfo>()
            {
                userToChange,
                new UserInfo
                {
                    UserInfoId = 2,
                    Login = "login2",
                    Name = "name2",
                    Password = "password2"
                },
                new UserInfo
                {
                    UserInfoId = 3,
                    Login = "login3",
                    Name = "name3",
                    Password = "password3"
                }
            }.AsQueryable();

            UserInfo newUser = new UserInfo
            {
                UserInfoId = 1,
                Login = "loginnew",
                Name = "namenew",
                Password = "passwordnew"
            };

            var dbSetMock = new Mock<DbSet<UserInfo>>();
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserInfo>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);

            var repo = new UserInfoRepository(dbfactory);
            repo.Update(newUser);
            //uow.Commit();
            var result = repo.Get(u => u.UserInfoId == 1);
            Assert.AreEqual(newUser.Name, result.Name);

        }

        [TestMethod]
        public void UserRepository_ShouldAddUser()
        {
            var newUser = new UserInfo
            {
                Login = "login1",
                Name = "name123",
                Password = "password1",
                UserRoleId = 1
            };

            var dbData = new List<UserInfo>()
            {
                new UserInfo
                {
                    UserInfoId = 2,
                    Login = "login2",
                    Name = "name2",
                    Password = "password2",
                    UserRoleId = 1
                },
                new UserInfo
                {
                    UserInfoId = 3,
                    Login = "login3",
                    Name = "name3",
                    Password = "password3",
                    UserRoleId = 1
                }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<UserInfo>>();
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserInfo>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);
            var repo = new UserInfoRepository(dbfactory);

            repo.Add(newUser);
            uow.Commit();

            var result = repo.Get(u => u.Name == "name123");

            Assert.AreEqual(result.Name, "name123");

        }

        [TestMethod]
        public void UserRepository_ShouldDeleteUser()
        {
            var newUser = new UserInfo
            {
                Login = "login1",
                Name = "name123",
                Password = "password1",
                UserRoleId = 1
            };

            var dbData = new List<UserInfo>()
            {
                new UserInfo
                {
                    UserInfoId = 2,
                    Login = "login2",
                    Name = "name2",
                    Password = "password2",
                    UserRoleId = 1
                },
                new UserInfo
                {
                    UserInfoId = 3,
                    Login = "login3",
                    Name = "name3",
                    Password = "password3",
                    UserRoleId = 1
                }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<UserInfo>>();
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserInfo>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserInfo>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);
            var repo = new UserInfoRepository(dbfactory);

            repo.Add(newUser);
            uow.Commit();
            Assert.AreEqual(repo.Get(u => u.Name == "name123").Name, "name123");
            repo.Delete(u => u.Name == "name123");
            uow.Commit();
            var result = repo.Get(u => u.Name == "name123");
            Assert.IsNull(result);

        }

        [TestMethod]
        public void RoleRepository_ShouldReturnUpdatedRole()
        {
            var roleToChange = new UserRole
            {
                Role = "role1",
                UserRoleId = 1
            };

            var dbData = new List<UserRole>()
            {
                roleToChange,
                new UserRole
                {
                    Role = "role2",
                    UserRoleId = 2
                },
                new UserRole
                {
                    Role = "role3",
                    UserRoleId = 3
                }
            }.AsQueryable();

            UserRole newRole = new UserRole
            {
                Role = "role123",
                UserRoleId = 1
            };

            var dbSetMock = new Mock<DbSet<UserRole>>();
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserRole>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);

            var repo = new UserRoleRepository(dbfactory);
            repo.Update(newRole);
            var result = repo.Get(u => u.UserRoleId == 1);
            Assert.AreEqual(newRole.Role, result.Role);

        }

        [TestMethod]
        public void RoleRepository_ShouldAddRole()
        {
            var newRole = new UserRole
            {
                Role = "role1"
            };

            var dbData = new List<UserRole>()
            {
                new UserRole
                {
                    Role = "role2"
                },
                new UserRole
                {
                    Role = "role3"
                }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<UserRole>>();
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserRole>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);
            var repo = new UserRoleRepository(dbfactory);

            repo.Add(newRole);
            uow.Commit();

            var result = repo.Get(u => u.Role == "role1");

            Assert.AreEqual(result.Role, "role1");

        }

        [TestMethod]
        public void RoleRepository_ShouldDeleteRole()
        {
            var newRole = new UserRole
            {
                Role = "role1"                
            };

            var dbData = new List<UserRole>()
            {
                new UserRole
                {
                    Role = "role2"
                },
                new UserRole
                {
                    Role = "role3"
                }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<UserRole>>();
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<UserRole>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());

            var dbContextMock = new Mock<HostFilesEntities>();
            dbContextMock.Setup(x => x.Set<UserRole>()).Returns(dbSetMock.Object);

            var dbfactory = new DbFactory();
            var uow = new UnitOfWork(dbfactory);
            var repo = new UserRoleRepository(dbfactory);

            repo.Add(newRole);
            uow.Commit();
            Assert.AreEqual(repo.Get(u => u.Role == "role1").Role, "role1");
            repo.Delete(u => u.Role == "role1");
            uow.Commit();
            var result = repo.Get(u => u.Role == "role1");
            Assert.IsNull(result);

        }
    }
}
