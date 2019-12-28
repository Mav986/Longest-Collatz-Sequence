using System;
using System.Collections.Generic;
using System.Text;

namespace CollatzSequence
{
    public class CollatzChain
    {
        private long _currentNum = 0;

        public CollatzChain(long startingNum)
        {
            _currentNum = startingNum;
            NumToCalculate = startingNum;
        }

        public long NumToCalculate { get; private set; }
        public int Length { get; set; }
        public long CurrentNumber 
        {
            get
            {
                return _currentNum;
            }

            set
            {
                _currentNum = value;
                Length++;
            }
        }
    }
}
