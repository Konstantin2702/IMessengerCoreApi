using iMessengerCoreAPI.Models.Data;
using iMessengerCoreAPI.Models.Models;
using iMessengerCoreAPI.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Tests
    {
        private readonly List<Guid> _correctClients = new List<Guid>
        {
            new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"),
            new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
            new Guid("7de3299b-2796-4982-a85b-2d6d1326396e")
        };
        private readonly List<Guid> _unCorrectClients = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid()
        };
        private readonly Guid _correctDialog = new Guid("fcd6b112-1834-4420-bee6-70c9776f6378");

        private DialogClientService _service = new DialogClientService();
        private readonly DbContextOptionsBuilder<RGDialogDbContext> _options = new DbContextOptionsBuilder<RGDialogDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase");
        private RGDialogClientCollection _rGDialogClientCollection = new();

        [SetUp]
        public void Setup()
        {
            _rGDialogClientCollection.RGDialogsClients = RGDialogsClients.Init();
            using (var context = new TestDbContext(_options.Options))
            {
                context.AddRange(_rGDialogClientCollection.RGDialogsClients);
                context.SaveChanges();
            }
           
        }

        [Test]
        public void CheckDialogIsExistsInDB()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                Assert.AreEqual(_correctDialog, _service.GetDialogsFromDB(_correctClients, context));
            }
        }

        [Test]
        public void CheckDialogIsNotExistsIbDB()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                Assert.AreEqual(Guid.Empty, _service.GetDialogsFromDB(_unCorrectClients, context));
            }
        }


        [Test]
        public void CheckDialogIsExistsInColelction()
        {

            Assert.AreEqual(_correctDialog, _service.GetDialogsFromCollection(_correctClients, _rGDialogClientCollection));

        }

        [Test]
        public void CheckDialogIsNotExistsInCollection()
        {

            Assert.AreEqual(Guid.Empty, _service.GetDialogsFromCollection(_unCorrectClients, _rGDialogClientCollection));
        }

        [TearDown]
        public void TearDown()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                context.RemoveRange(_rGDialogClientCollection.RGDialogsClients);
                context.SaveChanges();
            }
            _rGDialogClientCollection.RGDialogsClients = new();
        }
    }
}