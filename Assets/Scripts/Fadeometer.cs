using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fadeometer : MonoBehaviour
{
	private string gameID = "AtlasFade";
    private int powState = 1;
    private int onOffState = 1;

    public static bool isPlaying = false;
    bool isHitting = false;
    float delay = 0;
   
	public GameObject infoCanvas;
	public GameObject selectionCanvas;
	public GameObject atlasCanvas;
	public GameObject resultCanvas;

	public Transform dialKnob;
	public Transform tickLeft;
	public Transform tickRight;

	public UnityEngine.UI.Image lightLeft;
	public UnityEngine.UI.Image lightRight;


	private bool faded = false;

	private static int chosenSample;

	private float maxRunTime = 15;
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
		tickLeft.eulerAngles = new Vector3 (0, 0, 36);
		tickRight.eulerAngles = new Vector3 (0, 0, 36);
	}
    
    // Update is called once per frame
    void Update()
    {
        delay = delay > 0 ? delay - Time.deltaTime : delay;
        if(state.Equals(MeterState.Running)) {
            runTime = runTime + Time.deltaTime;
			dialKnob.Rotate(0, 0,-1*(360/maxRunTime)*Time.deltaTime);
			tickLeft.eulerAngles = new Vector3 (0, 0, Mathf.Sin(runTime*2+Mathf.PI/2)*20 +16);
			lightLeft.color = new Color(lightLeft.color.r, lightLeft.color.g, lightLeft.color.b, (float)Mathf.Sin(runTime*2-(float)Mathf.PI/2)/2 +.5f);
			tickRight.eulerAngles = new Vector3 (0, 0, Mathf.Sin(runTime*3+Mathf.PI/2)*24 +12);
			lightRight.color = new Color(lightRight.color.r, lightRight.color.g, lightRight.color.b, (float)Mathf.Sin(runTime*3-(float)Mathf.PI/2)/2 +.5f);

			if(runTime >= maxRunTime) {
				SetResultState();
			}
        }
    }

    void OnTriggerStay(Collider other)
    {
		//Checks to see if the player is in the area of the fadeometer
        if (other.tag.Equals("Player"))
        {
            Transform cam = Camera.main.transform;
            Ray ray = new Ray(cam.position, cam.forward);
            RaycastHit hit = new RaycastHit();
            
			//Closes the fadeometer if you hit e or escape
			if (isPlaying && (Input.GetButtonUp("Select") || Input.GetButtonUp("Pause")) && delay <= 0) {
				CloseAtlasFade();
            } 
			//Checks to see if you are looking at it
			else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals("Fadeometer"))
                {
					//If you press e and no other menus are open, it opens the fadeometer
					if (Input.GetButtonUp("Select") && !isPlaying && delay <= 0)
                    {
						if(GameController.SetOutsideMenuState(GameController.MenuState.Game, gameID)) {
                        	MovementFreeze.FreezePlayer();
                        	isPlaying = true;
                        	isHitting = false;
							SetInfoState();
                        	Screen.lockCursor = false;
                        	delay = .4f;
						}
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

	public void CloseAtlasFade() {
		infoCanvas.SetActive (false);
		selectionCanvas.SetActive (false);
		atlasCanvas.SetActive(false);
		resultCanvas.SetActive (false);
		GameController.ClearOustideMenuState(gameID);
		Screen.lockCursor = true;
		isPlaying = false;
		MovementFreeze.UnFreezePlayer();
		delay = .4f;
		if(faded && !AchievementController.CheckAchievement(AchievementController.Achievements.Fadeometer)) {
			AchievementController.UnlockAchievement(AchievementController.Achievements.Fadeometer);
		}
	}

	public void SetInfoState() {
		state = MeterState.Info;
		infoCanvas.SetActive (true);
		selectionCanvas.SetActive (false);
		atlasCanvas.SetActive(false);
		resultCanvas.SetActive (false);
	}

	public void SetSelectingState() {
		state = MeterState.Selecting;
		infoCanvas.SetActive (false);
		selectionCanvas.SetActive (true);
		atlasCanvas.SetActive(false);
		resultCanvas.SetActive (false);
	}

	public void SetSettingsState(int sampleNum) {
		chosenSample = sampleNum;
		state = MeterState.Settings;
		infoCanvas.SetActive (false);
		selectionCanvas.SetActive (false);
		atlasCanvas.SetActive(true);
		resultCanvas.SetActive (false);
	}

	public void SetRunningState() {
		state = MeterState.Running;
	}
	public void SetResultState() {
		state = MeterState.Result;
		faded = true;
		infoCanvas.SetActive (false);
		selectionCanvas.SetActive (false);
		atlasCanvas.SetActive(false);
		resultCanvas.SetActive (true);
	}
}

