using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker2 : MonoBehaviour
{
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win, Over };
	Screen currentScreen;
    string password;

	// Start is called before the first frame update
	void Start()
	{
		Terminal.ClearScreen();
		ShowMainMenu();

	}
	void ShowMainMenu()
	{
		currentScreen = Screen.MainMenu;
		Terminal.WriteLine("What would you like to hack into?");
		Terminal.WriteLine("");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for NASA");
		Terminal.WriteLine("");
		Terminal.WriteLine("Enter your selection: ");

	}

	void OnUserInput(string input)
	{
        if (input == "menu") // always go to main menu
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Restart(input);
        }
	}
    void RunMainMenu(string input)
	{
        if (input == "1")
		{
			level = 1;
            password = "book";
			StartGame();
		}
		else if (input == "2")
		{
			level = 2;
            password = "jail";
            StartGame();
		}
		else if (input == "3")
		{
			level = 3;
            password = "moon";
            StartGame();
		}
		else if (input == "007")
		{
			Terminal.ClearScreen();
			currentScreen = Screen.MainMenu;
			Terminal.WriteLine("Welcome Mr. Bond");
			ShowMainMenu();
		}
		else
		{
			currentScreen = Screen.MainMenu;
			Terminal.WriteLine("Self Destruct Mode Initiated");
		}
	}

	void StartGame()
	{
        currentScreen = Screen.Password;
		Terminal.WriteLine("You have chosen " + level);
        Terminal.WriteLine("Please enter password: ");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.ClearScreen();
            currentScreen = Screen.Win;
            Terminal.WriteLine("Well Done");
            Terminal.WriteLine("Would you like to hack into another station? Type yes to continue");
        }
        else
        {
            Terminal.WriteLine("Wrong Password. Try again");
        }
    }


    void Restart(string input)
    {
        if (input == "yes")
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (input == "no")
        {
            currentScreen = Screen.Over;
            Terminal.ClearScreen();
            Terminal.WriteLine("Well then, fuck right off");
        }

    }
	// Update is called once per frame
	void Update()
	{

	}
}
