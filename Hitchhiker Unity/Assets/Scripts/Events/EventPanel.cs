using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventPanel : MonoBehaviour {

	// Public VAriables
    public Text message;
    public Button yes;
    public Button no;
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

    void ClosePanel () {
        EventPanelObject.SetActive (false);
    }
}
