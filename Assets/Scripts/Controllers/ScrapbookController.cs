using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class ScrapbookController : MonoBehaviour {
	public static ScrapbookController instance;
    private bool isActive = false;
    public static bool isOpen = false;
    public Texture[] lockedTextures;
    public Texture[] unlockedTextures;
	private GameObject scrapBookBackground;
	public GameObject scrapBook;

    public GameObject taskPage;
    public GameObject achievementsPage;
    public GameObject roomsPage;
    public GameObject objectsPage;

    public enum BookState {
        Missions,
        Achievements,
        Objects,
        Rooms,
    };
    
    private static BookState state = BookState.Missions;


	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void OnLevelWasLoaded (int level)
	{

	}
	
    public void SetState(string newState) {
        state = (BookState) Enum.Parse( typeof(BookState), newState, true );
    }

	// Update is called once per frame
	void Update () {
		if (!isOpen && GameController.GetMenuState() == GameController.MenuState.Scrapbook)
        {
			if (GameController.GetGameState () == GameController.GameState.Room) {
				MovementFreeze.OpenBook();
			}
            state = BookState.Missions;
            isOpen = true;
            scrapBook.SetActive(true);
            MovementFreeze.FreezePlayer();
		    Screen.lockCursor = false;
        } else if (isOpen && GameController.GetMenuState() != GameController.MenuState.Scrapbook) {
			if (GameController.GetGameState () == GameController.GameState.Room) {
				MovementFreeze.CloseBook();
			}
			CloseScrapbook();
            //isOpen = false;
            //scrapBook.SetActive(false);
            MovementFreeze.UnFreezePlayer();
			if(GameController.GetGameState() != GameController.GameState.Diorama) {
				Screen.lockCursor = true;
			}
        }

        if (isOpen)
        {
            switch(state) {
                case BookState.Missions:
                    taskPage.SetActive(true);
                    achievementsPage.SetActive(false);
                    roomsPage.SetActive(false);
                    objectsPage.SetActive(false);
                    break;
                case BookState.Achievements:
                    taskPage.SetActive(false);
                    achievementsPage.SetActive(true);
                    roomsPage.SetActive(false);
                    objectsPage.SetActive(false);
                    break;
                case BookState.Rooms:
                    taskPage.SetActive(false);
                    achievementsPage.SetActive(false);
                    roomsPage.SetActive(true);
                    objectsPage.SetActive(false);
                    break;
                case BookState.Objects:
                    taskPage.SetActive(false);
                    achievementsPage.SetActive(false);
                    roomsPage.SetActive(false);
                    objectsPage.SetActive(true);
                    break;
            }
        }
	}

    public void CloseScrapbook() {
		isOpen = false;
        scrapBook.SetActive(false);
    }

}
