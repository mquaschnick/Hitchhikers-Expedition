using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_Hunger : MonoBehaviour
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
        // Low Need Hunger Variants
        // You're hungry. Eating something should help.
        // You're getting really hungry. You should eat something soon.
        // Your stomach won't stop growling. Eat something soon.
        // High Need Hunger Variant
        // You're experiencing starvation. Even the leaves look delicious right now. Eat something as soon as possible.
        string message = "Looks like you're hungry. You should probably eat something.";
        eventPanel.Choice(message, YesFunction, NoFunction);
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("Nothing a little snack can't cure.");
        player.GetComponent<PlayerController_Statuses>().updateHunger(-0.2f);
        Time.timeScale = 1;
    }

    void NoFunction()
    {
        eventDisplayManager.DisplayMessage("*stomach growls angrily in protest*");
        player.injuredAffect = 0.5f;
        Time.timeScale = 1;
    }
}
