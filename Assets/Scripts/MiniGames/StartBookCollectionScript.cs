using UnityEngine;
using System.Collections;

public class StartBookCollectionScript : MonoBehaviour
{
	public GameObject player;
	public GameObject bookMiniGameTrigger;
	private bool showText = false;

	public string labelText = "";

	void OnGUI() {
		GUILayout.Label(labelText);
	}
	void OnTriggerEnter(Collider other)
	{

		Debug.Log ("We in this");
		if (AchievementController.CheckAchievement (AchievementController.Achievements.ObjectCollection)) 
		{
			labelText = "";
		} 
		else 
		{
			labelText = "I need you to help me find my five missing books! They're hidden around the library.";
		}
}
	void OnTriggerExit(Collider other)
	{
		labelText = "";
		Debug.Log ("we out");
	}
}