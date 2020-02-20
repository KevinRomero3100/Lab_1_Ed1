using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Helpers;

namespace Lab_1.Models
{
    public class Player
    {
        
        public String last_name { get; set; }
        public String club { get; set; }
        public String fisrt_name { get; set; }
        public String position { get; set; }
        public float base_salary { get; set; }
        public float guaranteed_compensation { get; set; }
        public int id { get; set; }

        public void save()
        {
            try
            {
                if (Storage.Instance.typeList == "ListaArtesanal")
                {
                    Storage.Instance.playersListProp.Add(this);
                }
                else if (Storage.Instance.typeList == "ListaC#")
                {
                    Storage.Instance.playersListCshap.Add(this);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}