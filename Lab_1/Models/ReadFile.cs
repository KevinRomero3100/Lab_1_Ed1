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
            
            int i = 0;
           string[] lines = File.ReadAllLines(route);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (i!=0)
                {
                    Storage.Instance.ID += 1;
                    var player = new Player 
                    {
                        club = values[0],
                        last_name = values[1],
                        fisrt_name = values[2],
                        position = values[3],
                        base_salary = float.Parse(values[4]),
                        guaranteed_compensation = float.Parse(values[5]),
                        id = Storage.Instance.ID
                    };

                    player.save();
                }
                i++;            
            }
        }
    }
}