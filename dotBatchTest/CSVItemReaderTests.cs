using System;
using dotBatchLib;
using NUnit.Framework;

namespace dotBatchTest
{
    [TestFixture]
    public class CSVItemReaderTests
    {
        private readonly string _testData = @"C:\data\owid\covid\owid-covid-data.csv";

        [Test]
        public void CanOpenFile()
        {
            CSVItemReader reader = new CSVItemReader(){FilePath = _testData};

            reader.Open();

            Assert.True(reader.HasNext());

            reader.Close();
        }

        [Test]
        public void CanGoToEndOfFile()
        {
            ITemReader reader = new CSVItemReader() {FilePath = _testData};
            
            reader.Open();
            int i = 0; // only 10 lines for this test
            while (reader.HasNext() && i < 10)
            {
                var item = reader.ReadItem();
                
                Console.WriteLine(item.ToString());
                
                i++;
            }
            
            Assert.False(reader.HasNext());
            
            reader.Close();
        }
    }
}