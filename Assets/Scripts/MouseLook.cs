using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes { 
        XY = 0,
        X = 1,
        Y = 2
    };

    public RotationAxes rotationAxis = RotationAxes.XY;

    public float horizontalSensivity = 3.0f;
    public float verticalSensivity = 3.0f;

    public float minVerticalRotation = -45.0f;
    public float maxVerticalRotation = 45.0f;

    private float _rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationX;

        switch(rotationAxis) {
            case RotationAxes.X:
                float delta = Input.GetAxis("Mouse X") * horizontalSensivity;
                rotationX = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(0, rotationX, 0);
                break;

            case RotationAxes.Y:

                _rotationY -= Input.GetAxis("Mouse Y") * verticalSensivity;
                _rotationY = Mathf.Clamp(
                    _rotationY, 
                    minVerticalRotation, 
                    maxVerticalRotation
                );

                rotationX = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationY, rotationX, 0);
                break;
        }
    }
}
