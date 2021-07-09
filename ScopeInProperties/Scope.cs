using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScopeInProperties
{
    [TypeConverter(typeof(ScopeConverter))]
    public class Scope
    {
        private Int32 _min = 0;
        private Int32 _max = 0;

        public Scope()
        {
        }

        public Scope(Int32 min, Int32 max)
        {
            _min = min;
            _max = max;
        }

        [Browsable(true)]
        public Int32 Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }

        [Browsable(true)]
        public Int32 Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }

        }
    }
}
