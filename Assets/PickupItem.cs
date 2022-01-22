using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float pickupRange = 360;
    public Transform player;

    public void Update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E)) { pickup(); }
    }

    public void pickup()
    {
        GameObject.Destroy(gameObject);
        print("Got Object; Object Destoryed");

    }
}
