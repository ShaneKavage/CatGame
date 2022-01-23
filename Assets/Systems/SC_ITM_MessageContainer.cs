using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ITM_MessageContainer : MonoBehaviour
{

    [SerializeField]
    private string _MessageText;
    public string MessageText { get => _MessageText; set => _MessageText = value; }
    [SerializeField]
    private GameObject _MessageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMessage()
    {
        GameObject pan = GameObject.FindGameObjectWithTag("FadeInOutPanel");
        pan.GetComponent<SC_HUD_BlackPanel>().ShowMessage(_MessageText);
   }

    public void OnTriggerExit(Collider other)
    {
        GameObject pan = GameObject.FindGameObjectWithTag("FadeInOutPanel");
        pan.GetComponent<SC_HUD_BlackPanel>().HideMessage();
    }
}
