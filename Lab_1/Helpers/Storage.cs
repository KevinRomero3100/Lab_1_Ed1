using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genericos.Structures;
using Lab_1.Models;

namespace Lab_1.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public int ID = 0;
        public string typeDate = "";
        public string typeList = "";

        public List<Player> playersListCshap = new List<Player>();
        public ListProp<Player> playersListProp = new ListProp<Player>();
        public List<Timer> time = new List<Timer>();
    }
}