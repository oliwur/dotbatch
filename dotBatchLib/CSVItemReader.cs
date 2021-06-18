using System.IO;

namespace dotBatchLib
{
    public class CSVItemReader : AbstractItemReader
    {
        private StreamReader _streamReader;
        public string FilePath { get; set; }

        public override void Open()
        {
            base.Open();
            _streamReader = new StreamReader(FilePath);
        }

        public override void Close()
        {
            base.Close();
            _streamReader.Close();
        }

        public override object ReadItem()
        {
            return _streamReader.ReadLine();
        }

        public override bool HasNext()
        {
            return !_streamReader.EndOfStream;
        }
    }
}