using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;

namespace XNAHelper
{
    class StorageManager
    {
        public IsolatedStorageFile Storage;

        public StorageManager()
        {
#if WINDOWS_PHONE
            Storage = IsolatedStorageFile.GetUserStoreForApplication();
#else
            Storage = IsolatedStorageFile.GetUserStoreForDomain();
#endif
        }

        //Put Functions
        public void PutInt(String key, int value)
        {
            using (IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                if (fs != null)
                {
                    byte[] saveBytes = System.BitConverter.GetBytes(value);
                    fs.Write(saveBytes, 0, saveBytes.Length);
                }
            }
        }

        public void PutDouble(String key, double value)
        {
            using (IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                byte[] saveBytes = System.BitConverter.GetBytes(value);
                fs.Write(saveBytes, 0, saveBytes.Length);
            }
        }

        public void PutLong(String key, long value)
        {
            using (IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                byte[] saveBytes = System.BitConverter.GetBytes(value);
                fs.Write(saveBytes, 0, saveBytes.Length);
            }
        }

        public void PutShort(String key, short value)
        {
            using (IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                byte[] saveBytes = System.BitConverter.GetBytes(value);
                fs.Write(saveBytes, 0, saveBytes.Length);
            }
        }

        public void PutBool(String key, bool value)
        {
            using (IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                byte[] saveBytes = System.BitConverter.GetBytes(value);
                fs.Write(saveBytes, 0, saveBytes.Length);
            }
        }

        private byte[] getBytes(String key, int byteLength)
        {
            byte[] result = new byte[byteLength];
            using(IsolatedStorageFileStream fs = Storage.OpenFile(key, FileMode.OpenOrCreate))
            {
                if (fs.Read(result, 0, byteLength) > 0) return result;
            }
            return null;
        }

        public int GetInt(String key, int defaultValue)
        {
            byte[] readBytes = getBytes(key, 4);
            if (readBytes != null) return System.BitConverter.ToInt32(readBytes, 0);
            return defaultValue;
        }

        public double GetDouble(String key, double defaultValue)
        {
            byte[] readBytes = getBytes(key, 8);
            if (readBytes != null) return System.BitConverter.ToDouble(readBytes, 0);
            return defaultValue;
        }

        public long GetLong(String key, long defaultValue)
        {
            byte[] readBytes = getBytes(key, 8);
            if (readBytes != null) return System.BitConverter.ToInt64(readBytes, 0);
            return defaultValue;
        }

        public short GetShort(String key, short defaultValue)
        {
            byte[] readBytes = getBytes(key, 2);
            if (readBytes != null) return System.BitConverter.ToInt16(readBytes, 0);
            return defaultValue;
        }

        public bool GetBool(String key, bool defaultValue)
        {
            byte[] readBytes = getBytes(key, 1);
            if (readBytes != null) return System.BitConverter.ToBoolean(readBytes, 0);
            return defaultValue;
        }
    }
}
