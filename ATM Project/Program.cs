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
            CardGuessMethod();

            PinGuessMethod();
        }

        public static void CardGuessMethod()
        {
            string cardNumber = "1111 1111";
            string cardNumberGuess = "";

            while (cardNumberGuess != cardNumber)
            {
                Console.Write("Enter your card Number: ");
                cardNumberGuess = Console.ReadLine();

                if(cardNumberGuess != cardNumber)
                {
                    Console.WriteLine("Card Invalid");
                    Console.WriteLine("Please Enter a valid Card");
                    Console.ReadLine();
                }
            }
        }

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

                if (functions == "Withdraw")
                {
                    WithdrawMoney();
                    break;
                }
                else if (functions == "Withdraw")
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
            Random random = new Random();

            int balanceInt = random.Next(1000, 10000);

            Console.WriteLine("You have $" + balanceInt + "!");

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
