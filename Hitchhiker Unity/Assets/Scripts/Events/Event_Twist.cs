using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Twist : MonoBehaviour {
    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;
    private UnityAction noAction;

    private PlayerController_Master player;

    public float percentChance;

    void Awake () {
        eventPanel = EventPanel.Instance ();
        eventDisplayManager = EventDisplayManager.Instance ();

        yesAction = new UnityAction (YesFunction);
        noAction = new UnityAction (NoFunction);
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
		string message = "You got distracted thinking about the multiple applications your [YOUR NOUN] could have and tripped. A twisted ankle is not great but at least you didn’t break anything. Would you like to rest for [SET AMOUT OF TIME]?";
        eventPanel.Choice (message, YesFunction, NoFunction);
    }

    void YesFunction () {
        eventDisplayManager.DisplayMessage ("Your ankle feels better, you move on. So much time has passed, you feel hungry though.");
        player.GetComponent<PlayerController_Statuses>().updateHunger(-0.2f);
        Time.timeScale = 1;
    }

    void NoFunction () {
        eventDisplayManager.DisplayMessage ("Ouch, you move at half the speed.");
        player.injuredAffect = 0.5f;
        Time.timeScale = 1;
    }
}
