using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    private Vector3 offsetVector;
    private Vector3 rotOffsetVector;

    private Vector3 originalVector;
    private Vector3 originalRotVector;

    private void Start()
    {
        originalVector = transform.localPosition;
        originalRotVector = transform.localRotation.eulerAngles;
    }
    
    public void headBob(float speed, float strength, float smoothness)
    {
        float val = Mathf.Sin(Time.time * speed) * strength;

        offsetVector = originalVector;

        offsetVector.y += val;

        transform.localPosition = Vector3.Lerp(transform.localPosition, offsetVector, smoothness);
    }

    public void headBobRot(float speed, float strength, float smoothness)
    {
        float val = Mathf.Sin(Time.time * speed) * strength;

        rotOffsetVector = originalRotVector;

        rotOffsetVector.z += val;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotOffsetVector), smoothness);
    }
}
