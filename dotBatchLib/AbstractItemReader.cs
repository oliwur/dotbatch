using System;

namespace dotBatch
{
    public abstract class AbstractItemReader : ItemReader
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