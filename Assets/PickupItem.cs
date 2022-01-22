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
    public HUD hud;

    public void Start()
    {
        hud = GameObject.FindGameObjectWithTag("UI").GetComponent<HUD>();
    }

    public void Update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E)) { pickup(); }
    }

    public void pickup()
    {
       hud.GainCollectible();
       UIObject.SetActive(false);
       print("Got Object; Object Destoryed");
       Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIObject.SetActive(false);
        }
    }
}
