using System;
using Microsoft.AspNetCore.Identity;

namespace TP3_EcoWatch.Models
{
    public class AppUser : IdentityUser

    {
        public String Id { get; set; } 
        public string Region { get; set; } = "";

        public string Speciality { get; set; } = "";
    }
}
