using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.DataModel
{
    class Queue
    {
        private int _size;
        private int _start;
        private int _end;
        private int[] _array;

        public Queue(int size)
        {
            _start = 0;
            _end = 0;
            _size = size;
        }

        public bool Push(int value)
        {
            if ((_end + 1) % _size == _start)
                return false;
            _end = (_end + 1) % _size;
            _array[_end] = value;
            return true;
        }

        public int Pop()
        {
            int ret = -1;
            if (_end == _start)
                return ret;
            ret = _array[_start];
            _start = (_start + 1) % _size;
            return ret;
        }
    }
}
