using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {
	public AchievementController.FindableObject questObjectName;
	// Use this for initialization
	void Start () {
		this.gameObject.renderer.material.SetColor("_RimColor", Color.black);
		this.gameObject.SetActive(!AchievementController.CheckObject (questObjectName));
	}
	
	// Update is called once per frame
	void Update () {
		//this.gameObject.renderer.material.SetColor("_RimColor", Color.black);
	}

	public void CollectObject() {
		AchievementController.FoundObject (questObjectName);
		this.gameObject.SetActive (false);
	}
}
