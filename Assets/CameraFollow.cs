using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamerFollow : MonoBehaviour
{
    [SerializeField] private Transform _catTransform;
    [SerializeField] private float hight;
    [SerializeField] private float distance;
    [SerializeField] private float _cameraSpeed;
    Vector3 cameraPosition;
    private void Update()
    {
        cameraPosition.x = _catTransform.position.x;
        cameraPosition.y = _catTransform.position.y + hight;
        cameraPosition.z = _catTransform.position.z - distance;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * _cameraSpeed);
    }
}
