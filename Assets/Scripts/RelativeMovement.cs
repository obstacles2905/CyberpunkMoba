using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0) {
            movement.x = horizontalInput;
            movement.z = verticalInput;

            Quaternion startRotation = target.rotation; //сохраняем начальную ориентацию, 
            //чтобы вернуться к ней после завершения работы с объектом

            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = startRotation;

            transform.rotation = Quaternion.LookRotation(movement); //вычисляет кватернион, смотрящий в этом направлении
        }
    }
}
