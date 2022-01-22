using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float pickupRange = 10;
    public Transform player;

    public void update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange) { pickup(); }
    }

    public void pickup()
    {
        GameObject.Destroy(gameObject);
        print("Got Object; Object Destoryed");

    }
}
