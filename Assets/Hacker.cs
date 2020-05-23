using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game State
    int level;
    string password;

    const string menu = "type menu to go home";

    // On screen
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    

    //Game passwords
    string[] level1_Pass = { "books", "study", "read", "letters" };
    string[] level2_Pass = { "brown", "kobe", "court", "raptors"};
    string[] level3_pass = { "abilities", "adventure", "begin", "announced", "candidate", "dependent" };


    // Use this for initialization
    void Start () {

        ShowMainMenu();
		
	} 

    void ShowMainMenu() {

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        
        //Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Basket Ball");
        Terminal.WriteLine("How good do you think you are? press 3");
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
            Terminal.WriteLine(menu);

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
            case 3:
                password = level3_pass[Random.Range(0, level3_pass.Length)];
                break;
            default:
                
                Debug.LogError("Invalid NUMBER");
                break;
        }

        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menu);

    }

    void RunPasswordSelection(string input)
    {
        if(input == password)
        {
            WinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        StartGame();
        
    }

 

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menu);


    }

    void ShowLevelReward()
    {
        
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"

      ______ ______ 
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\      
 //________.|.________\\     
`----------`-'----------'
"
                );
                
                break;
            case 2:
                Terminal.WriteLine("Look at this dunk you made (:");
                Terminal.WriteLine(@"

    o      |   __   |
      \_ O |  |__|  |
   ____/ \ |___WW___|
   __/   /     ||
               ||
               ||
_______________||________________
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"

You are the ultimate
███████____█████____██████__██████
██__████_█████████_███__██_███__██
██__████_████_████_████____████
███████__███___███__█████___█████
██__████_████_████_____███_____███
██__████__███████__███████_██████
███████____█████____█████___█████ 
woot woot, you can celebrate now!

"
                );
                break; 
            default:
                Debug.LogError("Invalid Level");
                break;

        }
    }
}
