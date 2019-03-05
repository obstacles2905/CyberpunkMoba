using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target; //ссылка на объект, вокруг которого производится облёт

    public float rotationSpeed = 1.5f;

    private float _rotationY;
    private Vector3 _offset;

    void Start()
    {
        _rotationY = transform.eulerAngles.y;
        _offset = target.position - transform.position; //сохранение начального смещения между камерой и целью 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0) { //медленный поворот камеры при помощи клавиш со стрелками
            _rotationY += horizontalInput * rotationSpeed;
        }
        else
        {
            _rotationY += Input.GetAxis("Mouse X") * rotationSpeed * 3; //или быстрый поворот с помощью с мыши
        }

        Quaternion rotation = Quaternion.Euler(0, _rotationY, 0);
        transform.position = target.position - (rotation * _offset); //поддерживаем начальное смещение, сдвигаемое в соотв. с поворотом камеры
        transform.LookAt(target); //камера всегда направлена на цель, где бы относительно этой цели она ни располагалась
    }
} 
