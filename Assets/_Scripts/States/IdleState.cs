using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.Idle);
    }

    protected override void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0.01f)
        {
            agent.ChangeState(MoveState);
        }
    }
}
