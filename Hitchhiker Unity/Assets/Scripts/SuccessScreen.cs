using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessScreen : MonoBehaviour {

    [Tooltip("Set this to on if you don't want the button to reset player back to the level. If you set to on, be sure to type the name of the scene in the string variable below and the script will take care of the rest for you.")]
    public bool ResetLevelInsteadOfReturnToTitle = false;
    [Tooltip("If you set the bool above to true, enter the name of the scene for the level here.")]
    public string LevelName = "BetaEnvironment";

    string ChangeButtonText = "Play Again";

    Text ButtonText;

	// Use this for initialization
	void Start () {
        ButtonText = GameObject.Find("Canvas").transform.Find("ResetButton").transform.Find("Text").gameObject.GetComponent<Text>();
        if (ResetLevelInsteadOfReturnToTitle == true)
        {
            ButtonText.text = ChangeButtonText;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ReturnButtonPressed()
    {
        if (ResetLevelInsteadOfReturnToTitle == false)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {

            SceneManager.LoadScene(LevelName);
        }
    }
}
