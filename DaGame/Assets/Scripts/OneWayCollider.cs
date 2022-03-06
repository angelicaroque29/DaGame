using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollider : MonoBehaviour
{
    private BoxCollider collider;
    private bool oneWay;
    // Start is called before the first frame update
    void Start()
    {
        collider.enabled = false;
        oneWay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (oneWay.Equals(true)) {
            collider.enabled = true;
            collider.isTrigger = false;
        }  
        else{
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            oneWay = false;
            Debug.Log(oneWay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            oneWay = true;
            Debug.Log(oneWay);
        }
    }
}
