using UnityEngine;
using System.Collections;



public class MenuTools : MonoBehaviour {

    public Texture2D[] buttonTex;
    public Texture2D[] buttonLightTex;

    public static Texture2D[] button;
    public static Texture2D[] buttonLight;

    public Texture2D backgroundTex;
    public Texture2D topTex;
    public Texture2D bottomTex;
    public Texture2D leftTex;
    public Texture2D rightTex;
    public Texture2D LTtex;
    public Texture2D RTtex;
    public Texture2D LBtex;
    public Texture2D RBtex;

    public static Texture2D background;
    public static Texture2D top;
    public static Texture2D bottom;
    public static Texture2D left;
    public static Texture2D right;
    public static Texture2D lt;
    public static Texture2D rt;
    public static Texture2D lb;
    public static Texture2D rb;

	public static  GUIStyle buttonStyle = new GUIStyle();
	public static  GUIStyle labelStyle = new GUIStyle();
    public static  GUIStyle dioramaLabel = new GUIStyle();

    public static float delay = 0;

    
	public Font harveyFont;

    void Start() {
		labelStyle.font = harveyFont;
		labelStyle.alignment = TextAnchor.UpperCenter;
		labelStyle.fontSize = 24;
		labelStyle.normal.textColor = new Color(0.588f, 0.537f, 0.470f);

        dioramaLabel.font = harveyFont;
        dioramaLabel.alignment = TextAnchor.UpperLeft;
        dioramaLabel.fontSize = 36;
        dioramaLabel.normal.textColor = Color.white;

		buttonStyle.font = harveyFont;
		buttonStyle.alignment = TextAnchor.UpperCenter;
		buttonStyle.fontSize = 24;
		buttonStyle.normal.textColor = Color.white;


        button = new Texture2D[buttonTex.Length];
        for (int i = 0; i < button.Length; i++)
        {
            button[i] = buttonTex[i];
        }

        buttonLight = new Texture2D[buttonLightTex.Length];
        for (int i = 0; i < buttonLight.Length; i++)
        {
            buttonLight[i] = buttonLightTex[i];
        }

        Debug.Log("loaded");
        background = backgroundTex;
        top = topTex;
        bottom = bottomTex;
        left = leftTex;
        right = rightTex;
        lt = LTtex;
        rt = RTtex;
        lb = LBtex;
        rb = RBtex;
    }

    void Update() {
        if (delay > 0)
        {
            delay -= Time.unscaledDeltaTime;
        }
        if (delay < 0)
        {
            delay = 0;
        }
    }

    public static bool DrawButton(int horizPos, int vertPos, int width, int height, string text, GUIStyle fontStyle) {
        int minWidth = 32;
        int minHeight = 32;

        bool isClicked = false;

        int buttonWidth = width > minWidth ? width : minWidth;
        int buttonHeight = height > minHeight ? height : minHeight;
        Rect rect = new Rect(horizPos, vertPos, buttonWidth, buttonHeight);

        if (rect.Contains(Event.current.mousePosition) && GUI.enabled){
            GUI.DrawTexture(new Rect(horizPos, vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), buttonLight[3]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), buttonLight[4]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos, buttonWidth-minWidth, (minHeight/2)), buttonLight[1]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+buttonHeight-(minHeight/2), buttonWidth-minWidth, (minHeight/2)), buttonLight[2]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+(minHeight/2), buttonWidth-minWidth, buttonHeight-minHeight), buttonLight[0]);
            
            GUI.DrawTexture(new Rect(horizPos, vertPos, (minWidth/2), (minHeight/2)), buttonLight[5]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos, (minWidth/2), (minHeight/2)), buttonLight[6]);
            GUI.DrawTexture(new Rect(horizPos, vertPos+buttonHeight-(minHeight/2), (minWidth/2), (minHeight/2)), buttonLight[7]);
            GUI.DrawTexture(new Rect(horizPos + buttonWidth - (minWidth/2), vertPos + buttonHeight - (minHeight/2), (minWidth/2), (minHeight/2)), buttonLight[8]);

            if (delay == 0 && Event.current.type == EventType.mouseUp) {
                isClicked = true;
                Event.current = null;
                delay = 0.2f;
            }

        } else {
            GUI.DrawTexture(new Rect(horizPos, vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), button[3]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), button[4]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos, buttonWidth-minWidth, (minHeight/2)), button[1]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+buttonHeight-(minHeight/2), buttonWidth-minWidth, (minHeight/2)), button[2]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+(minHeight/2), buttonWidth-minWidth, buttonHeight-minHeight), button[0]);
            
            GUI.DrawTexture(new Rect(horizPos, vertPos, (minWidth/2), (minHeight/2)), button[5]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos, (minWidth/2), (minHeight/2)), button[6]);
            GUI.DrawTexture(new Rect(horizPos, vertPos+buttonHeight-(minHeight/2), (minWidth/2), (minHeight/2)), button[7]);
            GUI.DrawTexture(new Rect(horizPos + buttonWidth - (minWidth/2), vertPos + buttonHeight - (minHeight/2), (minWidth/2), (minHeight/2)), button[8]);
        }

        fontStyle.alignment = TextAnchor.UpperCenter;
       
        fontStyle.fontSize = (2*buttonHeight)/3;
        GUI.Label(new Rect(horizPos, vertPos+height/2 - fontStyle.fontSize*3/5, width, height), text, fontStyle);

        return isClicked;
    }
    
    public static void DrawSmallMenu(int horizPos, int vertPos, int width, int height) {
        int minWidth = 32;
        int minHeight = 32;
        int buttonWidth = width > minWidth ? width : minWidth;
        int buttonHeight = height > minHeight ? height : minHeight;

            GUI.DrawTexture(new Rect(horizPos, vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), button[3]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos+(minHeight/2), (minWidth/2), buttonHeight-minHeight), button[4]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos, buttonWidth-minWidth, (minHeight/2)), button[1]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+buttonHeight-(minHeight/2), buttonWidth-minWidth, (minHeight/2)), button[2]);
            GUI.DrawTexture(new Rect(horizPos+(minWidth/2), vertPos+(minHeight/2), buttonWidth-minWidth, buttonHeight-minHeight), button[0]);
            
            GUI.DrawTexture(new Rect(horizPos, vertPos, (minWidth/2), (minHeight/2)), button[5]);
            GUI.DrawTexture(new Rect(horizPos+buttonWidth-(minWidth/2), vertPos, (minWidth/2), (minHeight/2)), button[6]);
            GUI.DrawTexture(new Rect(horizPos, vertPos+buttonHeight-(minHeight/2), (minWidth/2), (minHeight/2)), button[7]);
            GUI.DrawTexture(new Rect(horizPos + buttonWidth - (minWidth/2), vertPos + buttonHeight - (minHeight/2), (minWidth/2), (minHeight/2)), button[8]);

    }



    public static void DrawMenu(int horizPos, int vertPos, int width, int height) {
        int guiWidth = width > 128 ? width : 128;
        int guiHeight = height > 128 ? height : 128;
        GUI.DrawTexture(new Rect(horizPos, vertPos+64, 64, guiHeight-128), left);
        GUI.DrawTexture(new Rect(horizPos+guiWidth-64, vertPos+64, 64, guiHeight-128), right);
        GUI.DrawTexture(new Rect(horizPos+64, vertPos, guiWidth-128, 64), top);
        GUI.DrawTexture(new Rect(horizPos+64, vertPos+guiHeight-64, guiWidth-128, 64), bottom);
        GUI.DrawTexture(new Rect(horizPos+64, vertPos+64, guiWidth-128, guiHeight-128), background);

        GUI.DrawTexture(new Rect(horizPos, vertPos, 64, 64), lt);
        GUI.DrawTexture(new Rect(horizPos+guiWidth-64, vertPos, 64, 64), rt);
        GUI.DrawTexture(new Rect(horizPos, vertPos+guiHeight-64, 64, 64), lb);
        GUI.DrawTexture(new Rect(horizPos + guiWidth - 64, vertPos + guiHeight - 64, 64, 64), rb);
    }

}
