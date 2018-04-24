using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class Scr_Pixelate : MonoBehaviour {


    public Material effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // source is all of the pixels coming in, destination is the material we're applying to
    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        // Blit runs this shit through the shader
        // Shaders go through each pixel, and say run this function on this pixel
        Graphics.Blit(source, destination, effect);
    }
}
