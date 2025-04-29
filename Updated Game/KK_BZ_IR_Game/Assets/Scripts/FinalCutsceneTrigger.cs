using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutsceneTrigger : MonoBehaviour
{
    public AnimationController animationTrigger;
    public GameObject player;
    public float interactionRadius = 1f;
    private bool isPlayerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= interactionRadius && !isPlayerNearby)
            {
                isPlayerNearby = true;
                StartCoroutine(TriggerFinalCutscene());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = false;
        }
    }

    private IEnumerator TriggerFinalCutscene()
    {
        // Trigger the animation
        Debug.Log("Cutscene Triggered");
        animationTrigger.TriggerAnim();
        
        // Wait for 1 second before changing the scene
        yield return new WaitForSeconds(3f);  // Delay for 1 second

        // After the delay, load the next scene asynchronously
        SceneManager.LoadSceneAsync(2);  // Adjust scene index as needed
    }
}
