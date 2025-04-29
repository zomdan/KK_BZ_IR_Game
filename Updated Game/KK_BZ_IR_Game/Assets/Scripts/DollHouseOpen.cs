using UnityEngine;
using System.Collections;

public class DollHouseOpen : MonoBehaviour
{
    public Camera camera1;  // Reference to the first camera
    public Camera camera2;  // Reference to the second camera
    public AnimationController animationTrigger;
    public GameObject DollHouse; 
    private bool isPressed = false;

    private void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PushableObject")) 
        {
            isPressed = true;
            Debug.Log("Pressure Pad Activated!");
            StartCoroutine(SwitchCameras());
            DollHouseSlideOut();
        }
    }

    private void DollHouseSlideOut()
    {

     animationTrigger.TriggerAnim();
    }

    private IEnumerator SwitchCameras()
    {
        yield return new WaitForSeconds(0.5f); 
        // Switch between the cameras by enabling one and disabling the other
        camera1.enabled = false;
        camera2.enabled = true;

        yield return new WaitForSeconds(3f); 

        camera1.enabled = true;
        camera2.enabled = false;
        Destroy(this);
    }
}