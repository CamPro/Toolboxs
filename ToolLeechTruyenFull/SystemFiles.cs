using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SystemFiles
{
    public static string _CONECTION_STRING = "";

    public static int _USER_ID = 0;

    public static bool _CHECK = false;

    public static string _SOURCE = "";

    private static readonly string[] VietNamChar = new string[15]
    {
        "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ",
        "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ"
    };

    public static string GetPlainTextFromHtml(string htmlString)
    {
        string pattern = "<.*?>";
        htmlString = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.IgnoreCase | RegexOptions.Singleline).Replace(htmlString, string.Empty);
        htmlString = Regex.Replace(htmlString, pattern, string.Empty);
        htmlString = Regex.Replace(htmlString, "^\\s+$[\\r\\n]*", "", RegexOptions.Multiline);
        htmlString = htmlString.Replace("&nbsp;", string.Empty);
        return htmlString;
    }

    private static string ClearSlug(string str)
    {
        str = str.Replace(":", string.Empty);
        str = str.Replace("[", string.Empty);
        str = str.Replace("]", string.Empty);
        str = str.Replace(",", string.Empty);
        str = str.Replace(";", string.Empty);
        str = str.Replace("?", string.Empty);
        str = str.Replace("!", string.Empty);
        str = str.Replace("(", string.Empty);
        str = str.Replace(")", string.Empty);
        str = str.Replace(".", string.Empty);
        str = str.Replace("【", string.Empty);
        str = str.Replace("】", string.Empty);
        str = str.Replace("》", string.Empty);
        str = str.Replace("《", string.Empty);
        str = str.Replace(". ", string.Empty);
        str = str.Replace("&quot", string.Empty);
        str = str.Replace("&quot;", string.Empty);
        str = str.Replace("  ", " ");
        str = str.Replace("-", string.Empty);
        str = str.Replace("--", "-");
        str = str.Replace("--", "-");
        str = str.Trim();
        str = str.ToLower();
        str = ClearUTF8(str);
        return str;
    }

    private static string ClearUTF8(string str)
    {
        str = str.Replace("á", "a");
        str = str.Replace("à", "a");
        str = str.Replace("ả", "a");
        str = str.Replace("ã", "a");
        str = str.Replace("ạ", "a");
        str = str.Replace("ă", "a");
        str = str.Replace("ắ", "a");
        str = str.Replace("ằ", "a");
        str = str.Replace("ẳ", "a");
        str = str.Replace("ẵ", "a");
        str = str.Replace("ặ", "a");
        str = str.Replace("â", "a");
        str = str.Replace("ấ", "a");
        str = str.Replace("ầ", "a");
        str = str.Replace("ẩ", "a");
        str = str.Replace("ẫ", "a");
        str = str.Replace("ậ", "a");
        str = str.Replace("ơ", "o");
        str = str.Replace("ớ", "o");
        str = str.Replace("ờ", "o");
        str = str.Replace("ở", "o");
        str = str.Replace("ỡ", "o");
        str = str.Replace("ợ", "o");
        str = str.Replace("o", "o");
        str = str.Replace("ó", "o");
        str = str.Replace("ò", "o");
        str = str.Replace("ỏ", "o");
        str = str.Replace("õ", "o");
        str = str.Replace("ọ", "o");
        str = str.Replace("ô", "o");
        str = str.Replace("ố", "o");
        str = str.Replace("ồ", "o");
        str = str.Replace("ổ", "o");
        str = str.Replace("ỗ", "o");
        str = str.Replace("ộ", "o");
        str = str.Replace("ư", "u");
        str = str.Replace("ứ", "u");
        str = str.Replace("ừ", "u");
        str = str.Replace("ử", "u");
        str = str.Replace("ữ", "u");
        str = str.Replace("ự", "u");
        str = str.Replace("ú", "u");
        str = str.Replace("ù", "u");
        str = str.Replace("ủ", "u");
        str = str.Replace("ũ", "u");
        str = str.Replace("ụ", "u");
        str = str.Replace("ê", "e");
        str = str.Replace("ế", "e");
        str = str.Replace("ề", "e");
        str = str.Replace("ể", "e");
        str = str.Replace("ễ", "e");
        str = str.Replace("ệ", "e");
        str = str.Replace("í", "i");
        str = str.Replace("ì", "i");
        str = str.Replace("ỉ", "i");
        str = str.Replace("ĩ", "i");
        str = str.Replace("ị", "i");
        str = str.Replace("ý", "y");
        str = str.Replace("ỳ", "y");
        str = str.Replace("ỷ", "y");
        str = str.Replace("ỹ", "y");
        str = str.Replace("ỵ", "y");
        return str;
    }

    public static string Slug(string str)
    {
        str = ClearSlug(str);
        str = ClearUTF8(str);
        for (int i = 1; i < VietNamChar.Length; i++)
        {
            for (int j = 0; j < VietNamChar[i].Length; j++)
            {
                str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
        }
        str = ClearUTF8(str.Trim());
        str = str.Replace(" ", "-");
        str = ClearUTF8(str);
        for (int k = 1; k < VietNamChar.Length; k++)
        {
            for (int l = 0; l < VietNamChar[k].Length; l++)
            {
                str = str.Replace(VietNamChar[k][l], VietNamChar[0][k - 1]);
            }
        }
        str = ClearUTF8(str);
        str = SlugVietChar(str);
        return str;
    }

    private static string SlugVietChar(string str)
    {
        for (int i = 1; i < VietNamChar.Length; i++)
        {
            for (int j = 0; j < VietNamChar[i].Length; j++)
            {
                str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
        }
        str = str.Replace("`", string.Empty);
        return str.Replace("_", "-");
    }

    public static int WK(string str)
    {
        char[] separator = new char[3] { ' ', '\r', '\n' };
        return str.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string ClearContent(string str)
    {
        str = str.Replace("<div class=\"visible-md visible-lg ads-responsive incontent-ad\" id=\"ads-chapter-pc-top\" align=\"center\" style=\"height:90px\"></div>", "");
        char[] separator = new char[4] { '<', 'b', 'r', '>' };
        List<string> list = new List<string>();
        list.AddRange(str.Split(separator));
        while (list[0].Trim() == "<br>")
        {
            list.RemoveAt(0);
        }
        return string.Join("<br>", list.ToArray());
    }
}
