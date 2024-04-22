using System.Collections.Generic;

namespace BackupRestoreChromeProfiles
{
    public class ChromeProfile
    {
        public string Profile { get; set; }

        public string Name { get; set; }

        public List<Account> ListAccount { get; set; }

        public List<Cookies> ListCookies { get; set; }
    }
}
