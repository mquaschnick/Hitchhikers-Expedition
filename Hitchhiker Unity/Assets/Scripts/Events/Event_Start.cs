using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Start : MonoBehaviour {

    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;
    private UnityAction noAction;

    void Awake() {
        eventPanel = EventPanel.Instance();
        eventDisplayManager = EventDisplayManager.Instance();

        yesAction = new UnityAction(YesFunction);
        noAction = new UnityAction(NoFunction);
    }

    private void Start() {
        Time.timeScale = 0;
        StartYN();
    }

    public void StartYN() {
        string message = "You invented the most amazing product, organic nose rings! You poured every penny you had into this idea, but no one here understands, and refuse to invest in your product.  You're heading out west to California to find an investor! Are you excited?";
        eventPanel.Choice(message, YesFunction, NoFunction);
    }

    void YesFunction() {
        eventDisplayManager.DisplayMessage("Yippee! This is where the fun begins.");
        Time.timeScale = 1;
    }

    void NoFunction() {
        eventDisplayManager.DisplayMessage("No way, José!");
        Time.timeScale = 1;
    }
}
