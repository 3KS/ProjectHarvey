using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public string splashSceneName;
		public string menuSceneName;
		public string dioramaSceneName;
		public string[] cutsceneNames;
		public string[] roomNames;
		public static bool isPaused = false;
		public bool isPausedOutput; //for debugging purposes
		private static bool isAchievements = false;
		private static bool isQuit = false;
		public Texture2D overlayTexture;
		private float currentOpacity = 0f;
		public float fadeSpeed;
		public float overlayOpacity;
		public Texture[] lockedTextures;
		public Texture[] unlockedTextures;
		private Texture2D blackTexture;
		private static float delay = 0;



		private static string outsideMenuID;

		public enum MenuState
		{
				None,
				Pause,
				Quit,
				Scrapbook,
				Dialog,
				Inspector,
				Game
		};

		public enum GameState
		{
				Splash,
				MainMenu,
				Cutscene,
				Diorama,
				Room
		};

		private static GameState gameState = GameState.Splash;
		private static MenuState menuState = MenuState.None;

		//********************************************
		// Start()
		// Does graphics stuff that I must remember - Ben
		//********************************************
		void Start ()
		{
				blackTexture = new Texture2D (1, 1);
				//renderer.material.mainTexture = blackTexture;
				int y = 0;
				while (y < blackTexture.height) {
						int x = 0;
						while (x < blackTexture.width) {
								Color color = new Color (0, 0, 0, overlayOpacity);
								blackTexture.SetPixel (x, y, color);
								++x;
						}
						++y;
				}
				blackTexture.Apply ();
		}


		//********************************************
		// Awake()
		// Sets the game controller object as persistent in the game
		//********************************************
		void Awake ()
		{
				DontDestroyOnLoad (transform.gameObject);
		}


		//********************************************
		// OnLevelWasLoaded()
		// loads the position of the first person controller when the room has loaded
		//********************************************
		void OnLevelWasLoaded (int level)
		{
				SceneLoadTasks ();
		}

		//********************************************
		// SceneLoadTasks()
		// performs tasks on load of a new scene
		//********************************************
		private void SceneLoadTasks ()
		{
				SetSceneType ();
				if (gameState == GameState.Room) {
						SaveController.LoadCurrentFPC ();
				}
		}

		//********************************************
		// SetSceneType()
		// sets the type of the scene
		//********************************************
		private void SetSceneType ()
		{
				if (Application.loadedLevelName.Equals (splashSceneName)) {
						gameState = GameState.Splash;
						return;
				} else if (Application.loadedLevelName.Equals (menuSceneName)) {
						gameState = GameState.MainMenu;
						return;
				} else if (Application.loadedLevelName.Equals (dioramaSceneName)) {
						gameState = GameState.Diorama;
						return;
				} else if (CheckCutscene ()) {
						gameState = GameState.Cutscene;
						return;
				} else if (CheckRoom ()) {
						gameState = GameState.Room;
						return;
				}
		}

		//********************************************
		// CheckCutscene()
		// checks if the game is in a cutscene
		//********************************************
		private bool CheckCutscene ()
		{
				bool isCutscene = false;
				foreach (string sceneName in cutsceneNames) {
						isCutscene = Application.loadedLevelName.Equals (sceneName) ? true : isCutscene;
				}
				return isCutscene;
		}

		//********************************************
		// CheckRoom()
		// checks if the game is in a room in harvey hall
		//********************************************
		private bool CheckRoom ()
		{
				bool isRoom = false;
				foreach (string roomName in roomNames) {
						isRoom = Application.loadedLevelName.Equals (roomName) ? true : isRoom;
				}
				return isRoom;
		}

		//********************************************
		// GetGameState()
		// returns the state of the game
		//********************************************
		public static GameState GetGameState ()
		{
				return gameState;
		}


		//********************************************
		// SetOutsideMenuState()
		// used for opening outside menus
		//********************************************
		public static bool SetOutsideMenuState(MenuState state, string menuID) {
			if (menuState == MenuState.None) {
				menuState = state;
				outsideMenuID = menuID;
				return true;
			} 
			Debug.Log ("SetOutsideMenuState(MenuState state, string menuID): An outside source tried opening a menu while a menu is already open.");
			return false;
		}
		
		//********************************************
		// ClearOustideMenuState()
		// used for closing outside menus
		//********************************************
		public static bool ClearOustideMenuState(string menuID) {
			if (outsideMenuID.Equals (menuID)) {
				menuState = MenuState.None;
				outsideMenuID = "";
				delay = .4f;
				return true;
			}
			Debug.Log ("ClearOutsideMenuState(string menuID): An outside source tried clearing a menu that it does not own.");
			return false;
		}

		//********************************************
		// GetMenuState()
		// returns the state of the menus
		//********************************************
		public static MenuState GetMenuState ()
		{
				return menuState;
		}

		//********************************************
		// UpdateMenuState()
		// updates the state of the menus
		//********************************************
		private void UpdateMenuState ()
		{
				if (gameState == GameState.Splash && menuState != MenuState.None) { //If the scene is the splash screen
						menuState = MenuState.None;
				} else if (gameState == GameState.MainMenu) { //If the scene is the main menu
						if (menuState != MenuState.None && menuState != MenuState.Quit) {
								menuState = MenuState.None;
						}
						if (Input.GetButtonUp ("Pause")) {
								menuState = menuState == MenuState.None ? MenuState.Quit : MenuState.None;
								isPaused = isPaused ? false : true;
						}
				} else if (gameState == GameState.Diorama) { //If the scene is the diorama
						if (menuState == MenuState.Dialog || menuState == MenuState.Inspector || menuState == MenuState.Game) {
								menuState = MenuState.None;
						} else if (Input.GetButtonUp ("Pause")) { //If you press the pause button
								if (menuState != MenuState.None) { //If something is open, close it
										menuState = MenuState.None;
										isPaused = false;
								} else { //If nothing is open, open the pause menu
					Debug.Log("open pause diorama");		
										menuState = MenuState.Pause;
										isPaused = true;
								}
						} else if (Input.GetButtonUp ("Book")) { //If you press the scrapbook button
								if (menuState == MenuState.None) {
										menuState = MenuState.Scrapbook;
										isPaused = true;
								} else if (menuState == MenuState.Scrapbook) {
										menuState = MenuState.None;
										isPaused = false;
								}
						}
				} else if (gameState == GameState.Room) {
						 if (Input.GetButtonUp ("Pause")) { //If you press the pause button
								if (menuState != MenuState.None && menuState != MenuState.Game) { //If something is open, close it
										menuState = MenuState.None;
										isPaused = false;
								} else if(menuState == MenuState.None) { //If nothing is open, open the pause menu
										Debug.Log("open pause");
										menuState = MenuState.Pause;
										isPaused = true;
								}
						} else if (Input.GetButtonUp ("Book")) { //If you press the scrapbook button
								if (menuState == MenuState.None) {
										menuState = MenuState.Scrapbook;
										isPaused = true;
								} else if (menuState == MenuState.Scrapbook) {
										menuState = MenuState.None;
										isPaused = false;
								}
						}
				} else if (gameState == GameState.Cutscene && menuState != MenuState.None) { //If the scene is a cutscene
						menuState = MenuState.None;
				}
		}

		//********************************************
		// Update()
		// Controlls returning to the diorama, toggling game pause state via esc, and toggling GUI active when game is paused and unpaused
		//********************************************
		void Update ()
		{
				isPausedOutput = isPaused; //for debugging purposes
				if (delay <= 0) {
					UpdateMenuState (); //Updates the state of the menus
				}			

				delay = delay > 0 ? delay - Time.unscaledDeltaTime : delay;

				if (isPaused) {
						Time.timeScale = 0;
						GUI.enabled = false;
				} else {
						Time.timeScale = 1;
						GUI.enabled = true;
				}
		}

		//********************************************
		// ReturnToDiorama()
		// Loads the diorama scene
		//********************************************
		public void ReturnToDiorama ()
		{
				SaveController.SaveCurrentFPC ();
				Screen.lockCursor = false;
				Application.LoadLevel ("HarveyWithLighting");
		}

		//********************************************
		// GetPauseState()
		// Returns if the game is currently paused
		//********************************************
		public static bool GetPauseState ()
		{
				return isPaused;
		}

		//********************************************
		// QuitMenu()
		// Sets the QuitMenu to draw
		//********************************************
		public static void QuitMenu ()
		{
				isPaused = true; 
				isQuit = true;
		}

		//********************************************
		// OnGUI()
		// controls the drawing of the pause menu button and the calling of DrawPauseMenu
		//********************************************
		void OnGUI ()
		{
				if (menuState == MenuState.Quit) {
						DrawQuitMenu ();
				} else if (menuState == MenuState.Pause) {
						DrawPauseMenu ();
				}

				if (isPaused) {
						GUI.enabled = false;
				}

				if (Application.loadedLevelName.Equals ("HarveyWithLighting")) {
						if (MenuTools.DrawButton (Screen.width - 200, 0, 200, 50, "Menu", MenuTools.buttonStyle)) {
								isPaused = true;
								Screen.lockCursor = false;
						}
				}

       
		}

		//********************************************
		// DrawPauseMenu()
		// controlls which version of the pause menu is drawn
		//********************************************
		private void DrawPauseMenu ()
		{
				GUI.enabled = true;
				GUI.depth = 1;
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);
				if (!isAchievements) {
						DrawNormalMenu ();
				} else {
						DrawAchievementMenu ();			
				}
		}

		//********************************************
		// DrawNormalMenu()
		// Draws the Normal version of the pause menu
		//********************************************
		private void DrawNormalMenu ()
		{
				MenuTools.DrawMenu (Screen.width / 2 - 150, Screen.height / 2 - 250, 300, 500);
		
				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 50, "Resume Game", MenuTools.buttonStyle)) {
						isPaused = false;
						if (!Application.loadedLevelName.Equals ("HarveyWithLighting") && !Application.loadedLevelName.Equals ("MainMenu") && !Application.loadedLevelName.Equals ("LogoSplash")) {
								Screen.lockCursor = true;
						}
				}

				//if (MenuTools.DrawButton(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50, "Achievements", MenuTools.buttonStyle)) {
				//	isAchievements = true;
				//  }

				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50, "Main Menu", MenuTools.buttonStyle)) {
						SaveController.SaveCurrentProfile ();
						isPaused = false;
						Application.LoadLevel ("MainMenu");
				}

				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50, "Quit to Desktop", MenuTools.buttonStyle)) {
						isQuit = true;
				}
		}

		//********************************************
		// DrawAchievementMenu()
		// Draws the Achievement version of the pause menu - to be replaced by the scrapbook controller
		//********************************************
		private void DrawAchievementMenu ()
		{
				MenuTools.DrawMenu (Screen.width / 2 - 150, Screen.height / 2 - 250, 300, 500);
				if (!AchievementController.CheckAchievement (AchievementController.Achievements.HarveysHats)) {
						float imgHeight = (200 * ((float)lockedTextures [0].height / (float)lockedTextures [0].width));
						GUI.DrawTexture (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 150, 200, imgHeight), lockedTextures [0]);
				} else {
						float imgHeight = (200 * ((float)unlockedTextures [0].height / (float)unlockedTextures [0].width));
						GUI.DrawTexture (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 150, 200, imgHeight), unlockedTextures [0]);
				}
				if (!AchievementController.CheckAchievement (AchievementController.Achievements.SwatTeam)) {
						float imgHeight = (200 * ((float)lockedTextures [1].height / (float)lockedTextures [1].width));
						GUI.DrawTexture (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, imgHeight), lockedTextures [1]);
				} else {
						float imgHeight = (200 * ((float)unlockedTextures [1].height / (float)unlockedTextures [1].width));
						GUI.DrawTexture (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, imgHeight), unlockedTextures [1]);
				}
		
		
				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50, "<-- Back", MenuTools.buttonStyle)) {
						isAchievements = false;
				}
		}

		//********************************************
		// DrawQuitMenu()
		// Draws the Quit version of the pause menu
		//********************************************
		private void DrawQuitMenu ()
		{
				MenuTools.DrawMenu (Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 250);
		
				GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 125, 300, 50), "Do you want to quit?", MenuTools.labelStyle);
		
				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 50, "Yes", MenuTools.buttonStyle)) {
						SaveController.SaveCurrentProfile ();
						Application.Quit ();
				}
				if (MenuTools.DrawButton (Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50, "No", MenuTools.buttonStyle)) {
						menuState = MenuState.None;
				}
		}
}
