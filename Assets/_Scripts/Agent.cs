using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [HideInInspector] public PlayerInput agentInput;
    [HideInInspector] public Rigidbody2D agentRb;
    [HideInInspector] public AnimationController agentAnimation;
    [HideInInspector] public FlipController flipController;
    private GroundDetector groundDetector;

    public State currentState = null;
    public State IdleState;
    

    private void Awake()
    {
        agentInput = GetComponentInParent<PlayerInput>();
        agentRb = GetComponent<Rigidbody2D>();
        agentAnimation = GetComponentInChildren<AnimationController>();
        flipController = GetComponentInChildren<FlipController>();
        groundDetector = GetComponentInChildren<GroundDetector>();
    }

    private void Start()
    {
        InitializeAgentToStates();
        ChangeState(IdleState); // set the initial state to IdleState
    }

    private void InitializeAgentToStates()
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeAgent(this);
        }
    }

    private void Update()
    {
        //currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        //currentState.StateFixedUpdate();
    }

    
    public void ChangeState(State newState)
    {
        if (newState == null)
            return;

        if(currentState != null)
            currentState.Exit();
        
        currentState = newState;
        currentState.Enter();
    }



}
