using UnityEngine;
using System.Collections;

public class AudioCollider: MonoBehaviour 
{

	public AudioSource sound;
	private int timer = 9001;
	public int waitTime = 1800;
	public bool repeat = true;

	// Use this for initialization
	void Start () 
	{
		timer = 9001;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (repeat) {
						timer++;
				}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "First Person Controller")
		{

						if (timer >= waitTime) 
						{
								sound.Play ();
								timer = 0;
						}
		}

						

	}
}
