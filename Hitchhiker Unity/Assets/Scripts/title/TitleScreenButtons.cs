using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour {


    [Tooltip("After player goes through the opening bits of the game, this scene is where begin button in character select will take you.")]
    public string GameplaySceneName = "BetaEnvironment";

    public void NewGame()
    {
        SavedPlayerStats.StartingGameLevelSceneName = GameplaySceneName;
        SceneManager.LoadScene("Controls");
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
