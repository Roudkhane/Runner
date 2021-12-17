using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    [SerializeField] private GameObject[] bg;
    [SerializeField] private float LastposY;
    void Start()
    {
        bg = GameObject.FindGameObjectsWithTag("bg");

        LastposY = bg[0].transform.position.y;

        for (int i = 0; i < bg.Length; i++)
        {
            if (bg[i].transform.position.y>LastposY)
            {
                LastposY = bg[i].transform.position.y;
            }
        }

    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bg"))
        {
            Vector3 temp = collision.transform.position;
            float height = ((BoxCollider2D)collision).size.y;
            temp.y = height + LastposY;
            collision.transform.position = temp;
            LastposY = temp.y;

        }
    }
  
}
