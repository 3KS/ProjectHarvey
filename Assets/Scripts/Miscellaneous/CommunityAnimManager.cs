using UnityEngine;
using System.Collections;

public class CommunityAnimManager : MonoBehaviour {


	protected Animator animator;

	public bool Walk1;
	public bool Walk2;
	public bool Build1;
	public bool Piano1;
	public bool clarinet;
	public bool eat;
	public bool drink;
	public bool cards;
	public bool board;
	public bool sit_down;
	public bool typewriting;
	public bool lecture;



	public bool Talk;
	public bool read;
	public bool LookAround;
	public bool disagree;
	public bool agree;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool ("walk_1", Walk1);
		animator.SetBool ("walk_2", Walk2);
		animator.SetBool ("Hammering_1", Build1);
		animator.SetBool ("piano_1", Piano1);
		animator.SetBool ("clarineting", clarinet);
		animator.SetBool ("eating", eat);
		animator.SetBool ("drinking", drink);
		animator.SetBool ("cardsing", cards);
		animator.SetBool ("board", board);
		animator.SetBool ("sit_down", sit_down);
		animator.SetBool ("typewriting", typewriting);
		animator.SetBool ("lecture", lecture);



	}
	
	// Update is called once per frame
	void Update () {
		if (Talk) {
			animator.SetTrigger ("talk");
			Talk = false;
		}
		if (LookAround) {
			animator.SetTrigger ("lookAround");
			LookAround = false;
		}
		if (read) {
			animator.SetTrigger ("read");
			read = false;
		}
		if (agree) {
			animator.SetTrigger ("agree");
			agree = false;
		}
		if (disagree) {
			animator.SetTrigger ("disagree");
			disagree = false;
		}
	}

}


