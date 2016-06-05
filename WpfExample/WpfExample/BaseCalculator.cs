using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample
{
    class BaseCalculator
    {
        public virtual string add(double _first, double _second)
        {
            return (_first + _second).ToString();
        }
        public virtual string subtract(double _first, double _second)
        {
            return (_first - _second).ToString();
        }
    }
}
