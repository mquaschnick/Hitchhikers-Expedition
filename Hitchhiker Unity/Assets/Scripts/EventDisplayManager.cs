using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventDisplayManager : MonoBehaviour {

    public Text message;
	public Image back;
    public float displayTime;
    public float fadeTime;
    
    private IEnumerator fadeAlpha;
    
    private static EventDisplayManager eventDisplayManager;
    
    public static EventDisplayManager Instance () {
        if (!eventDisplayManager) {
            eventDisplayManager = FindObjectOfType(typeof (EventDisplayManager)) as EventDisplayManager;
            if (!eventDisplayManager)
                Debug.LogError ("There needs to be one active EventDisplayManager script on a GameObject in your scene.");
        }
        
        return eventDisplayManager;
    }

    public void DisplayMessage (string message) {
        this.message.text = message;
        SetAlpha ();
    }
    
    void SetAlpha () {
        if (fadeAlpha != null) {
            StopCoroutine (fadeAlpha);
        }
        fadeAlpha = FadeAlpha ();
        StartCoroutine (fadeAlpha);
    }
    
    IEnumerator FadeAlpha () {
        Color resetColor = message.color;
		Color resetColorBack = back.color;
        resetColor.a = 1;
		resetColorBack.a = 0.75f;
        message.color = resetColor;
		back.color = resetColorBack;
        
        yield return new WaitForSeconds (displayTime);
        
        while (message.color.a > 0) {
            Color displayColor = message.color;
			Color displayColorBack = back.color;
            displayColor.a -= Time.deltaTime / fadeTime;
			displayColorBack.a -= Time.deltaTime / fadeTime;
            message.color = displayColor;
			back.color = displayColorBack;
            yield return null;
        }

        yield return null;
    }
}
