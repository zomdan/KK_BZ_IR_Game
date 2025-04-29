using UnityEngine;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public Camera camera1;  // Reference to the first camera
    public Camera camera2;  // Reference to the second camera
    public GameObject lightTrigger;
    public AnimationController animationTrigger;
    public GameObject building;
    public RotatingStone[] stones; // Array of stones

    void start()
    {
        lightTrigger.SetActive(false);
    }


    public void Update()
    {

        if (CheckPuzzleSolved())
        {
            StartCoroutine(SwitchCameras());
            BuildingUp();
            lightTrigger.SetActive(true);
        }
    }

    bool CheckPuzzleSolved()
    {
        foreach (RotatingStone stone in stones)
        {
            if (stone.GetCurrentSymbol() != "Eagle") // Change to your correct symbol
            {
                return false;
            }
        }
        return true;
    }

    void BuildingUp()
    {
        animationTrigger.TriggerAnim();
        this.enabled = false; // Disable further checks
    }

    private IEnumerator SwitchCameras()
    {
        yield return new WaitForSeconds(0.5f); 
        // Switch between the cameras by enabling one and disabling the other
        camera1.enabled = false;
        camera2.enabled = true;

        yield return new WaitForSeconds(4f); 

        camera1.enabled = true;
        camera2.enabled = false;
        Destroy(this);
    }
}
