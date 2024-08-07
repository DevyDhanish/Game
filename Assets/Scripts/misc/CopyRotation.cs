using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public Transform target;

    public bool X;
    public bool Y;
    public bool Z;

    private Vector3 rotationVector;
    private void Update()
    {
        rotationVector.x = X ? target.rotation.eulerAngles.x : transform.rotation.eulerAngles.x;
        rotationVector.y = Y ? target.rotation.eulerAngles.y : transform.rotation.eulerAngles.y;
        rotationVector.z = Z ? target.rotation.eulerAngles.z : transform.rotation.eulerAngles.z;

        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
