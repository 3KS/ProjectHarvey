using UnityEngine;
using System.Collections;

public class BackToDiorama_Trigger : MonoBehaviour
{

	private int exit;
	private int originalCount;

	public int leaveDelay;

    private bool exiting = false;
	//private bool showTimer;

	void OnGUI ()
	{

		/**if (showTimer == true)
		{
			GUI.Label (new Rect (Screen.width / 2, 0, 150, 100), "Leaving room in " + leaveDelay);
		}**/
        if (exiting)
        {
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Press 'E' to return to diorama"));
            MenuTools.DrawSmallMenu(Screen.width/2 - (int)size.x/2 + 10, Screen.height/2 - (int)size.y/2 + 10, (int)size.x + 20, (int)size.y + 20);
            GUI.Label(new Rect(Screen.width/2 - (int)size.x/2 + 10 + 10, Screen.height/2 - (int)size.y/2 + 10 + 10, 150, 50), "Press 'E' to return to diorama", MenuTools.dioramaLabel);
        }
    }

	void Start ()
	{
		/**showTimer = false;
		originalCount = leaveDelay;
		exit = 0;**/
	}

	void Update ()
	{
		/**if (leaveDelay == exit)
		{
			Application.LoadLevel ("HarveyWithLighting");
		}**/
	}

    void OnTriggerEnter (Collider other) {
        if (other.tag.Equals("Player"))
        {
            exiting = true;
        }
    }

	void OnTriggerStay (Collider door)
	{
    //    Debug.Log("Wants to exit!");

        if (Input.GetKeyDown(KeyCode.E) && exiting)
        {
            Screen.lockCursor = false;
            Application.LoadLevel("HarveyWithLighting");
        }
        //if (door.tag == "Exit")
		//{
		//	leaveDelay--;
		//	showTimer = true;
		//}
	}

	void OnTriggerExit (Collider door)
	{
        exiting = false;
		/**leaveDelay = originalCount;
		showTimer = false;**/
	}
}
