using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : PlayerState
{
    public override void OnEnter(PlayerController controller) 
    {
        controller.animController.switchAnimation("MovementAnimation", AnimationController.animations.Run);
    }
    public override void OnUpdate(PlayerController controller) 
    {
        Vector3 moveDir = controller.head.transform.forward * controller.inputs.movementVector.y + controller.head.transform.right * controller.inputs.movementVector.x;

        controller.movement.Move(moveDir, controller.runSpeed);

        controller.head.GetComponent<HeadBob>().headBob(controller.headBobRunSpeed, controller.headBobStrength, controller.headBobSmoothness);
        controller.head.GetComponent<HeadBob>().headBobRot(controller.headRotBobRunSpeed, controller.headRotBobStrength, controller.headRotBobSmoothness);
    }
    public override void OnExit(PlayerController controller) { }
}
