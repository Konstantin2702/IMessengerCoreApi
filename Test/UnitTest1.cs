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

        [SetUp]
        public void Setup()
        {       
            using (var context = new TestDbContext(_options.Options))
            {
                context.AddRange(RGDialogsClients.Init());
                context.SaveChanges();
            }   
        }

        [Test]
        public void CheckDialogIsExists()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                Assert.AreEqual(_correctDialog, _service.GetDialogs(_correctClients, context));
            }
        }

        [Test]
        public void CheckDialogIsNotExists()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                Assert.AreEqual(Guid.Empty, _service.GetDialogs(_unCorrectClients, context));
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var context = new TestDbContext(_options.Options))
            {
                context.RemoveRange(RGDialogsClients.Init());
            }

        }
    }
}