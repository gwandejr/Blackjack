using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Objects;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            string userBegGmeYn = "";
            do
            {
                string userAddtlCardYn = "", userRepeatYn = "", userWager = "";
                int odds = 5;
                int userCard1, userCard2, userCard3, userTotal1 = 0, userTotal2 = 0;
                int dlrCard1, dlrCard2, dlrCard3, dlrTotal1 = 0, dlrTotal2 = 0;

                try
                {
                    //Default setting at program startup
                    if (userBegGmeYn.ToUpper() == "")
                    {
                        Console.WriteLine(" WELCOME TO THE CONSOLE BLACKJACK GAME - the odds are 5 to 1" + "\n");
                        Console.Write(" To start the game, type: 'Y'.  To exit, type: 'N'. ");
                        userBegGmeYn = Console.ReadLine();
                        Console.WriteLine();
                    }

                    //The user has started playing
                    if (userBegGmeYn.ToUpper() == "Y")
                    {
                        try
                        {
                            Console.Write(" How much would you like to wager in dollars? ");
                            userWager = Console.ReadLine();
                            /* Converts the user wager input to an integer which will throw an error if 
                             non-numeric characters are entered.*/
                            Int32.Parse(userWager);
                        }
                        catch (FormatException fEx)
                        {
                            Console.WriteLine("  Must input a number.");
                        }

                        if ( (userWager.Length >= 8) || (Int32.Parse(userWager) < 20))
                        {
                            Console.WriteLine("  A minimum wager of $20 up to a maximum " +
                                "of a million dollars is required.");
                            throw new Exception();
                        }

                        Console.WriteLine();

                        Cards cards = new Cards();

                        //The player's card draws for two cards
                            userCard1 = cards.GetCardNum();
                            Console.Write($"    Your first card is: {userCard1}" + "\n");

                            userCard2 = cards.GetCardNum();
                            Console.Write($"    Your second card is: {userCard2}" + "\n");

                            userTotal1 = cards.AddTwoCards(userCard1, userCard2);
                            Console.Write($"    Your total card value is: {userTotal1}" + "\n\n");

                        //The dealer's card draw for two cards
                            dlrCard1 = cards.GetCardNum();
                            Console.Write($"    The dealer's first card is: {dlrCard1}" + "\n");

                            dlrCard2 = cards.GetCardNum();
                            Console.Write($"    The dealer's second card is: {dlrCard2}" + "\n");

                            dlrTotal1 = cards.AddTwoCards(dlrCard1, dlrCard2);
                            Console.Write($"    The dealer's total card value is: {dlrTotal1}" + "\n\n");

                        Console.Write(" Would you like another card? If so type: 'Y'. If not type: 'N'. ");
                        userAddtlCardYn = Console.ReadLine();
                        Console.WriteLine();

                        //Player draws a third card?
                        if (userAddtlCardYn.ToUpper() == "Y")
                        {
                            userCard3 = cards.GetCardNum();
                            Console.Write($"    Your third and final card is: {userCard3}" + "\n");
                            userTotal2 = cards.AddTwoCards(userTotal1, userCard3);
                            Console.Write($"    Your final total card value is: {userTotal2}" + "\n\n");
                        }

                        if (userAddtlCardYn == "N")
                        {
                            userTotal2 = cards.AddTwoCards(userTotal1, 0);
                            Console.Write($"    Your final total card value is: {userTotal2}" + "\n\n");
                        }

                        //Dealer draws a third card?
                        if (dlrTotal1 <= 17)
                        {
                            dlrCard3 = cards.GetCardNum();
                            Console.Write($"    The dealer's third and final card is: {dlrCard3}" + "\n");
                            dlrTotal2 = cards.AddTwoCards(dlrTotal1, dlrCard3);
                            Console.Write($"    The dealer's final total card value is: {dlrTotal2}" + "\n\n");
                        }

                        if (dlrTotal1 > 17)
                        {
                            dlrTotal2 = cards.AddTwoCards(dlrTotal1, 0);
                            Console.Write($"    The dealer's final total card value is: {dlrTotal2}" + "\n\n");
                        }

                        //Who wins?
                        if ((userTotal2 <= 21) && (dlrTotal2 <= 21) && (userTotal2 > dlrTotal2))
                        {
                            Console.WriteLine($" CONGRATULATIONS, YOU WIN!  You've won " +
                                $"{cards.CalculateWinnings(Int32.Parse(userWager), odds)} dollars." + "\n");
                        }

                        else if ((userTotal2 <= 21) && (dlrTotal2 >= 22))
                        {
                            Console.WriteLine($" CONGRATULATIONS, YOU WIN!  You've won " +
                                $"{cards.CalculateWinnings(Int32.Parse(userWager), odds)} dollars." + "\n");

                        }

                        else if ((userTotal2 <= 21) && (dlrTotal2 <= 21) && (dlrTotal2 > userTotal2))
                        {
                            Console.WriteLine($" Sorry, you lose.  The House gets {userWager} dollars." + "\n");
                        }

                        else if ((dlrTotal2 <= 21) && (userTotal2 >= 22))
                        {
                            Console.WriteLine($" Sorry, you lose.  The House gets {userWager} dollars." + "\n");
                        }

                        else if ((userTotal2 <= 21) && (dlrTotal2 <= 21) && (userTotal2 == dlrTotal2))
                        {
                            Console.WriteLine(" Tie Game.  You get your wager back." + "\n");
                        }

                        Console.Write(" Would you like to play again? If so type: 'Y'. To exit type: 'N'. ");
                        userRepeatYn = Console.ReadLine();
                        Console.WriteLine();

                        if (userRepeatYn.ToUpper() == "Y")
                        {
                            continue;
                        }

                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine("  An error has occurred.  Please start over below.");
                    Console.WriteLine();
                }

            } while (true);
        }
    }
}
