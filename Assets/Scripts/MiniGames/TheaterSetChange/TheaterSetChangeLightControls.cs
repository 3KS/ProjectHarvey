using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheaterSetChangeLightControls : MonoBehaviour
{
	public Light light;

	public Slider colorSlider;
	public Slider intensitySlider;

	public Color originalLightColor;
	public Color colorFromSlider;
	private float colorValueFromSlider;
	private float colorModifier;

	private Color red;
	private Color blue;
	private Color green;

	private float intensityFromSlider;
	private float intensityModifier;


	/*
	public Light light2;
	public Slider colorSlider2;
	public Slider intensitySlider2; 
	public Color originalLightColor2;
	public Color colorFromSlider2;
	public float colorModifier2;
	public float intensityFromSlider2;
	public float intensityModifier2;
	*/

	void Start ()
	{
		red = Color.red;
		green = Color.green;
		blue = Color.blue;
		originalLightColor = light.color;
	}

	void Update ()
	{
		ColorChangeControl ();
	}

	public void ColorChangeControl ()
	{
		intensityModifier = intensityFromSlider * 5.0f;

		light.intensity = intensityModifier;

		colorModifier = colorValueFromSlider / 1.0f;
		if (colorModifier > .66f)
		{
			colorFromSlider = red;
			light.color = Color.Lerp (originalLightColor, colorFromSlider, colorModifier);
		}
		else if (colorModifier < .33f)
		{
			colorFromSlider = blue;
			light.color = Color.Lerp (originalLightColor, colorFromSlider, colorModifier);
		}
		else
		{
			colorFromSlider = green;
			light.color = Color.Lerp (originalLightColor, colorFromSlider, colorModifier);
		}
	}

	public void GetColorSliderValues ()
	{
		colorValueFromSlider = colorSlider.value;
	}

	public void GetIntensitySliderValues ()
	{
		intensityFromSlider = intensitySlider.value;
	}

	void lightRotationChange ()
	{

	}
}
