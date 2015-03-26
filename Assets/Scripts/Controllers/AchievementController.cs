using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class AchievementController : MonoBehaviour {

    public static List<FindableObject> hatList;

	private static bool isDisplay = false;
	private static Achievements toDisplay;
    private static bool isProgressDisplay = false;
    private static string progressToDisplay;
	private static float displayTime = 6;
	private static float timeLeft = 0;
	public Texture[] popupTextures;
	public AudioClip achieved;
	private static GameObject controllerObject;
    private static int hatCount;
    public GUIText textDisplay;
    private static AudioSource objectSound;
    private static AudioSource achievementSound;
    public AudioSource objectSoundTemp;
    public AudioSource achievementSoundTemp;

    public static int displayedAchievements = 3;

    public enum FindableObject {
        HatWhite,
        HatBlack,
        HatGray,
        HatGold
	};

    public enum VisitableRooms {
        HallFourth_1917,
        HallFirst_1917,
        Library_1917,
        Presidents_1917,
        Sewing_1917,
        Theater_1917,
        Presidents_1950,
        Textile_1950
    };

    public enum Achievements {
        HarveysHats,
        EveryRoom,
        FiveMinutes,
		SwatTeam,
		ObjectCollection,
        Fadeometer
    };

    void Start () {
        PrepQuests();
		controllerObject = this.transform.gameObject;
        textDisplay.enabled = false;
        objectSound = objectSoundTemp;
        achievementSound = achievementSoundTemp;
    }
     
    private static void PrepQuests() {
        hatList = new List<FindableObject>();
        hatList.Add(FindableObject.HatWhite);
        hatList.Add(FindableObject.HatBlack);
        hatList.Add(FindableObject.HatGray);
        hatList.Add(FindableObject.HatGold);
        hatCount = PlayerPrefs.HasKey(SaveController.GetPrefix() + "hatCount") ? PlayerPrefs.GetInt(SaveController.GetPrefix() + "hatCount") : 0;
    }

    private static void UpdateAchievements() {
        UpdateHatQuest();
    }

    private static void UpdateHatQuest() {
        if (PlayerPrefs.GetInt(SaveController.GetPrefix() + Achievements.HarveysHats.ToString()) == 0)
        {
            bool achievementEarned = true;
            int tempCount = 0;
            int maxCount = 0;
            foreach(FindableObject hat in hatList) {
                achievementEarned = PlayerPrefs.GetInt(SaveController.GetPrefix() + hat.ToString()) == 0 ? false : achievementEarned;
                tempCount = PlayerPrefs.GetInt(SaveController.GetPrefix() + hat.ToString()) == 1 ? tempCount+1 : tempCount;
                maxCount += 1;
            }
            if(achievementEarned) {
				UnlockAchievement(Achievements.HarveysHats);
            } else {
                if(tempCount > PlayerPrefs.GetInt(SaveController.GetPrefix() + "hatCount")) {
                    PlayerPrefs.SetInt(SaveController.GetPrefix() + "hatCount", tempCount);
                    progressToDisplay = (tempCount + " of " + maxCount + " hats found.");
                    timeLeft = displayTime;
                    isProgressDisplay = true;
                }
            }
        }
    }

    public static void ResetAchievements() 
	{
        //Debug.Log("Reset achievements");
        ResetObjects();
        ResetRooms();

        foreach (Achievements achieve in (Achievements[]) Enum.GetValues(typeof (Achievements)))
        {
            PlayerPrefs.SetInt(SaveController.GetPrefix() + achieve.ToString(), 0);
        }
        PlayerPrefs.SetInt(SaveController.GetPrefix() + "hatCount", 0);
    }

	void OnGUI() {
				if (isDisplay)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isDisplay = false;
            } else
            {
                int textNum = 1;	
                switch (toDisplay.ToString())
                {
                    case "HarveysHats":
                        textNum = 0;
                        break;
                    case "SwatTeam":
                        textNum = 1;
                        break;
				case "ObjectCollection":
					textNum = 2;
					break;
                    case "Fadeometer":
                        textNum = 3;
                        break;
                }
                GUI.DrawTexture(new Rect(Screen.width/2 -  popupTextures [textNum].width/2, Screen.height/2 - popupTextures [textNum].height/2, popupTextures [textNum].width, popupTextures [textNum].height), popupTextures [textNum]);
            }
        } else if (isProgressDisplay)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isDisplay = false;
                textDisplay.enabled = false;
            } else
            {
                textDisplay.text = progressToDisplay;
                textDisplay.enabled = true;
            }
        }
                
	}


	private static void DisplayAchievement(Achievements achieved) {
		isDisplay = true;
		toDisplay = achieved;
		timeLeft = displayTime;
	}

    private static void ResetObjects() {
        foreach (FindableObject objects in (FindableObject[]) Enum.GetValues(typeof(FindableObject)))
        {
            PlayerPrefs.SetInt(SaveController.GetPrefix() + objects.ToString(), 0);
        }
    }

	public static bool CheckObject(FindableObject chkObj) {
		return PlayerPrefs.GetInt (SaveController.GetPrefix () + chkObj.ToString ()) == 0 ? false : true;
	}

	public static bool CheckAchievement(Achievements ach) {
		return PlayerPrefs.GetInt (SaveController.GetPrefix () + ach.ToString ()) == 0 ? false : true;
	}

    private static void ResetRooms() {
        foreach (VisitableRooms room in (VisitableRooms[]) Enum.GetValues(typeof(VisitableRooms)))
        {
            PlayerPrefs.SetInt(SaveController.GetPrefix() + room.ToString(), 0);
        }
    }

	public static void UnlockAchievement(Achievements achieved) {
		PlayerPrefs.SetInt(SaveController.GetPrefix() + achieved.ToString(), 1);
		Debug.Log(achieved.ToString() + " Unlocked");
		DisplayAchievement(achieved);
		achievementSound.Play();
	}

    public static void FoundObject(FindableObject foundObj) {
        PlayerPrefs.SetInt(SaveController.GetPrefix() + foundObj.ToString(), 1);
        UpdateAchievements();
        objectSound.Play();
    }

    public static void VisitedRoom(VisitableRooms visitedRoom) {
        PlayerPrefs.SetInt(SaveController.GetPrefix() + visitedRoom.ToString(), 1);
    }
}