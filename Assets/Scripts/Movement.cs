using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Keyboard Movement")]
public class Movement : MonoBehaviour
{
    private CharacterController _player;

    public float movementSpeed = 5.0f;
    public float gravity = -9.8f;
    private string HORIZONAL_AXIS = "Horizontal";
    private string VERTICAL_AXIS = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis(HORIZONAL_AXIS) * movementSpeed;
        float deltaZ = Input.GetAxis(VERTICAL_AXIS) * movementSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, movementSpeed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _player.Move(movement);
    }
}
