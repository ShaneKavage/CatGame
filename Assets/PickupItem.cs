using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float pickupRange = 360;
    public Transform player;
    public GameObject UIObject;

    public void Update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude > pickupRange) { UIObject.SetActive(false); return; }
        if (distanceToPlayer.magnitude <= pickupRange) { UIObject.SetActive(true); }
            if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E)) { pickup(); }
    }

    public void pickup()
    {
        GameObject.Destroy(gameObject);
        UIObject.SetActive(false);
        print("Got Object; Object Destoryed");

    }

    void EnterPickupRange(Collider other)
    {
        if (other.tag == "Player")
        {
            UIObject.SetActive(true);
        }
    }
}
