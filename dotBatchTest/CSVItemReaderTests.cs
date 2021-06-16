using System;
using dotBatch;
using NUnit.Framework;

namespace dotBatchTest
{
    [TestFixture]
    public class CSVItemReaderTests
    {
        private string testData = @"C:\data\owid\covid\owid-covid-data.csv";

        [Test]
        public void CanOpenFile()
        {
            CSVItemReader reader = new CSVItemReader(){FilePath = testData};

            reader.Open();

            Assert.True(reader.HasNext());

            reader.Close();
        }

        [Test]
        public void CanGoToEndOfFile()
        {
            ItemReader reader = new CSVItemReader() {FilePath = testData};
            
            reader.Open();
            while (reader.HasNext())
            {
                var item = reader.ReadItem();
                
                Console.WriteLine(item.ToString());
            }
            
            Assert.False(reader.HasNext());
            
            reader.Close();
        }
    }
}