using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float pickupRange = 2.5f;
    public Transform player;
    public GameObject UIObject;
    public HUD hud;

    public void Start()
    {

        hud = GameObject.FindGameObjectWithTag("UI").GetComponent<HUD>();
    }

    public void Update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude > pickupRange)
        {
            UIObject.SetActive(false); 
            return; 
        }
        if (distanceToPlayer.magnitude <= pickupRange) 
        { 
            UIObject.SetActive(true); 
        }
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E)) { pickup(); }
    }

    public void pickup()
    {
       hud.GainCollectible();
       UIObject.SetActive(false);
       print("Got Object; Object Destoryed");
       Destroy(gameObject);

    }
}
