using System.ComponentModel.DataAnnotations;

namespace ShopThuCungMVC.Models
{
    public class UserAccount
    {
        [Key]
        public string id { get; set; }
        public string user_name { get; set; }
        public string passMaHoa { get; set; }
        public string pass { get; set; }

        public int status { get; set; }
        public int role { get; set; }
        public UserAccount(string id, string user_name, string passMaHoa, string pass, int status, int role)
        {
            this.id = id;
            this.user_name = user_name;
            this.passMaHoa = passMaHoa;
            this.pass = pass;
            this.status = status;
            this.role = role;
        }
    }
}