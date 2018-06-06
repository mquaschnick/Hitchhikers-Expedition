using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_FlavorEvents : MonoBehaviour
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

    private void FixedUpdate()
    {
        if (!player.isMoving && !player.isInCar)
        {

            float chance = Random.Range(0.0f, 100.0f);

            if (chance < percentChance)
            {
                Time.timeScale = 0;
                FlavorYN();
            }
        }
    }

    public void FlavorYN()
    {

        // These will be random things that pop up that don't affect anything, but add some flavor text to their life.
        string message = "A scrap of a magazine cover you saw says there's been an outcry for [your noun] in California. Apparently developers are popping up left and right to chase this money trail. Better start running.";
        eventPanel.Choice(message, YesFunction, NoFunction);
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("That's...not...great.");
        Time.timeScale = 1;
    }

    void NoFunction()
    {
        eventDisplayManager.DisplayMessage("They'll all fail without my genius.");
        Time.timeScale = 1;
    }
}
