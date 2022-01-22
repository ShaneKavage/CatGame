using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SCE_GridManager : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    private const int _GridWidth = 3;
    [SerializeField]
    private const int _GridHeight = 4;

    [SerializeField]
    private const int _SubGridSize = 20;
    [SerializeField]
    private const int _SingleCellSize = 5;

    [SerializeField]
    private int _MaxPositionX;
    [SerializeField]
    private int _MaxPositionZ;

    [SerializeField]
    private int _CurrentGridX;
    [SerializeField]
    private int _CurrentGridZ;

    [SerializeField]
    private int _CurrentSubGridX;
    [SerializeField]
    private int _CurrentSubGridZ;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _MaxPositionX = _GridWidth * _SubGridSize * _SingleCellSize;
        _MaxPositionZ = _GridHeight * _SubGridSize * _SingleCellSize;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCurrentLocation();
    }

    private void CalculateCurrentLocation()
    {
        _CurrentSubGridX = (int)Mathf.Ceil(player.transform.position.x / _SingleCellSize);
        _CurrentSubGridZ = (int)Mathf.Ceil(player.transform.position.z / _SingleCellSize);

        _CurrentGridX = (int)Mathf.Ceil(_CurrentSubGridX / _SubGridSize);
        _CurrentGridZ = (int)Mathf.Ceil(_CurrentSubGridZ / _SubGridSize);

        CheckWrapAround();
    }
    private void CheckWrapAround()
    {
        if (player.transform.position.x > _MaxPositionX)
        {
            Vector3 newPosition = new Vector3(0,
                                              player.transform.position.y,
                                              player.transform.position.z);

            player.transform.SetPositionAndRotation(newPosition,
                                                    player.transform.rotation);
        }
        if (player.transform.position.x < 0)
        {
            Vector3 newPosition = new Vector3(_MaxPositionX, 
                                              player.transform.position.y, 
                                              player.transform.position.z);

            player.transform.SetPositionAndRotation(newPosition, 
                                                    player.transform.rotation);
        }

        if (player.transform.position.z > _MaxPositionZ)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x,
                                              player.transform.position.y,
                                              0);

            player.transform.SetPositionAndRotation(newPosition,
                                                    player.transform.rotation);
        }
        if (player.transform.position.z < 0)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x, 
                                              player.transform.position.y, 
                                              _MaxPositionZ);

            player.transform.SetPositionAndRotation(newPosition,
                                                    player.transform.rotation);
        }
    }
}
