using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskInteract : MonoBehaviour
{
    public StarterAssets.ThirdPersonController thirdPersonController;
    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject player;
    public GameObject promptUI;
    private bool hasInspected = false;
    public float interactionRadius = 3f;
    
    private bool isPlayerNearby = false; 

    void Start()
    {
        if (thirdPersonController == null)
        {
            thirdPersonController = FindObjectOfType<StarterAssets.ThirdPersonController>();
        }
        if (promptUI != null)
            promptUI.SetActive(false); // Hide prompt initially

        paper1.SetActive(false);
        paper2.SetActive(false);
        paper3.SetActive(false);

        thirdPersonController.enabled = true;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactionRadius)
        {
            ShowPrompt();
            isPlayerNearby = true;

            if (Input.GetKeyDown(KeyCode.E) && !hasInspected)
            {
                StartCoroutine(InspectPaper());

                thirdPersonController.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.F) && hasInspected)
            {
                StartCoroutine(Exit());
            }

        }

        else
        {
            HidePrompt();
            isPlayerNearby = false;
            hasInspected = false;
        }
    }

    void ShowPrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(true);
    }

    void HidePrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }


    private IEnumerator InspectPaper()
    {
        paper1.SetActive(true);
        yield return new WaitForSeconds(1f);
        paper2.SetActive(true);
        paper1.SetActive(false);
        hasInspected = true;
        
    }

    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.8f);
        paper1.SetActive(false);
        paper2.SetActive(false);
        paper3.SetActive(true);
        yield return new WaitForSeconds(1f);
        paper3.SetActive(false);
        hasInspected = false;
        thirdPersonController.enabled = true;
    }
}
