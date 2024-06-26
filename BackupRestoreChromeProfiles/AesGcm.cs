﻿using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BackupRestoreChromeProfiles
{
    internal class AesGcm
    {
        public byte[] Decrypt(byte[] key, byte[] iv, byte[] aad, byte[] cipherText, byte[] authTag)
        {
            IntPtr num1 = this.OpenAlgorithmProvider(BCrypt.BCRYPT_AES_ALGORITHM, BCrypt.MS_PRIMITIVE_PROVIDER, BCrypt.BCRYPT_CHAIN_MODE_GCM);
            IntPtr hKey;
            IntPtr hglobal = this.ImportKey(num1, key, out hKey);
            BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo = new BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag);
            byte[] pbOutput;
            using (pPaddingInfo)
            {
                byte[] pbIV = new byte[this.MaxAuthTagSize(num1)];
                int pcbResult = 0;
                uint num2 = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref pPaddingInfo, pbIV, pbIV.Length, (byte[])null, 0, ref pcbResult, 0);
                if (num2 > 0U)
                    throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() (get size) failed with status code: {0}", (object)num2));
                pbOutput = new byte[pcbResult];
                uint num3 = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref pPaddingInfo, pbIV, pbIV.Length, pbOutput, pbOutput.Length, ref pcbResult, 0);
                if ((int)num3 == (int)BCrypt.STATUS_AUTH_TAG_MISMATCH)
                    throw new CryptographicException("BCrypt.BCryptDecrypt(): authentication tag mismatch");
                if (num3 > 0U)
                    throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() failed with status code:{0}", (object)num3));
            }
            int num4 = (int)BCrypt.BCryptDestroyKey(hKey);
            Marshal.FreeHGlobal(hglobal);
            int num5 = (int)BCrypt.BCryptCloseAlgorithmProvider(num1, 0U);
            return pbOutput;
        }

        public int MaxAuthTagSize(IntPtr hAlg)
        {
            byte[] property = this.GetProperty(hAlg, BCrypt.BCRYPT_AUTH_TAG_LENGTH);
            return BitConverter.ToInt32(new byte[4]
            {
        property[4],
        property[5],
        property[6],
        property[7]
            }, 0);
        }

        public IntPtr OpenAlgorithmProvider(string alg, string provider, string chainingMode)
        {
            IntPtr phAlgorithm = IntPtr.Zero;
            uint num1 = BCrypt.BCryptOpenAlgorithmProvider(out phAlgorithm, alg, provider, 0U);
            if (num1 > 0U)
                throw new CryptographicException(string.Format("BCrypt.BCryptOpenAlgorithmProvider() failed with status code:{0}", (object)num1));
            byte[] bytes = Encoding.Unicode.GetBytes(chainingMode);
            uint num2 = BCrypt.BCryptSetAlgorithmProperty(phAlgorithm, BCrypt.BCRYPT_CHAINING_MODE, bytes, bytes.Length, 0);
            if (num2 > 0U)
                throw new CryptographicException(string.Format("BCrypt.BCryptSetAlgorithmProperty(BCrypt.BCRYPT_CHAINING_MODE, BCrypt.BCRYPT_CHAIN_MODE_GCM) failed with status code:{0}", (object)num2));
            return phAlgorithm;
        }

        public IntPtr ImportKey(IntPtr hAlg, byte[] key, out IntPtr hKey)
        {
            int int32 = BitConverter.ToInt32(this.GetProperty(hAlg, BCrypt.BCRYPT_OBJECT_LENGTH), 0);
            IntPtr pbKeyObject = Marshal.AllocHGlobal(int32);
            byte[] pbInput = this.Concat(BCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC, BitConverter.GetBytes(1), BitConverter.GetBytes(key.Length), key);
            uint num = BCrypt.BCryptImportKey(hAlg, IntPtr.Zero, BCrypt.BCRYPT_KEY_DATA_BLOB, out hKey, pbKeyObject, int32, pbInput, pbInput.Length, 0U);
            if (num > 0U)
                throw new CryptographicException(string.Format("BCrypt.BCryptImportKey() failed with status code:{0}", (object)num));
            return pbKeyObject;
        }

        public byte[] GetProperty(IntPtr hAlg, string name)
        {
            int pcbResult = 0;
            uint property1 = BCrypt.BCryptGetProperty(hAlg, name, (byte[])null, 0, ref pcbResult, 0U);
            if (property1 > 0U)
                throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() (get size) failed with status code:{0}", (object)property1));
            byte[] pbOutput = new byte[pcbResult];
            uint property2 = BCrypt.BCryptGetProperty(hAlg, name, pbOutput, pbOutput.Length, ref pcbResult, 0U);
            if (property2 > 0U)
                throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() failed with status code:{0}", (object)property2));
            return pbOutput;
        }

        public byte[] Concat(params byte[][] arrays)
        {
            int num = 0;
            foreach (byte[] array in arrays)
            {
                if (array != null)
                    num += array.Length;
            }
            byte[] dst = new byte[num - 1 + 1];
            int dstOffset = 0;
            foreach (byte[] array in arrays)
            {
                if (array != null)
                {
                    Buffer.BlockCopy((Array)array, 0, (Array)dst, dstOffset, array.Length);
                    dstOffset += array.Length;
                }
            }
            return dst;
        }
    }
}
