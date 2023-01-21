using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace city_building
{
    internal class Wolves
    {
        public int nextWave = 300; // 5 min
        public int waveDifficulty = 0;

        public void Resolve(Game game)
        {
            // check if the nextWave should come
            if(nextWave == 0)
            {
                SendWave(game.actions);
                nextWave = 300;
                waveDifficulty++;
            }
            else
            {
                nextWave--;
            }
        }

        public void SendWave(List<Tuple<Action, string, int, int>> actions)
        {
            // based on waveDifficulty, decide the number of wolves that attack
            // for each pack of 3 wolves, create an action that is then resolved by
            // the GameTimer_Tick function

            // the first int keeps the number of wolves that are still alive in the pack
            // the second int keeps the location of the wolf pack
            /*actions.Add(new Tuple<Action, string, int, int>(() =>
            {
                // this delta figures out which tile the wolves will attack   
            }, "wolves", 3, ));*/
        }
    }
}
