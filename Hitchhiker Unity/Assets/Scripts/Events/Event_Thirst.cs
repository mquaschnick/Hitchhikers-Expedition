using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Thirst : MonoBehaviour
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
        if (player.isMoving && !player.isInCar && player.thirst <= .05)
        {

            float chance = Random.Range(0.0f, 100.0f);

            if (chance < percentChance)
            {
                Time.timeScale = 0;
                ThirstYN();
            }
        }
    }

    public void ThirstYN()
    {
        ArrayList msgArray = new ArrayList();
        msgArray.Add("Looks like you’re thirsty. You should drink something.");
        msgArray.Add("The thirst is strong. Find something to drink soon.");
        int rand = (int)Random.Range(0, msgArray.Count);
        string message = (string)msgArray[rand];
        string title = "Thirsty";
        rand = (int)Random.Range(0, spritesArray.Length);
        eventPanel.Choice(message, title, YesFunction, spritesArray[rand], "OK");
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("Ahhhh need a cool, refreshing, liquid.");
        Time.timeScale = 1;
    }
}