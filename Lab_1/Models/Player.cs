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
        //Uso del comparison para busqueda
        //Comparación con el nombre del jugador
        public static Comparison<Player> Comparate_LastName = delegate (Player Player01, Player Player02)
        {
            //return Player01.last_name.ToLowerInvariant().CompareTo(Player02.last_name.ToLower());
            return Player01.last_name.ToLower().CompareTo(Player02.last_name.ToLower());
        };
        //Comparación con el apellido del jugador
        public static Comparison<Player> Comparate_FirstName = delegate (Player Player01, Player Player02)
        {
            return Player01.fisrt_name.ToLower().CompareTo(Player02.fisrt_name.ToLower());
        };
        //Comparación con la posición del jugador
        public static Comparison<Player> Comparate_Position = delegate (Player Player01, Player Player02)
        {
            return Player01.position.ToLower().CompareTo(Player02.position.ToLower());
        };
        //Comparación con el salario del jugador
        public static Comparison<Player> Comparate_LastName = delegate (Player Player01, Player Player02)
        {
            return Player01.base_salary.ToLower().CompareTo(Player02.base_salary.ToLower());
            if (Player01.base_salary.ToString == Player02.base_salary.ToString)
            {

            }
            else if (Player01.base_salary.ToString < Player02.base_salary.ToString)
            {

            }
            else
            {

            }
        };
    }
}