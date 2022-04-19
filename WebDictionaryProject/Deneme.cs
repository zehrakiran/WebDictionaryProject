using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionaryProject
{
    public class Deneme
    {
        public static int InstanceCount = 0;
        public Deneme()
        {
            InstanceCount++;
        }
        public string Name { get { return InstanceCount + "deneme"; } }
    }
}
