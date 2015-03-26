using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


public class ScrapbookController : MonoBehaviour {

    private bool isActive = false;
    public bool isOpen = false;
    private float delay = 0;
    public Texture[] lockedTextures;
    public Texture[] unlockedTextures;

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
	void Start () {

	}
	
    public void SetState(string newState) {
        state = (BookState) Enum.Parse( typeof(BookState), newState, true );
    }

	// Update is called once per frame
	void Update () {
        if (!Application.loadedLevelName.Equals("MainMenu") && !Application.loadedLevelName.Equals("LogoSplash"))
        {
            isActive = true;
        }
        Debug.Log(isActive &&  !GameController.GetPauseState());
        if (isActive && (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Book"))&& !GameController.GetPauseState())
        {
			Input.m
            state = BookState.Missions;
            isOpen = isOpen ? false : true;
            if (isOpen)
            {
                scrapBook.SetActive(true);
                MovementFreeze.FreezePlayer();
            } else
            {
                scrapBook.SetActive(false);
                MovementFreeze.UnFreezePlayer();
            }
            delay = .2f;
        } else if (isOpen && (Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("Pause")))
        {
            isOpen = false;
            scrapBook.SetActive(false);

            MovementFreeze.UnFreezePlayer();
            delay = .2f;
        }
        delay = delay > 0 ? delay - Time.deltaTime : 0;

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
        scrapBook.SetActive(false);
        isOpen = false;
    }

    void Awake()
    {
     
    }
}
