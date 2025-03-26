using UnityEngine;


public enum AnimationType
{
    Idle,
    Run,
    Jump,
    Fall
}

public class AnimationController : MonoBehaviour
{
    private Animator anim;



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Run:
                Play("Run");
                break;
            case AnimationType.Jump:
                Play("Jump");
                break;
            case AnimationType.Fall:
                Play("Fall");
                break;
            default:
                print("No Animation found");
                break;
        }
    }

    private void Play(string name)
    {
        anim.Play(name, -1, 0f);
    }
}

