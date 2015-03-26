using UnityEngine;
using System.Collections;

/**********************************
 * Class: QuestObjectActivator.cs
 * Author: Benjamin Pease
 * Description: Is applied to the first person controller for changing the glow of the object when it is viewed by the player.
 * Requires the object to have the tag "QuestObject" and also the "Caveman/Adjustable Bumped Diffuse, Adjustable Glow" shader
 **********************************/

public class QuestObjectActivator : MonoBehaviour {
	private Transform lastTransform;
	void Start () {
	
	}
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit, 2.0f)) {
						if (hit.transform.tag.Equals ("QuestObject") && hit.transform.gameObject.activeSelf) {
								if (lastTransform == null) {
										lastTransform = hit.transform;
								}
								hit.transform.gameObject.renderer.material.SetColor ("_RimColor", Color.cyan);
								if (Input.GetMouseButton (0)) {
										hit.transform.gameObject.GetComponent<QuestObject> ().CollectObject ();
								}
						}
						if (lastTransform != null && !lastTransform.Equals (hit.transform)) {
								lastTransform.gameObject.renderer.material.SetColor ("_RimColor", Color.black);
								lastTransform = null;
						}
				} else if (lastTransform != null) {
						lastTransform.gameObject.renderer.material.SetColor ("_RimColor", Color.black);
						lastTransform = null;
				}
		}
		
	}

