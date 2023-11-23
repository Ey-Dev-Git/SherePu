using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module.Controllers;
using Module.Data;
using Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class ActivityControllerTest
    {
        private ApplicationDBContext _dbContext;
        private ActivityController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDBContext(options);
            _controller = new ActivityController(_dbContext);

            // Add test data
            var activities = new List<Activities>
            {
                new Activities {
                ActivityID = 1,
                ActivityName = "ActivityName 1",
                ActivityDetail = "ActivityDetail 1",
                ActivityPicture ="ActivityPicture 1",
                LocationTravelID = 1
                },
                new Activities {
                ActivityID = 2,
                ActivityName = "ActivityName 2",
                ActivityDetail = "ActivityDetail 2",
                ActivityPicture ="ActivityPicture 2",
                LocationTravelID = 2
                },new Activities {
                ActivityID = 3,
                ActivityName = "ActivityName 3",
                ActivityDetail = "ActivityDetail 3",
                ActivityPicture ="ActivityPicture 3",
                LocationTravelID = 3
                }
             };
            _dbContext.Activities.AddRange(activities);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void CreateDataActivity_ValidModel_Returns_Correct()
        {
            // Arrange
            var model = new Activities
            {
                // มอโดลที่ใช้ในการทำงาน
                ActivityID = 4,
                ActivityName = "ActivityName 4",
                ActivityDetail = "ActivityDetail 4",
                ActivityPicture = "ActivityPicture 4",
                LocationTravelID = 4
            };

            // Act
            var result = _controller.CreateDataActivity(model) as OkObjectResult;


            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("สร้างเรียบร้อย", result.Value);
        }

        [TestMethod]
        public void UpdateDataActivity_ValidModel_Returns_Correct()
        {
            // Arrange
            var id = 3;
            var model = new Activities
            {
                // มอโดลที่ใช้ในการทำงาน
                ActivityName = "ActivityName 4",
                ActivityDetail = "ActivityDetail 4",
                ActivityPicture = "ActivityPicture 4",
                LocationTravelID = 4
            };
            var expectedUpdateDataActivity = _dbContext.Activities.Find(id);


            // Act
            var result = _controller.UpdateDataActivity(id, model) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("แก้ไขเรียบร้อย", result.Value);
            Assert.IsTrue(expectedUpdateDataActivity.ActivityName == "ActivityName 4");
            Assert.IsTrue(expectedUpdateDataActivity.ActivityDetail == "ActivityDetail 4");
            Assert.IsTrue(expectedUpdateDataActivity.ActivityPicture == "ActivityPicture 4");
            Assert.IsTrue(expectedUpdateDataActivity.LocationTravelID == 4);
        }

        [TestMethod]
        public void DeleteActivity_ExistingId_Returns_Correct()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.DeleteActivity(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ลบเรียบร้อย", result.Value);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
        }


    }
}
