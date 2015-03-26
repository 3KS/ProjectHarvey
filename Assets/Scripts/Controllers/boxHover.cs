using UnityEngine;
using System.Collections;

public class boxHover : MonoBehaviour
{
    //public GameObject levelSelectControl;
    private Vector3 cameraDestination;
    private static bool zoomingRoom = false;
    private static Camera mainCamera;
    private static float zoomSpeed = 0.2f;
    public string DestinationScene;
    public bool isHovered;
    public string roomName;
    public string roomInfo;
    public AchievementController.VisitableRooms room;

    void Start()
    {
        zoomingRoom = false;
        mainCamera = Camera.main;
        //cameraDestination = this.transform.GetChild(0).transform.renderer.bounds.center;
    }
   
    void Update()
    {
		if (Time.timeScale == 0 ) {
			Light[] lights = GetComponentsInChildren<Light> (true);
			foreach (Light light in lights) {
				light.enabled = false;
			}
			isHovered = false;
		}
        zoomRoom();    
    }
    
    void  OnMouseOver()
    {
		if (Time.timeScale == 1) {
			if (this.enabled && !zoomingRoom && BeginFader.GetDoneLoad ()) {
				Light[] lights = gameObject.GetComponentsInChildren<Light> (false);
                isHovered = true;
				foreach (Light light in lights) {
					light.enabled = true;
				}
				if (Input.GetMouseButton (0) || Input.GetButtonDown("Select")) {
					zoomingRoom = true;
                    PlayerPrefs.SetInt(SaveController.GetPrefix() + room.ToString(), 1);
					BeginFader.StartRoomZoom (DestinationScene);
				}
			}
		}
    }

    void OnGUI() {

        if (isHovered)
        {
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent(roomName));
            //GUI.Box(new Rect((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y, size.x, size.y), "");
            MenuTools.DrawSmallMenu((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y, (int)size.x+20, (int)size.y+20);
            GUI.Label(new Rect(Input.mousePosition.x+10, Screen.height-Input.mousePosition.y+10, 150, 50),roomName, MenuTools.dioramaLabel);
        }
    }
    void zoomRoom()
    {
        if (zoomingRoom)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraDestination, Time.deltaTime * zoomSpeed);
        }
    }

    void  OnMouseExit()
    {
		if (Time.timeScale == 1) {
			Light[] lights = GetComponentsInChildren<Light> (true);
			foreach (Light light in lights) {
				light.enabled = false;
			}
            isHovered = false;
		}
    }
    
    void OnMouseDown()
    {
        //levelSelectControl.GetComponent<ZoomIntoRoom>().Zoom();
    }
}
