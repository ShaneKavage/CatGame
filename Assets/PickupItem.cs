using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float pickupRange = 2.5f;
    public Transform player;
    private TextMeshProUGUI _TMP;
    public HUD hud;

    public void Start()
    {
        hud = GameObject.FindGameObjectWithTag("UI").GetComponent<HUD>();
        _TMP = GameObject.FindGameObjectWithTag("ItemTextCanvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Update()
    {
        //Check if player is within range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude > pickupRange)
        {
            _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 0);
            return; 
        }
        if (distanceToPlayer.magnitude <= pickupRange) 
        {
            _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 1);
        }
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E)) { pickup(); }
    }

    public void pickup()
    {
       hud.GainCollectible();
       _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 0);
       GetComponent<SC_ITM_SpawnScroll>().SpawnScroll();
       print("Got Object; Object Destoryed");
       Destroy(gameObject);
    }
}
