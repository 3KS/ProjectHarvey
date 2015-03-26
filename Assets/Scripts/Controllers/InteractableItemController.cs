using UnityEngine;
using System.Collections;

public class InteractableItemController : MonoBehaviour 
{

	public GameObject sphere;
	public GameObject notASphere;
	public GameObject capsule;

//Library Objects
	public GameObject Oliver_Typewriter;
	public GameObject Issue_of_Stoutonia;
	public GameObject Card_Catalogue;
	public GameObject Student_projects;
//Books
	public GameObject The_Model_Cookbook;
	public GameObject Paper_Sloyd;
	public GameObject The_Simple_Carbohydrates_and_the_Glucosides;
	public GameObject Womans_Institute_Library_of_Cookery_Vol_4;
	public GameObject Clean_Water_and_How_to_get_it;
//Presidents Office
	public GameObject Electro_Writer;
	public GameObject Embosser;
	public GameObject Bathroom;
	public GameObject Shaving_Mug;
//Hallway
	public GameObject Bubbler;
	public GameObject Bubbler_2;
	public GameObject Cigarettes;
	public GameObject Easel;
	public GameObject Elevator;
//Sewing Class
	public GameObject Sewing_Machine;
	public GameObject Sewing_Machine_2;
	public GameObject Sewing_Machine_3;
	public GameObject Sewing_Machine_4;
	public GameObject Sewing_Machine_5;
	public GameObject Wall_Scale_Tension;
	public GameObject Mannequin;
	public GameObject Mannequin_2;
	public GameObject Mannequin_3;
	public GameObject Mannequin_4;
	public GameObject Mannequin_5;
	public GameObject Bunsen_Burner;
	public GameObject Sewing_Boxes;
	public GameObject Sewing_Course_Book;
	public GameObject Sewing_Course_Book_2;
	public GameObject Sewing_Course_Book_3;
	public GameObject Sewing_Course_Book_4;
	public GameObject Sewing_Course_Book_5;
//Textile Class
	public GameObject Fadeometer;
	public GameObject Fadeometer_Sample;
	public GameObject Dye_Jars;
	public GameObject Weaving_Squares;
//Theater
	public GameObject Deck_of_cards;
	public GameObject Piano;
	public GameObject Clarinet;
	public GameObject Angklung;
	public GameObject Radio;
	public GameObject Ski_Poles;
	public GameObject Preforming_Orchesis;
	public GameObject Imaginary_Invalid;
	public GameObject Barrys_Etchings;

	public static Vector3 originalSpherePosition;
	public static Vector3 originalNotASpherePosition;
	public static Vector3 originalCapsulePosition;

	public static Vector3 Oliver_Typewriter_Position;
	public static Vector3 Issue_of_Stoutonia_Position;
	public static Vector3 Card_Catalogue_Position;
	public static Vector3 Student_projects_Position;
	public static Vector3 The_Model_Cookbook_Position;
	public static Vector3 Paper_Sloyd_Position;
	public static Vector3 The_Simple_Carbohydrates_and_the_Glucosides_Position;
	public static Vector3 Womans_Institute_Library_of_Cookery_Vol_4_Position;
	public static Vector3 Clean_Water_and_How_to_get_it_Position;
	public static Vector3 Electro_Writer_Position;
	public static Vector3 Embosser_Position;
	public static Vector3 Bathroom_Position;
	public static Vector3 Shaving_Mug_Position;
	public static Vector3 Bubbler_Position;
	public static Vector3 Bubbler_2_Position;
	public static Vector3 Cigarettes_Position;
	public static Vector3 Easel_Position;
	public static Vector3 Elevator_Position;
	public static Vector3 Sewing_Machine_Position;
	public static Vector3 Sewing_Machine_Position_2;
	public static Vector3 Sewing_Machine_Position_3;
	public static Vector3 Sewing_Machine_Position_4;
	public static Vector3 Sewing_Machine_Position_5;
	public static Vector3 Wall_Scale_Tension_Position;
	public static Vector3 Mannequin_Position;
	public static Vector3 Mannequin_Position_2;
	public static Vector3 Mannequin_Position_3;
	public static Vector3 Mannequin_Position_4;
	public static Vector3 Mannequin_Position_5;
	public static Vector3 Bunsen_Burner_Position;
	public static Vector3 Sewing_Boxes_Position;
	public static Vector3 Sewing_Course_Book_Position;
	public static Vector3 Sewing_Course_Book_Position_2;
	public static Vector3 Sewing_Course_Book_Position_3;
	public static Vector3 Sewing_Course_Book_Position_4;
	public static Vector3 Sewing_Course_Book_Position_5;
	public static Vector3 Fadeometer_Position;
	public static Vector3 Fadeometer_Sample_Position;
	public static Vector3 Dye_Jars_Position;
	public static Vector3 Weaving_Squares_Position;
	public static Vector3 Deck_of_cards_Position;
	public static Vector3 Piano_Position;
	public static Vector3 Clarinet_Position;
	public static Vector3 Angklung_Position;
	public static Vector3 Radio_Position;
	public static Vector3 Ski_Poles_Position;
	public static Vector3 Preforming_Orchesis_Position;
	public static Vector3 Imaginary_Invalid_Position;
	public static Vector3 Barrys_Etchings_Position;

	public static Quaternion originalSphereRotation;
	public static Quaternion originalNotASphereRotation;
	public static Quaternion originalCapsuleRotation;

	public static Quaternion Oliver_Typewriter_Rotation;
	public static Quaternion Issue_of_Stoutonia_Rotation;
	public static Quaternion Card_Catalogue_Rotation;
	public static Quaternion Student_projects_Rotation;
	public static Quaternion The_Model_Cookbook_Rotation;
	public static Quaternion Paper_Sloyd_Rotation;
	public static Quaternion The_Simple_Carbohydrates_and_the_Glucosides_Rotation;
	public static Quaternion Womans_Institute_Library_of_Cookery_Vol_4_Rotation;
	public static Quaternion Clean_Water_and_How_to_get_it_Rotation;
	public static Quaternion Electro_Writer_Rotation;
	public static Quaternion Embosser_Rotation;
	public static Quaternion Bathroom_Rotation;
	public static Quaternion Shaving_Mug_Rotation;
	public static Quaternion Bubbler_Rotation;
	public static Quaternion Bubbler_2_Rotation;
	public static Quaternion Cigarettes_Rotation;
	public static Quaternion Easel_Rotation;
	public static Quaternion Elevator_Rotation;
	public static Quaternion Sewing_Machine_Rotation;
	public static Quaternion Sewing_Machine_Rotation_2;
	public static Quaternion Sewing_Machine_Rotation_3;
	public static Quaternion Sewing_Machine_Rotation_4;
	public static Quaternion Sewing_Machine_Rotation_5;
	public static Quaternion Wall_Scale_Tension_Rotation;
	public static Quaternion Mannequin_Rotation;
	public static Quaternion Mannequin_Rotation_2;
	public static Quaternion Mannequin_Rotation_3;
	public static Quaternion Mannequin_Rotation_4;
	public static Quaternion Mannequin_Rotation_5;
	public static Quaternion Bunsen_Burner_Rotation;
	public static Quaternion Sewing_Boxes_Rotation;
	public static Quaternion Sewing_Course_Book_Rotation;
	public static Quaternion Sewing_Course_Book_Rotation_2;
	public static Quaternion Sewing_Course_Book_Rotation_3;
	public static Quaternion Sewing_Course_Book_Rotation_4;
	public static Quaternion Sewing_Course_Book_Rotation_5;
	public static Quaternion Fadeometer_Rotation;
	public static Quaternion Fadeometer_Sample_Rotation;
	public static Quaternion Dye_Jars_Rotation;
	public static Quaternion Weaving_Squares_Rotation;
	public static Quaternion Deck_of_cards_Rotation;
	public static Quaternion Piano_Rotation;
	public static Quaternion Clarinet_Rotation;
	public static Quaternion Angklung_Rotation;
	public static Quaternion Radio_Rotation;
	public static Quaternion Ski_Poles_Rotation;
	public static Quaternion Preforming_Orchesis_Rotation;
	public static Quaternion Imaginary_Invalid_Rotation;
	public static Quaternion Barrys_Etchings_Rotation;

	public static bool turnOff;
	public static bool getPosition;
	public static bool getRotation;
	public static bool sizeCheck;
	
	void Start ()
	{
		originalSpherePosition = sphere.transform.position;
		originalSphereRotation = sphere.transform.rotation;
		
		originalNotASpherePosition = notASphere.transform.position;
		originalNotASphereRotation = notASphere.transform.rotation;
		
		originalCapsulePosition = capsule.transform.position;
		originalCapsuleRotation = capsule.transform.rotation;


		Oliver_Typewriter_Position = Oliver_Typewriter.transform.position;
		Oliver_Typewriter_Rotation = Oliver_Typewriter.transform.rotation;

		Issue_of_Stoutonia_Position = Issue_of_Stoutonia.transform.position;
		Issue_of_Stoutonia_Rotation = Issue_of_Stoutonia.transform.rotation;

		Card_Catalogue_Position = Card_Catalogue.transform.position;
		Card_Catalogue_Rotation = Card_Catalogue.transform.rotation;

		Student_projects_Position = Student_projects.transform.position;
		Student_projects_Rotation = Student_projects.transform.rotation;

		The_Model_Cookbook_Position = The_Model_Cookbook.transform.position;
		The_Model_Cookbook_Rotation = The_Model_Cookbook.transform.rotation;

		Paper_Sloyd_Position = Paper_Sloyd.transform.position;
		Paper_Sloyd_Rotation = Paper_Sloyd.transform.rotation;

		The_Simple_Carbohydrates_and_the_Glucosides_Position = The_Simple_Carbohydrates_and_the_Glucosides.transform.position;
		The_Simple_Carbohydrates_and_the_Glucosides_Rotation = The_Simple_Carbohydrates_and_the_Glucosides.transform.rotation;

		Womans_Institute_Library_of_Cookery_Vol_4_Position = Womans_Institute_Library_of_Cookery_Vol_4.transform.position;
		Womans_Institute_Library_of_Cookery_Vol_4_Rotation = Womans_Institute_Library_of_Cookery_Vol_4.transform.rotation;

		Clean_Water_and_How_to_get_it_Position = Clean_Water_and_How_to_get_it.transform.position;
		Clean_Water_and_How_to_get_it_Rotation = Clean_Water_and_How_to_get_it.transform.rotation;

		Electro_Writer_Position = Electro_Writer.transform.position;
		Electro_Writer_Rotation = Electro_Writer.transform.rotation;

		Embosser_Position = Embosser.transform.position;
		Embosser_Rotation = Embosser.transform.rotation;

		Bathroom_Position = Bathroom.transform.position;
		Bathroom_Rotation = Bathroom.transform.rotation;

		Shaving_Mug_Position = Shaving_Mug.transform.position;
		Shaving_Mug_Rotation = Shaving_Mug.transform.rotation;

		Bubbler_Position = Bubbler.transform.position;
		Bubbler_Rotation = Bubbler.transform.rotation;

		Bubbler_2_Position = Bubbler_2.transform.position;
		Bubbler_2_Rotation = Bubbler_2.transform.rotation;

		Cigarettes_Position = Cigarettes.transform.position;
		Cigarettes_Rotation = Cigarettes.transform.rotation;

		Easel_Position = Easel.transform.position;
		Easel_Rotation = Easel.transform.rotation;

		Elevator_Position = Elevator.transform.position;
		Elevator_Rotation = Elevator.transform.rotation;

		Sewing_Machine_Position = Sewing_Machine.transform.position;
		Sewing_Machine_Rotation = Sewing_Machine.transform.rotation;

		Sewing_Machine_Position_2 = Sewing_Machine_2.transform.position;
		Sewing_Machine_Rotation_2 = Sewing_Machine_2.transform.rotation;

		Sewing_Machine_Position_3 = Sewing_Machine_3.transform.position;
		Sewing_Machine_Rotation_3 = Sewing_Machine_3.transform.rotation;

		Sewing_Machine_Position_4 = Sewing_Machine_4.transform.position;
		Sewing_Machine_Rotation_4 = Sewing_Machine_4.transform.rotation;

		Sewing_Machine_Position_5 = Sewing_Machine_5.transform.position;
		Sewing_Machine_Rotation_5 = Sewing_Machine_5.transform.rotation;

		Wall_Scale_Tension_Position = Wall_Scale_Tension.transform.position;
		Wall_Scale_Tension_Rotation = Wall_Scale_Tension.transform.rotation;

		Mannequin_Position = Mannequin.transform.position;
		Mannequin_Rotation = Mannequin.transform.rotation;

		Mannequin_Position_2 = Mannequin_2.transform.position;
		Mannequin_Rotation_2 = Mannequin_2.transform.rotation;

		Mannequin_Position_3 = Mannequin_3.transform.position;
		Mannequin_Rotation_3 = Mannequin_3.transform.rotation;

		Mannequin_Position_4 = Mannequin_4.transform.position;
		Mannequin_Rotation_4 = Mannequin_4.transform.rotation;

		Mannequin_Position_5 = Mannequin_5.transform.position;
		Mannequin_Rotation_5 = Mannequin_5.transform.rotation;

		Bunsen_Burner_Position = Bunsen_Burner.transform.position;
		Bunsen_Burner_Rotation = Bunsen_Burner.transform.rotation;

	 	Sewing_Boxes_Position = Sewing_Boxes.transform.position;
	 	Sewing_Boxes_Rotation = Sewing_Boxes.transform.rotation;

	 	Sewing_Course_Book_Position = Sewing_Course_Book.transform.position;
	 	Sewing_Course_Book_Rotation = Sewing_Course_Book.transform.rotation;

		Sewing_Course_Book_Position_2 = Sewing_Course_Book_2.transform.position;
		Sewing_Course_Book_Rotation_2 = Sewing_Course_Book_2.transform.rotation;

		Sewing_Course_Book_Position_3 = Sewing_Course_Book_3.transform.position;
		Sewing_Course_Book_Rotation_3 = Sewing_Course_Book_3.transform.rotation;

		Sewing_Course_Book_Position_4 = Sewing_Course_Book_4.transform.position;
		Sewing_Course_Book_Rotation_4 = Sewing_Course_Book_4.transform.rotation;

		Sewing_Course_Book_Position_5 = Sewing_Course_Book_5.transform.position;
		Sewing_Course_Book_Rotation_5 = Sewing_Course_Book_5.transform.rotation;

		Fadeometer_Position = Fadeometer.transform.position;
		Fadeometer_Rotation = Fadeometer.transform.rotation;

		Fadeometer_Sample_Position = Fadeometer_Sample.transform.position;
		Fadeometer_Sample_Rotation = Fadeometer_Sample.transform.rotation;

		Dye_Jars_Position = Dye_Jars.transform.position;
		Dye_Jars_Rotation = Dye_Jars.transform.rotation;

		Weaving_Squares_Position = Weaving_Squares.transform.position;
		Weaving_Squares_Rotation = Weaving_Squares.transform.rotation;

		Deck_of_cards_Position = Deck_of_cards.transform.position;
		Deck_of_cards_Rotation = Deck_of_cards.transform.rotation;

		Piano_Position = Piano.transform.position;
		Piano_Rotation = Piano.transform.rotation;

		Clarinet_Position = Clarinet.transform.position;
		Clarinet_Rotation = Clarinet.transform.rotation;

		Angklung_Position = Angklung.transform.position;
		Angklung_Rotation = Angklung.transform.rotation;

		Radio_Position = Radio.transform.position;
		Radio_Rotation = Radio.transform.rotation;

		Ski_Poles_Position = Ski_Poles.transform.position;
		Ski_Poles_Rotation = Ski_Poles.transform.rotation;

		Preforming_Orchesis_Position = Preforming_Orchesis.transform.position;
		Preforming_Orchesis_Rotation = Preforming_Orchesis.transform.rotation;

		Imaginary_Invalid_Position = Imaginary_Invalid.transform.position;
		Imaginary_Invalid_Rotation = Imaginary_Invalid.transform.rotation;

		Barrys_Etchings_Position = Barrys_Etchings.transform.position;
		Barrys_Etchings_Rotation = Barrys_Etchings.transform.rotation;

	}
	
	void Update ()
	{
		if (getPosition == true && Pickup.selectedObject.name == sphere.name || getRotation == true && Pickup.selectedObject.name == "Sphere")
		{
			Pickup.selectedObjectOriginalPosition = originalSpherePosition;
			Pickup.selectedObjectOriginalRotation = originalSphereRotation;
		}
		
		if (getPosition == true && Pickup.selectedObject.name == notASphere.name || getRotation == true && Pickup.selectedObject.name == notASphere.name)
		{
			Pickup.selectedObjectOriginalPosition = originalNotASpherePosition;
			Pickup.selectedObjectOriginalRotation = originalNotASphereRotation;
		}
		
		if (getPosition == true && Pickup.selectedObject.name == capsule.name || getRotation == true && Pickup.selectedObject.name == capsule.name)
		{
			Pickup.selectedObjectOriginalPosition = originalCapsulePosition;
			Pickup.selectedObjectOriginalRotation = originalCapsuleRotation;
		}
//OLIVER TYPEWRITER
		if (getPosition == true && Pickup.selectedObject.name == Oliver_Typewriter.name || getRotation ==true && Pickup.selectedObject.name == Oliver_Typewriter.name)
		{
			Pickup.selectedObjectOriginalPosition = Oliver_Typewriter_Position;
			Pickup.selectedObjectOriginalRotation = Oliver_Typewriter_Rotation;
			GameObject.Find ("Oliver Typewriter Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Oliver Typewriter Description").guiText.enabled = false;
		}
//ISSUE OF STOUTONIA
		if (getPosition == true && Pickup.selectedObject.name == Issue_of_Stoutonia.name || getRotation ==true && Pickup.selectedObject.name == Issue_of_Stoutonia.name)
		{
			Pickup.selectedObjectOriginalPosition = Issue_of_Stoutonia_Position;
			Pickup.selectedObjectOriginalRotation = Issue_of_Stoutonia_Rotation;
			GameObject.Find ("Issue of Stoutonia Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Issue of Stoutonia Description").guiText.enabled = false;
		}
//CARD CATALOGUE
		if (getPosition == true && Pickup.selectedObject.name == Card_Catalogue.name || getRotation ==true && Pickup.selectedObject.name == Card_Catalogue.name)
		{
			Pickup.selectedObjectOriginalPosition = Card_Catalogue_Position;
			Pickup.selectedObjectOriginalRotation = Card_Catalogue_Rotation;
			GameObject.Find ("Card Catalogue Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Card Catalogue Description").guiText.enabled = false;
		}
//STUDENT PROJECTS
		if (getPosition == true && Pickup.selectedObject.name == Student_projects.name || getRotation ==true && Pickup.selectedObject.name == Student_projects.name)
		{
			Pickup.selectedObjectOriginalPosition = Student_projects_Position;
			Pickup.selectedObjectOriginalRotation = Student_projects_Rotation;
			GameObject.Find ("Student projects Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Student projects Description").guiText.enabled = false;
		}
//THE MODEL COOKBOOK
		if (getPosition == true && Pickup.selectedObject.name == The_Model_Cookbook.name || getRotation ==true && Pickup.selectedObject.name == The_Model_Cookbook.name)
		{
			Pickup.selectedObjectOriginalPosition = The_Model_Cookbook_Position;
			Pickup.selectedObjectOriginalRotation = The_Model_Cookbook_Rotation;
			GameObject.Find ("The Model Cookbook Description").guiText.enabled = true;
		}

		if (turnOff)
		{
			GameObject.Find ("The Model Cookbook Description").guiText.enabled = false;
		}
//PAPER SLOYD
		if (getPosition == true && Pickup.selectedObject.name == Paper_Sloyd.name || getRotation ==true && Pickup.selectedObject.name == Paper_Sloyd.name)
		{
			Pickup.selectedObjectOriginalPosition = Paper_Sloyd_Position;
			Pickup.selectedObjectOriginalRotation = Paper_Sloyd_Rotation;
			GameObject.Find ("Paper Sloyd Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Paper Sloyd Description").guiText.enabled = false;
		}
//THE SIMPLE CARBOHYDRATES AND THE GLUCOSIDES
		if (getPosition == true && Pickup.selectedObject.name == The_Simple_Carbohydrates_and_the_Glucosides.name || getRotation ==true && Pickup.selectedObject.name == The_Simple_Carbohydrates_and_the_Glucosides.name)
		{
			Pickup.selectedObjectOriginalPosition = The_Simple_Carbohydrates_and_the_Glucosides_Position;
			Pickup.selectedObjectOriginalRotation = The_Simple_Carbohydrates_and_the_Glucosides_Rotation;
			GameObject.Find ("The Simple Carbohydrates and the Glucosides Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("The Simple Carbohydrates and the Glucosides Description").guiText.enabled = false;
		}
//WOMANS INSTITUTE LIBRARY OF COOKERY VOLUME 4
		if (getPosition == true && Pickup.selectedObject.name == Womans_Institute_Library_of_Cookery_Vol_4.name || getRotation ==true && Pickup.selectedObject.name == Womans_Institute_Library_of_Cookery_Vol_4.name)
		{
			Pickup.selectedObjectOriginalPosition = Womans_Institute_Library_of_Cookery_Vol_4_Position;
			Pickup.selectedObjectOriginalRotation = Womans_Institute_Library_of_Cookery_Vol_4_Rotation;
			GameObject.Find ("Womans Institute Library of Cookery Vol. 4 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Womans Institute Library of Cookery Vol. 4 Description").guiText.enabled = false;
		}
//CLEAN WATER AND HOW TO GET IT
		if (getPosition == true && Pickup.selectedObject.name == Clean_Water_and_How_to_get_it.name || getRotation ==true && Pickup.selectedObject.name == Clean_Water_and_How_to_get_it.name)
		{
			Pickup.selectedObjectOriginalPosition = Clean_Water_and_How_to_get_it_Position;
			Pickup.selectedObjectOriginalRotation = Clean_Water_and_How_to_get_it_Rotation;
			GameObject.Find ("Clean Water and How to get it Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Clean Water and How to get it Description").guiText.enabled = false;
		}
//ELECTRO WRITER
		if (getPosition == true && Pickup.selectedObject.name == Electro_Writer.name || getRotation ==true && Pickup.selectedObject.name == Electro_Writer.name)
		{
			Pickup.selectedObjectOriginalPosition = Electro_Writer_Position;
			Pickup.selectedObjectOriginalRotation = Electro_Writer_Rotation;
			GameObject.Find ("Electro Writer Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Electro Writer Description").guiText.enabled = false;
		}
//EMBOSSER
		if (getPosition == true && Pickup.selectedObject.name == Embosser.name || getRotation ==true && Pickup.selectedObject.name == Embosser.name)
		{
			Pickup.selectedObjectOriginalPosition = Embosser_Position;
			Pickup.selectedObjectOriginalRotation = Embosser_Rotation;
			GameObject.Find ("Embosser Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Embosser Description").guiText.enabled = false;
		}
//BATHROOM
		if (getPosition == true && Pickup.selectedObject.name == Bathroom.name || getRotation ==true && Pickup.selectedObject.name == Bathroom.name)
		{
			Pickup.selectedObjectOriginalPosition = Bathroom_Position;
			Pickup.selectedObjectOriginalRotation = Bathroom_Rotation;
			GameObject.Find ("Bathroom Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Bathroom Description").guiText.enabled = false;
		}
//SHAVING MUG
		if (getPosition == true && Pickup.selectedObject.name == Shaving_Mug.name || getRotation ==true && Pickup.selectedObject.name == Shaving_Mug.name)
		{
			Pickup.selectedObjectOriginalPosition = Shaving_Mug_Position;
			Pickup.selectedObjectOriginalRotation = Shaving_Mug_Rotation;
			GameObject.Find ("Shaving Mug Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Shaving Mug Description").guiText.enabled = false;
		}
//BUBBLER
		if (getPosition == true && Pickup.selectedObject.name == Bubbler.name || getRotation ==true && Pickup.selectedObject.name == Bubbler.name)
		{
			Pickup.selectedObjectOriginalPosition = Bubbler_Position;
			Pickup.selectedObjectOriginalRotation = Bubbler_Rotation;
			GameObject.Find ("Bubbler Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Bubbler Description").guiText.enabled = false;
		}
//BUBBLER 2
		if (getPosition == true && Pickup.selectedObject.name == Bubbler_2.name || getRotation ==true && Pickup.selectedObject.name == Bubbler_2.name)
		{
			Pickup.selectedObjectOriginalPosition = Bubbler_2_Position;
			Pickup.selectedObjectOriginalRotation = Bubbler_2_Rotation;
			GameObject.Find ("Bubbler 2 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Bubbler 2 Description").guiText.enabled = false;
		}
//CIGARETTES
		if (getPosition == true && Pickup.selectedObject.name == Cigarettes.name || getRotation ==true && Pickup.selectedObject.name == Cigarettes.name)
		{
			Pickup.selectedObjectOriginalPosition = Cigarettes_Position;
			Pickup.selectedObjectOriginalRotation = Cigarettes_Rotation;
			GameObject.Find ("Cigarettes Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Cigarettes Description").guiText.enabled = false;
		}
//EASEL
		if (getPosition == true && Pickup.selectedObject.name == Easel.name || getRotation ==true && Pickup.selectedObject.name == Easel.name)
		{
			Pickup.selectedObjectOriginalPosition = Easel_Position;
			Pickup.selectedObjectOriginalRotation = Easel_Rotation;
			GameObject.Find ("Easel Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Easel Description").guiText.enabled = false;
		}
//ELEVATOR
		if (getPosition == true && Pickup.selectedObject.name == Elevator.name || getRotation ==true && Pickup.selectedObject.name == Elevator.name)
		{
			Pickup.selectedObjectOriginalPosition = Elevator_Position;
			Pickup.selectedObjectOriginalRotation = Elevator_Rotation;
			GameObject.Find ("Elevator Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Elevator Description").guiText.enabled = false;
		}
//SEWING MACHINE
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Machine.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Machine.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Machine_Position;
			Pickup.selectedObjectOriginalRotation = Sewing_Machine_Rotation;
			GameObject.Find ("Sewing Machine Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Machine Description").guiText.enabled = false;
		}
//SEWING MACHINE 2
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Machine_2.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Machine_2.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Machine_Position_2;
			Pickup.selectedObjectOriginalRotation = Sewing_Machine_Rotation_2;
			GameObject.Find ("Sewing Machine 2 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Machine 2 Description").guiText.enabled = false;
		}
//SEWING MACHINE 3
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Machine_3.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Machine_3.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Machine_Position_3;
			Pickup.selectedObjectOriginalRotation = Sewing_Machine_Rotation_3;
			GameObject.Find ("Sewing Machine 3 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Machine 3 Description").guiText.enabled = false;
		}
//SEWING MACHINE 4
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Machine_4.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Machine_4.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Machine_Position_4;
			Pickup.selectedObjectOriginalRotation = Sewing_Machine_Rotation_4;
			GameObject.Find ("Sewing Machine 4 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Machine 4 Description").guiText.enabled = false;
		}
//SEWING MACHINE 5
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Machine_5.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Machine_5.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Machine_Position_5;
			Pickup.selectedObjectOriginalRotation = Sewing_Machine_Rotation_5;
			GameObject.Find ("Sewing Machine 5 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Machine 5 Description").guiText.enabled = false;
		}
//WALL SCALE TENSION
		if (getPosition == true && Pickup.selectedObject.name == Wall_Scale_Tension.name || getRotation ==true && Pickup.selectedObject.name == Wall_Scale_Tension.name)
		{
			Pickup.selectedObjectOriginalPosition = Wall_Scale_Tension_Position;
			Pickup.selectedObjectOriginalRotation = Wall_Scale_Tension_Rotation;
			GameObject.Find ("Wall Scale Tension Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Wall Scale Tension Description").guiText.enabled = false;
		}
//MANNEQUIN
		if (getPosition == true && Pickup.selectedObject.name == Mannequin.name || getRotation ==true && Pickup.selectedObject.name == Mannequin.name)
		{
			Pickup.selectedObjectOriginalPosition = Mannequin_Position;
			Pickup.selectedObjectOriginalRotation = Mannequin_Rotation;
			GameObject.Find ("Mannequin Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Mannequin Description").guiText.enabled = false;
		}
//MANNEQUIN 2
		if (getPosition == true && Pickup.selectedObject.name == Mannequin_2.name || getRotation ==true && Pickup.selectedObject.name == Mannequin_2.name)
		{
			Pickup.selectedObjectOriginalPosition = Mannequin_Position_2;
			Pickup.selectedObjectOriginalRotation = Mannequin_Rotation_2;
			GameObject.Find ("Mannequin 2 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Mannequin 2 Description").guiText.enabled = false;
		}
//MANNEQUIN 3
		if (getPosition == true && Pickup.selectedObject.name == Mannequin_3.name || getRotation ==true && Pickup.selectedObject.name == Mannequin_3.name)
		{
			Pickup.selectedObjectOriginalPosition = Mannequin_Position_3;
			Pickup.selectedObjectOriginalRotation = Mannequin_Rotation_3;
			GameObject.Find ("Mannequin 3 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Mannequin 3 Description").guiText.enabled = false;
		}
//MANNEQUIN 4
		if (getPosition == true && Pickup.selectedObject.name == Mannequin_4.name || getRotation ==true && Pickup.selectedObject.name == Mannequin_4.name)
		{
			Pickup.selectedObjectOriginalPosition = Mannequin_Position_4;
			Pickup.selectedObjectOriginalRotation = Mannequin_Rotation_4;
			GameObject.Find ("Mannequin 4 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Mannequin 4 Description").guiText.enabled = false;
		}
//MANNEQUIN 5
		if (getPosition == true && Pickup.selectedObject.name == Mannequin_5.name || getRotation ==true && Pickup.selectedObject.name == Mannequin_5.name)
		{
			Pickup.selectedObjectOriginalPosition = Mannequin_Position_5;
			Pickup.selectedObjectOriginalRotation = Mannequin_Rotation_5;
			GameObject.Find ("Mannequin 5 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Mannequin 5 Description").guiText.enabled = false;
		}
//BUNSEN BURNER
		if (getPosition == true && Pickup.selectedObject.name == Bunsen_Burner.name || getRotation ==true && Pickup.selectedObject.name == Bunsen_Burner.name)
		{
			Pickup.selectedObjectOriginalPosition = Bunsen_Burner_Position;
			Pickup.selectedObjectOriginalRotation = Bunsen_Burner_Rotation;
			GameObject.Find ("Bunsen Burner Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Bunsen Burner Description").guiText.enabled = false;
		}
//SEWING BOXES
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Boxes.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Boxes.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Boxes_Position;
			Pickup.selectedObjectOriginalRotation = Sewing_Boxes_Rotation;
			GameObject.Find ("Sewing Boxes Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Boxes Description").guiText.enabled = false;
		}
//SEWING COURSE BOOK
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Course_Book.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Course_Book.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Course_Book_Position;
			Pickup.selectedObjectOriginalRotation = Sewing_Course_Book_Rotation;
			GameObject.Find ("Sewing Course Book Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Course Book Description").guiText.enabled = false;
		}
//SEWING COURSE BOOK 2
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Course_Book_2.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Course_Book_2.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Course_Book_Position_2;
			Pickup.selectedObjectOriginalRotation = Sewing_Course_Book_Rotation_2;
			GameObject.Find ("Sewing Course Book 2 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Course Book 2 Description").guiText.enabled = false;
		}
//SEWING COURSE BOOK 3
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Course_Book_3.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Course_Book_3.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Course_Book_Position_3;
			Pickup.selectedObjectOriginalRotation = Sewing_Course_Book_Rotation_3;
			GameObject.Find ("Sewing Course Book 3 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Course Book 3 Description").guiText.enabled = false;
		}
//SEWING COURSE BOOK 4
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Course_Book_4.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Course_Book_4.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Course_Book_Position_4;
			Pickup.selectedObjectOriginalRotation = Sewing_Course_Book_Rotation_4;
			GameObject.Find ("Sewing Course Book 4 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Course Book 4 Description").guiText.enabled = false;
		}
//SEWING COURSE BOOK 5
		if (getPosition == true && Pickup.selectedObject.name == Sewing_Course_Book_5.name || getRotation ==true && Pickup.selectedObject.name == Sewing_Course_Book_5.name)
		{
			Pickup.selectedObjectOriginalPosition = Sewing_Course_Book_Position_5;
			Pickup.selectedObjectOriginalRotation = Sewing_Course_Book_Rotation_5;
			GameObject.Find ("Sewing Course Book 5 Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Sewing Course Book 5 Description").guiText.enabled = false;
		}
//FADEOMETER
		if (getPosition == true && Pickup.selectedObject.name == Fadeometer.name || getRotation ==true && Pickup.selectedObject.name == Fadeometer.name)
		{
			Pickup.selectedObjectOriginalPosition = Fadeometer_Position;
			Pickup.selectedObjectOriginalRotation = Fadeometer_Rotation;
			GameObject.Find ("Fadeometer Description").guiText.enabled = true;
			//Pickup.stopMoving = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Fadeometer Description").guiText.enabled = false;
		}
//FADEOMETER SAMPLE
		if (getPosition == true && Pickup.selectedObject.name == Fadeometer_Sample.name || getRotation ==true && Pickup.selectedObject.name == Fadeometer_Sample.name)
		{
			Pickup.selectedObjectOriginalPosition = Fadeometer_Sample_Position;
			Pickup.selectedObjectOriginalRotation = Fadeometer_Sample_Rotation;
			GameObject.Find ("Fadeometer Sample Description").guiText.enabled = true;
			//Pickup.moveToContainer = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Fadeometer Sample Description").guiText.enabled = false;
		}
//DYE JARS
		if (getPosition == true && Pickup.selectedObject.name == Dye_Jars.name || getRotation ==true && Pickup.selectedObject.name == Dye_Jars.name)
		{
			Pickup.selectedObjectOriginalPosition = Dye_Jars_Position;
			Pickup.selectedObjectOriginalRotation = Dye_Jars_Rotation;
			GameObject.Find ("Dye Jars Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Dye Jars Description").guiText.enabled = false;
		}

//WEAVING SQUARES
		if (getPosition == true && Pickup.selectedObject.name == Weaving_Squares.name || getRotation ==true && Pickup.selectedObject.name == Weaving_Squares.name)
		{
			Pickup.selectedObjectOriginalPosition = Weaving_Squares_Position;
			Pickup.selectedObjectOriginalRotation = Weaving_Squares_Rotation;
			GameObject.Find ("Weaving Squares Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Weaving Squares Description").guiText.enabled = false;
		}
//DECK OF CARDS
		if (getPosition == true && Pickup.selectedObject.name == Deck_of_cards.name || getRotation ==true && Pickup.selectedObject.name == Deck_of_cards.name)
		{
			Pickup.selectedObjectOriginalPosition = Deck_of_cards_Position;
			Pickup.selectedObjectOriginalRotation = Deck_of_cards_Rotation;
			GameObject.Find ("Deck of cards Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Deck of cards Description").guiText.enabled = false;
		}
//PIANO
		if (getPosition == true && Pickup.selectedObject.name == Piano.name || getRotation ==true && Pickup.selectedObject.name == Piano.name)
		{
			Pickup.selectedObjectOriginalPosition = Piano_Position;
			Pickup.selectedObjectOriginalRotation = Piano_Rotation;
			GameObject.Find ("Piano Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Piano Description").guiText.enabled = false;
		}
//CLARINET
		if (getPosition == true && Pickup.selectedObject.name == Clarinet.name || getRotation ==true && Pickup.selectedObject.name == Clarinet.name)
		{
			Pickup.selectedObjectOriginalPosition = Clarinet_Position;
			Pickup.selectedObjectOriginalRotation = Clarinet_Rotation;
			GameObject.Find ("Clarinet Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Clarinet Description").guiText.enabled = false;
		}
//ANGKLUNG
		if (getPosition == true && Pickup.selectedObject.name == Angklung.name || getRotation ==true && Pickup.selectedObject.name == Angklung.name)
		{
			Pickup.selectedObjectOriginalPosition = Angklung_Position;
			Pickup.selectedObjectOriginalRotation = Angklung_Rotation;
			GameObject.Find ("Angklung Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Angklung Description").guiText.enabled = false;
		}
//RADIO
		if (getPosition == true && Pickup.selectedObject.name == Radio.name || getRotation ==true && Pickup.selectedObject.name == Radio.name)
		{
			Pickup.selectedObjectOriginalPosition = Radio_Position;
			Pickup.selectedObjectOriginalRotation = Radio_Rotation;
			GameObject.Find ("Radio Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Radio Description").guiText.enabled = false;
		}
//SKI POLES
		if (getPosition == true && Pickup.selectedObject.name == Ski_Poles.name || getRotation ==true && Pickup.selectedObject.name == Ski_Poles.name)
		{
			Pickup.selectedObjectOriginalPosition = Ski_Poles_Position;
			Pickup.selectedObjectOriginalRotation = Ski_Poles_Rotation;
			GameObject.Find ("Ski Poles Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Ski Poles Description").guiText.enabled = false;
		}
//PREFORMING ORCHESIS
		if (getPosition == true && Pickup.selectedObject.name == Preforming_Orchesis.name || getRotation ==true && Pickup.selectedObject.name == Preforming_Orchesis.name)
		{
			Pickup.selectedObjectOriginalPosition = Preforming_Orchesis_Position;
			Pickup.selectedObjectOriginalRotation = Preforming_Orchesis_Rotation;
			GameObject.Find ("Preforming Orchesis Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Preforming Orchesis Description").guiText.enabled = false;
		}
//IMAGINARY INVALID
		if (getPosition == true && Pickup.selectedObject.name == Imaginary_Invalid.name || getRotation ==true && Pickup.selectedObject.name == Imaginary_Invalid.name)
		{
			Pickup.selectedObjectOriginalPosition = Imaginary_Invalid_Position;
			Pickup.selectedObjectOriginalRotation = Imaginary_Invalid_Rotation;
			GameObject.Find ("Imaginary Invalid Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Imaginary Invalid Description").guiText.enabled = false;
		}
//BARRYS ETCHINGS
		if (getPosition == true && Pickup.selectedObject.name == Barrys_Etchings.name || getRotation ==true && Pickup.selectedObject.name == Barrys_Etchings.name)
		{
			Pickup.selectedObjectOriginalPosition = Barrys_Etchings_Position;
			Pickup.selectedObjectOriginalRotation = Barrys_Etchings_Rotation;
			GameObject.Find ("Barrys Etchings Description").guiText.enabled = true;
		}

		if (turnOff == true)
		{
			GameObject.Find ("Barrys Etchings Description").guiText.enabled = false;
		}
	}
}
