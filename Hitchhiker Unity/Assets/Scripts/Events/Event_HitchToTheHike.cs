using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_HitchToTheHike : MonoBehaviour {
    public Sprite[] spritesArray;
    
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
            ArrayList yesArray = new ArrayList();
            ArrayList noArray = new ArrayList();
            msgArray.Add("Hop in! You like Cher?");
            yesArray.Add("Let's go.");
            noArray.Add("I'll walk.");
            msgArray.Add("Hey, need a ride?");
            yesArray.Add("Cool, thanks.");
            noArray.Add("I'll pass.");
            msgArray.Add("Need a ride? Just kick all that duct tape under the seat there.");
            yesArray.Add("Yea thanks.");
            noArray.Add("Uhhh no thanks.");
            int rand = (int)Random.Range(0, msgArray.Count);
            string message = (string)msgArray[rand];
            string yes = (string)yesArray[rand];
            string no = (string)noArray[rand];
            rand = (int)Random.Range(0, spritesArray.Length);
            eventPanel.Choice (message, title, YesFunction, NoFunction, spritesArray[rand], yes, no);
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
