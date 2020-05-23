
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game State
    int level;
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    string password;

    //Game passwords
    string[] level1_Pass = { "books", "study", "read", "letters" };
    string[] level2_Pass = { "theif", "jail", "sirens", "red", "blue"};


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

        bool isValid = ( input == "1" || input == "2" || input == "3" );

        if(isValid)
        {
            level = int.Parse(input);
            StartGame();
        }
       
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Choose the correct level Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Choose between 1 - 3");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        switch (level) // CLEAN UPPPP
        {
            case 1:
                password = level1_Pass[Random.Range(0, level1_Pass.Length)];
                break;
            case 2:
                password = level2_Pass[Random.Range(0, level2_Pass.Length)];
                break;
            default:
                
                Debug.LogError("Invalid NUMBER");
                break;
        }

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
