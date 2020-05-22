using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game State
    int level;
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    string password;


    // Use this for initialization
    void Start () {

        ShowMainMenu();
		
	} // TODO handle depending on screen

    void ShowMainMenu() {

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Police station");
        Terminal.WriteLine("Enter your selection:");

    }
	
	void OnUserInput(string input) {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPasswordSelection(input);
        }

    }

   

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame(1);

        }
        else if (input == "2")
        {
            level = 2;
            password = "government";
            StartGame(2);
        }
        else if (input == "3")
        {
            level = 3;
            StartGame(3);
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Choose the correct level Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Choose between 1 - 3");
        }
    }

    void StartGame(int level)
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Welcome to level " + level);
        Terminal.WriteLine("Please type the password:");
    }

    void RunPasswordSelection(string input)
    {
        if(input == password)
        {
            Terminal.WriteLine("Well Done");
        }
        else
        {
            Terminal.WriteLine("Wrong, try again please.");
        }
    }
}
