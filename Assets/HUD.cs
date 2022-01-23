using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public int collectionNum;
    [SerializeField] private Image[] colImage;
    public Sprite hasCol;
    public Sprite notHasCol;

    public void Start()
    {
        collectionNum = 0;
    }

    public void GainCollectible() //always adds one
    {
        colImage[collectionNum].GetComponent<Image>().sprite = hasCol;
        collectionNum++;
        GetComponent<AudioSource>().Play();
    }

    public void ResetCollectables()
    {
        for (int i = 0; i >= 0; i++)
        {
            colImage[i].GetComponent<Image>().sprite = notHasCol;
            collectionNum = 0;
        }
    
    }
}
