using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventPanel : MonoBehaviour {

	// Public VAriables
    public Text message;
    public Text title;
    public Button event1;
    public Button event2;
    public Button event3;
    public Image iconImage;
    public GameObject EventPanelObject;
    public Sprite defaultSprite;
    
    private static EventPanel eventPanel;
    
    public static EventPanel Instance () {
        if (!eventPanel) {
            eventPanel = FindObjectOfType(typeof (EventPanel)) as EventPanel;
            if (!eventPanel)
                Debug.LogError ("There needs to be one active EventPanel script on a GameObject in your scene.");
        }
        
        return eventPanel;
    }
 
    public void Choice (string message, UnityAction firstEvent, UnityAction secondEvent) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

		// Message
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = "Yes";
        event2.GetComponentInChildren<Text>().text = "No";

        // Icon
        iconImage.sprite = defaultSprite;

    }

    public void Choice (string message, string title, UnityAction firstEvent, UnityAction secondEvent) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = "Yes";
        event2.GetComponentInChildren<Text>().text = "No";

        // Icon
        iconImage.sprite = defaultSprite;
    }

    public void Choice (string message, UnityAction firstEvent, UnityAction secondEvent, Sprite sprite) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

		// Message
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = "Yes";
        event2.GetComponentInChildren<Text>().text = "No";

        // Icon
        iconImage.sprite = sprite;
    }

    public void Choice (string message, string title, UnityAction firstEvent, UnityAction secondEvent, Sprite sprite) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = "Yes";
        event2.GetComponentInChildren<Text>().text = "No";

        // Icon
        iconImage.sprite = sprite;
    }

    public void Choice (string message, string title, UnityAction firstEvent, Sprite sprite, string button1) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (false);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = button1;

        // Icon
        iconImage.sprite = sprite;
    }

    public void Choice (string message, string title, UnityAction firstEvent, UnityAction secondEvent, Sprite sprite, string button1, string button2) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (false);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = button1;
        event2.GetComponentInChildren<Text>().text = button2;

        // Icon
        iconImage.sprite = sprite;
    }

    public void Choice (string message, string title, UnityAction firstEvent, UnityAction secondEvent, UnityAction thirdEvent, Sprite sprite, string button1, string button2, string button3) {
        EventPanelObject.SetActive (true);
        event1.gameObject.SetActive (true);
        event2.gameObject.SetActive (true);
        event3.gameObject.SetActive (true);
        
		// Event1
        event1.onClick.RemoveAllListeners();
        event1.onClick.AddListener (firstEvent);
        event1.onClick.AddListener (ClosePanel);
        
		// Event2
        event2.onClick.RemoveAllListeners();
        event2.onClick.AddListener (secondEvent);
        event2.onClick.AddListener (ClosePanel);

        // Event3
        event3.onClick.RemoveAllListeners();
        event3.onClick.AddListener (thirdEvent);
        event3.onClick.AddListener (ClosePanel);

		// Message
        this.title.text = title;
        this.message.text = message;
        event1.GetComponentInChildren<Text>().text = button1;
        event2.GetComponentInChildren<Text>().text = button2;
        event3.GetComponentInChildren<Text>().text = button3;

        // Icon
        iconImage.sprite = sprite;
    }

    void ClosePanel () {
        EventPanelObject.SetActive (false);
    }
}
