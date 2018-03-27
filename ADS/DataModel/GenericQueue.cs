using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.DataModel
{
    class GenericQueue<T>
    {
        private int _size;
        private int _start;
        private int _end;
        private T[] _array;

        public GenericQueue(int size)
        {
            _start = 0;
            _end = 0;
            _size = size;
            _array = new T[size];
        }

        public bool Push(T value)
        {
            if ((_end + 1) % _size == _start)
                return false;
            _array[_end] = value;
            _end = (_end + 1) % _size;
            return true;
        }

        public T Pop()
        {
            T ret = default(T);
            if (_end == _start)
                return ret;
            ret = _array[_start];
            _start = (_start + 1) % _size;
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = _start < _end ? _end - _start : _size + _end - _start;

            for (int i = 0; i < count; i++)
            {
                sb.Append(_array[(i + _start) % _size]);
                sb.Append(", ");
            }
            if (sb.Length > 2)
                sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
