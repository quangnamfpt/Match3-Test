using System.Collections.Generic;

namespace Utilities
{
    public class PoolItemHandle<T> where T : Item, new()
    {
        private readonly Stack<T> _pool = new Stack<T>();

        public PoolItemHandle(int prewarmCount = 0)
        {
            Prewarm(prewarmCount);
        }

        private void Prewarm(int count)
        {
            if(count <= 0) return;
            for (int i = 0; i < count; i++)
            {
                var item = new T();
                item.Reset();
                _pool.Push(item);
            }
        }
        public T Get()
        {
            return _pool.Count > 0 ? _pool.Pop() : new T();
        }

        public void Release(T item)
        {
            item.Reset();
            _pool.Push(item);
        }
    }
}
