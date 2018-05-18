using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Reset : MonoBehaviour {

	public void LoadScene() {
		Time.timeScale = 1;
		SceneManager.LoadScene("PreAlphaEnvironment");
	}

}
