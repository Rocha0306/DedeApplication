using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DedeApplication.Entities
{
    public class StaffsEntity
    {
    public string Id { get; set; }
    public string Name {get;set;}
    public string Email { get; set; } 
    public string Role { get; set; }
    public string HospitalName { get; set; } 

     public StaffsEntity(string id, string name, string email, string role, string hospitalName)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
        HospitalName = hospitalName;
    }

    public string KeyAcess {get; set;}

    public StaffsEntity CreateStaff(StaffsEntity staffsEntity) {
        staffsEntity.KeyAcess = RandomNumberGenerator.GetString("Anything, i hope that dont repeat", 10); 
        return staffsEntity; 
    }

    }
}