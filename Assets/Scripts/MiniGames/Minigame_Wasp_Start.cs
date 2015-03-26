using UnityEngine;
using System.Collections;

public class Minigame_Wasp_Start : MonoBehaviour
{
	public static bool gameHasStarted;
	public static int killCount;

	void Start ()
	{
		gameHasStarted = false;
		killCount = 0;	
	}
	
	void Update ()
	{
		//gameHasStarted = true;
	
		if (killCount == 10)
		{
//			AchievementContoller.UnlockAchievement (AchievementContoller.Achievements.SwatTeam);
			killCount = 0;
		}
		
	//	Debug.Log (killCount);
	}
	
	void OnTriggerEnter(Collider waspGame)
	{
		gameHasStarted = true;
		
		if (waspGame.name == "WaspGameTrigger")
		{
			MiniGame_Wasp_Swatter.swatterVisible = true;
		}
	}
	
	void OnTriggerExit(Collider waspGame)
	{
		gameHasStarted = false;
	
		if (waspGame.name == "WaspGameTrigger")
		{
			MiniGame_Wasp_Swatter.swatterVisible = false;
			MiniGame_Wasp_Swatter.audioCanPlay = false;
		}
		
	}
}
