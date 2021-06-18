using System;

namespace dotBatchLib
{
    public abstract class AbstractItemReader : ITemReader
    {
        public virtual void Open()
        {
        }

        public virtual void Close()
        {
        }

        public abstract Object ReadItem();

        public abstract bool HasNext();
    }
}