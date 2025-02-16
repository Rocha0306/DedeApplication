using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Entities;
using DedeApplication.UsersCase.Database;
using MongoDB.Driver.Linq;

namespace DedeApplication.UsersCase
{
    public class ListPatients
    {

        private readonly KeepData keepData; 

        public ListPatients(KeepData _keepData)
        {

            keepData = _keepData; 
            
        }
     
    }
}