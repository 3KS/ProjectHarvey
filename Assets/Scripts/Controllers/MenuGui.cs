using UnityEngine;
using System.Collections;

public class MenuGui : MonoBehaviour
{

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public bool debugRaycast;
    public GameObject mainPage;
    public GameObject buttonNew;
    public GameObject buttonQuit;
    public Material newDefault;
    public Material newHover;
    public Material quitDefault;
    public Material quitHover;
    private float rawLerp;
    private float lerp;
    public float speed;
    private Quaternion source;
    private Quaternion target;
    private GameObject lerpingObject;
    private bool lerpingPage = false;
    private bool lerpDirection = true;
    public GameObject menuController;
    public Camera mainCamera;
    public int startFOV;
    public int endFOV;
    public bool zooming;
    public static bool isCreatingProfile = false;
    public static bool isLoadingProfile = false;
    public float cameraSpeed;
    public GUITexture flashTexture;
    private float currentOpacity = 0f;
    private string tempProfName = "Enter Name Here";
	
    public Texture2D menuTitle;
    public float titleScale;


    //270 ---- 450
    
    private enum Menu
    {
        Main,
        Settings,
        About}
    ;
        
    private Menu currentMenu;

    void Start()
    {
        mainCamera.fieldOfView = startFOV;
        zooming = false;
        currentMenu = Menu.Main;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Menu Updating");
        /**Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (debugRaycast)
            {
                DebugRaycast(ray, hit);
            } else
            {
                EndDebugRaycast();
            }

            if (Input.GetMouseButtonDown(0))
            {
                ButtonClick(hit.transform.tag);
            }
        }
                

        if (lerpingPage)
        {
            rawLerp += Time.deltaTime * speed;
            lerp = Mathf.Min(rawLerp, 1);
            if (lerpDirection)
            {
                lerpingObject.transform.rotation = Quaternion.Slerp(source, target, lerp);    
                source = lerpingObject.transform.rotation;
            } else
            {
                lerpingObject.transform.rotation = Quaternion.Slerp(target, source, lerp);    
                target = lerpingObject.transform.rotation;
            }
        }
        LoadGame();**/

    }
        
    void ButtonClick(string itemTag)
    {
        if (currentMenu == Menu.Main && !zooming)
        {
            switch (itemTag)
            {
                case "newGame":
                    isCreatingProfile = true;
                    //zooming = true;
                    //LoadGame();
                    //RotatePageForward(mainPage);
                    break;
                case "loadGame":
                    isLoadingProfile = true;
                    //LoadSaved();
                    break;
                case "quitGame":
                    GameController.QuitMenu();
                    break;
            }
        }
    }

    void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width/2 - (menuTitle.width/2)*titleScale, -20, menuTitle.width*titleScale, menuTitle.height*titleScale), menuTitle);

        if (isCreatingProfile || isLoadingProfile || GameController.GetPauseState())
        {
            GUI.enabled = false;
        }
		if (MenuTools.DrawButton(Screen.width / 2 - 100, Screen.height / 2 -50, 200, 50, "New Game", MenuTools.buttonStyle))
        {
            SaveController.CreateProfile("BetaTestor", 0);
            Application.LoadLevel("HarveyWithLighting");
            //isCreatingProfile = true;
        }
		if (MenuTools.DrawButton(Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 50, "Load Game", MenuTools.buttonStyle))
        {
            if(!SaveController.LoadProfile(0)) {
                //isLoadingProfile = true;
                Debug.Log("Profile Failed to Load");
            }
            //isLoadingProfile = true;
        }

		if (MenuTools.DrawButton(Screen.width / 2 - 100, Screen.height / 2 + 90, 200, 50, "Quit", MenuTools.buttonStyle))
        {
            GameController.QuitMenu();
        }

        GUI.enabled = true;


        if (isCreatingProfile)
        {
            //GUI.Box(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 300), "");
            MenuTools.DrawMenu(Screen.width/2 - 130, Screen.height/2 - 170, 260, 340);

            GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 20), "Create Profile", MenuTools.labelStyle);
            tempProfName = GUI.TextField(new Rect(Screen.width/2 - 100, Screen.height/2 - 120, 200, 20), tempProfName, 25);
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 90, 200, 20), "Select Save Slot:", MenuTools.labelStyle);

            string profNameOne = PlayerPrefs.HasKey("saveOne_profName") ? PlayerPrefs.GetString("saveOne_profName") : "Empty";
            string profNameTwo = PlayerPrefs.HasKey("saveTwo_profName") ? PlayerPrefs.GetString("saveTwo_profName") : "Empty";
            string profNameThree = PlayerPrefs.HasKey("saveThree_profName") ? PlayerPrefs.GetString("saveThree_profName") : "Empty";

			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 - 60, 200, 32, profNameOne, MenuTools.buttonStyle)) {
                SaveController.CreateProfile(tempProfName, 0);
                Application.LoadLevel("HarveyWithLighting");
                isCreatingProfile = false;
            }
			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 - 20, 200, 32, profNameTwo, MenuTools.buttonStyle)){
                SaveController.CreateProfile(tempProfName, 1);
                Application.LoadLevel("HarveyWithLighting");
                isCreatingProfile = false;
            }

			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 + 20, 200, 32, profNameThree, MenuTools.buttonStyle)){
                SaveController.CreateProfile(tempProfName, 2);
                Application.LoadLevel("HarveyWithLighting");
                isCreatingProfile = false;
            }

			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 + 100, 200, 32, "Cancel", MenuTools.buttonStyle)){
                isCreatingProfile = false;
            }
        }
        if (isLoadingProfile)
        {
            string profNameOne = PlayerPrefs.HasKey("saveOne_profName") ? PlayerPrefs.GetString("saveOne_profName") : "Empty";
            string profNameTwo = PlayerPrefs.HasKey("saveTwo_profName") ? PlayerPrefs.GetString("saveTwo_profName") : "Empty";
            string profNameThree = PlayerPrefs.HasKey("saveThree_profName") ? PlayerPrefs.GetString("saveThree_profName") : "Empty";
            //GUI.Box(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 300), "");
            MenuTools.DrawMenu(Screen.width/2 - 125, Screen.height/2 - 120, 250, 290);

			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 200, 20), "Load Profile", MenuTools.buttonStyle);

			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 - 60, 200, 32, profNameOne, MenuTools.buttonStyle)) {
                isLoadingProfile = false;
                if(!SaveController.LoadProfile(0)) {
                    isLoadingProfile = true;
                    Debug.Log("Profile Failed to Load");
                }
            }
			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 - 20, 200, 32, profNameTwo, MenuTools.buttonStyle)) {
                isLoadingProfile = false;
                if(!SaveController.LoadProfile(1)) {
                    isLoadingProfile = true;
                    Debug.Log("Profile Failed to Load");
                }
            }
			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 + 20, 200, 32, profNameThree, MenuTools.buttonStyle)) {
                isLoadingProfile = false;
                if(!SaveController.LoadProfile(2)) {
                    isLoadingProfile = true;
                    Debug.Log("Profile Failed to Load");
                }
            }
			if(MenuTools.DrawButton(Screen.width/2 - 100, Screen.height/2 + 100, 200, 32, "Cancel", MenuTools.buttonStyle)) {
                isLoadingProfile = false;
            }
        }
    }

    void LoadGame() {
        if(zooming){
            if(!flashTexture.guiTexture.enabled) {
                flashTexture.guiTexture.enabled = true;
                flashTexture.guiTexture.color = new Color(1f,1f,1f,0f);
                RotatePageForward(mainPage);
            }
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, endFOV, Time.deltaTime * cameraSpeed);
            currentOpacity = Mathf.Lerp(currentOpacity, 1f, Time.deltaTime * cameraSpeed);
            flashTexture.guiTexture.color = new Color(1f,1f,1f,currentOpacity);
            if(currentOpacity > 0.7f) {
                Application.LoadLevel("HarveyWithLighting");
            }
        }
        //Application.LoadLevel("HarveyWithLighting");
    }

    void RotatePageForward(GameObject pageToRotate)
    {
        Debug.Log("rotating");
        lerpingObject = pageToRotate;
        lerpingPage = true;
        source = lerpingObject.transform.rotation;
        lerpingObject.transform.Rotate(0, -180, 0);
        target = lerpingObject.transform.rotation;
    }
    
    void RotatePageBackward(GameObject pageToRotate)
    {

    }

    void DebugRaycast(Ray ray, RaycastHit hit)
    {
        Debug.DrawLine(ray.origin, hit.point);
        Debug.Log("Raycast hit : " + hit.collider.gameObject.name);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            LineRenderer lineRendererNew = gameObject.AddComponent<LineRenderer>();
            lineRendererNew.material = new Material(Shader.Find("Particles/Additive"));
            lineRendererNew.SetColors(c1, c2);
            lineRendererNew.SetWidth(0.05F, 0.05F);
            lineRenderer = lineRendererNew;
        }
        lineRenderer.enabled = true;         
        lineRenderer.SetPosition(0, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - .2f, Camera.main.transform.position.z)); 
        lineRenderer.SetPosition(1, hit.point);
    
    }
    
    void EndDebugRaycast()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            Destroy(lineRenderer);
        }
    }
}
