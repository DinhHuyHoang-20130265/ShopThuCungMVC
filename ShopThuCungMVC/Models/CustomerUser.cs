
namespace ShopThuCungMVC.Models
{
    public class CustomerUser
    {
        public int id_user {get; set;}
        public string user_name { get; set;}
        public string pass { get; set;}
        public bool status { get; set;}

        public CustomerUser(int id_user, string user_name, string pass, bool status)
        {
            this.id_user = id_user;
            this.user_name = user_name;
            this.pass = pass;
            this.status = status;
        }

    }
}
