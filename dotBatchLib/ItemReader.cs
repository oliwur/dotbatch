using System;

namespace dotBatchLib
{
    /// <summary>
    /// ItemReader defines the batch artifact that reads items for chunk processing
    /// </summary>
    public interface ITemReader
    {
        // private readonly ILogger _logger = AppLogging.CreateLogger<ItemReader>();

        /// <summary>
        /// The Open method prepares the reader to read items
        /// </summary>
        public void Open();

        /// <summary>
        /// The Close method marks the end of use of the ItemReader
        /// </summary>
        public void Close();

        /// <summary>
        /// The ReadItem method returns the next item for chunk processing
        /// </summary>
        public Object ReadItem();

        /// <summary>
        /// Checks if there are more items to come
        /// </summary>
        /// <returns>true if there are more</returns>
        public bool HasNext();
    }
}