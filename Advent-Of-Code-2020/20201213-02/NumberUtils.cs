using System;
using System.Collections.Generic;
using System.Text;

namespace _20201213_02
{
    class NumberUtils
    {
        public static long mulInv(long a, long b)
        {
            if (b == 1) return 1;

            long b0 = b, x0 = 0, x1 = 1;

            while (a > 1)
            {
                long q = a / b;
                b = a % (a = b);
                x0 = x1 - q * (x1 = x0);
            }

            return x1 < 0 ? x1 + b0 : x1;
        }
    }
}
