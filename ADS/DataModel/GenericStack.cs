using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.DataModel
{
    class GenericStack<T>
    {
        private int _size;
        private int _position;
        private T[] _array;

        public GenericStack(int size)
        {
            _size = size;
            _position = -1;
            _array = new T[size];
        }

        public bool Push(T value)
        {
            if (_size == _position + 1)
                return false;
            _array[++_position] = value;
            return true;
        }

        public T Pop()
        {
            T ret = default(T);
            if (_position != -1)
                ret = _array[_position--];
            return ret;
        }

        public override string ToString()
        {
            return String.Join(", ", _array.ToList().GetRange(0, _position));
        }
    }
}
