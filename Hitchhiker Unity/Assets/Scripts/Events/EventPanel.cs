using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventPanel : MonoBehaviour {

	// Public VAriables
    public Text message;
    public Text title;
    public Button yes;
    public Button no;
    public Image iconImage;
    public GameObject EventPanelObject;
    
    private static EventPanel eventPanel;
    
    public static EventPanel Instance () {
        if (!eventPanel) {
            eventPanel = FindObjectOfType(typeof (EventPanel)) as EventPanel;
            if (!eventPanel)
                Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }
        
        return eventPanel;
    }
 
    public void Choice (string message, UnityAction yesEvent, UnityAction noEvent) {
        EventPanelObject.SetActive (true);
        
		// Yes
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener (yesEvent);
        yes.onClick.AddListener (ClosePanel);
        
		// No
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener (noEvent);
        no.onClick.AddListener (ClosePanel);

		// Message
        this.message.text = message;
    }

    public void Choice (string message, string title, UnityAction yesEvent, UnityAction noEvent) {
        EventPanelObject.SetActive (true);
        
		// Yes
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener (yesEvent);
        yes.onClick.AddListener (ClosePanel);
        
		// No
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener (noEvent);
        no.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
    }

    public void Choice (string message, UnityAction yesEvent, UnityAction noEvent, Sprite sprite) {
        EventPanelObject.SetActive (true);
        
		// Yes
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener (yesEvent);
        yes.onClick.AddListener (ClosePanel);
        
		// No
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener (noEvent);
        no.onClick.AddListener (ClosePanel);

		// Message
        this.message.text = message;

        // Icon
        iconImage.sprite = sprite;
    }

    public void Choice (string message, string title, UnityAction yesEvent, UnityAction noEvent, Sprite sprite) {
        EventPanelObject.SetActive (true);
        
		// Yes
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener (yesEvent);
        yes.onClick.AddListener (ClosePanel);
        
		// No
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener (noEvent);
        no.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;

        // Icon
        iconImage.sprite = sprite;
    }

    void ClosePanel () {
        EventPanelObject.SetActive (false);
    }
}
