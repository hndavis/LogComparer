using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RTStringExtentions
{
    public static class ExtensionMethods
    {
        public static bool Similiar(this string value, string cmpValue)
        {
            double similarThreshold = .7;
            int matchCount = 0;
            for (int i= 0; i < value.Length;i++)
            {
                if (i >= cmpValue.Length)
                    break;
                if (value[i] == cmpValue[i])
                {
                    matchCount ++;
                }
            }

            return ((double) matchCount/(double) value.Length) > similarThreshold;


        }
    }
}
