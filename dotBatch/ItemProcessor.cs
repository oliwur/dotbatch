using System;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public interface ItemProcessor
    {
        public Object Process(Object o);
    }

    public class FuncItemProcessor<T,Tret> : ItemProcessor
    {
        private Func<T,Tret> _func;
        
        public FuncItemProcessor(Func<T,Tret> func)
        {
            _func = func;
        }
        
        public Object Process(object o)
        {
            return _func.Invoke((T) o);
        }
    }
}