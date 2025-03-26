using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rb;



    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.OnMovement += HandleMovement;
    }


    private void HandleMovement(Vector2 input)
    {
        if(Mathf.Abs(input.x) > 0)
        {
            rb.velocity = new Vector2(input.x * 5f, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
