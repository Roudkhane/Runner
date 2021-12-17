using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TirController : MonoBehaviour
{
    [SerializeField] private Tire prfb_PoolTire;
    [SerializeField] private Tire prfb_PoolTwoTire;

    [SerializeField] private Transform trfPlayer;
    [SerializeField] private Vector3 offsetOne;
    [SerializeField] private Vector3 offsetTwo;

    [SerializeField] private int size=50;
    [SerializeField] private int sizeTwoPool=20;

    [SerializeField] private List<Tire> lisOneTire;
    [SerializeField] private List<Tire> lisTwoTire;

    [SerializeField]private float time = 0;
    public static bool isclick=true;
    public static bool boolTwoTire = false;

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
           var t= Instantiate(prfb_PoolTire, transform);
            lisOneTire.Add(t);
            t.gameObject.SetActive(false);
        }

        for (int i = 0; i <sizeTwoPool; i++)
        {
            var t = Instantiate(prfb_PoolTwoTire, transform);
            lisTwoTire.Add(t);
            t.gameObject.SetActive(false);
        }
    }

    public GameObject GetPool()
    {
        if (!boolTwoTire)
        {
            for (int i = 0; i < lisOneTire.Count; i++)
            {
                if (!lisOneTire[i].gameObject.activeInHierarchy)
                {
                    lisOneTire[i].gameObject.transform.position = trfPlayer.position + offsetOne;
                    return lisOneTire[i].gameObject;
                }
             }
        }
        else
        {
            for (int i = 0; i < lisTwoTire.Count; i++)
            {
                if (!lisTwoTire[i].gameObject.activeInHierarchy)
                {
                    lisTwoTire[i].gameObject.transform.position = trfPlayer.position + offsetTwo;
                    return lisTwoTire[i].gameObject;
                }
            }
        }
            
        return null;
    }


    public void Shoot()
    {
        var tir = GetPool();
        if (tir != null)
            tir.SetActive(true);
    }

    public void BtnShelick()
    {
        if (!isclick)
            return;
        Shoot();
    }

    private void Update()
    {
        if (boolTwoTire)
        {
            if (time < 5)
                time += Time.deltaTime;
            if (time > 5)
            {
                boolTwoTire = false;
                time = 0;
            }

        }
    }
}
