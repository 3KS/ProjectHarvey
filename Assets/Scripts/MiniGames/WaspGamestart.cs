using UnityEngine;
using System.Collections;

public class WaspGamestart : MonoBehaviour
{
	
	public GameObject waspGameTrigger;
	public GameObject waspSwatter;
	
	void Start ()
	{
		waspSwatter.renderer.enabled = false;
	}
	
	void OnTriggerEnter ()
	{
		waspSwatter.renderer.enabled = true;

		WaspSwatter.gameIsRunning = true;
	}
	
	void OnTriggerExit()
	{
		waspSwatter.renderer.enabled = false;

		WaspSwatter.gameIsRunning = false;
	}
}