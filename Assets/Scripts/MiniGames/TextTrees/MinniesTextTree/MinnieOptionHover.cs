using UnityEngine;
using System.Collections;

public class MinnieOptionHover : MonoBehaviour
{
	public GameObject player;
	public GameObject hoverOption;

	void Start ()
	{
		
	}

	 void OnMouseOver ()
	{
		Debug.Log("Mouse is hovering over an option");

		player.GetComponent<MinnieTextTree>().hoveringOverOption = true;

		if (Input.GetMouseButtonDown (0))
		{
			player.GetComponent<MinnieTextTree>().currentOption = hoverOption;
		}
	}
}
