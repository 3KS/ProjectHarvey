using UnityEngine;
using System.Collections;

public class EditorTools : MonoBehaviour {
    public GameObject gameController;
	// Use this for initialization
	void Start () {
	    if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameObject temp;
            temp = GameObject.Find("GameController(Clone)");
			GameObject temp2;
			temp2 = GameObject.Find("GameController");
            if(temp == null && temp2 == null) {
                GameObject.Instantiate(gameController);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
