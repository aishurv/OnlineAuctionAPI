﻿using OnlineAuctionAPI.Models;
using DB;
using System.Xml.Linq;
namespace OnlineAuctionAPI
{   
    public static class AddDummyData
    {
        static User user = new User()
        {
            UserId = new MongoDB.Bson.ObjectId(),
            Name = "Aishu",
            UserName ="@aishu",
            ContactNo = 1234567890
        };
        static Product product = new Product()
        {
            Id = new MongoDB.Bson.ObjectId(),
            Name = "Dummy1",
            Description = "Sample Dummy Product ",
            InitialValue = 100m,
            CurrentValue=120m,
            PreValue =118m,
            IsActive =true
        };

        public static void AddDummyUser()
        {
            DBConnection.AddUser(user);
        }
        public static void AddDummyProduct()
        {
            DBConnection.AddProduct(product);
        }

    }
}
