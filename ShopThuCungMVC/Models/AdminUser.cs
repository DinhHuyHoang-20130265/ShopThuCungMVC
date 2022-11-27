namespace ShopThuCungMVC.Models
{
    public class AdminUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string address { get; set; }

        public AdminUser(int id, string username, string pass, string address)
        {
            this.id = id;
            this.username = username;
            this.pass = pass;
            this.address = address;
        }
    }
}