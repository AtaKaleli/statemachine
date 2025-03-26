using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private AnimationController anim;
    private FlipController flipController;


    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationController>();
        flipController = GetComponentInChildren<FlipController>();
    }

    private void OnEnable()
    {
        playerInput.OnMovement += HandleMovement;
        playerInput.OnMovement += flipController.Flip;
        
    }


    private void HandleMovement(Vector2 input)
    {


        if (Mathf.Abs(input.x) > 0)
        {
            if(Mathf.Abs(rb.velocity.x) < 0.01f)
            {
                anim.PlayAnimation(AnimationType.Run);
            }

            rb.velocity = new Vector2(input.x * 5f, rb.velocity.y);
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) > 0.01f)
            {
                anim.PlayAnimation(AnimationType.Idle);
            }

            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        
        
    }
}
