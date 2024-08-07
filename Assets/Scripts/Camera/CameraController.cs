using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour, IInputRecieve
{
    [SerializeField] private float sens;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private Transform target;

    private Vector3 mouseMovement;

    private Vector3 rotationVector;

    void Start()
    {
        rotationVector = transform.rotation.eulerAngles;
        mouseMovement = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        rotationVector.x -= mouseMovement.y;
        rotationVector.y += mouseMovement.x;

        rotationVector.x = Mathf.Clamp(rotationVector.x, minX, maxX);

        Quaternion cameraRotation = Quaternion.Euler(rotationVector);

        transform.rotation = cameraRotation;

        stayAtPosition(target.position);
    }
    public void handleInput(InputStruct inputs)
    {
        mouseMovement.x = inputs.mouseAxisVector.x;
        mouseMovement.y = inputs.mouseAxisVector.y;
        mouseMovement.z = 0;

        mouseMovement = mouseMovement * sens * Time.deltaTime;
    }

    private void stayAtPosition(Vector3 position)
    {
        transform.position = position;
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
