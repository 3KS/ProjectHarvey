using UnityEngine;
using System.Collections;

public class DialogueTreeOptions : MonoBehaviour
{
	public GameObject player;
	public GameObject chatMiniGameTrigger;

	public bool option1Play;
	public bool option2Play;
	public bool option3Play;
	public bool option4Play;
	public bool option5Play;
	public bool option6Play;
	public bool option7Play;

	public bool optionAPlay;
	public bool optionBPlay;
	public bool optionCPlay;
	public bool optionDPlay;
	public bool optionEPlay;
	public bool optionFPlay;
	public bool optionGPlay;


	public AudioSource option1;
	public AudioSource option2;
	public AudioSource option3;
	public AudioSource option4;
	public AudioSource option5;
	public AudioSource option6;
	public AudioSource option7;
	
	public AudioSource optionA;
	public AudioSource optionB;
	public AudioSource optionC;
	public AudioSource optionD;
	public AudioSource optionE;
	public AudioSource optionF;
	public AudioSource optionG;	


/*HOW DOES IT WORK?
 * 
 * The Dialogue Tree script on the player displays GUI buttons as options.
 * 
 * When the player chooses a button, the options turn off and the response to their selection plays.
 * 		The audio plays because the Dialogue Tree script calls the corresponding function below.
 * 
 * When the response ends, this script sets the next option set to true, allowing the player to chose again.
 * 		When the audio plays, it sets a variable to true (both are handled by  that is checked by this script's Update function
 * 		When the function is called, and the audio ends, the Update advances the dialogue tree by setting a boolean in Dialogue Tree true or calling a function
 * 
 * This script should be attached to an object that has all of the dialogue for that character as attatched audiosources.
 * 
*****The character chooses from a random number of greetings and farewells to keep gameplay interesting.*****
 * 
 * SEE OPTION 1 IN THE Update and the Function List to see more details.
 * */

	void Update()
	{
		if (option1Play == true && !option1.isPlaying) 				// Checks to see if the function has been called via variable and waits for that function's audio to play
		{
			Debug.Log ("option 1 is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decision2 = true;	// Advances the dialougue tree to the next 
			Debug.Log ("option 1 stuff should be done");
			
			option1Play = false;
		}

		if (option2Play == true && !option2.isPlaying)
		{
			Debug.Log ("option 2 is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decision3 = true;
			Debug.Log ("option 2 stuff should be done");

			option2Play = false;
		}

		if (option3Play == true && !option3.isPlaying)
		{
			Debug.Log ("option 3 is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decision3 = true;
			Debug.Log ("option 3 stuff should be done");

			option3Play = false;
		}

		if (option4Play == true && !option4.isPlaying)
		{
			Debug.Log ("option 4 is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option 4 stuff should be done");

			option4Play = false;
		}

		if (option5Play == true && !option5.isPlaying)
		{
			Debug.Log ("option 5 is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option 5 stuff should be done");

			option5Play = false;
		}

		if (option6Play == true && !option6.isPlaying)
		{
			Debug.Log ("option 6 is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option 6 stuff should be done");

			option6Play = false;
		}

		if (option7Play == true && !option7.isPlaying)
		{
			Debug.Log ("option 7 is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option 7 stuff should be done");

			option7Play = false;
		}


// THIS IS THE END OF DIALOGUE BRANCH NUMBERS
// THIS IS THE BEGINNING OF DIALOGUR BRANCH LETTERS


		if (optionAPlay == true && !optionA.isPlaying)
		{
			Debug.Log ("option A is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decisionB = true;
			Debug.Log ("option A stuff should be done");

			optionAPlay = false;
		}

		if (optionBPlay == true && !optionB.isPlaying)
		{
			Debug.Log ("option B is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decisionC = true;
			Debug.Log ("option B stuff should be done");

			optionBPlay = false;
		}

		if (optionCPlay == true && !optionC.isPlaying)
		{
			Debug.Log ("option C is over, should be doing stuff");
			player.GetComponent <DialogueTree>().decisionD = true;
			Debug.Log ("option C stuff should be done");

			optionCPlay = false;
		}

		if (optionCPlay == true && !optionD.isPlaying)
		{
			Debug.Log ("option D is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option D stuff should be done");

			optionDPlay = false;
		}

		if (optionEPlay == true && !optionE.isPlaying)
		{
			Debug.Log ("option E is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option E stuff should be done");

			optionEPlay = false;
		}

		if (optionFPlay == true && !optionF.isPlaying)
		{
			Debug.Log ("option F is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option F stuff should be done");

			optionFPlay = false;
		}

		if (optionGPlay == true && !optionG.isPlaying)
		{
			Debug.Log ("option G is over, should be doing stuff");
			chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses>().PlayRandomFarewell ();
			Debug.Log ("option G stuff should be done");

			optionGPlay = false;
		}
	}

// Each of the following functions control audio for the selected dialogue option
// They also control turning the option GUI off when a button is pressed
	public void Option1 ()
	{
		option1.Play ();											// Plays the audio
		option1Play = true;											// Needed in the Update function for advancing the dialogue
		player.GetComponent <DialogueTree>().decision1 = false;		// Accesses the Dialogue Tree script to turn off the selection menu
	}

	public void Option2 ()
	{
		option2.Play ();
		option2Play = true;
		player.GetComponent <DialogueTree>().decision2 = false;
	}

	public void Option3 ()
	{
		option3.Play ();
		option3Play = true;
		player.GetComponent <DialogueTree>().decision2 = false;
	}

	public void Option4 ()
	{
		option4.Play ();
		option4Play = true;
		player.GetComponent <DialogueTree>().decision3 = false;
	}

	public void Option5 ()
	{
		option5.Play ();
		option5Play = true;
		player.GetComponent <DialogueTree>().decision3 = false;
	}

	public void Option6 ()
	{
		option6.Play ();
		option6Play = true;
		player.GetComponent <DialogueTree>().decision4 = false;
	}

	public void Option7 ()
	{
		option7.Play ();
		option7Play = true;
		player.GetComponent <DialogueTree>().decision4 = false;
	}

	
// THIS IS THE END OF DIALOGUE BRANCH NUMBERS
// THIS IS THE BEGINNING OF DIALOGUR BRANCH LETTERS
	
	
	public void OptionA ()
	{
		optionA.Play ();
		optionAPlay = true;
		player.GetComponent <DialogueTree>().decision1 = false;
	}

	public void OptionB ()
	{
		optionB.Play ();
		optionBPlay = true;
		player.GetComponent <DialogueTree>().decisionB = false;
	}

	public void OptionC ()
	{
		optionC.Play ();
		optionCPlay = true;
		player.GetComponent <DialogueTree>().decisionB = false;
	}
	public void OptionD ()
	{
		optionD.Play ();
		optionDPlay = true;
		player.GetComponent <DialogueTree>().decisionC = false;
	}

	public void OptionE ()
	{
		optionE.Play ();
		optionEPlay = true;
		player.GetComponent <DialogueTree>().decisionC = false;
	}

	public void OptionF ()
	{
		optionF.Play ();
		optionFPlay = true;
		player.GetComponent <DialogueTree>().decisionD = false;
	}

	public void OptionG ()
	{
		optionG.Play ();
		optionGPlay = true;
		player.GetComponent <DialogueTree>().decisionD = false;
	}
}
