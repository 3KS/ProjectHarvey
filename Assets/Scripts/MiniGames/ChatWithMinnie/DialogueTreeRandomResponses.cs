using UnityEngine;
using System.Collections;

public class DialogueTreeRandomResponses : MonoBehaviour
{
	public GameObject soundPlayer;
	public GameObject player;

	public bool playGreeting;
	public bool playFarewell;

	public float audioWait;

	public AudioClip[] greetings = new AudioClip[3];
	public AudioClip[] farewells = new AudioClip[3];


	void Update ()
	{
		if (playGreeting == true)
		{
			Invoke("Greeting", audioWait);
		}

		if (playFarewell == true)
		{
			Invoke ("Farewell", audioWait);
		}
	}


	public void PlayRandomGreeting ()
	{
		audio.clip = (greetings [Random.Range(0, greetings.Length)]);
		audioWait = audio.clip.length;
		audio.Play ();
		playGreeting = true;
	}


	public void PlayRandomFarewell ()
	{
		audio.clip = (farewells [Random.Range(0, farewells.Length)]);
		audioWait = audio.clip.length;
		audio.Play ();
		playFarewell = true;
	}
	
	
	void Greeting ()
	{
		playGreeting = false;
		player.GetComponent <DialogueTree> ().greetingIsOver = true;
	}


	void Farewell ()
	{
		MovementFreeze.UnFreezePlayer ();
		playFarewell = false;

	}

	void OnTriggerEnter (Collider other)
	{
		PlayRandomGreeting ();
	}


	void OnTriggerExit (Collider other)
	{
		PlayRandomFarewell ();
	}
}
