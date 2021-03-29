using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch.Manager
{
    public class TravelDistanceMeter : MonoBehaviour
    {
        public UnityEvent onDistanceTraveled;
        
        [SerializeField] private Transform objectToCalculate;
        [SerializeField] private float distanceToTriggerAfter;
        
        // Variables to calculate traveled distance
        private float _lastObjectPosY;
        private float _traveledDistance;

        private void FixedUpdate()
        {
           CalculateTraveledDistance(); 
        }

        private void CalculateTraveledDistance()
        {
            float objectPos = objectToCalculate.transform.position.y;
            _traveledDistance += objectPos - _lastObjectPosY;
            _lastObjectPosY = objectPos;

            if (_traveledDistance >= distanceToTriggerAfter)
            {
                onDistanceTraveled?.Invoke();
                distanceToTriggerAfter = 0;
            }
        }

        public void SetDistanceToTriggerAfter(float distance)
        {
            distanceToTriggerAfter = distance;
        }
    }
}
