using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour {

    [Tooltip("The scene where the game begins, or maybe the scene where you slect Male/Female.")]
    public string SceneName;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ControlsScreen()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
