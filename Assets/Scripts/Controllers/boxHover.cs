using UnityEngine;
using System.Collections;

public class boxHover : MonoBehaviour
{
    //public GameObject levelSelectControl;
	public bool available = true;
    private Vector3 cameraDestination;
    private static bool zoomingRoom = false;
    private static Camera mainCamera;
    private static float zoomSpeed = 0.2f;
    public string DestinationScene;
    public bool isHovered;
    public string roomName;
    public string roomInfo;
    public AchievementController.VisitableRooms room;
	private string menuID = "hoverRoom";

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
			if(isHovered) {
				isHovered = false;
				GameController.ClearNotification(menuID);
			}
		}
        zoomRoom();    
    }
    
    void  OnMouseOver()
    {
		if (Time.timeScale == 1) {
			if (this.enabled && !zoomingRoom && BeginFader.GetDoneLoad ()) {
				Light[] lights = gameObject.GetComponentsInChildren<Light> (false);
                if(!isHovered) {
					isHovered = true;
					GameController.DisplayFollowNotification(menuID, roomName);
				}
				foreach (Light light in lights) {
					light.enabled = true;
				}
				if ((Input.GetMouseButton (0) || Input.GetButtonDown("Select")) && available) {

					Screen.lockCursor = true;
					zoomingRoom = true;
                    PlayerPrefs.SetInt(SaveController.GetPrefix() + room.ToString(), 1);
					BeginFader.StartRoomZoom (DestinationScene);
				}
			}
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
			if(isHovered) {
	            isHovered = false;
				GameController.ClearNotification(menuID);
			}
		}
    }
    
    void OnMouseDown()
    {
        //levelSelectControl.GetComponent<ZoomIntoRoom>().Zoom();
    }
}
