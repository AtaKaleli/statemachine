using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeAgent(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnMovement += HandleMovement;

        OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnMovement -= HandleMovement;

        OnExit?.Invoke();
        ExitState();
    }



    protected virtual void EnterState()
    {

    }

    protected virtual void ExitState()
    {

    }

    protected virtual void HandleMovement(Vector2 input)
    {
        agent.flipController.Flip(input);
    }

    protected virtual void HandleJumpReleased()
    {

    }

    protected virtual void HandleJumpPressed()
    {

    }

    protected virtual void HandleAttack()
    {

    }
    public virtual void StateUpdate()
    {

    }
    public virtual void StateFixedUpdate()
    {

    }


}
