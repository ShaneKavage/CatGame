using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_ITM_RereadMessage : MonoBehaviour
{
    // Start is called before the first frame update

    private float _PickupRange = 4;
    private Transform _Player;
    private TextMeshProUGUI _TMP;
    private HUD _HUD;
    private GameObject _Pan;

    public Transform Player { get => _Player; set => _Player = value; }
    public TextMeshProUGUI TMP { get => _TMP; set => _TMP = value; }
    public HUD HUD { get => _HUD; set => _HUD = value; }

    public void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        _TMP = GameObject.FindGameObjectWithTag("ItemTextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        _HUD = GameObject.FindGameObjectWithTag("UI").GetComponent<HUD>();
        _Pan = GameObject.FindGameObjectWithTag("FadeInOutPanel");

    }

    public void Update()
    {
        if(_Pan.GetComponent<Image>().color.a > 0)
        {
            _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 0);
            return;
        }

        Vector3 distanceToPlayer = _Player.position - transform.position;
        if (distanceToPlayer.magnitude > _PickupRange)
        {
            _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 0);
            return;
        }
        if (distanceToPlayer.magnitude <= _PickupRange)
        {
            _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 1);
        }
        if (distanceToPlayer.magnitude <= _PickupRange && Input.GetKeyDown(KeyCode.E))
        {
            Reread(); 
        }
    }

    public void Reread()
    {
        _TMP.color = new Color(_TMP.color.r, _TMP.color.g, _TMP.color.b, 0);
        GameObject pan = GameObject.FindGameObjectWithTag("FadeInOutPanel");
        pan.GetComponent<SC_HUD_BlackPanel>().ShowMessage(GetComponent< SC_ITM_MessageContainer >().MessageText);
    }
}
