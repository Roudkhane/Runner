using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airplane : MonoBehaviour
{
   
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbody;


    void Update() => rigidbody.velocity = new Vector2(0, 1) * speed;

    public void MoveHorizental(int x)=> gameObject.transform.position += new Vector3(x*Time.deltaTime*160, 1* Time.deltaTime * speed, 0);
     
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enmy"))
        {
            gameObject.SetActive(false);
            UIManager.Instance.GameOver();
        }

        if (collision.CompareTag("Fuel"))
        {
            UIManager.Instance.AddFuel(5);
            TirController.boolTwoTire = true;
          
        }


    }
}