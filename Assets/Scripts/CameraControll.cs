using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

   
    private void Update()
    {
        Vector3 temptrf = transform.position;
        temptrf.y = offset.y + player.position.y;
        transform.position = temptrf;
    }
}
