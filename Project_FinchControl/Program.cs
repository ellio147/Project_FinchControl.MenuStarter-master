﻿using FinchAPI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project_FinchControl
{
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        TEMPANDLIGHT,
        SONGANDDANCE,
        DONE
    }

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
            DisplayLoginRegister();
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

        // *****************************************************************
        // *                          Main Menu                            *
        // *****************************************************************
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
                Console.WriteLine("\tf) Change Theme");
                Console.WriteLine("\tg) Disconnect Finch Robot");
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
                        DisplayUserProgrammingMenuScreen(myFinch);
                        break;

                    case "f":
                        DisplaySetTheme();
                        break;

                    case "g":
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
                Console.WriteLine("\te) Write Data to File");
                Console.WriteLine("\tf) Read Data from File");
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

                    case "e":
                        DataRecorderWriteDataToFile(myFinch);
                        break;

                    case "f":
                        DataRecorderReadDataFromFile();
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

        static void DataRecorderReadDataFromFile()
        {
            string temperature;
            string light;
            string timeStamp;
            bool validData = true;

            do
            {
                DisplayScreenHeader("Read Data From File");

                Console.WriteLine();
                Console.WriteLine("\tEnter temperature:");
                temperature = Console.ReadLine();
                Console.WriteLine("\tEnter light senor value:");
                light = Console.ReadLine();
                Console.WriteLine("\tEnter time stamp");
                timeStamp = Console.ReadLine();

                validData = IsValidDataSet(temperature, light, timeStamp);

                Console.WriteLine();

                if (validData)
                {
                    Console.WriteLine("You have entered a valid data set!");
                }

                else
                {
                    Console.WriteLine("Invalid data combination.");
                    Console.WriteLine("Please try again.");
                }
                DisplayContinuePrompt();
            } while (!validData);
        }
        static List<(string temperature, string light, string timeStamp)> DataRecorderReadDataFile()
        {
            string dataPath = @"Data/TempAndLight.txt";

            string[] dataCollectedArray;
            (string temperature, string light, string timeStamp) dataCollectedTouple;

            List<(string temperature, string light, string timeStamp)> collectedData =
                new List<(string temperature, string light, string timeStamp)>();

            dataCollectedArray = File.ReadAllLines(dataPath);

            foreach (string loginInfoText in dataCollectedArray)
            {
                dataCollectedArray = loginInfoText.Split(',');

                dataCollectedTouple.temperature = dataCollectedArray[0];
                dataCollectedTouple.light = dataCollectedArray[1];
                dataCollectedTouple.timeStamp = dataCollectedArray[2];

                collectedData.Add(dataCollectedTouple);
            }

            return collectedData;
        }
        static bool IsValidDataSet(string temperature, string light, string timeStamp)
        {
            List<(string temperature, string light, string timeStamp)> collectedData = 
                new List<(string temperature, string light, string timeStamp)>();
            bool validData = false;

            collectedData = DataRecorderReadDataFile();
            
            foreach ((string temperature, string light, string timeStamp) tempAndLightInfo in collectedData)
            {
                if ((tempAndLightInfo.temperature == temperature) && (tempAndLightInfo.light == light) && (tempAndLightInfo.timeStamp == timeStamp))
                {
                    validData = true;
                    Console.WriteLine("You have entered a valid data set.");
                    break;
                }

                else
                {
                    Console.WriteLine("The data you have input is not in the system.");
                }
            }

            return validData;
        }
        static void DataRecorderWriteDataToFile(Finch myFinch)
        {
            string dataPath = @"Data/TempAndLight.txt";
            string temperatureAndLightInfo;
            double temperature2;
            string temperature;
            double light2;
            string light;
            string timeStamp;

            Console.Clear();
            Console.WriteLine("Press any key to begin data collection.");
            Console.ReadKey();
            temperature2 = myFinch.getTemperature();
            temperature = temperature2.ToString("n2");
            light2 = (myFinch.getRightLightSensor() + myFinch.getLeftLightSensor()) / 2;
            light = light2.ToString("n2");
            timeStamp = DateTime.Now.ToString("t");

            temperatureAndLightInfo = temperature + "," + light + ',' + timeStamp;

            Console.WriteLine($"Temperature: {temperature}");
            Console.WriteLine($"Light: {light}");
            Console.WriteLine($"Time: {timeStamp}");

            DisplayContinuePrompt();

            File.AppendAllText(dataPath, temperatureAndLightInfo);
        }

        static void DataRecorderDisplayData(double[] temperatures, int numberOfDataPoints)
        {
            string userResponse;
            DisplayScreenHeader("Show Temperature Data");

            DataRecorderDisplayTable(temperatures);

            Console.WriteLine("Would you like to see other temperature data?");
            userResponse = Console.ReadLine();

            if (userResponse == "yes" || userResponse == "Yes")
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
                Console.WriteLine($"\tThe {rangeType} light threshold value of {currentLightSensorValue} or " +
                    $"{rangeType} temperature threshold value of {currentTemperature} was exceeded.");
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
                Console.WriteLine($"\tThe {rangeType} light threshold value of {currentLightSensorValue} or " +
                    $"{rangeType} temperature threshold value of {currentTemperature} was not exceeded.");
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
                        currentLightSensorValue = (myFinch.getRightLightSensor() + myFinch.getLeftLightSensor()) / 2;
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

        #region USER PROGRAMMING

        /// <summary>
        /// *****************************************************************
        /// *                  User Programming Menu                        *
        /// *****************************************************************
        /// </summary>
        static void DisplayUserProgrammingMenuScreen(Finch myFinch)
        {
            string menuChoice;
            bool quitUserProgrammingMenu = false;

            //tuple
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                // get user menu choice
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplaySetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(commands, commandParameters, myFinch);
                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tEnter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;

                }

            } while (!quitUserProgrammingMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *          User Programming > Set Command Parameters            *
        /// *****************************************************************
        /// </summary>
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplaySetCommandParameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            GetValidInteger("\tEnter Motor Speed [1 - 255]:", 1, 255, out commandParameters.motorSpeed);
            GetValidInteger("\tEnter LED Brightness [1 - 255]:", 1, 25, out commandParameters.ledBrightness);
            GetValidDouble("\t Enter Wait [in seconds]:", 0, 10, out commandParameters.waitSeconds);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait Command Duration [in seconds]: {commandParameters.waitSeconds}");


            DisplayMenuPrompt("User Programming");
            return commandParameters;
        }

        // methods to get info
        static void GetValidDouble(string v1, int v2, int v3, out double waitSeconds)
        {
            bool validResponse;
            string userResponse;

            do
            {
                validResponse = true;

                Console.WriteLine(v1);
                userResponse = Console.ReadLine();
                Console.WriteLine();

                if (!double.TryParse(userResponse, out waitSeconds))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number." +
                    $"Please {v1}");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);
        }
        static void GetValidInteger(string v1, int v2, int v3, out int motorSpeed)
        {
            bool validResponse;
            string userResponse;

            do
            {
                validResponse = true;
                Console.WriteLine(v1);
                userResponse = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(userResponse, out motorSpeed))
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine("It appears you have entered an invalid number." +
                    $"Please {v1}");

                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!validResponse);
        }
        //

        /// <summary>
        /// *****************************************************************
        /// *              User Programming > Add Commands                  *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            //list commands
            int commandCount = 1;
            Console.WriteLine("\tList of Availible Commands");
            Console.WriteLine();
            Console.WriteLine("\t-");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.WriteLine($"\t- {commandName}");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.WriteLine("\tEnter Command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }

                else
                {
                    Console.WriteLine("\t\t***********************************************");
                    Console.WriteLine("\t\t* Please enter a command form the list above. *");
                    Console.WriteLine("\t\t***********************************************");
                }
            }
        }

        /// <summary>
        /// *****************************************************************
        /// *              User Programming > View Commands                 *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// *****************************************************************
        /// *            User Programming > Execute Commands                *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayExecuteFinchCommands(
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters,
            Finch myFinch)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedBack = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute finch Commands");

            Console.WriteLine($"The Finch Robot is ready to execute its list of commands.");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        commandFeedBack = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        myFinch.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedBack = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        myFinch.setMotors(0, 0);
                        commandFeedBack = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        myFinch.wait(waitMilliSeconds);
                        commandFeedBack = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        myFinch.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedBack = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        myFinch.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedBack = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        myFinch.setLED(ledBrightness, ledBrightness,
                            ledBrightness);
                        commandFeedBack = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        myFinch.setLED(0, 0, 0);
                        commandFeedBack = Command.LEDOFF.ToString();
                        break;

                    case Command.TEMPANDLIGHT:
                        commandFeedBack = $"Temperature: {myFinch.getTemperature().ToString("n2")}\n & " +
                            $"Light Sensor Value: {(myFinch.getRightLightSensor() + myFinch.getRightLightSensor()) / 2}";
                        break;

                    case Command.SONGANDDANCE:
                        myFinch.noteOn(880);
                        myFinch.wait(250);
                        myFinch.noteOn(1047);
                        myFinch.wait(250);

                        myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        myFinch.wait(waitMilliSeconds);
                        myFinch.setMotors(0, 0);
                        myFinch.wait(300);
                        myFinch.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        myFinch.wait(500);
                        myFinch.setMotors(0, 0);
                        myFinch.setLED(0, 0, 0);


                        myFinch.noteOn(1047);
                        myFinch.wait(1000);
                        myFinch.noteOff();
                        myFinch.wait(500);
                        myFinch.noteOn(1319);
                        myFinch.wait(500);

                        myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        myFinch.wait(waitMilliSeconds);
                        myFinch.setMotors(0, 0);
                        myFinch.wait(300);
                        myFinch.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        myFinch.wait(300);
                        myFinch.setMotors(0, 0);
                        myFinch.setLED(0, 0, 0);

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

                        myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        myFinch.wait(waitMilliSeconds);
                        myFinch.setMotors(0, 0);
                        myFinch.wait(500);
                        myFinch.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        myFinch.wait(500);
                        myFinch.setMotors(0, 0);
                        myFinch.setLED(0, 0, 0);

                        myFinch.noteOn(1047);
                        myFinch.wait(1000);
                        myFinch.noteOff();
                        myFinch.wait(500);
                        myFinch.noteOn(1319);
                        myFinch.wait(500);
                        myFinch.noteOff();

                        myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        myFinch.wait(waitMilliSeconds);
                        myFinch.setMotors(0, 0);
                        myFinch.wait(300);
                        myFinch.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        myFinch.wait(500);
                        myFinch.setMotors(0, 0);
                        myFinch.setLED(0, 0, 0);
                        commandFeedBack = Command.SONGANDDANCE.ToString();
                        break;

                    case Command.DONE:
                        break;

                    default:

                        break;
                }

                Console.WriteLine($"\t{commandFeedBack}");
            }

            DisplayMenuPrompt("User Programming");
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
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

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
            Console.WriteLine("Do you want to rate your experience? [yes || no]");
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

        #region THEME MENU

        // *****************************************************************
        // *                            Set Theme                          *
        // *****************************************************************
        static void DisplaySetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;

            //current theme
            themeColors = ReadThemeData();
            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            Console.Clear();

            DisplayScreenHeader("Set Application Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.WriteLine("\t would you like to change te current theme? [yes || no]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    //set new theme
                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();

                    DisplayScreenHeader("Set Application Theme");

                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.WriteLine("\tIs this the theme you would like?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        WriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);
                    }
                } while (!themeChosen);
            }

        }

        // *****************************************************************
        // *                        Get Colors From User                   *
        // *****************************************************************
        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.WriteLine($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\t*****It appears you have entered an invalid console color selection. Please try again.*****\n");
                }

                else
                {
                    validConsoleColor = true;
                }

            } while (!validConsoleColor);

            return consoleColor;
        }

        // *****************************************************************
        // *                         Read Theme Data                       *
        // *****************************************************************
        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeData()
        {
            string dataPath = @"Data\Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            themeColors = File.ReadAllLines(dataPath);

            Enum.TryParse(themeColors[0], true, out foregroundColor);
            Enum.TryParse(themeColors[1], true, out backgroundColor);

            return (foregroundColor, backgroundColor);
        }

        // *****************************************************************
        // *                        Write Theme Data                       *
        // *****************************************************************
        static void WriteThemeData(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";

            File.WriteAllText(dataPath, foreground.ToString() + "\n");
            File.AppendAllText(dataPath, background.ToString());
        }
        #endregion

        #region LOGIN
        // *****************************************************************
        // *                       Login/Register Screen                   *
        // *****************************************************************
        static void DisplayLoginRegister()
        {
            DisplayScreenHeader("Login/Register");

            Console.WriteLine("\tAre you a registered user? [yes \\ no]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                DisplayLogin();
            }

            else
            {
                DisplayRegisterUser();
                DisplayLogin();
            }
        }

        // *****************************************************************
        // *                          Login Screen                         *
        // *****************************************************************
        static void DisplayLogin()
        {
            string userName;
            string password;
            bool validLogin;

            do
            {
                DisplayScreenHeader("Login");

                Console.WriteLine();
                Console.WriteLine("\tEnter username:");
                userName = Console.ReadLine();
                Console.WriteLine("\tEnter password:");
                password = Console.ReadLine();

                validLogin = IsValidLoginInfo(userName, password);

                Console.WriteLine();

                if (validLogin)
                {
                    Console.WriteLine("You are now logged in!");
                }

                else
                {
                    Console.WriteLine("Invalid username and password combination.");
                    Console.WriteLine("Please try again.");
                }
                DisplayContinuePrompt();
            } while (!validLogin);
        }

        // *****************************************************************
        // *                        Register Screen                        *
        // *****************************************************************
        static void DisplayRegisterUser()
        {
            string userName;
            string password;

            DisplayScreenHeader("Register");

            Console.WriteLine("\t Enter your username:");
            userName = Console.ReadLine();
            Console.WriteLine("\t Enter your password:");
            password = Console.ReadLine();

            WriteLoginInfoData(userName, password);

            Console.WriteLine();
            Console.WriteLine("You have entered the following information and it has been saved.");
            Console.WriteLine($"Username: {userName}");
            Console.WriteLine($"Password: {password}");

            DisplayContinuePrompt();
        }

        // *****************************************************************
        // *                      Save Login Information                   *
        // *****************************************************************
        static void WriteLoginInfoData(string userName, string password)
        {
            string dataPath = @"Data/Logins.txt";
            string loginInfoText;

            loginInfoText = userName + "," + password;

            File.AppendAllText(dataPath, loginInfoText);
        }

        // *****************************************************************
        // *                    Validating Login Info                      *
        // *****************************************************************
        static bool IsValidLoginInfo(string userName, string password)
        {
            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();
            bool validUser = false;

            registeredUserLoginInfo = ReadLoginInfoData();
                foreach ((string userName, string password) userLoginInfo in registeredUserLoginInfo)
                {
                    if ((userLoginInfo.userName == userName) && (userLoginInfo.password == password))
                    {
                        validUser = true;
                        break;
                    }
                }

            return validUser;
        }

        static List<(string userName, string password)> ReadLoginInfoData()
        {
            string dataPath = @"Data/Logins.txt";

            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();

            loginInfoArray = File.ReadAllLines(dataPath);

            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                loginInfoTuple.userName = loginInfoArray[0];
                loginInfoTuple.password = loginInfoArray[1];

                registeredUserLoginInfo.Add(loginInfoTuple);
            }

            return registeredUserLoginInfo;

        }

        #endregion
    }
}
