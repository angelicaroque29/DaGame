/*
 * For use on Storekeeper in China Shoppe Level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaShop_Storekeeper : MonoBehaviour
{
    // Variables //
    public Transform pos1;
    public Transform pos2;
    GameObject player;
    Transform target;
    private Vector3 posA;
    private Vector3 posB;
    public float speed = 1.0f;
    public GameObject hidingPlace;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        posA = new Vector3(pos1.position.x, pos1.position.y, pos1.position.z);
        posB = new Vector3(pos2.position.x, pos2.position.y, pos2.position.z);

        target = pos1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(hidingPlace.transform.position, player.transform.position) < 7.0f)
        {
            GetComponent<Animation>().Play("WalkingTy");

            Vector3 currPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (currPosition.Equals(posA))
            {
                target = pos2;
            }
        }
        
    }
}
