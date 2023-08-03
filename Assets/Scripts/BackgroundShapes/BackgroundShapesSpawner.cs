using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShapesSpawner : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Camera _camera;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _backgroundShapePrefab;


    [Header("====Debugs====")]
    [SerializeField] float _currentTimeToSpawn;


    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _timeToSpawn;


    private void Awake()
    {
        _currentTimeToSpawn = _timeToSpawn;
    }


    private void Update()
    {
        PositionSpawnPoint();

        SpawnerTimer();
    }



    private void PositionSpawnPoint()
    {
        float cameraHeight = _camera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * _camera.aspect;

        _spawnPoint.position = new Vector3(cameraWidth + 0.5f, cameraHeight/2, 0);
    }

    private void SpawnerTimer()
    {
        _currentTimeToSpawn -= 50 * Time.deltaTime;
        _currentTimeToSpawn = Mathf.Clamp(_currentTimeToSpawn, 0, _timeToSpawn);

        if (_currentTimeToSpawn > 0) return;

        SpawnShape();
        _currentTimeToSpawn = _timeToSpawn;
    }


    private void SpawnShape()
    {
        float spawnHeight = Random.Range(-_camera.orthographicSize, _camera.orthographicSize);

        Vector3 spawnPosition = new Vector3(_spawnPoint.position.x, spawnHeight, 0);
        float spawnRotationZ = Random.Range(-180, 180);
        Instantiate(_backgroundShapePrefab, spawnPosition, Quaternion.Euler(0, 0, spawnRotationZ), transform);
    }
}
