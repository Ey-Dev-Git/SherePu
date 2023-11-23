using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module.Controllers;
using Module.Data;
using Module.Models;
using Namotion.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Services;

namespace TestProject
{
    [TestClass]
    public class LocationTravelControllerTest
    {
        private ApplicationDBContext _dbContext;
        private LocationTravelController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDBContext(options);
            _controller = new LocationTravelController(_dbContext);

            // Add test data
            var locationTravel = new List<LocationTravels>
            {
                new LocationTravels { LocationTravelID = 1, LocationTravelName = "LocationTrave 1", LocationTravelDetail = "LocationTrave 1 detail", LocationTravelPicture = "LocationTravelpicture1.jpg",LocationTravelPathGoogleMap ="LocationTravelPathGoogleMap1",
                    Activities = new List<Activities> {new Activities { ActivityID = 1, ActivityName = "Activity 1" ,ActivityDetail = "Activity 1 Detail",ActivityPicture ="Activity 1 Picture"},
                    new Activities { ActivityID = 2, ActivityName = "Activity 2" ,ActivityDetail = "Activity 2 Detail",ActivityPicture ="Activity 2 Picture"}
                    }},
                new LocationTravels { LocationTravelID = 2, LocationTravelName = "LocationTrave 2", LocationTravelDetail = "LocationTrave 2 detail", LocationTravelPicture = "LocationTravelpicture2.jpg",LocationTravelPathGoogleMap ="LocationTravelPathGoogleMap2" },
                new LocationTravels { LocationTravelID = 3, LocationTravelName = "LocationTrave 3", LocationTravelDetail = "LocationTrave 3 detail", LocationTravelPicture = "LocationTravelpicture3.jpg" ,LocationTravelPathGoogleMap ="LocationTravelPathGoogleMap3"}
            };
            _dbContext.LocationTravels.AddRange(locationTravel);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void AllLocationTravel_ShouldReturnCorrect()
        {
            // Arrange
            var expectedAllLocationTravel = _dbContext.LocationTravels
                                            .Select(locationTravel => new
                                            {
                                                locationTravel.LocationTravelName,
                                                locationTravel.LocationTravelPicture
                                            });

            // Act
            var resultAllLocationTravel = _controller.AllLocationTravel() as OkObjectResult;
            var actualAllLocationTravel = resultAllLocationTravel.Value as IEnumerable<object>;
            var expectedAllLocationTravelList = expectedAllLocationTravel.ToList();
            var actualAllLocationTravelList = actualAllLocationTravel.Cast<object>().ToList();
            
            // Assert
            Assert.IsNotNull(expectedAllLocationTravel);
            Assert.IsNotNull(actualAllLocationTravel);
            Assert.AreEqual(expectedAllLocationTravelList.Count, actualAllLocationTravelList.Count);
            for (int i = 0; i < expectedAllLocationTravelList.Count; i++)
            {
                var expectedLocationTravel = expectedAllLocationTravelList[i];
                var actualLocationTravel = actualAllLocationTravelList[i];

                Assert.AreEqual(expectedLocationTravel.LocationTravelName, actualLocationTravel.GetType().GetProperty("LocationTravelName")?.GetValue(actualLocationTravel, null));
                Assert.AreEqual(expectedLocationTravel.LocationTravelPicture, actualLocationTravel.GetType().GetProperty("LocationTravelPicture")?.GetValue(actualLocationTravel, null));
            }
        }
        
        [TestMethod]
        public void FindLocationTravelByID_ShouldReturnCorrect()
        {
            // Arrange
            var id = 1;
            var expectedLocationTravelByID = from locationTravelData in _dbContext.LocationTravels
                                 where locationTravelData.LocationTravelID == id
                                 select new
                                 {

                                     locationTravelData.LocationTravelName,
                                     locationTravelData.LocationTravelDetail,
                                     locationTravelData.LocationTravelPicture,
                                     locationTravelData.LocationTravelPathGoogleMap,
                                     activities = (from activityData in _dbContext.Activities
                                                   where activityData.LocationTravelID == locationTravelData.LocationTravelID
                                                   select new
                                                   {
                                                       activityData.ActivityName,
                                                       activityData.ActivityDetail,
                                                       activityData.ActivityPicture
                                                   }).ToList()
                                 };

            // Act
            var result = _controller.FindLocationTravelByID(id) as OkObjectResult;
            var actualLocationTravelByID = result.Value as IEnumerable<object>;
            var expectedList = expectedLocationTravelByID.ToList();
            var actuaList = actualLocationTravelByID.Cast<object>().ToList();

            // Assert
            Assert.IsNotNull(expectedLocationTravelByID);
            Assert.IsNotNull(actualLocationTravelByID);

            Assert.AreEqual(expectedLocationTravelByID.First().LocationTravelName, 
                actualLocationTravelByID.First().GetType().GetProperty("LocationTravelName")?.GetValue(actualLocationTravelByID.First(), null));
            Assert.AreEqual(expectedLocationTravelByID.First().LocationTravelDetail,
                actualLocationTravelByID.First().GetType().GetProperty("LocationTravelDetail")?.GetValue(actualLocationTravelByID.First(), null));
            Assert.AreEqual(expectedLocationTravelByID.First().LocationTravelPicture,
                actualLocationTravelByID.First().GetType().GetProperty("LocationTravelPicture")?.GetValue(actualLocationTravelByID.First(), null));
            Assert.AreEqual(expectedLocationTravelByID.First().LocationTravelPathGoogleMap,
                actualLocationTravelByID.First().GetType().GetProperty("LocationTravelPathGoogleMap")?.GetValue(actualLocationTravelByID.First(), null));

            Assert.IsTrue(expectedLocationTravelByID.First().activities.Count > 0);

            Assert.AreEqual(expectedLocationTravelByID.First().activities.Count,
                    ((IEnumerable<object>)actualLocationTravelByID.First().GetType().GetProperty("activities")?.GetValue(actualLocationTravelByID.First(), null)).Count());
            for (int i = 0; i < expectedLocationTravelByID.First().activities.Count; i++)
            {
                var expectedActivity = expectedLocationTravelByID.First().activities[i];
                var actualActivity = ((IEnumerable<object>)actualLocationTravelByID.First().GetType().GetProperty("activities")?.GetValue(actualLocationTravelByID.First(), null)).ToList()[i];

                Assert.AreEqual(expectedActivity.ActivityName, actualActivity.GetType().GetProperty("ActivityName")?.GetValue(actualActivity, null));
                Assert.AreEqual(expectedActivity.ActivityDetail, actualActivity.GetType().GetProperty("ActivityDetail")?.GetValue(actualActivity, null));
                Assert.AreEqual(expectedActivity.ActivityPicture, actualActivity.GetType().GetProperty("ActivityPicture")?.GetValue(actualActivity, null));
            }


        }

        [TestMethod]
        public void CreateDataLocationTravel_ValidModel_Returns_Correct()
        {
            // Arrange
            var model = new LocationTravels
            {
                // มอโดลที่ใช้ในการทำงาน
                LocationTravelName = "LocationTrave 4",
                LocationTravelDetail = "LocationTrave 4 detail",
                LocationTravelPicture = "LocationTravelpicture4.jpg",
                LocationTravelPathGoogleMap = "LocationTravelPathGoogleMap4"

            };

            // Act
            var result = _controller.CreateDataLocationTravel(model) as OkObjectResult;


            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("สร้างเรียบร้อย", result.Value);
        }

        [TestMethod]
        public void UpdateDataLocationTravel_ValidModel_Returns_Correct()
        {
            // Arrange
            var id = 3;
            var model = new LocationTravels
            {
                // มอโดลที่ใช้ในการทำงาน
                LocationTravelName = "LocationTrave 4",
                LocationTravelDetail = "LocationTrave 4 detail",
                LocationTravelPicture = "LocationTravelpicture4.jpg",
                LocationTravelPathGoogleMap = "LocationTravelPathGoogleMap4"
            };
            var expectedUpdateDataLocationTravel = _dbContext.LocationTravels.Find(id);


            // Act
            var result = _controller.UpdateDataLocationTravel(id, model) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("แก้ไขเรียบร้อย", result.Value);
            Assert.IsTrue(expectedUpdateDataLocationTravel.LocationTravelName == "LocationTrave 4");
            Assert.IsTrue(expectedUpdateDataLocationTravel.LocationTravelDetail == "LocationTrave 4 detail");
            Assert.IsTrue(expectedUpdateDataLocationTravel.LocationTravelPicture == "LocationTravelpicture4.jpg");
            Assert.IsTrue(expectedUpdateDataLocationTravel.LocationTravelPathGoogleMap == "LocationTravelPathGoogleMap4");
        }
        
        [TestMethod]
        public void DeleteLocationTravel_ExistingId_Returns_Correct()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.DeleteLocationTravel(id) as OkObjectResult;

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
