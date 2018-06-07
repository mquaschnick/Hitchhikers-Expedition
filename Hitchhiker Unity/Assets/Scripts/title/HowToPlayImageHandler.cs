using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayImageHandler : MonoBehaviour {

    public Sprite[] TutorialImages;


    private void Start()
    {
        HowToPlayScreen.Instance.AddNewImages(TutorialImages);
    }
}
