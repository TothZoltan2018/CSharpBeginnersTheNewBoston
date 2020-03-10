using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//

namespace ZolisIO //Atneveztuk a prject veverol az osztalynevre
{
    //Part186, 187, 188, 189, 190 - Project 6 Reading and Writing Class
    //A BitReader/Writer osztaly Little Endian modon (forditva) kezeli a szamokat.
    //Ezert irjunk egy oszalyt, aminek megadhatjuk, hogy Little v. Big Endian kezelje.

    public abstract class BaseIO //Atneveztuk az eredeti osztalynevrol
    {
        /// <summary>
        /// The order of the bytes both read and written.
        /// </summary>
        public enum ByteOrder
        {
            BigEndian, LittleEndian
        }

        protected ByteOrder byteOrder;
    }

    public class Reader : BaseIO
    {
        /// <summary>
        /// Create a reader to read a file.
        /// </summary>
        /// <param name="path">The path to the file to read.</param>
        public Reader(string path)
        {
            br = new BinaryReader(File.OpenRead(path));
            this.byteOrder = ByteOrder.BigEndian;
        }

        /// <summary>
        /// Create a reader to read a file.
        /// </summary>
        /// <param name="path">The path to the file to read.</param>
        /// <param name="byteOrder">The order of the bytes to read.</param>
        public Reader(string path, ByteOrder byteOrder)
        {
            br = new BinaryReader(File.OpenRead(path));
            this.byteOrder = byteOrder;
        }

        BinaryReader br;
        /// <summary>
        /// The position to read at.
        /// </summary>
        public long Position
        {
            get { return br.BaseStream.Position; }
            set { br.BaseStream.Position = value; }
        }

        //Todo: A ReadByte-ok nal miert nem kell megforditani a byte-ok sorrendjet?
        /// <summary>
        /// After reading index is incremented.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return br.ReadByte();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sbyte ReadSByte()
        {
            return (sbyte)br.ReadByte();
        }

        public short ReadInt16()
        {
            short myShort = br.ReadInt16();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myShort);
                Array.Reverse(buff);
                myShort = BitConverter.ToInt16(buff, 0);//Now it is Big Endian
            }
            return myShort;
        }

        public ushort ReadUInt16()
        {
            ushort myUShort = br.ReadUInt16();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myUShort);
                Array.Reverse(buff);
                myUShort = BitConverter.ToUInt16(buff, 0);//Now it is Big Endian
            }
            return myUShort;
        }

        public int ReadInt32()
        {
            int myInt = br.ReadInt32();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myInt);
                Array.Reverse(buff);
                myInt = BitConverter.ToInt32(buff, 0);//Now it is Big Endian
            }
            return myInt;
        }

        public uint ReadUInt32()
        {
            uint myUInt = br.ReadUInt32();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myUInt);
                Array.Reverse(buff);
                myUInt = BitConverter.ToUInt32(buff, 0);//Now it is Big Endian
            }
            return myUInt;
        }

        public long ReadInt64()
        {
            long myLong = br.ReadInt64();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myLong);
                Array.Reverse(buff);
                myLong = BitConverter.ToInt64(buff, 0);//Now it is Big Endian
            }
            return myLong;
        }

        public ulong ReadUInt64()
        {
            ulong myULong = br.ReadUInt64();//Default is Little Endian
            if (byteOrder == ByteOrder.BigEndian)
            {
                byte[] buff = BitConverter.GetBytes(myULong);
                Array.Reverse(buff);
                myULong = BitConverter.ToUInt64(buff, 0);//Now it is Big Endian
            }
            return myULong;
        }
                
        public byte[] ReadBytes(int amount)
        {
            byte[] buffer = br.ReadBytes(amount);
            if (byteOrder == ByteOrder.LittleEndian)
            {//A ReadBytes metodus a logikus (Big Endian) modon olvas.
                buffer.Reverse(); //= Array.Reverse(buffer);
            }
            return buffer;            
        }

        public void Close(string path)
        {
            br.Close();
        }

        public void ChangeByteOrder(ByteOrder bo)
        {
            this.byteOrder = bo;
        }

        //Todo: Melyik a jobb?
        public string ReadString(int length)
        {
            //return br.ReadChars(length).ToString();
            return new string(br.ReadChars(length));
        }

        public string ReadUnicodeString(int length)
        {
            if (byteOrder == ByteOrder.BigEndian)
                return Encoding.BigEndianUnicode.GetString(br.ReadBytes(length));
            else
                return Encoding.Unicode.GetString(br.ReadBytes(length));

        }
    }
}
