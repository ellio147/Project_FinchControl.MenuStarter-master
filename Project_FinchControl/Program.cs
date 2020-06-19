using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using HidSharp.ReportDescriptors.Units;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Elliott, Kelsi
    // Dated Created: 05/31/2020
    // Last Modified: 06/14/2020
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
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Light Alarm System");
                Console.WriteLine("\te) User Programming");
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
                        DisplayDataRecorderMenuScreen(myFinch);
                        break;

                    case "d":
                        DisplayLightAlarmMenuScreen(myFinch);
                        break;

                    case "e":

                        break;

                    case "f":
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
        /// *****************************************************************
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
        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                    Data Recorder Menu                         *
        /// *****************************************************************
        static void DisplayDataRecorderMenuScreen(Finch myFinch)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points ");
                Console.WriteLine("\tc) Get Data ");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myFinch);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures, numberOfDataPoints);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tEnter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }


        static void DataRecorderDisplayData(double[] temperatures, int numberOfDataPoints)
        {
            string userResponse;
            DisplayScreenHeader("Show Temperature Data");

            DataRecorderDisplayTable(temperatures);

            Console.WriteLine("Would you like to see other temperature data?");
            userResponse = Console.ReadLine();

            if (userResponse == "yes" || userResponse == "Yes" )
            {
                DataRecorderDisplayTemperatureData(temperatures, numberOfDataPoints);
            }

            DisplayContinuePrompt();
        }

        static double[] DataRecorderDisplayTemperatureData(double[] temperatures, int numberOfDataPoints)
        {
            DisplayScreenHeader("Temperature Data");

            double sum = 0;
            double average = sum / numberOfDataPoints;

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                sum += temperatures[i];
            }

            double averageF = ((average * 9) / 5) + 32;

            Console.WriteLine();
            Console.WriteLine($"The sum of the temperatures is {sum}.");
            Console.WriteLine($"The average temperature in Celcius is {average.ToString("n2")}.");
            Console.WriteLine($"The average temperature in Fahrenheit is {averageF.ToString("n2")}.");
            

            DisplayContinuePrompt();
            return temperatures;

        }

        static double[] DataRecorderDisplayTable(double[] temperatures)
        {
            //
            //display table headers
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temperature".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );

            //
            //display table data
            //
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine(
                    (i + 1).ToString().PadLeft(15) +
                    temperatures[i].ToString("n2").PadLeft(15)
                    );
            }
            return temperatures;
            
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myFinch)
        {
            double[] temperatures = new double[numberOfDataPoints];
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"\tData Point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot is ready to begin recording the temperature data!");
            DisplayContinuePrompt();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = myFinch.getTemperature();
                Console.WriteLine($"\tReading {i + 1}: {temperatures[i].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                myFinch.wait(waitInSeconds);
            }

            DisplayContinuePrompt();

            bool validResponse;
            string userResponse;
            do
            {
                validResponse = true;

                Console.WriteLine("Would you like to see the data in a table?");
                userResponse = Console.ReadLine();

                if (userResponse == "yes" || userResponse == "Yes")
                {
                    DisplayScreenHeader("Get Data");
                    Console.WriteLine();
                    Console.WriteLine("\t Table of Temperatures");
                    Console.WriteLine();
                    DataRecorderDisplayTable(temperatures);
                }

                else
                {
                    Console.WriteLine("Okay. No table of temperatures will be displayed.");
                }
            } while (!validResponse);

            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// get the frequency of data points from the user
        /// </summary>
        /// <returns> frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("\tFrequency of Data Points");

            do
            {
                validResponse = true;

                Console.Write("Enter frequency of data points you want to record: ");
                userResponse = Console.ReadLine();

                if (!double.TryParse(userResponse, out dataPointFrequency))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number for data point frequency." +
                    "Please enter a positive number.");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);

            Console.WriteLine($"Data points will be collected every {dataPointFrequency} second(s).");

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// get # of data points from user
        /// </summary>
        /// <returns> returns # of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                validResponse = true;

                Console.Write("Enter number of data points you want to record: ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out numberOfDataPoints))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number of data points." + 
                    "Please enter a positive integer.");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);

            Console.WriteLine($"{numberOfDataPoints} data points will be collected.");


            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                     Light Alarm Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayLightAlarmMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;
            int temperatureMinMaxThresholdValue = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tf) Set Temperature Minimum/maximum Threshold Value");
                Console.WriteLine("\tg)Temperature and Light Monitoring");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmDisplaySetMinMaxThresholdValue(rangeType, myFinch);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmDisplaySetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmDisplaySetAlarm(sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor, myFinch);
                        break;

                    case "f":
                        temperatureMinMaxThresholdValue = LightAlarmDisplayTemperatureMinMaxThresholdValue(rangeType);
                        break;

                    case "g":
                        LightAlarmDisplayTemperatureMonitoring(sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor, temperatureMinMaxThresholdValue, myFinch);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tEnter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static int LightAlarmDisplayTemperatureMinMaxThresholdValue(string rangeType)
        {
            int temperatureMinMaxThresholdValue;

            DisplayScreenHeader("\tTemperature Minimum/Maximum Threshold Value");

            bool validResponse;
            string userResponse;
            do
            {
                validResponse = true;

                Console.Write($"\tEnter the {rangeType} temperature value: ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out temperatureMinMaxThresholdValue))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number for the temperature value.");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);

            Console.WriteLine($"\tYou will be collecting a {rangeType} range type value of {temperatureMinMaxThresholdValue}.");

            DisplayContinuePrompt();
            return temperatureMinMaxThresholdValue;
        }
        static void LightAlarmDisplayTemperatureMonitoring(
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdValue, 
            int timeToMonitor,
            int temperatureMinMaxThresholdValue,
            Finch myFinch)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;
            double currentTemperature = 0;

            DisplayScreenHeader("Set Alarm for Temperature and Light");

            Console.WriteLine($"\tSensors to Monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange Type: {rangeType}");
            Console.WriteLine($"\tLight Min/Max Threshold Value: {minMaxThresholdValue}");
            Console.WriteLine($"\tTemperature Min/Max Threshold Value: {temperatureMinMaxThresholdValue}");
            Console.WriteLine($"\tTime to Monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = myFinch.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = myFinch.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (myFinch.getRightLightSensor() + myFinch.getRightLightSensor()) / 2;
                        break;
                }

                currentTemperature = myFinch.getTemperature();

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue || currentTemperature < temperatureMinMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue || currentTemperature > temperatureMinMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                myFinch.wait(1000);
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                myFinch.setLED(0, 0, 300);
                for (int i = 0; i < 5; i++)
                {
                    myFinch.noteOn(1000);
                    myFinch.wait(500);
                    myFinch.noteOff();
                }
                Console.WriteLine($"\tThe {rangeType} threshold value was exceeded by the current light sensor value of {currentLightSensorValue}");
                DisplayContinuePrompt();
                myFinch.setLED(0, 0, 0);
            }

            else
            {
                myFinch.setLED(0, 300, 0);
                for (int i = 0; i < 5; i++)
                {
                    myFinch.noteOn(1470);
                    myFinch.wait(500);
                    myFinch.noteOff();
                }
                Console.WriteLine($"\tThe {rangeType}  light threshold value of {currentLightSensorValue} and " +
                    "{temperatureRangeType} temperature threshold value of {currentTemperatureValue} was not exceeded.");
            }

            DisplayMenuPrompt("Light Alarm");
        }

        static void LightAlarmDisplaySetAlarm(
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdValue, 
            int timeToMonitor, 
            Finch myFinch)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to Monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange Type: {rangeType}");
            Console.WriteLine($"\tMin/Max Threshold Value: {minMaxThresholdValue}");
            Console.WriteLine($"\tTime to Monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = myFinch.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = myFinch.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (myFinch.getRightLightSensor() + myFinch.getRightLightSensor()) / 2;
                        break;
                }
                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                myFinch.wait(1000);
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                myFinch.setLED(300, 0, 0);
                for (int i = 0; i < 5; i++)
                {
                    myFinch.noteOn(800);
                    myFinch.wait(250);
                    myFinch.noteOff();
                }
                Console.WriteLine($"\tThe {rangeType} threshold value was exceeded by the current light sensor value of {currentLightSensorValue}");
                DisplayContinuePrompt();
                myFinch.setLED(0, 0, 0);
            }

            else
            {
                Console.WriteLine($"\tThe {rangeType} threshold value of {currentLightSensorValue} was not exceeded.");
            }

            DisplayMenuPrompt("Light Alarm");
        }

        static int LightAlarmDisplaySetTimeToMonitor()
        {
            int timeToMonitor;

            DisplayScreenHeader("\tTime to Monitor");

            bool validResponse;
            string userResponse;
            do
            {
                validResponse = true;

                Console.Write($"\tEnter the amount of time to monitor [in seconds]: ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out timeToMonitor))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number for the amount of time to monitor." +
                    "Please enter a positive number.");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);

            Console.WriteLine($"\tYou will be collecting data for {timeToMonitor} seconds.");

            DisplayMenuPrompt("Light Alarm");
            return timeToMonitor;
        }

        static int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch myFinch)
        {
            int minMaxThresholdValue;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine($"Left light sensor ambient value: {myFinch.getLeftLightSensor()} ");
            Console.WriteLine($"Right light sensor ambient value: {myFinch.getRightLightSensor()} ");
            Console.WriteLine();

            bool validResponse;
            string userResponse;
            do
            {
                validResponse = true;

                Console.Write($"\tEnter the {rangeType} light sensor value: ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out minMaxThresholdValue))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number for the light sensor value." +
                    "Please enter a positive number.");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);

            Console.WriteLine($"\tYou will be collecting a {rangeType} range type value of {minMaxThresholdValue}.");


            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Sensors to Monitor");

            Console.WriteLine("\tSensors to monitor [left, right, both]:");
            sensorsToMonitor = Console.ReadLine();

            Console.WriteLine($"You will be monitoring from (the) {sensorsToMonitor} sensor(s).");

            DisplayMenuPrompt("Light Alarm");
            return sensorsToMonitor;
        }

        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Range Type");

            Console.WriteLine("\tRange Type [minimum, maximum]:");
            rangeType = Console.ReadLine();

            Console.WriteLine($"You will be collecting the {rangeType} range type.");

            DisplayMenuPrompt("Light Alarm");
            return rangeType;
        }

        #endregion

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
