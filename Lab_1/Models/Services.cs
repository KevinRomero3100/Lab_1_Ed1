using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Helpers;

namespace Lab_1.Models
{
    public class Services
    {
        public class Services
        {
            public List<Player> GetPlayer()
            {
                return Storage.Instance.playersListCshap;
                return Storage.Instance.playersListProp;
            }


            public bool SavePlayers(Player player)
            {
                var PlayerFound = false;
                foreach (var item in Storage.Instance.playersListCshap)
                {
                    if (item.GetLastName() == player.GetLastName() && item.GetFirstName() == player.GetFirstName())
                    {
                        PlayerFound = true;
                        break;
                    }
                    if (!PlayerFound)
                        Storage.Instance.playersListCshap.Add(player);

                    return PlayerFound;
                }
            }

            public bool SavePlayers_withListProp(bool player)
            {
                try
                {
                    if (player)
                    {
                        Storage.Instance.playersListProp.Add(this);
                    }
                    else
                    {
                        Storage.playersListCshap.Add(this);
                    }
                }
                catch
                {

                }
            }

        }
    }
}