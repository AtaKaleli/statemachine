using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementVector { get; set; }

    public event Action<Vector2> OnMovement;
    public event Action OnAttack, OnJumpPressed, OnJumpReleased;

    public KeyCode jumpKey, attackKey;



    private void Update()
    {
        if (Time.timeScale > 0.01f)
        {
            CallOnMovement();
            CallOnAttack();
            CallOnJump();
        }
    }

    private void CallOnAttack()
    {
        if (Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }

    private void CallOnMovement()
    {
        MovementVector = GetPlayerMovementInput();
        OnMovement?.Invoke(MovementVector);
    }

    private Vector2 GetPlayerMovementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }



    private void CallOnJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            OnJumpPressed?.Invoke();
        }
        if (Input.GetKeyUp(jumpKey))
        {
            OnJumpReleased?.Invoke();
        }
    }





}
