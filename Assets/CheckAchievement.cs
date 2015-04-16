using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckAchievement : MonoBehaviour {

	public Sprite locked;
	public Sprite unLocked;
	public Text title;
	public Text description;
	public Image image;

	public AchievementController.Achievements achievement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(AchievementController.CheckAchievement(achievement)) {
			image.sprite = unLocked;
			title.color = Color.black;
			description.color = Color.black;
		} else {
			image.sprite = locked;
			title.color = new Color(.2f, .2f, .2f);
			description.color = new Color(.2f, .2f, .2f);
		}
	}
}
