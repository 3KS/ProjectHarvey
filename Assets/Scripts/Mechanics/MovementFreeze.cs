using UnityEngine;
using System.Collections;

public class MovementFreeze : MonoBehaviour
{
	
    public GameObject player;
	public GameObject playerCam;
    private static GameObject statPlayer;
    private static GameObject statPlayerCam;

	public static bool playerFrozen = false;

	void Start ()
	{
        statPlayer = player;
        statPlayerCam = playerCam;
	}

    public static bool FreezePlayer() {
        try{
            statPlayer.GetComponent<CharacterMotor> ().enabled = false;         //Used to freeze the player during examination
            statPlayer.GetComponent<MouseLook> ().enabled = false;              //Used to freeze the player during examination
            statPlayerCam.GetComponent<MouseLook> ().enabled = false;           //Used to freeze the player during examination
            playerFrozen = true;
        } catch {
            Debug.Log("MovementFreeze.FreezePlayer(); Encountered an error");
            return false;
        }
        return true;
    }

    public static bool UnFreezePlayer() {
        try{
            statPlayer.GetComponent<CharacterMotor> ().enabled = true;          //Used to freeze the player during examination
            statPlayer.GetComponent<MouseLook> ().enabled = true;               //Used to freeze the player during examination
            statPlayerCam.GetComponent<MouseLook> ().enabled = true;            //Used to freeze the player during examination
            playerFrozen = false;
        } catch {
            Debug.Log("MovementFreeze.UnFreezePlayer(); Encountered an error");
            return false;
        }
        return true;
    }

    public bool GetFreezeState() {
        return playerFrozen;
    }

}