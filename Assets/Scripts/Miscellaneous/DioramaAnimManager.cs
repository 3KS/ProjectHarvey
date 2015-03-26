using UnityEngine;
using System.Collections;

public class DioramaAnimManager : MonoBehaviour {

	protected Animator animator;
	
	public bool Walk1;
	public bool sit = false;
	public bool stand = false;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool ("walking", Walk1);
		if (sit == true) {
			animator.SetTrigger ("sitDown");
		}
		if (stand == true) {
			Walk1 = false;
			animator.SetBool ("walking", Walk1);
			if (sit == true) {
				sit = false;
				animator.SetTrigger ("standUp");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Stand(){
		if (stand == true) {
			Walk1 = false;
			animator.SetBool ("walking", Walk1);
			if (sit == true) {
				sit = false;
				animator.SetTrigger ("standUp");
			}
			stand = false;
		}
	}

	void SitDown(){
		if (sit) {
			animator.SetTrigger ("sitDown");
			sit = false;
		}
	}

}
