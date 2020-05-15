using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Util
{
    public static class Initializer
    {
        private static string rules = @"The object of the game is to accumulate a score of 100 points or more.
A score is made by rolling the dice and combining the points on the two dice.
For example: A 4 and 5 would be 9 points

If the player decides to take another roll of the dice and turns up a 3 and 5 (8 points)
he/she would then have an accumulated total of 17 points for the two rolls
The player has the privilege of continuing to shake to increase his score or of passing 
the dice to wait for the next series, thus preventing the possibility of rolling a Skunk
and losing his/her score.

A skunk in any series voids the score for that series only and draws a penalty of
1 chip placed in the 'kitty', and loss of dice.
A skunk and a deuce voids the score for that series only and draws a penalty of 2 chips
placed in the 'kitty', and loss of dice.

TWO skunks void the ENTIRE accumulated score and draws a penalty of 4 chips placed
in the kitty, and loss of dice. Player must again start to score from scratch.

Any number can play. [Assume at least two players!] The suggested number of chips
to start is 50.

The first player to accumulate a total of 100 or more points can continue to score as many
points over 100 as he/she believes is needed to win. When he/she decides to stop, his/her total score
is the goal. Each succeeding player receives one more chance to better the goal and end the game.

The winner of each game collects all chips in kitty and in addition, five chips
from each losing player or 10 chips from any player without a score.

For tournament play, a game ends when any player has 0 chips.  A new game will begin.  When a player 
accumuates 150 chips, they win the tournament.";

        public static string getRules()
        {
            return rules;
        }
    }
}
