﻿namespace BlogForest.WebUI.Models
{
    public class UserWithRolesViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
