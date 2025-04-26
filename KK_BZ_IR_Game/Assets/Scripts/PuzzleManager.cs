using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public AnimationController animationTrigger;
    public GameObject building;
    public RotatingStone[] stones; // Array of stones

    void Update()
    {
        if (CheckPuzzleSolved())
        {
            BuildingUp();
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
}
