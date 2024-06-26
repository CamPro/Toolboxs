﻿using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Text;

namespace BackupChromeProfiles
{
    public class SQLiteHandler
    {
        private byte[] db_bytes;
        private ulong encoding;
        private string[] field_names;
        private SQLiteHandler.sqlite_master_entry[] master_table_entries;
        private ushort page_size;
        private byte[] SQLDataTypeSize = new byte[10]
        {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 6,
      (byte) 8,
      (byte) 8,
      (byte) 0,
      (byte) 0
        };
        private SQLiteHandler.table_entry[] table_entries;

        public SQLiteHandler(string baseName)
        {
            if (!File.Exists(baseName))
                return;
            FileSystem.FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared);
            string s = Strings.Space((int)FileSystem.LOF(1));
            FileSystem.FileGet(1, ref s);
            FileSystem.FileClose(1);
            this.db_bytes = Encoding.Default.GetBytes(s);
            if (Encoding.Default.GetString(this.db_bytes, 0, 15).CompareTo("SQLite format 3") != 0)
                throw new Exception("Not a valid SQLite 3 Database File");
            if (this.db_bytes[52] > (byte)0)
                throw new Exception("Auto-vacuum capable database is not supported");
            this.page_size = (ushort)this.ConvertToInteger(16, 2);
            this.encoding = this.ConvertToInteger(56, 4);
            if (Decimal.Compare(new Decimal(this.encoding), 0M) == 0)
                this.encoding = 1UL;
            this.ReadMasterTable(100UL);
        }

        private ulong ConvertToInteger(int startIndex, int Size)
        {
            if (Size > 8 | Size == 0)
                return 0;
            ulong integer = 0;
            int num = Size - 1;
            for (int index = 0; index <= num; ++index)
                integer = integer << 8 | (ulong)this.db_bytes[startIndex + index];
            return integer;
        }

        private long CVL(int startIndex, int endIndex)
        {
            ++endIndex;
            byte[] numArray = new byte[8];
            int num1 = endIndex - startIndex;
            bool flag = false;
            if (num1 == 0 | num1 > 9)
                return 0;
            switch (num1)
            {
                case 1:
                    numArray[0] = (byte)((uint)this.db_bytes[startIndex] & (uint)sbyte.MaxValue);
                    return BitConverter.ToInt64(numArray, 0);
                case 9:
                    flag = true;
                    break;
            }
            int num2 = 1;
            int num3 = 7;
            int index1 = 0;
            if (flag)
            {
                numArray[0] = this.db_bytes[endIndex - 1];
                --endIndex;
                index1 = 1;
            }
            int num4 = startIndex;
            for (int index2 = endIndex - 1; index2 >= num4; index2 += -1)
            {
                if (index2 - 1 >= startIndex)
                {
                    numArray[index1] = (byte)((uint)(byte)((uint)this.db_bytes[index2] >> (num2 - 1 & 7)) & (uint)((int)byte.MaxValue >> num2) | (uint)(byte)((uint)this.db_bytes[index2 - 1] << (num3 & 7)));
                    ++num2;
                    ++index1;
                    --num3;
                }
                else if (!flag)
                    numArray[index1] = (byte)((uint)(byte)((uint)this.db_bytes[index2] >> (num2 - 1 & 7)) & (uint)((int)byte.MaxValue >> num2));
            }
            return BitConverter.ToInt64(numArray, 0);
        }

        public int GetRowCount() => this.table_entries.Length;

        public string[] GetTableNames()
        {
            string[] arySrc = (string[])null;
            int index1 = 0;
            int num = this.master_table_entries.Length - 1;
            for (int index2 = 0; index2 <= num; ++index2)
            {
                if (this.master_table_entries[index2].item_type == "table")
                {
                    arySrc = (string[])Utils.CopyArray((Array)arySrc, (Array)new string[index1 + 1]);
                    arySrc[index1] = this.master_table_entries[index2].item_name;
                    ++index1;
                }
            }
            return arySrc;
        }

        public string GetValue(int row_num, int field) => row_num >= this.table_entries.Length || field >= this.table_entries[row_num].content.Length ? (string)null : this.table_entries[row_num].content[field];

        public string GetValue(int row_num, string field)
        {
            int field1 = -1;
            int num = this.field_names.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (this.field_names[index].ToLower().CompareTo(field.ToLower()) == 0)
                {
                    field1 = index;
                    break;
                }
            }
            return field1 == -1 ? (string)null : this.GetValue(row_num, field1);
        }

        private int GVL(int startIndex)
        {
            if (startIndex > this.db_bytes.Length)
                return 0;
            int num = startIndex + 8;
            for (int index = startIndex; index <= num; ++index)
            {
                if (index > this.db_bytes.Length - 1)
                    return 0;
                if (((int)this.db_bytes[index] & 128) != 128)
                    return index;
            }
            return startIndex + 8;
        }

        private bool IsOdd(long value) => (value & 1L) == 1L;

        private void ReadMasterTable(ulong Offset)
        {
            if (this.db_bytes[(int)Offset] == (byte)13)
            {
                ushort uint16 = Convert.ToUInt16(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 3M)), 2)), 1M));
                int num1 = 0;
                if (this.master_table_entries != null)
                {
                    num1 = this.master_table_entries.Length;
                    this.master_table_entries = (SQLiteHandler.sqlite_master_entry[])Utils.CopyArray((Array)this.master_table_entries, (Array)new SQLiteHandler.sqlite_master_entry[this.master_table_entries.Length + (int)uint16 + 1]);
                }
                else
                    this.master_table_entries = new SQLiteHandler.sqlite_master_entry[(int)uint16 + 1];
                int num2 = (int)uint16;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    ulong integer = this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(Offset), 8M), new Decimal(index1 * 2))), 2);
                    if (Decimal.Compare(new Decimal(Offset), 100M) != 0)
                        integer += Offset;
                    int endIndex1 = this.GVL((int)integer);
                    this.CVL((int)integer, endIndex1);
                    int endIndex2 = this.GVL(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex1), new Decimal(integer))), 1M)));
                    this.master_table_entries[num1 + index1].row_id = this.CVL(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex1), new Decimal(integer))), 1M)), endIndex2);
                    ulong uint64 = Convert.ToUInt64(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex2), new Decimal(integer))), 1M));
                    int endIndex3 = this.GVL((int)uint64);
                    int endIndex4 = endIndex3;
                    long num3 = this.CVL((int)uint64, endIndex3);
                    long[] numArray = new long[5];
                    int index2 = 0;
                    do
                    {
                        int startIndex = endIndex4 + 1;
                        endIndex4 = this.GVL(startIndex);
                        numArray[index2] = this.CVL(startIndex, endIndex4);
                        numArray[index2] = numArray[index2] <= 9L ? (long)this.SQLDataTypeSize[(int)numArray[index2]] : (!this.IsOdd(numArray[index2]) ? (long)Math.Round((double)(numArray[index2] - 12L) / 2.0) : (long)Math.Round((double)(numArray[index2] - 13L) / 2.0));
                        ++index2;
                    }
                    while (index2 <= 4);
                    if (Decimal.Compare(new Decimal(this.encoding), 1M) == 0)
                        this.master_table_entries[num1 + index1].item_type = Encoding.Default.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(new Decimal(uint64), new Decimal(num3))), (int)numArray[0]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 2M) == 0)
                        this.master_table_entries[num1 + index1].item_type = Encoding.Unicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(new Decimal(uint64), new Decimal(num3))), (int)numArray[0]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 3M) == 0)
                        this.master_table_entries[num1 + index1].item_type = Encoding.BigEndianUnicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(new Decimal(uint64), new Decimal(num3))), (int)numArray[0]);
                    if (Decimal.Compare(new Decimal(this.encoding), 1M) == 0)
                        this.master_table_entries[num1 + index1].item_name = Encoding.Default.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0]))), (int)numArray[1]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 2M) == 0)
                        this.master_table_entries[num1 + index1].item_name = Encoding.Unicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0]))), (int)numArray[1]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 3M) == 0)
                        this.master_table_entries[num1 + index1].item_name = Encoding.BigEndianUnicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0]))), (int)numArray[1]);
                    this.master_table_entries[num1 + index1].root_num = (long)this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0])), new Decimal(numArray[1])), new Decimal(numArray[2]))), (int)numArray[3]);
                    if (Decimal.Compare(new Decimal(this.encoding), 1M) == 0)
                        this.master_table_entries[num1 + index1].sql_statement = Encoding.Default.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0])), new Decimal(numArray[1])), new Decimal(numArray[2])), new Decimal(numArray[3]))), (int)numArray[4]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 2M) == 0)
                        this.master_table_entries[num1 + index1].sql_statement = Encoding.Unicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0])), new Decimal(numArray[1])), new Decimal(numArray[2])), new Decimal(numArray[3]))), (int)numArray[4]);
                    else if (Decimal.Compare(new Decimal(this.encoding), 3M) == 0)
                        this.master_table_entries[num1 + index1].sql_statement = Encoding.BigEndianUnicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(numArray[0])), new Decimal(numArray[1])), new Decimal(numArray[2])), new Decimal(numArray[3]))), (int)numArray[4]);
                }
            }
            else
            {
                if (this.db_bytes[(int)Offset] != (byte)5)
                    return;
                int uint16 = (int)Convert.ToUInt16(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 3M)), 2)), 1M));
                for (int index = 0; index <= uint16; ++index)
                {
                    ushort integer = (ushort)this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(Offset), 12M), new Decimal(index * 2))), 2);
                    if (Decimal.Compare(new Decimal(Offset), 100M) == 0)
                        this.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(new Decimal(this.ConvertToInteger((int)integer, 4)), 1M), new Decimal((int)this.page_size))));
                    else
                        this.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(new Decimal(this.ConvertToInteger((int)((long)Offset + (long)integer), 4)), 1M), new Decimal((int)this.page_size))));
                }
                this.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 8M)), 4)), 1M), new Decimal((int)this.page_size))));
            }
        }

        public bool ReadTable(string TableName)
        {
            int index1 = -1;
            int num1 = this.master_table_entries.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (this.master_table_entries[index2].item_name.ToLower().CompareTo(TableName.ToLower()) == 0)
                {
                    index1 = index2;
                    break;
                }
            }
            if (index1 == -1)
                return false;
            string[] strArray = this.master_table_entries[index1].sql_statement.Substring(this.master_table_entries[index1].sql_statement.IndexOf("(") + 1).Split(',');
            int num2 = strArray.Length - 1;
            for (int index3 = 0; index3 <= num2; ++index3)
            {
                strArray[index3] = strArray[index3].TrimStart();
                int length = strArray[index3].IndexOf(" ");
                if (length > 0)
                    strArray[index3] = strArray[index3].Substring(0, length);
                if (strArray[index3].IndexOf("UNIQUE") != 0)
                {
                    this.field_names = (string[])Utils.CopyArray((Array)this.field_names, (Array)new string[index3 + 1]);
                    this.field_names[index3] = strArray[index3];
                }
                else
                    break;
            }
            return this.ReadTableFromOffset((ulong)(this.master_table_entries[index1].root_num - 1L) * (ulong)this.page_size);
        }

        private bool ReadTableFromOffset(ulong Offset)
        {
            if (this.db_bytes[(int)Offset] == (byte)13)
            {
                int int32 = Convert.ToInt32(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 3M)), 2)), 1M));
                int num1 = 0;
                if (this.table_entries != null)
                {
                    num1 = this.table_entries.Length;
                    this.table_entries = (SQLiteHandler.table_entry[])Utils.CopyArray((Array)this.table_entries, (Array)new SQLiteHandler.table_entry[this.table_entries.Length + int32 + 1]);
                }
                else
                    this.table_entries = new SQLiteHandler.table_entry[int32 + 1];
                int num2 = int32;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    SQLiteHandler.record_header_field[] arySrc = (SQLiteHandler.record_header_field[])null;
                    ulong integer = this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(Offset), 8M), new Decimal(index1 * 2))), 2);
                    if (Decimal.Compare(new Decimal(Offset), 100M) != 0)
                        integer += Offset;
                    int endIndex1 = this.GVL((int)integer);
                    this.CVL((int)integer, endIndex1);
                    int endIndex2 = this.GVL(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex1), new Decimal(integer))), 1M)));
                    this.table_entries[num1 + index1].row_id = this.CVL(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex1), new Decimal(integer))), 1M)), endIndex2);
                    ulong uint64 = Convert.ToUInt64(Decimal.Add(Decimal.Add(new Decimal(integer), Decimal.Subtract(new Decimal(endIndex2), new Decimal(integer))), 1M));
                    int endIndex3 = this.GVL((int)uint64);
                    int endIndex4 = endIndex3;
                    long num3 = this.CVL((int)uint64, endIndex3);
                    long num4 = Convert.ToInt64(Decimal.Add(Decimal.Subtract(new Decimal(uint64), new Decimal(endIndex3)), 1M));
                    int index2 = 0;
                    while (num4 < num3)
                    {
                        arySrc = (SQLiteHandler.record_header_field[])Utils.CopyArray((Array)arySrc, (Array)new SQLiteHandler.record_header_field[index2 + 1]);
                        int startIndex = endIndex4 + 1;
                        endIndex4 = this.GVL(startIndex);
                        arySrc[index2].type = this.CVL(startIndex, endIndex4);
                        arySrc[index2].size = arySrc[index2].type <= 9L ? (long)this.SQLDataTypeSize[(int)arySrc[index2].type] : (!this.IsOdd(arySrc[index2].type) ? (long)Math.Round((double)(arySrc[index2].type - 12L) / 2.0) : (long)Math.Round((double)(arySrc[index2].type - 13L) / 2.0));
                        num4 = num4 + (long)(endIndex4 - startIndex) + 1L;
                        ++index2;
                    }
                    this.table_entries[num1 + index1].content = new string[arySrc.Length - 1 + 1];
                    int num5 = 0;
                    int num6 = arySrc.Length - 1;
                    for (int index3 = 0; index3 <= num6; ++index3)
                    {
                        if (arySrc[index3].type > 9L)
                        {
                            if (!this.IsOdd(arySrc[index3].type))
                            {
                                if (Decimal.Compare(new Decimal(this.encoding), 1M) == 0)
                                    this.table_entries[num1 + index1].content[index3] = Encoding.Default.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(num5))), (int)arySrc[index3].size);
                                else if (Decimal.Compare(new Decimal(this.encoding), 2M) == 0)
                                    this.table_entries[num1 + index1].content[index3] = Encoding.Unicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(num5))), (int)arySrc[index3].size);
                                else if (Decimal.Compare(new Decimal(this.encoding), 3M) == 0)
                                    this.table_entries[num1 + index1].content[index3] = Encoding.BigEndianUnicode.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(num5))), (int)arySrc[index3].size);
                            }
                            else
                                this.table_entries[num1 + index1].content[index3] = Encoding.Default.GetString(this.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(num5))), (int)arySrc[index3].size);
                        }
                        else
                            this.table_entries[num1 + index1].content[index3] = Conversions.ToString(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(uint64), new Decimal(num3)), new Decimal(num5))), (int)arySrc[index3].size));
                        num5 += (int)arySrc[index3].size;
                    }
                }
            }
            else if (this.db_bytes[(int)Offset] == (byte)5)
            {
                int uint16 = (int)Convert.ToUInt16(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 3M)), 2)), 1M));
                for (int index = 0; index <= uint16; ++index)
                {
                    ushort integer = (ushort)this.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(new Decimal(Offset), 12M), new Decimal(index * 2))), 2);
                    this.ReadTableFromOffset(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(new Decimal(this.ConvertToInteger((int)((long)Offset + (long)integer), 4)), 1M), new Decimal((int)this.page_size))));
                }
                this.ReadTableFromOffset(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(new Decimal(this.ConvertToInteger(Convert.ToInt32(Decimal.Add(new Decimal(Offset), 8M)), 4)), 1M), new Decimal((int)this.page_size))));
            }
            return true;
        }

        private struct record_header_field
        {
            public long size;
            public long type;
        }

        private struct sqlite_master_entry
        {
            public long row_id;
            public string item_type;
            public string item_name;
            public string astable_name;
            public long root_num;
            public string sql_statement;
        }

        private struct table_entry
        {
            public long row_id;
            public string[] content;
        }
    }
}
