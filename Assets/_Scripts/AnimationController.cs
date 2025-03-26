using UnityEngine;


public enum AnimationType
{
    Idle,
    Run
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
                Play("Player_Idle");
                break;
            case AnimationType.Run:
                Play("Player_Run");
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

