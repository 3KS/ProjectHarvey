using UnityEngine;
using System.Collections;

public class TextTreeTrigger : MonoBehaviour
{
	public GameObject player;
	public GameObject goodbye;

	
	void Start ()
	{
		goodbye.active = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			TextTree.textTreeActive = true;
			//TextTree.textTreeActive = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		TextTree.textTreeActive = false;
		GoodbyeVisible ();
	}

	void GoodbyeVisible ()
	{
		goodbye.active = true;
		Invoke ("GoodbyeInvisible", 3.0f);
	}

	void GoodbyeInvisible ()
	{
		goodbye.active = false;
	}
}
