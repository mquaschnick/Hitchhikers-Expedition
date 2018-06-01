using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_HitchToTheHike : MonoBehaviour {
    public Sprite sprite;
    
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
        if (player.isDirty) {
            eventDisplayManager.DisplayMessage ("I must be too dirty to get a ride...");
            car.GetComponent<Car_Success>().setOffset(-100);
        } else {
            Time.timeScale = 0;
            string title = "Hitchhike";
            ArrayList msgArray = new ArrayList();
            msgArray.Add("Hop in! You like Cher?");
            msgArray.Add("Get in stranger!");
            msgArray.Add("Need a ride? Just kick all that duct tape under the seat there.");
            msgArray.Add("Hey, glad I saw you before I got past ya.");
            // High Need Hunger Variant
            // You're experiencing starvation. Even the leaves look delicious right now. Eat something as soon as possible.
            int rand = (int)Random.Range(0, msgArray.Count);
            string message = (string)msgArray[rand];
            // Old Placeholder
            // string message = "You see a very bloody axe in the back seat as the car approaches. 'Boi, be better' the driver says as he speeds away. Would you like grab onto the car last second?";
            eventPanel.Choice (message, title, YesFunction, NoFunction, sprite);
        }
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
