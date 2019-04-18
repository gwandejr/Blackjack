using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack.Objects
{
    public class Cards
    {
        Random rndmNum = new Random();

        public int GetCardNum()
        {
            return rndmNum.Next(1, 10);
        }

        public int AddTwoCards(int card1, int card2)
        {
            int totalCards = card1 + card2;
            return totalCards;
        }

        public int CalculateWinnings(int wager, int odds)
        {
            int winnings = wager * odds;
            return winnings;
        }
    }
}
