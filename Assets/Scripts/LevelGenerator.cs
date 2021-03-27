using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch.Generator
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstaclesType;
        [SerializeField] private GameObject colorSwitcher;
        [SerializeField] private float distanceToColorSwitcher = 1;
        [Tooltip("Average size of an obstacle")]
        [SerializeField] private float obstacleSize = 3.5f;
        [Range(0,5)] [Tooltip("Distance between obstacles")]
        [SerializeField] private float obstacleDistanceOffset = 3f;

        private UnityEngine.Camera _camera;
        
        private List<GameObject> _obstacles = new List<GameObject>();

        private float _screenHeight;

        // Variables to calculate traveled distance
        private float _lastPosY;
        private float _traveledDistance;
        
        // Y pos of objects to spawn
        private float _spawnPos;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Start()
        {
            _screenHeight = Screen.height / 100;
            _spawnPos = _screenHeight - obstacleSize;
            distanceToColorSwitcher += obstacleSize / 2;
            SpawnObstacle(new Vector2(0, _spawnPos));

            _lastPosY = _camera.transform.position.y;
        }

        private void FixedUpdate()
        {
            CalculateTraveledDistance();

            CheckForObjectSpawn();
            
            DeleteObstacles();
        }

        private void CalculateTraveledDistance()
        {
            float camPos = _camera.transform.position.y;
            _traveledDistance += camPos - _lastPosY;
            _lastPosY = camPos; 
        }

        private void CheckForObjectSpawn()
        {
            if (_traveledDistance >= _screenHeight - obstacleSize && _obstacles.Count < 6)
            {
                _spawnPos += obstacleDistanceOffset + obstacleSize + Random.Range(1,obstacleDistanceOffset-1);
                SpawnObstacle(new Vector2(0, _spawnPos));
                _traveledDistance = 0;
            } 
        }

        private void SpawnObstacle(Vector2 pos)
        {
            _obstacles.Add(Instantiate(obstaclesType[Random.Range(0,obstaclesType.Length)], pos, Quaternion.identity));
            Instantiate(colorSwitcher, new Vector2(pos.x, pos.y + distanceToColorSwitcher), Quaternion.identity);
        }

        private void DeleteObstacles()
        {
            for(int i = 0; i < _obstacles.Count; ++i)
            {
                if (_obstacles[i].transform.position.y + obstacleSize < _camera.transform.position.y - _screenHeight)
                {
                    Destroy(_obstacles[i]);
                    _obstacles.RemoveAt(i);
                }
            }
        }
    }
}
