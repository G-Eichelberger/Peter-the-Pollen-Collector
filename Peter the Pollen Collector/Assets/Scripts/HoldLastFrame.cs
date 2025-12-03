using UnityEngine;

public class HoldLastFrame : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Stop the animation once it reaches the end
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !anim.IsInTransition(0))
        {
            anim.speed = 0; // freezes it on the last frame
        }
    }
}

