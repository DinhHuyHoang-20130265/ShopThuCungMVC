namespace ShopThuCungMVC.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string detail { get; set; }
        public int status { get; set; }

        public Contact(int id, string name, string email, string detail, int status)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.detail = detail;
            this.status = status;
        }
    }
}
