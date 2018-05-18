using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Color_Shader_Script : MonoBehaviour {

	// Public Variables
	public Material effect;
	public float precision = 0.1f;
	public Color In0;
	public Color In1;
	public Color In2;
	public Color In3;
	public Color Out0;
	public Color Out1;
	public Color Out2;
	public Color Out3;

	// Set colors and render
	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		effect.SetFloat("_Precision", precision);
		effect.SetColor("_In0", In0);
		effect.SetColor("_Out0", Out0);
		effect.SetColor("_In1", In1);
		effect.SetColor("_Out1", Out1);
		effect.SetColor("_In2", In2);
		effect.SetColor("_Out2", Out2);
		effect.SetColor("_In3", In3);
		effect.SetColor("_Out3", Out3);

		Graphics.Blit(src, dst,  effect);
	}
}
