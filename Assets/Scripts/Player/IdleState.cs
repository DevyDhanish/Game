using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void OnEnter(PlayerController controller) 
    {
        controller.animController.switchAnimation("MovementAnimation", AnimationController.animations.Idle);
    }
    public override void OnUpdate(PlayerController controller) { }
    public override void OnExit(PlayerController controller) { }
}
