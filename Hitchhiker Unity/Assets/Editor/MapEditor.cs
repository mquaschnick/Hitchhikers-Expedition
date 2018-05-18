using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapEditor : Editor 
{
	private bool change = false;
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector (); 

		MapGenerator village = (MapGenerator) target;

        /*
		if (GUI.changed)
			village.GenerateVillage (); //whenever village is selected it will be constantly regenerating itself
        */

		if (GUILayout.Button ("Randomize & Generate")) 
		{
            village.RandomizeGenerate();
        }

		if (GUILayout.Button ("Generate")) 
		{
			village.GenerateMap ();
		}
	}
}
