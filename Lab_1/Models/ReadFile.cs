using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lab_1.Helpers;
using Lab_1.Models;

namespace Lab_1.Models
{
    public class ReadFile
    { 
        public void ReadFiles(string route)
        {
            Player player = new Player();
            int i = 0;
           string[] lines = File.ReadAllLines(route);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (i!=0)
                {
                    Storage.Instance.ID += 1;
                    player.club = values[0];
                    player.last_name = values[1];
                    player.fisrt_name = values[2];
                    player.position = values[3];
                    player.base_salary = float.Parse(values[4]);
                    player.guaranteed_compensation = float.Parse(values[5]);
                    player.id = Storage.Instance.ID;
    
                    if (Storage.Instance.typeList == "ListaArtesanal")
                    {
                        Storage.Instance.playersListProp.Add(player);
                    }
                    else if (Storage.Instance.typeList == "ListaC#")
                    {
                        Storage.Instance.playersListCshap.Add(player);
                    }
                    
                }
                i++;            
            }
        }
    }
}