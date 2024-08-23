using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    public override void OnEnter(PlayerController controller) 
    {
        controller.animController.switchAnimation("MovementAnimation", AnimationController.animations.Walk);
    }

    public override void OnUpdate(PlayerController controller) 
    {
        Vector3 moveDir = controller.head.transform.forward * controller.inputs.movementVector.y + controller.head.transform.right * controller.inputs.movementVector.x;

        controller.movement.Move(moveDir, controller.walkSpeed);

        controller.head.GetComponent<HeadBob>().headBob(controller.headBobWalkSpeed, controller.headBobStrength, controller.headBobSmoothness);
        controller.head.GetComponent<HeadBob>().headBobRot(controller.headRotBobWalkSpeed, controller.headRotBobStrength, controller.headRotBobSmoothness);
    
        if(controller.inputs.pressedSprint && controller.isGrounded)
        {
            controller.state.switchState(controller.runningState);
        }
        
        if(!controller.isMoving) controller.state.switchState(controller.idleState);
    }
    
    public override void OnExit(PlayerController controller) { }

    public override string getStateName()
    {
        return "Walking";
    }
}
