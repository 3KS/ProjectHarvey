using UnityEngine;
using System.Collections;

public class IInspector : MonoBehaviour
{
    private Transform lastTransform;
    public Transform objectTransform;
    private bool isViewing;
    private bool canInteract = false;
    private GameObject visibleObject;
    private string objectTitle;
    private string objectDescription;
    public Texture2D crosshair;
    // Use this for initialization

    void Start()
    {
        //Application.targetFrameRate = 15;
    }
    
    // Update is called once per frame
    void Update()
    {
        Transform cam = Camera.main.transform;
        Ray ray = new Ray(cam.position, cam.forward);
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 1));
        RaycastHit hit = new RaycastHit();
        if (isViewing && (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E)))
        {
            Object.Destroy(visibleObject);
            isViewing = false;
            MovementFreeze.UnFreezePlayer();
        } 
		else if (Physics.Raycast(ray, out hit, 4.0f))
        {
             if (hit.transform.tag.Equals("InteractiveObject"))
            {
                Debug.Log("hitting");
                if (lastTransform == null)
                {
                    lastTransform = hit.transform;
                }

                if(!isViewing) {
                    canInteract = true;
                }
                //hit.transform.gameObject.renderer.material.SetColor("_RimColor", Color.cyan);
                if ((Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E)) && !isViewing)
                {
                    ViewObject(hit);
                }
            } else 
			{
                canInteract = false;
            }
            if (lastTransform != null && !lastTransform.Equals(hit.transform))
            {
                //lastTransform.gameObject.renderer.material.SetColor("_RimColor", Color.black);
                lastTransform = null;
            }
        } 
		else if (lastTransform != null)
        {
            //lastTransform.gameObject.renderer.material.SetColor("_RimColor", Color.black);
            lastTransform = null;
            canInteract = false;
        }
        else 
		{
            canInteract = false;
        }
       
    }

    void OnGUI() 
	{
        GUI.DrawTexture (new Rect (Screen.width/2, Screen.height/2, crosshair.width / 4, crosshair.height / 4), crosshair);

        if (isViewing)
        {
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent(objectTitle));
            //GUI.Box(new Rect((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y, size.x, size.y), "");
            MenuTools.DrawSmallMenu(50, 50, Screen.width / 2 - 100, Screen.height - 100);
            GUI.Label(new Rect(100, 100, 150, 50), objectTitle, MenuTools.dioramaLabel);
            GUI.Label(new Rect(100, 150, 150, 50), objectDescription, MenuTools.dioramaLabel);
        } else if (canInteract)
        {
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Press 'E' to view object"));
            MenuTools.DrawSmallMenu(Screen.width/2 - (int)size.x/2 + 10, Screen.height/2 - (int)size.y/2 + 10, (int)size.x + 20, (int)size.y + 20);
            GUI.Label(new Rect(Screen.width/2 - (int)size.x/2 + 10 + 10, Screen.height/2 - (int)size.y/2 + 10 + 10, 150, 50), "Press 'E' to view object", MenuTools.dioramaLabel);
        }
    }

    private void ViewObject(RaycastHit hit) 
	{
        isViewing = true;
        GameObject temp = hit.transform.gameObject.GetComponent<IInspectable>().GetDisplayObject();
        visibleObject = Instantiate(temp, objectTransform.position, temp.transform.rotation) as GameObject;
        visibleObject.GetComponent<IInspectable>().SetIsCopy();
        objectTitle = visibleObject.GetComponent<IInspectable>().GetObjectTitle();
        objectDescription = visibleObject.GetComponent<IInspectable>().GetObjectDescription();

        visibleObject.layer = 16;
        MovementFreeze.FreezePlayer();
    }
}

