using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Twist : MonoBehaviour {
    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;
    private UnityAction noAction;

    void Awake () {
        eventPanel = EventPanel.Instance ();
        eventDisplayManager = EventDisplayManager.Instance ();

        yesAction = new UnityAction (YesFunction);
        noAction = new UnityAction (NoFunction);
    }

    public void TwistYN () {
		string message = "You got distracted thinking about the multiple applications your [YOUR NOUN] could have and tripped. A twisted ankle is not great but at least you didn’t break anything. Would you like to rest for [SET AMOUT OF TIME]?";
        eventPanel.Choice (message, YesFunction, NoFunction);
    }

    void YesFunction () {
        eventDisplayManager.DisplayMessage ("Heck yeah! Yup!");
    }

    void NoFunction () {
        eventDisplayManager.DisplayMessage ("No way, José!");
    }
}
