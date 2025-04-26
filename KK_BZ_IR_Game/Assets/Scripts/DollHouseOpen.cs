using UnityEngine;


public class DollHouseOpen : MonoBehaviour
{
    public AnimationController animationTrigger;
    public GameObject DollHouse; 
    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Object")) 
        {
            isPressed = true;
            Debug.Log("Pressure Pad Activated!");
            DollHouseSlideOut();
        }
    }

    private void DollHouseSlideOut()
    {
     animationTrigger.TriggerAnim();
    }
}