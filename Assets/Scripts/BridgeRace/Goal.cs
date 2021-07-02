using UnityEngine;

namespace BridgeRace
{
    public class Goal : MonoBehaviour
    {               
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Spawn"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}