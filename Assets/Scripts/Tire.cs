using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    [SerializeField] private float speed;
 

    private void OnEnable()
    {
        
        StartCoroutine(nameof(TimeDeactive));
    }

    IEnumerator TimeDeactive()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
  
    }

    void Update()
    {
        transform.Translate(Vector2.up*Time.deltaTime*speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enmy"))
        {
           // Debug.Log("T");
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            UIManager.Instance.AddScore(1);
        }


    }


}
