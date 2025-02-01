
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
        PlayerController.Instance.PlayerAnimatorPerformAnimation += AnimationPerformed;
        PlayerController.Instance.PlayerAnimatorStopAnimation += IdleAnimation;
    }
    private void OnDisable()
    {
        PlayerController.Instance.PlayerAnimatorPerformAnimation -= AnimationPerformed;
        PlayerController.Instance.PlayerAnimatorStopAnimation -= IdleAnimation;
    }
    private void AnimationPerformed(object sender, string e)
    {
        animator.SetBool(e, true);
    }
    private void IdleAnimation(object sender, string e)
    {
        animator.SetBool(e, false);
    }

    public void PerformAnimation(string e, bool b)
    {
        animator.SetBool(e, b);
    }


}


