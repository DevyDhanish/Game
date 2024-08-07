using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public enum animations
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
    }

    [SerializeField] private Animator animator;
    [SerializeField] private float animationSwitchSmoothness;
    private int index;
    private string parameter = "";
    private float threshHold;

    /// <summary>
    /// switches to another animation.
    /// </summary>
    /// <param name="parameterName">name of the parameter</param>
    /// <param name="anim">id of the animation see `AnimationController.animations` for all the possible animations</param>
    public void switchAnimation(string parameterName, animations anim)
    {
        parameter = parameterName;
        index = (int) anim;
    }

    private void Start()
    {
        index = 0;
        threshHold = 0;
    }

    private void Update()
    {
        threshHold = Mathf.SmoothStep(threshHold, index, animationSwitchSmoothness);
        if(parameter != "") animator.SetFloat(parameter, threshHold);
    }
}
