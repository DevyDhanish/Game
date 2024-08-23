using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerState
{
    public override void OnEnter(PlayerController controller)
    {
        
    }
    public override void OnUpdate(PlayerController controller)
    {
        controller.movement.Move(-controller.transform.up, controller.fallSpeed);
    }
    public override void OnExit(PlayerController controller) { }

    public override string getStateName()
    {
        return "Falling";
    }
}
