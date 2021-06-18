using System;

namespace dotBatchLib
{
    public interface ITemProcessor
    {
        public object Process(object o);
    }

    public class FuncItemProcessor<T,TRet> : ITemProcessor
    {
        private readonly Func<T,TRet> _func;
        
        public FuncItemProcessor(Func<T,TRet> func)
        {
            _func = func;
        }
        
        public Object Process(object o)
        {
            return _func.Invoke((T) o);
        }
    }
}