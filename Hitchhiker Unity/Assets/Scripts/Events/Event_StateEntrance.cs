using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Event_StateEntrances : MonoBehaviour
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
        if (player.isMoving && !player.isInCar)
        {

            float chance = Random.Range(0.0f, 100.0f);

            if (chance < percentChance)
            {
                Time.timeScale = 0;
                NewStateYN();
            }
        }
    }

    public void NewStateYN()
    {
        // These pop up as the player enters a new state on the map
        // "You're already in New Hampshire? Life free or die, granite, and the first to declare independence from England. Totally rebelling before it was cool."
        // "Vermont is really just New Hampshire turned right side up. You heard somewhere that the capital Montpelier still hasn't been touched by the evil corporate hands of McDonalds."
        string message = "Ah Maine...the state of rocky coasts and lots of freaking trees. it has its more secret beauties though, like the cannery in Wilton that cans your favorite dandelion greens. You might miss this place a bit...";
        eventPanel.Choice(message, YesFunction, NoFunction);
    }

    void YesFunction()
    {
        eventDisplayManager.DisplayMessage("Nothing a little snack can't cure.");
        Time.timeScale = 1;
    }

    void NoFunction()
    {
        eventDisplayManager.DisplayMessage("*stomach growls angrily in protest*");
        Time.timeScale = 1;
    }
}
