using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleScope.Common.Attributes;

namespace SingleScope.Example.Common
{
    [EnumTypeNames]
    public enum TestEnumType
    {
        [EnumName("TestingA")]
        A,
        B,
    }
}
