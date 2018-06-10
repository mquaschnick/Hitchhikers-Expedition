using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayImageHandler : MonoBehaviour {

    public Sprite[] TutorialImages;
    public string[] Headers;
    public string[] Texts;

    private void Start()
    {
        HowToPlayScreen.Instance.AddNewImages(TutorialImages, Texts, Headers);
    }
}
