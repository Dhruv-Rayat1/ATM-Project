﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start the Program
            CardNewMethod();

            PinGuessMethod();
        }

        public static void CardNewMethod()
        {
            // Instattiates the class
            Cards card = new Cards();

            Console.Write("Existing account or New Account: ");
            string newAccOrNew = Console.ReadLine();

            // This is a loop that iterates tnrough itself to make sure no funny buisness happens
            while (true)
            {
                if (newAccOrNew == "New Account")
                {
                    Console.Write("Please enter your new Card Number: ");
                    card.Card1 = Console.ReadLine();

                    Console.Write("Please enter your new Pin: ");
                    card.Pin1 = Console.ReadLine();

                    Console.WriteLine("Your Account has been Created");
                    Console.WriteLine(card.GetFullAccount());
                    Console.ReadLine();

                    CardGuessMethod();
                }
                else if (newAccOrNew == "Existing Account")
                {
                    CardGuessMethod();
                }
                else
                {
                    Console.WriteLine("Choose one of the options");
                }
            }
        }

        // Card Guess Method, this gives you access to each Card
        public static void CardGuessMethod()
        {
            // Instantiating Class
            Cards card = new Cards();

            string cardNumber = "1111 1111";
            string cardNumberGuess;

            string cardNumberGuess1 = card.Card1;

            while (true)
            {
                Console.Write("Enter your card Number: ");
                cardNumberGuess = Console.ReadLine();

                if(cardNumberGuess == cardNumber)
                {
                    PinGuessMethod();
                }
                else if (cardNumberGuess == cardNumberGuess1)
                {
                    PinGuessMethod();
                }
                else
                {
                    Console.WriteLine("Card Invalid");
                    Console.WriteLine("Please Enter a valid Card");
                    Console.ReadLine();
                }
            }
        }

        // Pin guess makes sure you know the pin before you are given access
        public static void PinGuessMethod()
        {
            string pin = "12345";
            string pinGuess = "";

            while (pinGuess != pin)
            {
                Console.Write("Enter your Pin Number: ");
                pinGuess = Console.ReadLine();

                if (pinGuess == pin)
                {
                    MethodsBank();
                }
                else if (pinGuess != pin)
                {
                    for (int pinGuesses = 0; pinGuesses < 10; pinGuesses++)
                    {
                        Console.Write("Enter your Pin Number: ");
                        pinGuess = Console.ReadLine();

                        if (pinGuess == pin)
                        {
                            MethodsBank();
                        } else if (pinGuess != pin)
                        {
                            Console.WriteLine("You have been locked out");
                            Console.ReadLine();

                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        public static void MethodsBank()
        {
            string functions;

            string[] lines = { "Withdraw", "Transfer", "Balance", "History", "Log out" };

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Withdraw, Transfer, Balance, History or Log out");
                Console.Write("Please write here: ");
                functions = Console.ReadLine();

                if (functions == "Withdraw" && functions == "withdraw")
                {
                    WithdrawMoney();
                    break;
                }
                else if (functions == "Transfer")
                {
                    TransferMoney();
                    break;
                }
                else if (functions == "Balance")
                {
                    Balance();
                    break;
                }
                else if (functions == "History")
                {
                    History();
                    break;
                }
                else if (functions == "Log out")
                {
                    Console.WriteLine("Thanks for Banking with us");
                    Console.WriteLine("Press enter to log out.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please write one of the options.");
                }
            }
        }

        public static void WithdrawMoney()
        {
            int withDrawnMoney;

            Console.Write("How much money would you like to Withdraw: ");
            withDrawnMoney = Convert.ToInt32(Console.ReadLine());

            if (withDrawnMoney >= 1000)
            {
                Console.WriteLine("Error 20182: Invalid ammount withdraw has to be less that $1000");
                WithdrawMoney();
            }
            else
            {
                Console.WriteLine("You have Withdrawn " + withDrawnMoney + " dollars!");
                MethodsBank();
            }
        }

        public static void TransferMoney()
        {
            int transfer;

            Console.Write("How much money would you like to Transfer: ");
            transfer = Convert.ToInt32(Console.ReadLine());

            if (transfer >= 1000)
            {
                Console.WriteLine("Error 20182: Invalid ammount transfer has to be less that $1000");
                TransferMoney();
            } else
            {
                Console.WriteLine("You have Transfered " + transfer + " dollars!");
                MethodsBank();
            }
        }

        public static void Balance()
        {
            Balance balance = new Balance();

            Console.WriteLine("You have $" + balance.balance + "!");

            Console.ReadLine();
            MethodsBank();
        }

        public static void History()
        {
            String line;

            try 
            {
                StreamReader sr = new StreamReader("C:\\Users\\dhruv\\Desktop\\Visual Studio 2022\\ATM Project\\History.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }   
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            } 
        }
    }
}
