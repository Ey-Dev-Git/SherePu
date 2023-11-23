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
    public class HostelControllerTest
    {
        private ApplicationDBContext _dbContext;
        private HostelController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDBContext(options);
            _controller = new HostelController(_dbContext);

            // Add test data
            var hostel = new List<Hostels>
            {
                new Hostels {
                HostelID = 1,
                HostelName = "Hostel 1",
                HostelPicture = "image1.jpg",
                HostelFacilities = "Facilities 1",
                HostelLinkToBook = "booklink1",
                HostelNameDetail = "Hostel 1 details",
                HostelNumberOfBathrooms = "1",
                HostelNumberOfBedrooms = "1",
                HostelNumberOfGuests = "1",
                HostelRoomPicture = "roomimage1.jpg",
                HostelZone = "Zone 1"
                },                
                new Hostels {
                HostelID = 2,
                HostelName = "Hostel 2",
                HostelPicture = "image2.jpg",
                HostelFacilities = "Facilities 2",
                HostelLinkToBook = "booklink2",
                HostelNameDetail = "Hostel 2 details",
                HostelNumberOfBathrooms = "2",
                HostelNumberOfBedrooms = "2",
                HostelNumberOfGuests = "2",
                HostelRoomPicture = "roomimage2.jpg",
                HostelZone = "Zone 2"
                },new Hostels {
                HostelID = 3,
                HostelName = "Hostel 3",
                HostelPicture = "image3.jpg",
                HostelFacilities = "Facilities 3",
                HostelLinkToBook = "booklink3",
                HostelNameDetail = "Hostel 3 details",
                HostelNumberOfBathrooms = "3",
                HostelNumberOfBedrooms = "3",
                HostelNumberOfGuests = "3",
                HostelRoomPicture = "roomimage3.jpg",
                HostelZone = "Zone 3"
                }
             };
            _dbContext.Hostels.AddRange(hostel);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void AllHostel_ShouldReturnCorrect()
        {
            // Arrange
            var expectedAllHostel = (from hostel in _dbContext.Hostels
                                                  select new
                                                  {
                                                      hostel.HostelName,
                                                      hostel.HostelPicture
                                                  });

            // Act
            var resultAllHostel = _controller.AllHostel() as OkObjectResult;
            var actualAllHostel = resultAllHostel.Value as IEnumerable<object>;
            var expectedAllHostelList = expectedAllHostel.ToList();
            var actualAllHostelList = actualAllHostel.Cast<object>().ToList();

            // Assert
            Assert.IsNotNull(expectedAllHostel);
            Assert.IsNotNull(actualAllHostel);
            Assert.AreEqual(expectedAllHostelList.Count, actualAllHostelList.Count);
            for (int i = 0; i < expectedAllHostelList.Count; i++)
            {
                var expectedHostel = expectedAllHostelList[i];
                var actualHostel = actualAllHostelList[i];

                Assert.AreEqual(expectedHostel.HostelName, actualHostel.GetType().GetProperty("HostelName")?.GetValue(actualHostel, null));
                Assert.AreEqual(expectedHostel.HostelPicture, actualHostel.GetType().GetProperty("HostelPicture")?.GetValue(actualHostel, null));
            }

        }

        [TestMethod]
        public void FindHostelByID_WithValidID_Returns_Correct()
        {
            // Arrange
            var id = 3;
            var expected = _dbContext.Hostels.Find(id);

            // Act
            var result = _controller.FindHostelByID(id) as OkObjectResult;
            var actual = result.Value as Hostels;

            // Assert
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.HostelID, actual.HostelID);
            Assert.AreEqual(expected.HostelName, actual.HostelName);
            Assert.AreEqual(expected.HostelPicture, actual.HostelPicture);
            Assert.AreEqual(expected.HostelFacilities, actual.HostelFacilities);
            Assert.AreEqual(expected.HostelLinkToBook, actual.HostelLinkToBook);
            Assert.AreEqual(expected.HostelNameDetail, actual.HostelNameDetail);
            Assert.AreEqual(expected.HostelNumberOfBathrooms, actual.HostelNumberOfBathrooms);
            Assert.AreEqual(expected.HostelNumberOfBedrooms, actual.HostelNumberOfBedrooms);
            Assert.AreEqual(expected.HostelNumberOfGuests, actual.HostelNumberOfGuests);
            Assert.AreEqual(expected.HostelRoomPicture, actual.HostelRoomPicture);
            Assert.AreEqual(expected.HostelZone, actual.HostelZone);
        }

        [TestMethod]
        public void CreateDataHostel_ValidModel_Returns_Correct()
        {
            // Arrange
            var model = new Hostels
            {
                // มอโดลที่ใช้ในการทำงาน
                HostelName = "Hostel 4",
                HostelPicture = "image4.jpg",
                HostelFacilities = "Facilities 4",
                HostelLinkToBook = "booklink4",
                HostelNameDetail = "Hostel 4 details",
                HostelNumberOfBathrooms = "4",
                HostelNumberOfBedrooms = "4",
                HostelNumberOfGuests = "4",
                HostelRoomPicture = "roomimage4.jpg",
                HostelZone = "Zone 4"
            };

            // Act
            var result = _controller.CreateDataHostel(model) as OkObjectResult;


            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("สร้างเรียบร้อย", result.Value);
        }

        [TestMethod]
        public void UpdateDataHostel_ValidModel_Returns_Correct()
        {
            // Arrange
            var id = 3;
            var model = new Hostels
            {
                // มอโดลที่ใช้ในการทำงาน
                HostelName = "Hostel 4",
                HostelPicture = "image4.jpg",
                HostelFacilities = "Facilities 4",
                HostelLinkToBook = "booklink5",
                HostelNameDetail = "Hostel 4 details",
                HostelNumberOfBathrooms = "4",
                HostelNumberOfBedrooms = "4",
                HostelNumberOfGuests = "4",
                HostelRoomPicture = "roomimage4.jpg",
                HostelZone = "Zone 4"
            };
            var expectedUpdateDataHostel = _dbContext.Hostels.Find(id);


            // Act
            var result = _controller.UpdateDataHostel(id, model) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("แก้ไขเรียบร้อย", result.Value);
            Assert.IsTrue(expectedUpdateDataHostel.HostelName == "Hostel 4");
            Assert.IsTrue(expectedUpdateDataHostel.HostelPicture == "image4.jpg");
            Assert.IsTrue(expectedUpdateDataHostel.HostelFacilities == "Facilities 4");
            Assert.IsTrue(expectedUpdateDataHostel.HostelLinkToBook == "booklink5");
            Assert.IsTrue(expectedUpdateDataHostel.HostelNameDetail == "Hostel 4 details");
            Assert.IsTrue(expectedUpdateDataHostel.HostelNumberOfBathrooms == "4");
            Assert.IsTrue(expectedUpdateDataHostel.HostelNumberOfBedrooms == "4");
            Assert.IsTrue(expectedUpdateDataHostel.HostelNumberOfGuests == "4");
            Assert.IsTrue(expectedUpdateDataHostel.HostelRoomPicture == "roomimage4.jpg");
            Assert.IsTrue(expectedUpdateDataHostel.HostelZone == "Zone 4");
        }

        [TestMethod]
        public void DeleteHostel_ExistingId_Returns_Correct()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.DeleteHostel(id) as OkObjectResult;

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
