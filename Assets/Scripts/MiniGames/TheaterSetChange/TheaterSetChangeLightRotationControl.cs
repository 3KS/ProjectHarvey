using UnityEngine;
using System.Collections;

public class TheaterSetChangeLightRotationControl : MonoBehaviour
{
	public GameObject light;
	public GameObject lightControl;

	private Ray ray;
	private RaycastHit hit;

	public bool canMoveLights;

	private Vector3 positionLock;

	void Start ()
	{
		canMoveLights = false;
	}

	void Update ()
	{
		light.transform.LookAt (lightControl.transform.position);
		if (canMoveLights == true)
		{
			if (Input.GetMouseButton (0))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//Debug.DrawLine(ray.origin, hit.point);
				
				if (Physics.Raycast(ray, out hit, 20))
				{
					lightControl.transform.position = new Vector3( hit.point.x, lightControl.transform.position.y, -hit.point.y - 10);
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				positionLock = lightControl.transform.position;
			}
		}
	}

	public void KeepLightInPlace ()
	{
		lightControl.transform.position = positionLock;
	}
}
