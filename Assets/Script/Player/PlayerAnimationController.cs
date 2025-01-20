using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();


    }
    private void Start()
    {
        PlayerController.Instance.PlayerAnimator += AnimationPerformed;
    }
    private void OnDisable()
    {
        PlayerController.Instance.PlayerAnimator -= AnimationPerformed;
    }
    private void AnimationPerformed(object sender, string e)
    {
        animator.SetBool(e, true);
    }
}


