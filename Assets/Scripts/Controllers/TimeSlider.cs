using UnityEngine;
using System.Collections;

public class TimeSlider : MonoBehaviour
{
    public float sliderWidth;
    public float sliderHeight;
    public int sliderTimePeriods;
    public float sliderVerticalPosition;
    
    public float tickWidth;
    public float tickHeight;

    private int calcWidth;
    private int calcHeight;
    private int calcHorizontalPosition;
    public static int calcVerticalPosition;

    private int calcTickWidth;
    private int calcTickHeight;
    public int CalcTickHeight{ get { return calcTickHeight; }}
    private int calcVerticalTickPosition;
    public int CalcVerticalTickPosition{ get { return calcVerticalTickPosition; } }


	private int sliderHoriz;
	public int SliderHoriz { get { return sliderHoriz; } }
	private int futureSliderHoriz;

    private static int currentTimePeriod;
    public int CurrentTimePeriod{ get { return currentTimePeriod; } }
    private static int futureTimePeriod;
    public int FutureTimePeriod{ get { return futureTimePeriod; } }

    public float sliderMoveSpeed;
    private bool sliding = false;
    public bool Sliding{ get { return sliding; }}

    public GameObject harveyHallModel;
    public Material[] timePeriodMaterials;

    public GameObject[] time01Rooms;
    public GameObject[] time02Rooms;
    public GameObject[] time03Rooms;
    public GameObject[] time04Rooms;
    public GameObject[] time05Rooms;

    private float rawLerp;
    private float lerp;
  
    public Texture2D sliderBackgroundMid;
    public Texture2D sliderBackgroundLeft;
    public Texture2D sliderBackgroundRight;

    public Texture2D[] timePeriodButton;
    public Texture2D[] timePeriodButtonLit;

	private string hover;

    // Use this for initialization
    void Start()
    {
        Screen.showCursor = true;
        if (PlayerPrefs.HasKey("temp_dioramTime"))
        {
            currentTimePeriod = PlayerPrefs.GetInt("temp_dioramTime");
        } else
        {
            currentTimePeriod = 1;
        }
        futureTimePeriod = currentTimePeriod;
        harveyHallModel.renderer.material.SetFloat("_TexSlider", currentTimePeriod-1);
    }
    
    // Update is called once per frame
    void Update()
    {
		UpdateTimePeriod();
        UpdateMeasurements();
        UpdateVisibleRooms();
    }
    
    public static int GetCurrentTimePeriod() {
        return currentTimePeriod;
    }

    public static int GetTimePeriod() {
        return futureTimePeriod;
    }

    void UpdateMeasurements() {
        calcWidth = (int)(Screen.width * sliderWidth);
        calcHeight = (int)(Screen.height * sliderHeight);
        calcHorizontalPosition = (int)((Screen.width / 2) - (calcWidth / 2));
        calcVerticalPosition =(int)(Screen.height - (Screen.height * sliderVerticalPosition) - calcHeight);
        
        calcTickWidth = (int)(Screen.width * sliderWidth * tickWidth);
        calcTickHeight = (int)(Screen.height * sliderHeight * tickHeight);
        calcVerticalTickPosition = calcVerticalPosition - ((calcTickHeight-calcHeight)/2);
        if (!sliding)
        {
            sliderHoriz = ((calcHorizontalPosition + (calcWidth / (sliderTimePeriods+1)) * currentTimePeriod));
			futureSliderHoriz = sliderHoriz;
        }
    }

    void UpdateVisibleRooms() {
        if (currentTimePeriod == 1 && !sliding)
        {
            foreach (GameObject room in time01Rooms)
            {
                if (room != null)
                {
                    room.SetActive(true);
                }
            }
            foreach (GameObject room in time02Rooms)
            {
                if (room != null)
                {
                    room.SetActive(false);
                }
            }
        } else if (currentTimePeriod == 2 && ! sliding)
        {
            foreach (GameObject room in time01Rooms)
            {
                if (room != null)
                {
                    room.SetActive(false);
                }
            }
            foreach (GameObject room in time02Rooms)
            {
                if (room != null)
                {
                    room.SetActive(true);
                }
            }
        } else
        {
            foreach (GameObject room in time01Rooms)
            {
                if (room != null)
                {
                    room.SetActive(true);
                }
            }
            foreach (GameObject room in time02Rooms)
            {
                if (room != null)
                {
                    room.SetActive(true);
                }
            }
        }
    }

    void UpdateTimePeriod() {
        if (currentTimePeriod != futureTimePeriod)
        {
            rawLerp += Time.deltaTime * sliderMoveSpeed;
            lerp = Mathf.Min(rawLerp, 1);

            sliding = true;

			sliderHoriz = (int)Mathf.Lerp(sliderHoriz, futureSliderHoriz, lerp);
            
			harveyHallModel.renderer.material.GetFloat("_TexSlider");
            harveyHallModel.renderer.material.SetFloat("_TexSlider", Mathf.Lerp( harveyHallModel.renderer.material.GetFloat("_TexSlider"), futureTimePeriod-1, lerp));

			if ((sliderHoriz >= futureSliderHoriz - 1) & currentTimePeriod < futureTimePeriod)
            {
				sliderHoriz = futureSliderHoriz;
                currentTimePeriod = futureTimePeriod;
                sliding = false;
            }

			if ((sliderHoriz <= futureSliderHoriz + 1) & currentTimePeriod > futureTimePeriod)
            {
				sliderHoriz = futureSliderHoriz;
                currentTimePeriod = futureTimePeriod;
                sliding = false;
            }
        } else
        {
            rawLerp = 0;
        }

    }

    public void ClickLeft() {
        if (currentTimePeriod > 1)
        {
            futureTimePeriod-=1;
			futureSliderHoriz = ((calcHorizontalPosition + (calcWidth / (sliderTimePeriods)) * futureTimePeriod) - 25) - (calcWidth / (sliderTimePeriods)) / 2;
            SaveController.CacheDiorama();
        }
    }

    public void ClickRight() {
        if (currentTimePeriod < sliderTimePeriods)
        {
            futureTimePeriod+=1;
			futureSliderHoriz = ((calcHorizontalPosition + (calcWidth / (sliderTimePeriods)) * futureTimePeriod) - 25) - (calcWidth / (sliderTimePeriods)) / 2;
            SaveController.CacheDiorama();
        }
    }

    void OnGUI()
    {
		//This Line must be in all OnGUI methods to allow for correct pausing of the game
		GUI.enabled = GameController.GetPauseState () ? false : true;

        //GUI.Box(new Rect(calcHorizontalPosition, calcVerticalPosition, calcWidth, calcHeight), "");

     
        GUI.depth = 3;
        GUI.DrawTexture(new Rect(calcHorizontalPosition, calcVerticalPosition, calcWidth, calcHeight), sliderBackgroundMid, ScaleMode.StretchToFill, true, 10.0f);
        GUI.DrawTexture(new Rect(calcHorizontalPosition-((calcHeight*sliderBackgroundLeft.width)/sliderBackgroundLeft.height), calcVerticalPosition, (calcHeight*sliderBackgroundLeft.width)/sliderBackgroundLeft.height, calcHeight), sliderBackgroundLeft, ScaleMode.StretchToFill, true, 10.0f);
        GUI.DrawTexture(new Rect(calcHorizontalPosition+calcWidth, calcVerticalPosition, (calcHeight*sliderBackgroundRight.width)/sliderBackgroundRight.height, calcHeight), sliderBackgroundRight, ScaleMode.StretchToFill, true, 10.0f);
        for (int i = 0; i < sliderTimePeriods; i++)
        {
            GUIStyle buttonStyle = new GUIStyle();
            GUIStyleState hoverState = new GUIStyleState();
            GUIStyleState normalState = new GUIStyleState();
         
            hoverState.background = timePeriodButtonLit[i];
            normalState.background = timePeriodButton[i];

            buttonStyle.hover = hoverState;
            buttonStyle.normal = normalState;

            if(GUI.Button(new Rect( calcHorizontalPosition + (calcWidth/(sliderTimePeriods+1))*(i+1) - ((calcHeight*timePeriodButton[i].width)/timePeriodButton[i].height)/2, calcVerticalPosition, ((calcHeight*timePeriodButton[i].width)/timePeriodButton[i].height), calcHeight), new GUIContent("","Button"+i), buttonStyle) && !sliding){
				if(i+1 == 3) {
					Debug.Log("Coming Soon");
				} else {
					futureTimePeriod = i+1;
					futureSliderHoriz = ((calcHorizontalPosition + (calcWidth / (sliderTimePeriods+1)) * futureTimePeriod));
        	        SaveController.CacheDiorama();
				}
            }
        }
        //drawTimeTicks();
		hover = GUI.tooltip;
		if (hover.Equals ("Button2")) {
			//MenuTools.DrawMenu((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y, 300, 20);
            Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Coming Soon!"));
            //GUI.Box(new Rect((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y, size.x, size.y), "");
            MenuTools.DrawSmallMenu((int)Input.mousePosition.x, Screen.height-(int)Input.mousePosition.y-30, (int)size.x+20, (int)size.y+20);
			GUI.Label(new Rect(Input.mousePosition.x+20, Screen.height-Input.mousePosition.y - 20, 150, 50),"Coming Soon!", MenuTools.buttonStyle);
		}
	}

    void drawTimeTicks() {
        for (int i = 0; i <= sliderTimePeriods+1; i++)
        {
            GUI.Box(new Rect(((calcHorizontalPosition + (calcWidth / (sliderTimePeriods+1)) * i)), calcVerticalTickPosition, calcTickWidth, calcTickHeight), "");
        }
    }

}
