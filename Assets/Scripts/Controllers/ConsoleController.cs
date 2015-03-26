using UnityEngine;
using System.Collections;

public class ConsoleController : MonoBehaviour
{

    private bool isConsole = false;
    private bool isDebug = false;
    private bool userHasHitReturn = false;
    private string currentCommand = "";
    private int currentPastCommand = -1;
    private string[] pastCommands = new string[20];


    // Use this for initialization
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown && (Event.current.keyCode.ToString().Equals("Tab")))
        {
            isConsole = isConsole ? false : true;
            if (!isConsole)
            {
                currentCommand = "";
                currentPastCommand = -1;
            }
        }

        if (isConsole)
        {
            if (Event.current.type == EventType.KeyDown && Event.current.keyCode.ToString().Equals("UpArrow"))
            {
                if (pastCommands [currentPastCommand + 1] != null)
                {
                    currentPastCommand += 1;
                    currentCommand = pastCommands [currentPastCommand];
                }
            } else  if (Event.current.type == EventType.KeyDown && Event.current.keyCode.ToString().Equals("DownArrow"))
            {
                if (currentPastCommand <= 0)
                {
                    currentCommand = "";
                    currentPastCommand = -1;
                } else  if (pastCommands [currentPastCommand - 1] != null)
                {
                    currentPastCommand -= 1;
                    currentCommand = pastCommands [currentPastCommand];
                } 
            }
            GUI.SetNextControlName("MyTextField");
            currentCommand = GUI.TextField(new Rect(10, 10, 500, 20), currentCommand);
            GUI.FocusControl("MyTextField");

            if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
            {
                ParseCommand();
                isConsole = false;
                PushCommand();
                currentCommand = "";
                currentPastCommand = -1;

            }

        } else if(isDebug)
        {

            GUI.Box(new Rect(10, 10, 500, 20), MenuTools.delay.ToString());
        }

    }

    private void ParseCommand()
    {
        switch (currentCommand.Split(' ')[0])
        {
            case "goto":
                LoadRoom();
                break;
            case "menu":
                Application.LoadLevel("MainMenu");
                break;
            case "quit":
                Debug.Log("Quitting");
                Application.Quit();
                break;
            case "debug":
                isDebug = isDebug ? false : true;
                break;
            case "clearAchievements":
                AchievementController.ResetAchievements();
                break;
            case "":
                break;
            default:
                Debug.Log("That command does not exist");
                break;
        }
    }

    private void LoadRoom() {
        switch (currentCommand.Split(' ') [1])
        {
            case "diorama":
                Application.LoadLevel("HarveyWithLighting");
                break;
            case "textilesRoom":
                Application.LoadLevel("1950_TextileRoom");
                break;
            case "list":
                Debug.Log("diorama" +
                          "\ntextilesRoom");
                break;
            default:
                Debug.Log("That scene does not exist");
                break;
        }
    }

    private void PushCommand() {
        if (!currentCommand.Equals(""))
        {
            for (int i = pastCommands.Length-2; i >= 0; i--)
            {
                if (pastCommands [i] != null)
                {
                    pastCommands [i + 1] = pastCommands [i];
                }
            }
            pastCommands [0] = currentCommand;
        }
    }
}