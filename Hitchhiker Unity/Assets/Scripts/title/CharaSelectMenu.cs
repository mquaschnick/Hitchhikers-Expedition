using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharaSelectMenu : MonoBehaviour {

    public bool IsFemale = false;

    public Sprite MaleSel, FemaleSel;
    public Image SelectionButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SavedPlayerStats.IsFemale = IsFemale;
	}


    public void BeginButton()
    {
        SceneManager.LoadScene(SavedPlayerStats.StartingGameLevelSceneName);
    }
    public void SwapGender()
    {
        IsFemale = !IsFemale;
        if (IsFemale)
        {
            SelectionButton.sprite = FemaleSel;
            SavedPlayerStats.IsFemale = IsFemale;
        }
        else
        {
            SelectionButton.sprite = MaleSel;
            SavedPlayerStats.IsFemale = IsFemale;
        }
    }
}
