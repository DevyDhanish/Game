using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction, float speed)
    {
        characterController.Move(direction * speed * Time.deltaTime);
    }
}
