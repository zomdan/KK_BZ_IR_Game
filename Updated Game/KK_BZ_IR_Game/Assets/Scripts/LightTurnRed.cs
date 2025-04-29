using System.Collections;
using UnityEngine;

public class LightTurnRed : MonoBehaviour
{
    public AnimationController animationTrigger;
    public GameObject player;
    public float interactionRadius = 70f;
    private bool isPlayerNearby = false;


void OnTriggerEnter(Collider other)
    {
    float distance = Vector3.Distance(player.transform.position, transform.position);
    if (distance <= interactionRadius && !isPlayerNearby)
        {
            isPlayerNearby = true;
            LightChange();
        }
    }

    void LightChange()
    {
        // Trigger the animation to turn the light red
        animationTrigger.TriggerAnim();

    }

}