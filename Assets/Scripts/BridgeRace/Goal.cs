using UnityEngine;
using UnityEngine.Events;

namespace BridgeRace
{
    public class Goal : MonoBehaviour
    {
        public UnityEvent GoalEvent;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Spawn"))
            {
                Destroy(other.gameObject);
                GoalEvent.Invoke();
            }
        }
    }
}