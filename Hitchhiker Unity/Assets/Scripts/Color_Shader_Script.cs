using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Color_Shader_Script : MonoBehaviour {

	// Public Variables
	public float precision = 0.1f;
	public Color In0;
	public Color In1;
	public Color In2;
	public Color In3;
	public Color Out0;
	public Color Out1;
	public Color Out2;
	public Color Out3;

	// Private Variables
	private Material _mat;

	// Create material
	void OnEnable() {
		Shader shader = Shader.Find("Custom/Camera/Color_Shader");
		if (_mat == null)
			_mat = new Material(shader);
    }

	// Set colors and render
	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		_mat.SetFloat("_Precision", precision);
		_mat.SetColor("_In0", In0);
		_mat.SetColor("_Out0", Out0);
		_mat.SetColor("_In1", In1);
		_mat.SetColor("_Out1", Out1);
		_mat.SetColor("_In2", In2);
		_mat.SetColor("_Out2", Out2);
		_mat.SetColor("_In3", In3);
		_mat.SetColor("_Out3", Out3);

		Graphics.Blit(src, dst,  _mat);
	}
}
