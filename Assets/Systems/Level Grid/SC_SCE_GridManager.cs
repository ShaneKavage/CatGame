using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SCE_GridManager : MonoBehaviour
{

    private GameObject _Player;

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
    private int _StartingGridX = 1;
    [SerializeField]
    private int _StartingGridZ = 2;
    [SerializeField]
    private int _StartingSubGridX;
    [SerializeField]
    private int _StartingSubGridZ;

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
        _Player = GameObject.FindGameObjectWithTag("Player");

        _MaxPositionX = _GridWidth * _SubGridSize * _SingleCellSize;
        _MaxPositionZ = _GridHeight * _SubGridSize * _SingleCellSize;

        _StartingSubGridX = Random.Range(0, _SubGridSize);
        _StartingSubGridZ = Random.Range(0, _SubGridSize);

        SetPlayerStartPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateCurrentLocation();
    }

    private void CalculateCurrentLocation()
    {
        _CurrentSubGridX = (int)Mathf.Ceil(_Player.transform.position.x / _SingleCellSize);
        _CurrentSubGridZ = (int)Mathf.Ceil(_Player.transform.position.z / _SingleCellSize);

        _CurrentGridX = (int)Mathf.Ceil(_CurrentSubGridX / _SubGridSize);
        _CurrentGridZ = (int)Mathf.Ceil(_CurrentSubGridZ / _SubGridSize);

        CheckWrapAround();
    }
    private void CheckWrapAround()
    {
        if (_Player.transform.position.x > _MaxPositionX)
        {
            _Player.transform.position = new Vector3(0,
                                                     _Player.transform.position.y,
                                                     _Player.transform.position.z);
        }
        if (_Player.transform.position.x < 0)
        {
            _Player.transform.position = new Vector3(_MaxPositionX,
                                                     _Player.transform.position.y,
                                                     _Player.transform.position.z);
        }

        if (_Player.transform.position.z > _MaxPositionZ)
        {
            _Player.transform.position = new Vector3(_Player.transform.position.x,
                                                     _Player.transform.position.y,
                                                     0);
        }
        if (_Player.transform.position.z < 0)
        {
            _Player.transform.position = new Vector3(_Player.transform.position.x,
                                                     _Player.transform.position.y,
                                                     _MaxPositionZ);
        }
    }
    private void SetPlayerStartPosition()
    {
        float startingPosX = ((_StartingGridX * _SubGridSize) + _StartingSubGridX) * _SingleCellSize;
        float startingPosZ = ((_StartingGridZ * _SubGridSize) + _StartingSubGridZ) * _SingleCellSize;

        Vector3 startingPosition = new Vector3(startingPosX,
                                               _Player.transform.position.y + 1, 
                                               startingPosZ);

        _Player.transform.SetPositionAndRotation(startingPosition,
                                                 Random.rotation);
    }
}
