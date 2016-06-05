using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample
{
    class ChildCalculator: BaseCalculator
    {
        public override string add(double _first, double _second)
        {
            return base.add(_first, _second)+"- Polymorphic Input for add ";
        }
        public override string subtract(double _first, double _second)
        {
            return base.subtract(_first, _second) + "- Polymorphic Input for subtract ";
        }
    }
}
