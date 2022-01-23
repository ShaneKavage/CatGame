using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_ITM_SpawnScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject _Message;

    [SerializeField]
    private string _MessageText;

    public void SpawnScroll()
    {
        GameObject messageInstant = Instantiate(_Message);
        messageInstant.transform.position = transform.position;

        messageInstant.GetComponent<SC_ITM_MessageContainer>().MessageText = _MessageText;

        messageInstant.GetComponent<SC_ITM_MessageContainer>().ShowMessage();
    }
}
