using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SCE_MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MainScreenMusic").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyME()
    {
        GetComponent<AudioSource>().Stop();
        //Destroy(this);
    }

}
