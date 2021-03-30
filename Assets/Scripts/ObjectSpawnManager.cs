using System.Collections.Generic;
using System.Linq;
using ColorSwitch.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ColorSwitch.Generator
{
    public class ObjectSpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstaclesType;
        [SerializeField] private GameObject colorSwitcher;
        
        [SerializeField] private int maximumObjectsPerScreen = 5;
        
        [Range(1,5)] [Tooltip("Distance between obstacles and color switching object")] 
        [SerializeField] private float distanceToColorSwitcher = 1;
        
        [Tooltip("Average size of an obstacle")]
        [SerializeField] private float obstacleSize = 3.5f;
        
        [Range(0,5)] [Tooltip("Distance between obstacles")]
        [SerializeField] private float obstacleDistanceOffset = 3f;

        private TravelDistanceMeter _travelDistanceMeter;
        private UnityEngine.Camera _camera;
        private List<GameObject> _obstacles = new List<GameObject>();

        private float _screenHeight;

        // Y pos of objects to spawn
        private float _spawnPos;

        private void Awake()
        {
            _travelDistanceMeter = GetComponent<TravelDistanceMeter>();
            _camera = UnityEngine.Camera.main;
        }

        private void Start()
        {
            _screenHeight = Screen.height / 100;
            _spawnPos = _screenHeight - obstacleSize;
            distanceToColorSwitcher += obstacleSize / 2;
            
            _travelDistanceMeter.SetDistanceToTriggerAfter(_screenHeight - obstacleSize);
            
            SpawnObstacle(new Vector2(0, _spawnPos));
        }

        private void FixedUpdate()
        {
            DeleteObstacles();
        }

        public void CheckForObjectSpawn()
        {
            if (_obstacles.Count < maximumObjectsPerScreen)
            {
                _spawnPos += obstacleDistanceOffset + obstacleSize + Random.Range(1,obstacleDistanceOffset-1);
                SpawnObstacle(new Vector2(0, _spawnPos));
            } 
        }

        private void SpawnObstacle(Vector2 pos)
        {
            _obstacles.Add(Instantiate(obstaclesType[Random.Range(0,obstaclesType.Length)], pos, Quaternion.identity));
            Instantiate(colorSwitcher, new Vector2(pos.x, pos.y + distanceToColorSwitcher), Quaternion.identity);
        }

        private void DeleteObstacles()
        {
            // Delete object if not in camera sight
            GameObject gameObjectToFind = _obstacles.FirstOrDefault(temp =>
            {
                float positionY = _camera.transform.position.y - _screenHeight;
                return temp.transform.position.y + obstacleSize < positionY;
            });

            _obstacles.Remove(gameObjectToFind);
            Destroy(gameObjectToFind);
        }
    }
}
