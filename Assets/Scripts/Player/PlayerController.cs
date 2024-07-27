using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInputRecieve
{
    [Header("Movement settings")]
    public float walkSpeed;
    public float runSpeed;
    public float fallSpeed;

    [Header("Headbobing settings")]
    public float headBobStrength;
    public float headBobWalkSpeed;
    public float headBobRunSpeed;
    public float headBobSmoothness;

    [Header("Headbobing rotation settings")]
    public float headRotBobStrength;
    public float headRotBobWalkSpeed;
    public float headRotBobRunSpeed;
    public float headRotBobSmoothness;

    [Header("Ground Check settings")]
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask standable;
    public Transform groundCheck;

    public bool isMoving { get; private set; }
    public AnimationController animController { get; private set; }
    public Transform head {  get; private set; }
    public InputStruct inputs { get; private set; }
    public Movement movement  { get; private set; }

    private PlayerState state;
    private IdleState idleState = new IdleState();
    private WalkState walkState = new WalkState();
    private RunningState runningState = new RunningState();
    private FallState fallState = new FallState();
    
    public void handleInput(InputStruct playerInputs)
    {
        //Debug.Log(inputs.mouseAxisVector);
        inputs = playerInputs;
    }

    private void Start()
    {
        state = new PlayerState();
        animController = gameObject.GetComponent<AnimationController>();
        head = transform.GetChild(0).transform; // the head
        movement = GetComponent<Movement>();
        state.initState(idleState, this);
    }

    private void Update()
    {
        isMoving = inputs.movementVector != Vector2.zero;
        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, standable).Length > 0;
        //Debug.Log(isGrounded);
        // idle
        if(!isMoving && state.getState() != idleState && isGrounded)
        {
            state.switchState(idleState);
        }
        // walk
        if(isMoving && state.getState() != walkState && isGrounded)
        {
            state.switchState(walkState);
        }
        // running
        if(isMoving && inputs.pressedSprint && state.getState() != runningState && isGrounded)
        {
            state.switchState(runningState);
        }
        //falling
        if(!isGrounded)
        {
            state.switchState(fallState);
        }

        state.getState().OnUpdate(this);
    }

    public void handleInteract(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleDrop(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleInventory(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleUtility(bool status)
    {
        throw new System.NotImplementedException();
    }
}
