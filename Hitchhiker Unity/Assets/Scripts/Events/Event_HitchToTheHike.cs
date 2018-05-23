using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_HitchToTheHike : MonoBehaviour {
    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;
    private UnityAction noAction;

    private PlayerController_Master player;

    private GameObject playerObj;
    private GameObject car;

    void Awake () {
        eventPanel = EventPanel.Instance ();
        eventDisplayManager = EventDisplayManager.Instance ();

        yesAction = new UnityAction (YesFunction);
        noAction = new UnityAction (NoFunction);
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Master>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
         car = GameObject.FindGameObjectWithTag("CarSuccess");
    }

    public void HitchToTheHikeYN () {
        Time.timeScale = 0;
		string message = "You see a very bloody axe in the back seat as the car approaches. 'Boi, be better' the driver says as he speeds away. Would you like grab onto the car last second?";
        eventPanel.Choice (message, YesFunction, NoFunction);
    }

    void YesFunction () {
        eventDisplayManager.DisplayMessage ("Yipee!");
        Time.timeScale = 1;
        playerObj.GetComponent<PlayerController_Movement>().getInCar();
        playerObj.transform.SetParent(car.transform);
    }

    void NoFunction () {
        eventDisplayManager.DisplayMessage ("Thats gonna be a yikes from me dawg");
        car.GetComponent<Car_Success>().setOffset(-100);
        Time.timeScale = 1;
    }
}
