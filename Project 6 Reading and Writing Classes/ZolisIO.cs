using System;
using System.IO;//
using System.Linq;
using System.Text;

namespace ZolisIO //Atneveztuk a prject veverol az osztalynevre
{
    //Part186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196 - Project 6 Reading and Writing Class - Ready
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

        public void ChangeByteOrder(ByteOrder bo)
        {
            this.byteOrder = bo;
        }
    }

    public class Reader : BaseIO
    {
        BinaryReader br;
        /// <summary>
        /// The position to read at.
        /// </summary>
        public long Position
        {
            get { return br.BaseStream.Position; }
            set { br.BaseStream.Position = value; }
        }

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

        public char ReadChar()
        {
            return br.ReadChar();
        }

        public char[] ReadChars(int length)
        {            
            return br.ReadChars(length);
        }
       
    }

    public class Writer : BaseIO
    {
        BinaryWriter bw;

        public Writer(string path)
        {
            bw = new BinaryWriter(File.OpenWrite(path));
            byteOrder = ByteOrder.BigEndian;            
        }

        public Writer(string path, ByteOrder bo)
        {
            bw = new BinaryWriter(File.OpenWrite(path));
            byteOrder = bo;
        }

        public long Position
        {
            get { return bw.BaseStream.Position; }
            set { bw.BaseStream.Position = value; }
        }

        public void WriteByte(byte toWrite)
        {
            bw.Write(toWrite);
        }

        public void WriteBytes(byte[] bytesToWrite)
        {
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(bytesToWrite);
            bw.Write(bytesToWrite);        
        }

        public void WriteInt16(short toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteUInt16(ushort toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteInt32(int toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteUInt32(uint toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteInt64(long toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteUInt64(ulong toWrite)
        {
            byte[] buffer = BitConverter.GetBytes(toWrite);
            if (byteOrder == ByteOrder.BigEndian)
                Array.Reverse(buffer);
            bw.Write(buffer);
        }

        public void WriteString(string toWrite)
        {
            //Ha  astringet kozvetlenul kiirnank, akkor az elso byte-ban a string hossza lenne!
            //Helyette: char[]
            bw.Write(toWrite.ToCharArray()); //a hossz nem lesz benne az elejen, csak a string ASCII karakterei
        }

        public void WriteUnicodeString(string toWrite)
        {
            byte[] buffer = (byteOrder == ByteOrder.BigEndian) ? Encoding.BigEndianUnicode.GetBytes(toWrite)
                                                                : Encoding.Unicode.GetBytes(toWrite) ;
            bw.Write(buffer);
        }

        public void WriteCharacter(char toWrite)
        {
            bw.Write(toWrite);
        }

        public void WriteCharacters(char[] toWrite)
        {
            bw.Write(toWrite); //A char[]-t mindig az ertelemszeru iranyban tarolja. (nincs Little/Big endian kerdes)
        }

        public void Close()
        {
            bw.Close();
        }

    }
}
