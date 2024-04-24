using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolLeechTruyenFull;

public class DAO_Truyen
{
    public static bool Check(string name, string author)
    {
        return DataProvider.ExecuteQuery("SELECT id FROM truyen WHERE name = @name AND author = @author", new object[2] { name, author }).Rows.Count > 0;
    }

    public static int getId(string name, string author)
    {
        return int.Parse(DataProvider.ExecuteQuery("SELECT id FROM truyen WHERE name = @name AND author = @author", new object[2] { name, author }).Rows[0]["id"].ToString());
    }

    public static int insertTruyen(string name, string author, string img, string status, string description, string[] tags)
    {
        int num = int.Parse(DataProvider.ExecuteQuery("SELECT MAX(id) as 'id' FROM truyen").Rows[0]["id"].ToString()) + 1;
        DataProvider.ExecuteNonQuery("INSERT INTO truyen(name, name_slug, cover, thumb, author, type_story, status, description, source, user_id, created_at, updated_at) VALUES ( @name , @name_slug , @cover , @thumb , @author , @type_story , @status , @description , @source , @user_id , NOW() , NOW() )", new object[10]
        {
            name,
            SystemFiles.Slug(name) + "-" + num,
            img,
            img,
            author,
            "Truyện Dịch",
            status,
            description,
            SystemFiles._SOURCE,
            SystemFiles._USER_ID
        });
        for (int i = 0; i < tags.Length; i++)
        {
            string text = tags[i].Trim();
            if (DataProvider.ExecuteQuery("SELECT id FROM the_loai_truyen WHERE name = @name", new object[1] { text }).Rows.Count == 0)
            {
                DataProvider.ExecuteNonQuery("INSERT INTO the_loai_truyen(name, name_slug) VALUES ( @name , @name_slug )", new object[2]
                {
                    text,
                    SystemFiles.Slug(text)
                });
            }
            DataProvider.ExecuteNonQuery("INSERT INTO truyen_theloai(truyen_id, name, name_slug) VALUES ( @truyen_id , @name , @name_slug )", new object[3]
            {
                num,
                text,
                SystemFiles.Slug(text)
            });
        }
        DataProvider.ExecuteNonQuery("INSERT INTO thanh_viens(user_id, truyen_id, created_at, updated_at) VALUES ( @user_id , @truyen_id , NOW() , NOW() )", new object[2]
        {
            SystemFiles._USER_ID,
            num
        });
        return num;
    }

    public static bool checkChapter(int numchap, int story_id)
    {
        return DataProvider.ExecuteQuery("SELECT id FROM chuong WHERE numchap = @numchap AND truyen_id = @truyen_id", new object[2] { numchap, story_id }).Rows.Count > 0;
    }

    public static void insertChapter(int numchap, string name, string content, int wk, int story_id)
    {
        DataProvider.ExecuteNonQuery("INSERT INTO chuong(truyen_id, user_id, numchap, name, content, number_letters, created_at, updated_at) VALUES ( @truyen_id , @user_id , @numchap , @name , @content , @number_letters , NOW() , NOW() )", new object[6]
        {
            story_id,
            SystemFiles._USER_ID,
            numchap,
            name,
            content,
            wk
        });
        DataProvider.ExecuteNonQuery("UPDATE truyen SET num_chaps = (num_chaps + 1) WHERE id = @id", new object[1] { story_id });
    }

    public static void updateStatus(string status, int story_id)
    {
        DataProvider.ExecuteNonQuery("UPDATE truyen SET status = @status WHERE id = @id", new object[2] { status, story_id });
    }

    public static void updateWK(int wk, int story_id)
    {
        DataProvider.ExecuteNonQuery("UPDATE truyen SET number_letters = @number_letters WHERE id = @id", new object[2] { wk, story_id });
    }

    public static string getStatus(int story_id)
    {
        return DataProvider.ExecuteQuery("SELECT status from truyen WHERE id = @id", new object[1] { story_id }).Rows[0]["status"].ToString().Trim();
    }

    public static int getNumchap(int story_id)
    {
        return int.Parse(DataProvider.ExecuteQuery("SELECT num_chaps from truyen WHERE id = @id", new object[1] { story_id }).Rows[0]["num_chaps"].ToString());
    }
}
