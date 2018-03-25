using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.DataModel
{
    class Stack
    {
        private int _size;
        private int _position;
        private int[] _array;

        public Stack(int size)
        {
            _size = size;
            _position = -1;
            _array = new int[size];
        }

        public bool Push(int value)
        {
            if (_size == _position + 1)
                return false;
            _array[++_position] = value;
            return true;
        }

        public int Pop()
        {
            int ret = -1;
            if (_position != -1)
                ret = _array[_position--];
            return ret;
        }

        public override string ToString()
        {
            return String.Join(", ",_array);
        }
    }
}
