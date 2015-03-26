using UnityEngine;
using System.Collections;

public class Fadeometer : MonoBehaviour
{
    private int powState = 1;
    private int onOffState = 1;

    public static bool isPlaying = false;
    bool isHitting = false;
    float delay = 0;
   
    public GUIStyle knobLeftStyle;
    public GUIStyle knobRightStyle;
    public GUIStyle knobUpStyle;
    public GUIStyle knobDownStyle;

    GUIStyle timeKnob;

    private bool faded = false;

    public Texture2D baseTexture;
    public Texture2D timeSwitchBox;
    // Use this for initialization

    private float runTime = 0;
    public enum MeterState {
        None,
        Info,
        Selecting,
        Settings,
        Running,
        Result
    };
    
    MeterState state = MeterState.None;

    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        delay = delay > 0 ? delay - Time.deltaTime : delay;
        Debug.Log("isPlaying: " + isPlaying);
        Debug.Log("isHitting: " + isHitting);

        if(state.Equals(MeterState.Running)) {
            runTime = runTime > 0 ? runTime - Time.deltaTime : 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Transform cam = Camera.main.transform;
            Ray ray = new Ray(cam.position, cam.forward);
//            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 1));
            RaycastHit hit = new RaycastHit();
            if (isPlaying && ((Input.GetKey(KeyCode.E))|| Input.GetKey(KeyCode.Escape)) && delay <= 0)
            {
                Debug.Log("Got here");

                Screen.lockCursor = true;
                isPlaying = false;
                MovementFreeze.UnFreezePlayer();
                delay = .4f;
            } else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals("Fadeometer"))
                {
                    if ((Input.GetKey(KeyCode.E)) && !isPlaying && delay <= 0)
                    {
                        MovementFreeze.FreezePlayer();
                        isPlaying = true;
                        isHitting = false;
                        state = MeterState.Info;

                        Screen.lockCursor = false;
                        delay = .4f;
                    } else if (!isPlaying)
                    {
                        isHitting = true;
                    }
                } else if (isHitting)
                {
                    isHitting = false;
                }
            }
        }
    }

    private void DrawSettings() {
        int textureBuffer = 50;
        GUI.DrawTexture(new Rect((Screen.width - (Screen.height - textureBuffer)) / 2, textureBuffer, Screen.height - textureBuffer, Screen.height - textureBuffer), baseTexture);
        GUI.DrawTexture(new Rect(Screen.width/2 - ((Screen.height - textureBuffer)/6)/2, textureBuffer + (Screen.height - textureBuffer)/2, (Screen.height - textureBuffer)/6, ((Screen.height - textureBuffer)/3)), timeSwitchBox);

        GUIStyle tempStyle = knobLeftStyle;
        GUIStyle tempTempStyle = knobLeftStyle;

        switch (powState)
        {
            case 1:
                tempStyle = knobUpStyle;
                break;

            case 2:
                tempStyle = knobRightStyle;
                break;

            case 3:
                tempStyle = knobDownStyle;
                break;

            case 4:
                tempStyle = knobLeftStyle;
                break;

        }

        switch (onOffState)
        {
            case 1:
                tempTempStyle = knobUpStyle;
                break;
                
            case 2:
                tempTempStyle = knobRightStyle;
                break;
                
            case 3:
                tempTempStyle = knobDownStyle;
                break;
                
            case 4:
                tempTempStyle = knobLeftStyle;
                break;
                
        }

        if (GUI.Button(new Rect( Screen.width/2 + (Screen.height - textureBuffer)/4 - ((Screen.height-textureBuffer)/10)/2 , Screen.height-((Screen.height - textureBuffer)/4), (Screen.height-textureBuffer)/10, (Screen.height-textureBuffer)/10), "", tempStyle))
        {
            powState = powState < 4 ? powState+1 : 1;
        }

        if (GUI.Button(new Rect( Screen.width/2 - (Screen.height - textureBuffer)/4 - ((Screen.height-textureBuffer)/10)/2 , Screen.height-((Screen.height - textureBuffer)/4), (Screen.height-textureBuffer)/10, (Screen.height-textureBuffer)/10), "", tempTempStyle))
        {
            onOffState = onOffState < 4 ? onOffState+1 : 1;
        }
        if (MenuTools.DrawButton(Screen.width/2 - 50, Screen.height/2 - 50, 100, 100, "Run", MenuTools.buttonStyle))
        {
         state = MeterState.Running;
             runTime = 5;
        }

    }

    void OnGUI()
    {

        if (isHitting)
        {
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Press 'E' to Use Fade-O-Meter"));
            Vector2 position = new Vector2(Screen.width/2 - size.x/2, Screen.height/2 - size.y/2);
            MenuTools.DrawSmallMenu((int)position.x, (int)position.y, (int)size.x+20, (int)size.y+20);
            GUI.Label(new Rect(position.x + 10, position.y + 10, 150, 50),"Press 'E' to Use Fade-O-Meter", MenuTools.dioramaLabel);
        }
        if (isPlaying)
        {
            if (state.Equals(MeterState.Info))
            {
                MenuTools.DrawMenu(100, 100, Screen.width - 200, Screen.height - 200);
                if (MenuTools.DrawButton(110, 110, Screen.width - 220, (Screen.height - 240) / 3, "Use Fade-O-Meter", MenuTools.buttonStyle))
                {
                    state = MeterState.Selecting;
                }
            } else if (state.Equals(MeterState.Selecting))
            {
                MenuTools.DrawMenu(100, 100, Screen.width - 200, Screen.height - 200);
                if (MenuTools.DrawButton(110, 110, Screen.width - 220, (Screen.height - 240) / 3, "Fabric One", MenuTools.buttonStyle))
                {
                    state = MeterState.Settings;
                }
                if (MenuTools.DrawButton(110, 110 + (Screen.height - 240) / 3 + 10, Screen.width - 220, (Screen.height - 240) / 3, "Fabric Two", MenuTools.buttonStyle))
                {
                    state = MeterState.Settings;
                }
                if (MenuTools.DrawButton(110, 110 + ((Screen.height - 240) / 3) * 2 + 20, Screen.width - 220, (Screen.height - 240) / 3, "Cancel", MenuTools.buttonStyle))
                {
                    Screen.lockCursor = true;
                    isPlaying = false;
                    MovementFreeze.UnFreezePlayer();
                    Debug.Log("No longer interacting with Fadeometer");           
                }
            } else if (state.Equals(MeterState.Settings))
            {
                    DrawSettings();
            } else if (state.Equals(MeterState.Running))
            {
                Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Fading... Time Remaining: " + Mathf.Round(runTime) + " seconds"));
                Vector2 position = new Vector2(Screen.width/2 - size.x/2, Screen.height/2 - size.y/2);
                MenuTools.DrawSmallMenu((int)position.x, (int)position.y, (int)size.x+20, (int)size.y+20);
                GUI.Label(new Rect(position.x + 10, position.y + 10, 150, 50),"Fading... Time Remaining: " + Mathf.Round(runTime) + " seconds", MenuTools.dioramaLabel);               
                Debug.Log("Time Remaining: " + runTime);    
                if (runTime <= 0)
                {
                    state = MeterState.Result;
                    faded = true;
                }
            } else if (state.Equals(MeterState.Result))
            {

                MenuTools.DrawMenu(100, 100, Screen.width - 200, Screen.height - 200);
            
                if (MenuTools.DrawButton(110, 110 + (Screen.height - 240) / 3 + 10, Screen.width - 220, (Screen.height - 240) / 3, "Test More Fabric", MenuTools.buttonStyle))
                {
                    state = MeterState.Selecting;
                }
                if (MenuTools.DrawButton(110, 110 + ((Screen.height - 240) / 3) * 2 + 20, Screen.width - 220, (Screen.height - 240) / 3, "Finish", MenuTools.buttonStyle))
                {
                    Screen.lockCursor = true;
                    isPlaying = false;
                    MovementFreeze.UnFreezePlayer();
                    Debug.Log("No longer interacting with Fadeometer");  
                    if(faded && !AchievementController.CheckAchievement(AchievementController.Achievements.Fadeometer)) {
                        AchievementController.UnlockAchievement(AchievementController.Achievements.Fadeometer);
                    }
                }
            }
        }
    }
}

