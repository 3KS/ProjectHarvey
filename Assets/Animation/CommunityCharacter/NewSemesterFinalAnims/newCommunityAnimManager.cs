using UnityEngine;
using System.Collections;

public class newCommunityAnimManager : MonoBehaviour {
	
	
	protected Animator animator;
	
	public bool iswalk;
	public int walktype;
	//public bool Walk2;
	//public bool Walk3;
	
	public bool Build1;
	

	public bool issit;
		public int sittype;
	/*public bool Piano1;
	public bool clarinet;
	public bool eat;
	public bool drink;
	public bool cards;
	public bool board;
	public bool sit_down;
	public bool typewriting;
	*/
	
	public bool lecture;
	public bool write;
	
	public bool brushOff;
	public bool smoke;

	public bool Talk;
	public bool read;
	public bool LookAround;
	public bool disagree;
	public bool agree;
	
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool ("IsWalk", iswalk);
		animator.SetInteger ("WalkEnum", walktype);
		//animator.SetBool ("walk_slow", Walk2);
		//animator.SetBool ("walk_fast", Walk3);
		
		animator.SetBool ("Hammering_1", Build1);
		
		animator.SetBool ("IsSit", issit);
		animator.SetInteger ("SitEnum", sittype);
		/*animator.SetBool ("piano_1", Piano1);
		animator.SetBool ("clarineting", clarinet);
		animator.SetBool ("eating", eat);
		animator.SetBool ("drinking", drink);
		animator.SetBool ("cardsing", cards);
		animator.SetBool ("board", board);
		animator.SetBool ("sit_down", sit_down);
		animator.SetBool ("typewriting", typewriting);
		*/
		
		animator.SetBool ("lecture", lecture);
		animator.SetBool ("write", write);

		animator.SetBool ("brushOff", brushOff);
		animator.SetBool ("smoke", smoke);
		
		
		
		
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


