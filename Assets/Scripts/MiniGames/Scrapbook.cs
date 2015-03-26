using UnityEngine;
using System.Collections;

public class Scrapbook : MonoBehaviour
{
	public static bool canReadScrapbook;
	public GameObject scrapbook;

	public AudioSource Fryklund_Clip;
	public AudioSource Menomonie_Clip;
	public AudioSource Stout_Institute_Clip;
	public AudioSource Student_Union_Clip;

	public Transform selectedMemory;
	public Transform selectedMemoryStandIn;

	private bool canPickAMemory;
	private bool enableAudio;
	private bool canStopLooking;

	void Start ()
	{
		canReadScrapbook = true;
		canPickAMemory = true;
	}

	void Update () 
	{
		if (canReadScrapbook == true)
		{
		
			if (canPickAMemory == true)
			{
				PickAMemory();
			}
			
			if (!Student_Union_Clip.isPlaying && !Stout_Institute_Clip.isPlaying && !Fryklund_Clip.isPlaying && !Menomonie_Clip.isPlaying)
			{
				Invoke ("StopLooking", 0.01f);
			}
		}
	}
	void PickAMemory ()
	{
		Ray checkForMemory = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));
		RaycastHit memoryFound;
		
		if (Physics.Raycast (checkForMemory, out memoryFound, 1.5f))
		{
			selectedMemory = memoryFound.transform;
			if (selectedMemory.tag == "Scrapbook" && Input.GetMouseButtonDown (0) && !selectedMemory.audio.isPlaying)
			{
				enableAudio = true;
				Invoke ("StopLooking", 1.0f);
				canPickAMemory = false;

				MovementFreeze.FreezePlayer();

				Pickup.scriptActive = false;
			}
		}
		
		if (enableAudio == true)
		{	
			Camera.main.transform.LookAt (selectedMemory.transform.position);

			if (selectedMemory.name == "Student_Union")
			{
				Student_Union_Clip.Play ();
			}

			if (selectedMemory.name == "Stout_Institute")
			{
				Stout_Institute_Clip.Play ();
			}

			if (selectedMemory.name == "Fryklund")
			{
				Fryklund_Clip.Play();
			}

			if (selectedMemory.name == "Menomonie")
			{
				Menomonie_Clip.Play ();
			}
		}
	}

	void StopLooking ()
	{
		if (!Menomonie_Clip.isPlaying && !Fryklund_Clip.isPlaying && !Stout_Institute_Clip.isPlaying && !Student_Union_Clip.isPlaying)
		{
			enableAudio = false;
			canPickAMemory = true;

			MovementFreeze.UnFreezePlayer();

			Pickup.scriptActive = true;
		}
	}
}