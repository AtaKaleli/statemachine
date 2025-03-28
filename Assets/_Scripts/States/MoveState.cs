using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveState : State
{
    public State IdleState;


    private float horizontalMovementDirection;
    private float currentSpeed;
    private Vector2 currentVelocity;

    [SerializeField] private float acceleration, deacceleration, maxSpeed;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.Run);
    }


    
    protected override void HandleMovement(Vector2 input)
    {
        base.HandleMovement(input); // for the purpose of face direction
        
        CalculateVelocity(input);
        SetVelocity();

        if (Mathf.Abs(agent.agentRb.velocity.x) < 0.01f)
        {
            agent.ChangeState(IdleState);
        }
    }


    private void CalculateVelocity(Vector2 input)
    {
        CalculateSpeed(input);
        CalculateHorizontalDirection(input);

        currentVelocity = new Vector2(horizontalMovementDirection * currentSpeed, agent.agentRb.velocity.y);
    }

    private void CalculateHorizontalDirection(Vector2 input)
    {
        if(Mathf.Abs(input.x) > 0)
        {
            horizontalMovementDirection = input.x;
        }
    }

    private void CalculateSpeed(Vector2 input)
    {
        if(Mathf.Abs(input.x) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void SetVelocity()
    {
        agent.agentRb.velocity = currentVelocity;
    }

    private void ClearMovementData()
    {
        horizontalMovementDirection = 0;
        currentVelocity = Vector2.zero;
        currentSpeed = 0;
    }

    protected override void ExitState()
    {
        ClearMovementData();
    }




}
