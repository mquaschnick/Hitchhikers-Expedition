using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Thirst : MonoBehaviour
{
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
        noAction = new UnityAction(NoFunction);
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
        // Low Need Thirst Variants
        // The thirst is strong. Find something to drink soon.
        // You're getting really thirsty. You should drink something soon.
        // High Need Thirst Variant
        // You're experiencing dehydration. You didn't think your tongue could feel like sandpaper. Find something to drink as soon as possible.
        string message = "Looks like you're getting thirsty. You should drink something soon.";
        eventPanel.Choice(message, YesFunction, NoFunction);
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("Ahhhh cool, refreshing, liquid.");
        Time.timeScale = 1;
    }

    void NoFunction()
    {
        eventDisplayManager.DisplayMessage("The thirst remains strong with this one.");
        Time.timeScale = 1;
    }
}