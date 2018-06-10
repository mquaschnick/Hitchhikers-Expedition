using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayScreen : MonoBehaviour {

    
    public static HowToPlayScreen Instance { get; set; }

    [Header("GameObjects and UI Element References")]
    public GameObject InstructionCanvas, instructionPanel;
    public Image InstructionElement;
    public Text InstructionText, InstructionHeader;
    public GameObject ContinueButton, ReturnButton;
    public GameObject BeginButton;

    [Header("Index")]
    public int InstructionIndex;

    [Header("Lists Management")]
    [Tooltip("Keep as 1 in editor. Gets set be a different script.")]
    public List<Sprite> spriteList = new List<Sprite>();
    public List<string> TextList = new List<string>();
    public List<string> HeaderList = new List<string>();

    [Header("Sound")]
    public AudioClip BeepAudio;
    public AudioSource SoundSource;


    // Use this for initialization
    void Awake () {
        Instance = this;
        
	}

    private void Start()
    {
        BeginButton.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void AddNewImages(Sprite[] UISprites, string[] TutorialTexts, string[] TutorialTitles)
    {
        InstructionIndex = -1;
        spriteList = new List<Sprite>();
        foreach (Sprite UISprite in UISprites)
        {
            spriteList.Add(UISprite);
        }
        TextList = new List<string>();
        foreach (string TutorialText in TutorialTexts)
        {
            TextList.Add(TutorialText);
        }
        HeaderList = new List<string>();
        foreach (string TutorialTitle in TutorialTitles)
        {
            HeaderList.Add(TutorialTitle);
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
            InstructionText.text = (TextList[InstructionIndex]);
            InstructionHeader.text = (HeaderList[InstructionIndex]);
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
                BeginButton.SetActive(true);
            }
            InstructionElement.sprite = (spriteList[InstructionIndex]);
            InstructionText.text = (TextList[InstructionIndex]);
            InstructionHeader.text = (HeaderList[InstructionIndex]);
        }
    }

    public void GoBackTutorialList()
    {
        if (InstructionIndex > 0)
        {
            BeginButton.SetActive(false);
            InstructionIndex--;
            ContinueButton.SetActive(true);
            if (InstructionIndex <= 0)
            {
                ReturnButton.SetActive(false);
            }
            InstructionElement.sprite = (spriteList[InstructionIndex]);
            InstructionText.text = (TextList[InstructionIndex]);
            InstructionHeader.text = (HeaderList[InstructionIndex]);
        }
    }



}
