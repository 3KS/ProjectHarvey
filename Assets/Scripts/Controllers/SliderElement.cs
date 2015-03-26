using UnityEngine;
using System.Collections;

public class SliderElement : MonoBehaviour {
   
    private TimeSlider  script;
    public Texture2D buckleTexture;
    private GUIStyle buckleStyle;

	// Use this for initialization
	void Start () {
        script = this.transform.gameObject.GetComponent<TimeSlider>();

        buckleStyle = new GUIStyle();
        GUIStyleState buckleStyleSS = new GUIStyleState();
        buckleStyleSS.background = buckleTexture;
        buckleStyle.normal = buckleStyleSS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.enabled = GameController.GetPauseState () ? false : true;

        GUI.depth = 2;
		if (GUI.Button(new Rect(script.SliderHoriz-100, script.CalcVerticalTickPosition-17, 200, script.CalcTickHeight+34), "", buckleStyle) && !script.Sliding)
        {
            script.ClickLeft();
            Debug.Log("Clicked the left button");
            Debug.Log(script.FutureTimePeriod);
            Debug.Log(script.CurrentTimePeriod);
        }
    }

}
