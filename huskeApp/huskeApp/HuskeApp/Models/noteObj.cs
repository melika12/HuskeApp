using System;
using System.Collections.Generic;
using System.Text;

namespace noteObj.Models
{
    public class login
    {
        public string name { get; set; }
        public string password { get; set; }

    }

    public class userIndex
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }

    public class newUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }

    public class editUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }

    public class deleteUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
    //_____________________________________note__________________________________________
    public class noteIndex
    {
        public int id { get; set; }
        public string name { get; set; }
        public string timeOfEvent { get; set; }
        public string description { get; set; }
    }

    public class newNote
    {
        public int id { get; set; }
        public string name { get; set; }
        public string timeOfEvent { get; set; }
        public string description { get; set; }
    }

    public class editNote
    {
        public int id { get; set; }
        public string name { get; set; }
        public string timeOfEvent { get; set; }
        public string description { get; set; }
    }

    public class deleteNote
    {
        public int id { get; set; }
        public string name { get; set; }
        public string timeOfEvent { get; set; }
        public string description { get; set; }
    }

}
