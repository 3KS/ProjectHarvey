using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour
{

    private static string prefix;


    public static string GetPrefix() {
        return prefix;
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
