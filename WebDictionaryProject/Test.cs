using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionaryProject
{
    public class Test
    {
        public static int InstanceCount = 0;
        Deneme _d;
        public Test(Deneme d)
        {
            _d = d;
            InstanceCount++;
        }
    }
}
