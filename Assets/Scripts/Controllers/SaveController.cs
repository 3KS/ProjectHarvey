using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour
{

    private static string prefix;

	//********************************************
	// GetPrefix()
	// returns the saved game prefix 
	//********************************************
    public static string GetPrefix() {
        return prefix;
    }

	//********************************************
	// GetRoomPrefix()
	// returns the saved game prefix with the current room
	//********************************************
	public static string GetRoomPrefix() {
		return prefix + Application.loadedLevelName + "_";
	}

    public static void CreateProfile(string name, int saveSlot)
    {
        //Debug.Log("Created profile");
        switch (saveSlot)
        {
            case 0:
                prefix = "saveOne_";
                break;
            case 1:
                prefix = "saveTwo_";
                break;
            case 2:
                prefix = "saveThree_";
                break;
            default:
                prefix = "saveOne_";
                break;
        }
        SaveNewProfile(name);
    }

    public static bool LoadProfile(int saveSlot) {
        if (SlotOccupied(saveSlot))
        {
            if(PlayerPrefs.GetString(prefix + "currentScene").Equals("HarveyWithLighting")) {
                PlayerPrefs.SetString("temp_dioramRot", PlayerPrefs.GetString(prefix + "dioramRot"));
                PlayerPrefs.SetInt("temp_dioramTime",  PlayerPrefs.GetInt(prefix + "dioramTime"));
            }
            Application.LoadLevel(PlayerPrefs.GetString(prefix + "currentScene"));
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SaveNewProfile(string name)
    {
        //Debug.Log("saved new profile");
        PlayerPrefs.SetString(prefix + "profName", name); 
        PlayerPrefs.SetString(prefix + "dioramRot", "Front"); 
        PlayerPrefs.SetInt(prefix + "dioramTime", 1);
        PlayerPrefs.SetString(prefix + "currentScene", "HarveyWithLighting");
        PlayerPrefs.SetFloat(prefix + "playTime", 0.0f);
        PlayerPrefs.SetString("temp_dioramRot", "Front");
        PlayerPrefs.SetInt("temp_dioramTime", 1);
		PlayerPrefs.SetInt(prefix + "canPlayTheater", 0);
		PlayerPrefs.SetInt (prefix + "canPlayWasps", 0);
		PlayerPrefs.SetInt (prefix + "CanPlayTea", 0);
		PlayerPrefs.SetInt ("booksAddedPrefs", 0);
		PlayerPrefs.SetInt ("muralsAddedPrefs", 0);
		ResetFPC();
        AchievementController.ResetAchievements();
        PlayerPrefs.Save();
    }

    public static void CacheDiorama()
    {
        PlayerPrefs.SetString("temp_dioramRot", DioramaRotation.GetDioramRot().ToString());
        PlayerPrefs.SetInt("temp_dioramTime", TimeSlider.GetTimePeriod());
        PlayerPrefs.Save();
    }

	//********************************************
	// SaveCurrentFPC()
	// saves the position of the first person controller in the current room
	//********************************************
	public static bool SaveCurrentFPC() {
		if (GameObject.Find("First Person Controller") != null) {
			Transform fpcTransform = GameObject.Find("First Person Controller").transform;
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerPosX", fpcTransform.position.x);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerPosY", fpcTransform.position.y);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerPosZ", fpcTransform.position.z);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerRotX", fpcTransform.eulerAngles.x);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerRotY", fpcTransform.eulerAngles.y);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerRotZ", fpcTransform.eulerAngles.z);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerScaleX", fpcTransform.localScale.x);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerScaleY", fpcTransform.localScale.y);
			PlayerPrefs.SetFloat(GetRoomPrefix() + "playerScaleZ", fpcTransform.localScale.z);
			return true;
		} 
		Debug.Log("SaveController.SaveCurrentFPC() could not find a First Person Controller in the current scene");
		return false;
	}

	//********************************************
	// LoadCurrentFPC()
	// loads the position of the first person controller in the current room
	//********************************************
	public static bool LoadCurrentFPC() {
		if (GameObject.Find("First Person Controller") != null) { //Checks if there is a first person controller
			if (PlayerPrefs.HasKey(SaveController.GetRoomPrefix() + "playerPosX")) { //Checks if there is save data for the first person controller
				GameObject.Find("First Person Controller").transform.position = new Vector3(
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerPosX"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerPosY"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerPosZ"));
				GameObject.Find("First Person Controller").transform.rotation = Quaternion.Euler(
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerRotX"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerRotY"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerRotZ"));
				GameObject.Find("First Person Controller").transform.localScale = new Vector3(
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerScaleX"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerScaleY"), 
					PlayerPrefs.GetFloat(GetRoomPrefix() + "playerScaleZ"));
				return true;
			}
			Debug.Log("SaveController.LoadCurrentFPC() could not find save data for the current scene");
			return false;
		}
		Debug.Log("SaveController.LoadCurrentFPC() could not find a First Person Controller in the current scene");
		return false;
	}

	//********************************************
	// ResetFPC()
	// saves the position of the first person controller in the current room
	//********************************************
    public static void ResetFPC() {
        PlayerPrefs.DeleteKey(prefix + "playerPosX");
        PlayerPrefs.DeleteKey(prefix + "playerPosY");
        PlayerPrefs.DeleteKey(prefix + "playerPosZ");
        PlayerPrefs.DeleteKey(prefix + "playerRotX");
        PlayerPrefs.DeleteKey(prefix + "playerRotY");
        PlayerPrefs.DeleteKey(prefix + "playerRotZ");
        PlayerPrefs.DeleteKey(prefix + "playerScaleX");
        PlayerPrefs.DeleteKey(prefix + "playerScaleY");
        PlayerPrefs.DeleteKey(prefix + "playerScaleZ");
    }

    public static void SaveCurrentProfile()
    {
        if (!Application.loadedLevelName.Equals("HarveyWithLighting") && !Application.loadedLevelName.Equals("MainMenu"))
        {
            Transform fpcTransform = GameObject.Find("First Person Controller").transform;
            PlayerPrefs.SetFloat(prefix + "playerPosX", fpcTransform.position.x);
            PlayerPrefs.SetFloat(prefix + "playerPosY", fpcTransform.position.y);
            PlayerPrefs.SetFloat(prefix + "playerPosZ", fpcTransform.position.z);
            PlayerPrefs.SetFloat(prefix + "playerRotX", fpcTransform.eulerAngles.x);
            PlayerPrefs.SetFloat(prefix + "playerRotY", fpcTransform.eulerAngles.y);
            PlayerPrefs.SetFloat(prefix + "playerRotZ", fpcTransform.eulerAngles.z);
            PlayerPrefs.SetFloat(prefix + "playerScaleX", fpcTransform.localScale.x);
            PlayerPrefs.SetFloat(prefix + "playerScaleY", fpcTransform.localScale.y);
            PlayerPrefs.SetFloat(prefix + "playerScaleZ", fpcTransform.localScale.z);
        } else
        {
            ResetFPC();
        }
        PlayerPrefs.SetString(prefix + "currentScene", Application.loadedLevelName);
        PlayerPrefs.SetFloat(prefix + "playTime", 0.0f);
        PlayerPrefs.SetString(prefix + "dioramRot", PlayerPrefs.GetString("temp_dioramRot"));
        PlayerPrefs.SetInt(prefix + "dioramTime", PlayerPrefs.GetInt("temp_dioramTime"));
        PlayerPrefs.Save();
    }

    public static bool SlotOccupied(int saveSlot)
    {
        switch (saveSlot)
        {
            case 0:
                prefix = "saveOne_";
                break;
            case 1:
                prefix = "saveTwo_";
                break;
            case 2:
                prefix = "saveThree_";
                break;
            default:
                prefix = "saveOne_";
                break;
        }
        if (PlayerPrefs.HasKey(prefix + "profName"))
        {
            return true;
        }
        return false;
    }
}
