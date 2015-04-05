using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class AchievementController : MonoBehaviour {

    public static List<FindableObject> hatList;
	//The list of books is a findable object
	public static List<FindableObject> bookList;
	//The list of mural is a findable object
	public static List<FindableObject> muralList;

	private static bool libraryIsLoaded = false;
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
	//set to true after you talk to Cal
	public static bool calsMuralStart = false;
	public static int muralCount;
	private static int bookCount;
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
        HatGold,
		UniversityOfHardKnocks,
		PicadillyJim,
		SigmundFreud,
		AnnesHouseOfDreams,
		SummerEdith,
		CalsMural,
		Imposter1,
		Imposter2
		//Added each book that can be found
	};

    public enum VisitableRooms {
        HallFourth_1917,
        HallFirst_1917,
        Library_1917,
        Presidents_1917,
        Sewing_1917,
        Theater_1917,
        Presidents_1950,
        Textile_1950,
		CalPeters_1917,
		Chemistry_1917,
		Tea_1917,
		Millinery_1950
    };

    public enum Achievements {
        HarveysHats,
        EveryRoom,
        FiveMinutes,
		SwatTeam,
		ObjectCollection,
        Fadeometer,
		//Add Cal's Mural once we have that achivement
		FindCalsMural

    };

    void Start () {
        PrepQuests();
		controllerObject = this.transform.gameObject;
        textDisplay.enabled = false;
        objectSound = objectSoundTemp;
        achievementSound = achievementSoundTemp;
		//LevelWasLoaded(Application.loadedLevel);
    }

	void Update()
	{
		//if the boolean from the other script is true
		//instantiate the objects
	}

    private static void PrepQuests() {
		//call to prompt the user to start the quest
		PrepHatQuest();
		//Prepare the book quest
		PrepBookQuest();
		PrepMuralQuest();
    }

	private static void PrepBookQuest() 
	{
		bookList = new List<FindableObject>();
		bookList.Add(FindableObject.UniversityOfHardKnocks); //Adding the books to the list of findable objects
		bookList.Add(FindableObject.PicadillyJim);
		bookList.Add(FindableObject.SigmundFreud);
		bookList.Add(FindableObject.AnnesHouseOfDreams);
		bookList.Add(FindableObject.SummerEdith);
		bookCount = PlayerPrefs.HasKey(SaveController.GetPrefix() + "bookCount") ? PlayerPrefs.GetInt(SaveController.GetPrefix() + "bookCount") : 0;
	}

	private static void PrepHatQuest() {
		hatList = new List<FindableObject>();
		hatList.Add(FindableObject.HatWhite);
		hatList.Add(FindableObject.HatBlack);
		hatList.Add(FindableObject.HatGray);
		hatList.Add(FindableObject.HatGold);
		hatCount = PlayerPrefs.HasKey(SaveController.GetPrefix() + "hatCount") ? PlayerPrefs.GetInt(SaveController.GetPrefix() + "hatCount") : 0;
	}

	private static void PrepMuralQuest(){
		muralList = new List<FindableObject> ();
		muralList.Add(FindableObject.CalsMural);
		muralList.Add(FindableObject.Imposter1);
		muralList.Add(FindableObject.Imposter2);
		muralCount = PlayerPrefs.HasKey (SaveController.GetPrefix () + "muralCount") ? PlayerPrefs.GetInt (SaveController.GetPrefix () + "muralCount") : 0;
	}
    private static void UpdateAchievements() {
        UpdateHatQuest();
		UpdateBookQuest();
		UpdateCalsMuralQuest();
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

	//Book quest function
	private static void UpdateBookQuest() {
		if (PlayerPrefs.GetInt(SaveController.GetPrefix() + Achievements.ObjectCollection.ToString()) == 0 && StartBookCollectionScript.canStartBookQuest)
		{
			bool achievementEarned = true;
			int tempCount = 0;
			int maxCount = 0;
			foreach(FindableObject book in bookList) {
				achievementEarned = PlayerPrefs.GetInt(SaveController.GetPrefix() + book.ToString()) == 0 ? false : achievementEarned;
				tempCount = PlayerPrefs.GetInt(SaveController.GetPrefix() + book.ToString()) == 1 ? tempCount+1 : tempCount;
				maxCount += 1;
				Debug.Log(tempCount);
				Debug.Log (SaveController.GetPrefix());
			}
			if(achievementEarned) {
				UnlockAchievement(Achievements.ObjectCollection);
			} 
			else 
			{
				//HOW TO GET TEXT TO SHOW UP HERE
				if(tempCount > PlayerPrefs.GetInt(SaveController.GetPrefix() + "bookCount")) 
				{
					PlayerPrefs.SetInt(SaveController.GetPrefix() + "bookCount", tempCount);
					progressToDisplay = (tempCount + " of " + maxCount + " books found.");
					timeLeft = displayTime;
					isProgressDisplay = true;
				}
			}
		}
	}

	public static void UpdateCalsMuralQuest()
	{
		if (PlayerPrefs.GetInt(SaveController.GetPrefix() + Achievements.FindCalsMural.ToString()) == 0)
		{
			bool achievementEarned = true;
			int tempCount = 0;
			int maxCount = 0;
			foreach(FindableObject mural in muralList) {
				achievementEarned = PlayerPrefs.GetInt(SaveController.GetPrefix() + mural.ToString()) == 0 ? false : achievementEarned;
				tempCount = PlayerPrefs.GetInt(SaveController.GetPrefix() + mural.ToString()) == 1 ? tempCount+1 : tempCount;
				maxCount += 1;
				Debug.Log(tempCount);
				Debug.Log (SaveController.GetPrefix());
			}
			if(achievementEarned) {
				//CHANGE THIS WHEN I CAN
				UnlockAchievement(Achievements.FindCalsMural);
			} 
			else 
			{
				//HOW TO GET TEXT TO SHOW UP HERE
				if(tempCount > PlayerPrefs.GetInt(SaveController.GetPrefix() + "muralCount")) 
				{
					PlayerPrefs.SetInt(SaveController.GetPrefix() + "muralCount", tempCount);
					progressToDisplay = (tempCount + " of " + maxCount + " murals found.");
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
		PlayerPrefs.SetInt(SaveController.GetPrefix() + "bookCount", 0);
		PlayerPrefs.SetInt(SaveController.GetPrefix() + "muralCount", 0);

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
					/*case "CalsMurals"
						textNum = 4;
						break;*/
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
		/*if (libraryIsLoaded) 
		{
			Debug.Log ("Library loaded");
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 400, 400), "You have entered the library and unlocked the ability to collect 5 hidden books."); 
		}*/
                
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