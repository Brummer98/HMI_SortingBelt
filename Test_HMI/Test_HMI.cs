using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data___Layer;

namespace Data___Layer.Tests
{
    [TestClass()]
    public class Test_HMI
    {
        private string constr = @"Data Source=.\sqlexpress;Initial Catalog=TagTableFactory;Integrated Security=True;";

        [TestMethod()]
        public void getSingleTagTest()
        {
            // Arrange
            List<TagDTOData> singleTagList = new List<TagDTOData>();
            Data___Layer.TagCollectionData testDataCollection = new Data___Layer.TagCollectionData();

            // Act
            singleTagList = testDataCollection.getSingleTag(4);

            // Assert
            Assert.IsTrue(singleTagList.Count == 1); 
        }

        [TestMethod()]
        public void GetAllTagsTest()
        {
            // Arrange
            List<TagDTOData> singleTagList = new List<TagDTOData>();
            Data___Layer.TagCollectionData testDataCollection = new Data___Layer.TagCollectionData();

            // Act
            singleTagList = testDataCollection.GetAllTags();

            // Assert
            Assert.IsTrue(singleTagList.Count > 0);
        }

        [TestMethod()]
        public void GetAllTagsHMISignalsTest()
        {
            // Arrange
            List<TagDTOData> singleTagList = new List<TagDTOData>();
            Data___Layer.TagCollectionData testDataCollection = new Data___Layer.TagCollectionData();

            // Act
            singleTagList = testDataCollection.GetAllTagsHMISignals();

            // Assert
            Assert.IsTrue(singleTagList.Count > 0);
        }
    }
}