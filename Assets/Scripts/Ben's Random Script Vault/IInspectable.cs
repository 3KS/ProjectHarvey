using UnityEngine;
using System.Collections;

public class IInspectable : MonoBehaviour {

    public GameObject viewableObject;

    public string title;
    public string description;

    private bool isCopy = false;

    public float viewingScale = 1;

    public float viewingXRotation;
    public float viewingYRotation;
    public float viewingZRotation;
	
    void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isCopy)
        {
            transform.RotateAround(this.transform.position, Vector3.up, 0.5f);
        }
	}

    public GameObject GetDisplayObject() {
        return viewableObject;
    }

    public void SetIsCopy() {
        isCopy = true;
        this.transform.localScale = new Vector3(viewingScale, viewingScale, viewingScale);
        this.transform.localEulerAngles = new Vector3(viewingXRotation, viewingYRotation, viewingZRotation);
        this.tag = "Untagged";
        this.gameObject.layer = 16;
    }

    public string GetObjectTitle() {
        return title;
    }
    
    public string GetObjectDescription() {
        return description;
    }
}
