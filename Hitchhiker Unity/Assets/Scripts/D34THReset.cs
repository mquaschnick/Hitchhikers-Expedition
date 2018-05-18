using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class D34THReset : MonoBehaviour {

	public void LoadScene() {
		Time.timeScale = 1;
		SceneManager.LoadScene("D34TH_T35T");
	}

}
