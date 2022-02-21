using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV2
{
    interface IWalkAway//Interfaces, including all their methods and properties, are always public so no need to use the public keyword
    {
        void WalkAway(Player player);//all classes that inherit the IWalkAway interface must implement this method, and take in those parameters, and return a void
    }
}
//IWALKAWAY USE CASE EXPLAINED:
/*
 In this hypothetical, we want to appease the gambling regulators by adhering to their law that states a player must have the option to walk away with their money/earnings at any time
Thus, we must integrate this feature of allowing a player to simply walk away from the game at any time
So why not just make this method a method within the Game class that other inheriting classes acquire? Because not all games are betting games (e.g. Solitaire), so it wouldn't make sense

 */