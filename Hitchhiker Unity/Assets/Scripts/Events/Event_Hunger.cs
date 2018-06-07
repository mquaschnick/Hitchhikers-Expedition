using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Hunger : MonoBehaviour
{
    public Sprite[] spritesArray;

    private EventPanel eventPanel;
    private EventDisplayManager eventDisplayManager;

    private UnityAction yesAction;
    private UnityAction noAction;

    private PlayerController_Master player;

    public float percentChance;

    void Awake()
    {
        eventPanel = EventPanel.Instance();
        eventDisplayManager = EventDisplayManager.Instance();

        yesAction = new UnityAction(YesFunction);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Master>();
        percentChance /= 100.0f;
    }

    private void Update()
    {
        if (player.isMoving && !player.isInCar && player.hunger <= .05)
        {

            float chance = Random.Range(0.0f, 100.0f);

            if (chance < percentChance)
            {
                Time.timeScale = 0;
                HungerYN();
            }
        }
    }

    public void HungerYN()
    {
        ArrayList msgArray = new ArrayList();
        msgArray.Add("Looks like you're hungry. You should probably eat something.");
        msgArray.Add("You’re hungry. Eating something should ward off the effects of hunger.");
        msgArray.Add("You’re getting really hungry. You should eat something soon.");
        msgArray.Add("Your stomach won’t stop growling. Eat something soon.");
        int rand = (int)Random.Range(0, msgArray.Count);
        string message = (string)msgArray[rand];
        string title = "Hungery";
        rand = (int)Random.Range(0, spritesArray.Length);
        eventPanel.Choice(message, title, YesFunction, spritesArray[rand], "OK");
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("Nothing a little snack can't cure.");
        Time.timeScale = 1;
    }
}
