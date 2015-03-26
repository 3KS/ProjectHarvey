using UnityEngine;
using System.Collections;

public class OriginalObjectAttributes : MonoBehaviour
{
	public GameObject sphere;
	public GameObject notASphere;
	public GameObject capsule;

	public static bool getPosition;
	public static bool getRotation;

	public static Vector3 originalSpherePosition;
	public static Quaternion originalSphereRotation;

	public static Vector3 originalNotASpherePosition;
	public static Quaternion originalNotASphereRotation;

	public static Vector3 originalCapsulePosition;
	public static Quaternion originalCapsuleRotation;

	void Start ()
	{
		originalSpherePosition = sphere.transform.position;
		originalSphereRotation = sphere.transform.rotation;

		originalNotASpherePosition = notASphere.transform.position;
		originalNotASphereRotation= notASphere.transform.rotation;

		originalCapsulePosition = capsule.transform.position;
		originalCapsuleRotation = capsule.transform.rotation;
	}

	void Update ()
	{
		if (getPosition == true && Pickup.selectedObject.name == sphere.name || getRotation == true && Pickup.selectedObject.name == sphere.name)
		{
			Pickup.selectedObjectOriginalPosition = originalSpherePosition;
			Pickup.selectedObjectOriginalRotation = originalSphereRotation;
		}

		if (getPosition == true && Pickup.selectedObject.name == notASphere.name || getRotation && Pickup.selectedObject.name == notASphere.name)
		{
			Pickup.selectedObjectOriginalPosition = originalNotASpherePosition;
			Pickup.selectedObjectOriginalRotation = originalNotASphereRotation;
		}

		if (getPosition == true && Pickup.selectedObject.name == capsule.name || getRotation && Pickup.selectedObject.name == capsule.name)
		{
			Pickup.selectedObjectOriginalPosition = originalCapsulePosition;
			Pickup.selectedObjectOriginalRotation = originalCapsuleRotation;
		}
	}
}