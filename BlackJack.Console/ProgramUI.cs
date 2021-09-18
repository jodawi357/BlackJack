using BlackJackRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Console
{
    public class ProgramUI
    {
        BlackJackRepo.CardRepo repo = new BlackJackRepo.CardRepo();
        public void Run()
        {
            MainMenu();
        }
        public void MainMenu()
        {
            System.Console.WriteLine("BlackJack Table\n\n" +
                "Press 'Spacebar' to have a seat.\n" +
                "Press any other key to exit.");
            repo.CreateDeck();
            bool menuLoop = true;
            var keySwitch = System.Console.ReadKey().Key;
            while (menuLoop == true)
            {
                switch (keySwitch)
                {
                    case ConsoleKey.Spacebar:
                        StartGame();
                        keySwitch = ChooseHitStay(System.Console.ReadKey().Key);
                        break;
                    default:
                        System.Console.Beep();
                        menuLoop = false;
                        break;
                }
                System.Console.ReadKey();
            }
        }
        public void StartGame()
        {
            repo.DealOpen();
            DisplayPlayerScreen();
        }
        public void DisplayNav()
        {
            System.Console.Clear();
            System.Console.WriteLine("                 BlackJack Table");
            System.Console.WriteLine("         Spacebar = Hit   Enter = Stay"); //Split = Backspace
            System.Console.WriteLine("\n\n\n");
        } //add w/l
        public void DisplayPlayerHand()
        {
            List<Card> hand = repo.GetPlayerHand();
            System.Console.Write("Player Hand: ");
            foreach (Card card in hand)
            {
                var value = ConvertValue(card.Value);
                System.Console.Write($"{value} {card.Suit}   ");
            }

        }
        public void DisplayDealerHand()
        {
            List<Card> hand = repo.GetDealerHand();
            System.Console.Write("Dealer Hand: ");
            foreach (Card card in hand)
            {
                var value = ConvertValue(card.Value);
                System.Console.Write($"{value} {card.Suit}   ");
            }
        }
        public void DisplayDealerUnknown()
        {
            List<Card> hand = repo.GetDealerHand();
            System.Console.Write("Dealer Hand: ");
            var value = ConvertValue(hand[0].Value);
            System.Console.Write($"{value} {hand[0].Suit}   Unknown ");
        }
        public void DisplayPlayerScreen()
        {
            DisplayNav();
            DisplayPlayerHand();
            System.Console.WriteLine("\n\n");
            DisplayDealerUnknown();
        }
        public void MainMenuLoop(ConsoleKey keyPress)
        {

        }
        public void DisplayPlayerBust()
        {
            DisplayNav();
            DisplayPlayerHand();
            System.Console.Write("BUST!");
            System.Console.WriteLine("\n\n");
            DisplayDealerUnknown();
            
        }
        public void DisplayPlayer21()
        {
            DisplayNav();
            DisplayPlayerHand();
            System.Console.Write("WINNER!");
            System.Console.WriteLine("\n\n");
            DisplayDealerUnknown();
        }
        public string ConvertValue(int value)
        {
            string valueString;
            switch (value)
            {
                case 11:
                    valueString = "J";
                    break;
                case 12:
                    valueString = "Q";
                    break;
                case 13:
                    valueString = "K";
                    break;
                default:
                    valueString = $"{value}";
                    break;

            }
            return valueString;
        }
        public ConsoleKey ChooseHitStay(ConsoleKey key)
        {
            ConsoleKey keyChoice = key;
            while (1 > 0)
            {
                switch (keyChoice)
                {
                    case ConsoleKey.Spacebar:
                        repo.DealPlayer();
                        switch (repo.CheckHand(repo.GetPlayerHand()))
                        {
                            case "21":
                                DisplayPlayer21();
                                return AskPlayAgain();
                            case "bust":
                                DisplayPlayerBust();
                                return AskPlayAgain();
                            default:
                                DisplayPlayerScreen();
                                keyChoice = System.Console.ReadKey().Key;
                                break;
                        }
                        break;
                    case ConsoleKey.Enter:
                        bool win = repo.DealerTurn();
                        DisplayWinLose(win);
                        return AskPlayAgain();
                    default:
                        System.Console.WriteLine("\n\nPlease select an action.");
                        keyChoice = System.Console.ReadKey().Key;
                        break;
                }
            }
        }
        public ConsoleKey AskPlayAgain()
        {
            repo.DiscardBothHands();
            System.Console.Write("\n\nPress Spacebar to play again.\nPress any other key to exit. ");
            return System.Console.ReadKey().Key;
        }
        public void DisplayWinLose(bool win)
        {
            DisplayNav();
            DisplayPlayerHand();
            System.Console.WriteLine("\n\n");
            DisplayDealerHand();
            System.Console.WriteLine("\n\n");
            if(win == true)
            {
                System.Console.WriteLine("     WINNER     WINNER     WINNER     WINNER     WINNER");
            }
            else
            {
                System.Console.WriteLine("                Better luck next time.");
            }
        }
    }
}

// Output Channel Consumer is operating with reduced functionality due to a missing dependency service: Microsoft.VisualStudio.Shell.OutputChannelStore (0.1).