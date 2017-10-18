using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoCanLogger
{
    public class Helpers
    {
        public static byte GetDataByte( ulong data, int idx )
        {
            return (byte)((data >> ((7-idx)*8)) & 0xFF);
        }

        public static ulong SetDataByte(ulong data, int idx, byte b)
        {
            return (data & ~( (ulong)0xFF << ((7 - idx) * 8))) | ((ulong)b << ((7 - idx) * 8));
        }

        public static string DataMaskAsString(ulong mask)
        {
            return string.Format("{0,16:X16}", mask);
        }

        public static string DataAsString(ulong data)
        {
            byte[] Data = new byte[8];
            for (int i = 0; i < 8; i++)
                Data[i] = GetDataByte(data, i);

            string s = string.Format("{0,2:X2}.{1,2:X2}:{2,2:X2}.{3,2:X2}:{4,2:X2}.{5,2:X2}:{6,2:X2}.{7,2:X2}",
                Data[0], Data[1], Data[2], Data[3], Data[4], Data[5], Data[6], Data[7]
                );

            return s;
        }

        public static string DataAsBinaryString(ulong data)
        {
            string[] Text = new string[8];
            for (int i = 0; i < 8; i++)
            {
                var v = GetDataByte(data, i);
                Text[i] = Convert.ToString(v, 2).PadLeft(8, '0');
            }

            string s = string.Format("{0}.{1}.{2}.{3}:{4}.{5}.{6}.{7}",
                Text[0], Text[1], Text[2], Text[3], Text[4], Text[5], Text[6], Text[7]
                );

            return s;
        }

        public static string DataAsBinaryDiffString(ulong data)
        {
            string[] Text = new string[8];
            for (int i = 0; i < 8; i++)
            {
                var v = GetDataByte(data, i);
                Text[i] = Convert.ToString(v, 2).PadLeft(8, '0').Replace('0', '.');
            }

            string s = string.Format("{0} {1} {2} {3}:{4} {5} {6} {7}",
                Text[0], Text[1], Text[2], Text[3], Text[4], Text[5], Text[6], Text[7]
                );

            return s;
        }

    }
}
