using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    public int fallSpeed; // 10
    public int spinSpeed; // 250
    private bool smashed;
    private bool broken;
    public AudioSource audioData;

    // set to true for one vase,
    // place slingshot object on floor where vase will fall
    public bool foundSlingshot; 
    public GameObject slingshot;

    void Start()
    {
        smashed = false;
        broken = false;
        audioData = GetComponent<AudioSource>();
        slingshot = GameObject.Find("Slingshot");
        slingshot.SetActive(false);
    }

    void Update()
    {
        if((smashed == true) && (broken == false))
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);   
        }
        if (broken == true)
        {
            // if slingshot in vase
            if (foundSlingshot == true)
            {
                slingshot.SetActive(true);
            }
            audioData.Play(0);
            gameObject.SetActive(false);   
        }
    }

    public void collided()
    {
        if (smashed == false)
        {
            transform.Translate(5, 0, 0);
            smashed = true;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            broken = true;
        }
    }

}
