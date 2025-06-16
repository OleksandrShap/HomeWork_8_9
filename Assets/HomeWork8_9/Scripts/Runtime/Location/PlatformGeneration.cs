using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private Transform _platFormParent;

    [SerializeField] private int _initialPlatform = 15;
    [SerializeField] private float _distanceBetweenPlatform = 20f;
    
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _screenLeftX;
    [SerializeField] private float _screenRightX;

    private Queue<GameObject> _platforms = new Queue<GameObject>();

    private float _highestY = -4f;

    private void Start()
    {
        GenerateInitPlatform();
    }

    private void Update()
    {
        if(_playerTransform.position.y +10f > _highestY)
        {
            GeneratePlatformRow();
            ClenupPlatformRow();
        }
    }


    private void GenerateInitPlatform()
    {
        for(int i = 0; i<_initialPlatform; i++ )
        {
            GeneratePlatformRow();
        }
    }
   

    private void GeneratePlatformRow()
    {
        float x = Random.Range( _screenLeftX, _screenRightX );
        Vector3 position  = new Vector3( x, _highestY, 0f );

        var platform = Instantiate(_platformPrefab, position, Quaternion.identity, _platFormParent);
        _platforms.Enqueue( platform );

        _highestY += _distanceBetweenPlatform;
    }

    private void ClenupPlatformRow()
    {
        if(_platforms.Count > 0)
        {
            GameObject element = _platforms.Dequeue();
            Destroy( element );
        }
    }
}
