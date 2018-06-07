using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayScreen : MonoBehaviour {

    
    public static HowToPlayScreen Instance { get; set; }

    [Header("GameObjects and UI Element References")]
    public GameObject InstructionCanvas, instructionPanel;
    public Image InstructionElement;
    public GameObject ContinueButton, ReturnButton;

    [Header("Index")]
    public int InstructionIndex;

    [Header("Lists Management")]
    [Tooltip("Keep as 0 in editor. Gets set be a different script.")]
    public List<Sprite> spriteList = new List<Sprite>();

    [Header("Sound")]
    public AudioClip BeepAudio;
    public AudioSource SoundSource;


    // Use this for initialization
    void Awake () {
        Instance = this;
	} 
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddNewImages(Sprite[] UISprites)
    {
        InstructionIndex = -1;
        spriteList = new List<Sprite>();
        foreach (Sprite UISprite in UISprites)
        {
            spriteList.Add(UISprite);
        }
        CreateTutorialList();
    }

    public void CreateTutorialList()
    {
        ReturnButton.SetActive(false);
        ContinueTutorialListPreDone();
    }

    public void ContinueTutorialListPreDone()
    {
        if (InstructionIndex < spriteList.Count - 1)
        {
            InstructionIndex++;
            InstructionElement.sprite = (spriteList[InstructionIndex]);

        }
    }

    public void ContinueTutorialList()
    { 
        if (InstructionIndex < spriteList.Count - 1)
        {
            InstructionIndex++;
            ReturnButton.SetActive(true);
            if (InstructionIndex >= spriteList.Count - 1)
            {
                ContinueButton.SetActive(false);
            }
            InstructionElement.sprite = (spriteList[InstructionIndex]);
           
        }
    }

    public void GoBackTutorialList()
    {
        if (InstructionIndex > 0)
        {
            InstructionIndex--;
            ContinueButton.SetActive(true);
            if (InstructionIndex <= 0)
            {
                ReturnButton.SetActive(false);
            }
            InstructionElement.sprite = (spriteList[InstructionIndex]);
        }
    }



}
