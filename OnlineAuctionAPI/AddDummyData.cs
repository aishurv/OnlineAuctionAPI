using OnlineAuctionAPI.Models;
using DB;
using System.Xml.Linq;
using OnlineAuctionAPI.Model;
using OnlineAuctionAPI.Controllers;
namespace OnlineAuctionAPI
{   
    public static class AddDummyData
    {
        static User user = new User()
        { 
            Name = "Aishu",
            UserName ="@aishu",
            ContactNo = 1234567890
        };
        static Product product = new Product()
        {
            Name = "Dummy1",
            Description = "Sample Dummy Product ",
            InitialValue = 100m,
            CurrentValue=120m,
            PreValue =118m,
            IsActive =true
        };
        static Admin admin = new Admin()
        {
            Name = "admin"
        };
        
        public static void AddDummyUser()
        {
            DBConnection.AddUser(user);
        }
        public static void AddDummyProduct()
        {
            DBConnection.AddProduct(product);
        }
        //public static void AddDummyAdmin()
        //{
        //    AdminController.addAdmin(admin);
        //}
    }
}
