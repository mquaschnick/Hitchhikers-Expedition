using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Twist : MonoBehaviour {
    public Sprite[] spritesArray;

    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;

    private PlayerController_Master player;

    public float percentChance;

    void Awake () {
        eventPanel = EventPanel.Instance ();
        eventDisplayManager = EventDisplayManager.Instance ();

        yesAction = new UnityAction (YesFunction);
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Master>();
        percentChance /= 100.0f;
    }

    private void Update() {
        if(player.isMoving && !player.isInCar) {
            
            float chance = Random.Range(0.0f, 100.0f);

            if(chance < percentChance) {
                Time.timeScale = 0;
                TwistYN();
            }
        }
    }

    public void TwistYN () {

        // "You twisted your already twisted ankle. Well...now it's broken. So good luck with that."
        // "That old quidditch injury from college is acting up again. The pain is manageable though."
		string message = "You tripped and twisted your ankle.";
        string title = "Twisted Ankle";
        int rand = (int)Random.Range(0, spritesArray.Length);
        eventPanel.Choice (message, title, YesFunction, spritesArray[rand], "OK");
    }

    void YesFunction () {
        eventDisplayManager.DisplayMessage ("You rested to heal your ankle. So much time has passed, you feel hungry though.");
        player.GetComponent<PlayerController_Statuses>().updateHunger(-0.2f);
        Time.timeScale = 1;
    }
}
