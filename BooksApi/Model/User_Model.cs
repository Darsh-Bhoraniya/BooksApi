﻿namespace BooksApi.Model
{
    public class User_Model
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
