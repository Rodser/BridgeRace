using UnityEngine;

namespace BridgeRace
{
    public class Stage : MonoBehaviour
    {
        [SerializeField]
        private Transform next;

        public Vector3 NextPosition => next.position;
        
    }
}