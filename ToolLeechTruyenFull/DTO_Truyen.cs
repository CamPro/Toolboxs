public class DTO_Truyen
{
    private string name;

    private string link;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string Link
    {
        get
        {
            return link;
        }
        set
        {
            link = value;
        }
    }

    public DTO_Truyen(string _name, string _link)
    {
        name = _name;
        link = _link;
    }
}
