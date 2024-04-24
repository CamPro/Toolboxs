using HtmlAgilityPack;
using System.Windows.Forms;
using System.Xml;
using ToolLeechTruyenFull;

public class getTruyen
{
    public static string[] getInfoStory(string url)
    {
        //IL_0000: Unknown result type (might be due to invalid IL or missing references)
        HtmlWeb val = new HtmlWeb();
        string[] array = new string[5];
        HtmlAgilityPack.HtmlDocument val2 = val.Load(url);
        HtmlNode val3 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[1]/div/img");
        if (val3 == null)
        {
            return null;
        }
        string text = val3.Attributes["src"].Value.ToString();
        string innerText = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[1]/a").InnerText;
        string innerHtml = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[3]/div[2]").InnerHtml;
        string text2 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[2]").InnerText.Replace("Thể loại:", string.Empty);
        try
        {
            string text3 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[4]/span").InnerText.Trim();
            if (text3 == null)
            {
                text3 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[3]/span").InnerText.Trim();
                if (text3 == null)
                {
                    text3 = "Đang ra";
                }
            }
            text3 = ((!(text3 == "Đang ra")) ? "Hoàn thành" : "Đang cập nhật");
            array[0] = innerText.Trim();
            array[1] = text.Trim();
            array[2] = innerHtml.Trim();
            array[3] = text2.Trim();
            array[4] = text3.Trim();
        }
        catch
        {
            string text4 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[3]/span").InnerText.Trim();
            if (text4 == null)
            {
                text4 = val2.DocumentNode.SelectSingleNode("//*[@id='truyen']/div[1]/div[1]/div[2]/div[2]/div[3]/span").InnerText.Trim();
                if (text4 == null)
                {
                    text4 = "Đang ra";
                }
            }
            text4 = ((!(text4 == "Đang ra")) ? "Hoàn thành" : "Đang cập nhật");
            array[0] = innerText.Trim();
            array[1] = text.Trim();
            array[2] = innerHtml.Trim();
            array[3] = text2.Trim();
            array[4] = text4.Trim();
        }
        return array;
    }

    public static string[] getChapter(string url)
    {
        //IL_0000: Unknown result type (might be due to invalid IL or missing references)
        HtmlAgilityPack.HtmlDocument val = new HtmlWeb().Load(url);
        HtmlNode val2 = val.DocumentNode.SelectSingleNode("//*[@id='chapter-big-container']/div/div/h2/a");
        if (val2 == null)
        {
            return null;
        }
        string text = SystemFiles.GetPlainTextFromHtml(val2.InnerText).Trim();
        if (!text.Contains(":"))
        {
            text += ": Không Tiêu Đề";
        }
        string innerHtml = val.DocumentNode.SelectSingleNode("//*[@id='chapter-c']").InnerHtml;
        innerHtml = innerHtml.Replace("<p>", "");
        innerHtml = innerHtml.Replace("</p>", "");
        string[] array = new string[2];
        string[] array2 = text.Split(':');
        string text2 = "";
        for (int i = 1; i < array2.Length; i++)
        {
            text2 = text2 + array2[i] + " ";
        }
        array[0] = text2.Trim();
        array[1] = innerHtml.Replace("<div class=\"visible-md visible-lg ads-responsive incontent-ad\" id=\"ads-chapter-pc-top\" align=\"center\" style=\"height:90px\"></div>", "");
        return array;
    }
}