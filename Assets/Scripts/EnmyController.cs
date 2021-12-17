using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnmyController : MonoBehaviour
{
    [SerializeField] private List<Sprite> enmy;
    [SerializeField] private List<SpriteRenderer> trfEnmy;
    [SerializeField] private GameObject Fuel;
    [SerializeField] private int random;

    private void Start()=> CreatRandomEnmy();
   
    public void CreatRandomEnmy()
    {
        trfEnmy.ForEach(i => i.gameObject.SetActive(true));
        random = Random.Range(0, 3);
        Fuel.SetActive(random>1?true:false);

        int i = 0;
        trfEnmy.OrderBy(i => Random.Range(0, 1000)).ToList()
            .ForEach(j =>
            {
                j.sprite = enmy[i];
                i = (int)Mathf.Repeat(i, enmy.Count);
                i++;
            });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("airPlane"))
        {
            CreatRandomEnmy();
        }
    }
}
