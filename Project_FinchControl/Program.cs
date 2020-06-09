using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Velis, John
    // Dated Created: 05/31/2020
    // Last Modified: 06/  /2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayAppRatingScreen();
            DisplayClosingScreen();
        }

        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(myFinch);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(myFinch);
                        break;

                    case "c":
                        DisplayDisconnectFinchRobot(myFinch);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(myFinch);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance ");
                Console.WriteLine("\tc) Song ");
                Console.WriteLine("\td) All Together");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplaySong(myFinch);
                        break;

                    case "d":
                        DisplayAllTogether(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tEnter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayLightAndSound(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);
                myFinch.wait(50);
                myFinch.noteOff();
            }

            DisplayMenuPrompt("Talent Show Menu");
        }


        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                             *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDance(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its dancing skills!");
            DisplayContinuePrompt();

            for (int i = 0; i < 4; i++)
            {
                myFinch.setMotors(255, 255);
                myFinch.wait(1000);
                myFinch.setMotors(0, 0);
                myFinch.wait(100);
                myFinch.setMotors(255, -255);
                myFinch.wait(425);
                myFinch.setMotors(0, 0);
            }
            myFinch.noteOff();

            DisplayMenuPrompt("Talent Show Menu");
        }


        /// <summary>
        /// ****************************************************************
        /// *               Talent Show > Song                              *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplaySong(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Song");

            Console.WriteLine("\tThe Finch robot will now sing 'I Want It That Way' by the Backstreet Boys!");

            //** first verse **
            myFinch.noteOn(880);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(250);

            myFinch.noteOn(1047);
            myFinch.wait(1000);
            myFinch.noteOff();
            myFinch.wait(500);
            myFinch.noteOn(1319);
            myFinch.wait(500);

            myFinch.noteOn(880);
            myFinch.wait(750);
            myFinch.noteOn(784);
            myFinch.wait(250);
            myFinch.noteOn(784);
            myFinch.wait(500);
            myFinch.noteOn(880);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(250);

            myFinch.noteOn(1047);
            myFinch.wait(1000);
            myFinch.noteOff();
            myFinch.wait(500);
            myFinch.noteOn(1319);
            myFinch.wait(500);

            myFinch.noteOn(880);
            myFinch.wait(750);
            myFinch.noteOn(1175);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(500);
            myFinch.noteOn(880);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(250);

            myFinch.noteOn(1047);
            myFinch.wait(1250);
            myFinch.noteOn(1319);
            myFinch.wait(500);

            myFinch.noteOn(880);
            myFinch.wait(750);
            myFinch.noteOn(784);
            myFinch.wait(250);
            myFinch.noteOn(784);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(880);
            myFinch.wait(750);
            myFinch.noteOn(1047);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(500);
            myFinch.noteOn(1319);
            myFinch.wait(500);

            myFinch.noteOn(1175);
            myFinch.wait(500);
            myFinch.noteOn(1047);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(500);
            myFinch.noteOn(880);
            myFinch.wait(250);
            myFinch.noteOn(1047);
            myFinch.wait(250);

            DisplayContinuePrompt();
        }


        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > All Together                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayAllTogether(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("All Together");

            Console.WriteLine("\tThe Finch robot will now show off ALL its skills!");
            DisplayContinuePrompt();

            for (int i = 0; i < 4; i++)
            {
                myFinch.setLED(205, 20, 30);
                myFinch.wait(10);
                myFinch.setMotors(255, 255);
                myFinch.wait(1000);
                myFinch.setMotors(0, 0);
                myFinch.wait(100);
                myFinch.noteOn(750);
                myFinch.wait(1000);
                myFinch.noteOff();
                myFinch.setMotors(255, -255);
                myFinch.wait(425);
                myFinch.setMotors(0, 0);
                myFinch.setLED(20, 120, 73);
                myFinch.wait(250);
            }
           

            DisplayMenuPrompt("Talent Show Menu");
        }



        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            myFinch.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch myFinch)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = myFinch.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            string userName;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();
            Console.WriteLine("Please enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine($"Welcome {userName}!");

            DisplayContinuePrompt();
        }


        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// *****************************************************************
        /// *                        App Rating                             *
        /// *****************************************************************
        /// </summary>
        static void DisplayAppRatingScreen()
        {
            Console.CursorVisible = false;
            string userResponse;
            int rating;
            bool validResponse;

            Console.Clear();
            Console.WriteLine("\t\tApp Rating");
            Console.WriteLine("Do you want to rate your experience?");
            userResponse = Console.ReadLine();
            if (userResponse == "yes" || userResponse == "yep")
            {
                do
                {
                    Console.WriteLine("Please rate your experience with the application!");
                    Console.WriteLine("0-5 scale");
                    userResponse = Console.ReadLine();
                    validResponse = int.TryParse(userResponse, out rating);

                } while (!validResponse);
                Console.WriteLine();
                Console.WriteLine($"Thank you for giving this application a {rating}.");
            }
            else
            {
                Console.WriteLine("That's okay, maybe next time.");
            }

            DisplayContinuePrompt();
        }

            #endregion
        }
}
#endregion