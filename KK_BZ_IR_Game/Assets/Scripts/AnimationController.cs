using UnityEngine;

public class AnimationController : MonoBehaviour
{
 Animator animator;

    void Start() 
    {
    animator = gameObject.GetComponent<Animator>();
    }
    public void TriggerAnim() 
    {
     animator.SetBool("ActivateAnim", true);
    }
}

