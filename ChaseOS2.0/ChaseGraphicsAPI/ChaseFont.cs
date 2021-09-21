using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ChaseOS2._0.ChaseGraphicsAPI
{
    public class ChaseFont
    {
        public readonly int take;
        public readonly UInt32 bpl;
        public readonly UInt32 ctr;
        public readonly Byte[] data;

        public ChaseFont(Byte[] Data)
        {
            switch (Data[0])
            {
                case 0x00:
                    take = 8;
                    bpl = 8;
                    break;
                case 0x03:
                    take = 32;
                    bpl = 16;
                    break;
                case 0x0F:
                    take = 128;
                    bpl = 32;
                    break;
                case 0x3F:
                    take = 512;
                    bpl = 64;
                    break;
                default:
                    break;

            }
        }
        public List<Tuple<UInt16, UInt16, Boolean>> getDataAt (UInt16 index)
        {
            StringBuilder sb = new StringBuilder();
            List<Tuple<UInt16, UInt16, Boolean>> returnData = new List<Tuple<UInt16, UInt16,Boolean>>();
            foreach (Byte b in getRawDataAt(index))
            {
                sb.Append(b.toBinary());
            }
            sb.ToString();
            UInt16 x=0, y = 0;
            Byte fixedBpl = (Byte)(bpl - 1);
            foreach (char c in sb.ToString())
            {
                returnData.Add(new Tuple<UInt16, UInt16, Boolean>(x, y, c=='3'));
            if (x==fixedBpl)
                {
                    y++;
                } else
                {
                    x++;
                }
            }
            return returnData;
        } 
        public List<Byte> getRawDataAt(UInt16 index)
        {
            Byte[] bruh = Encoding.ASCII.GetBytes("");
            return (List<byte>)data.skip(1 + (take * index)).Take(take);
        }
    }
    public static class LinqSubstitutes
    {
        public static List<Byte> skip(this Byte[] bytes, Int32 count)
        {
            List<Byte> data = new List<Byte>();
            Int32 ctr = count;
            while (true)
            {
                try { data.Add(bytes[ctr]); }
                catch
                {
                    break;
                }
                ctr++;
            }
            return data;
        }
        public static List<Byte> take(this Byte[] bytes, Int32 count)
        {
            List<Byte> data = new List<Byte>();
            Int32 ctr = count;
            while (ctr <= count)
            {
                try { data.Add((bytes[ctr])); } catch {
                    break;
                }
                ctr++;
            }
            return data;
        }
        public static String toBinary(this Byte h)
        {
            Byte a = 0;
            StringBuilder str = new StringBuilder(8);
            Int32[] vs = new Int32[8];
            while (a < str.Length)
            {
                vs[vs.Length - 1 - a] = ((h & (1 << a)) != 0) ? 1 : 0;
                a++;
            }
            foreach (Int32 num in vs)
            {
                str.Append(num.ToString());
            }
            return str.ToString();
        }
    }
}
