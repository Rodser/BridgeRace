using UnityEngine;

namespace BridgeRace
{
    public class Stage : MonoBehaviour
    {

        [SerializeField]
        private Transform next;
        [SerializeField]
        private Material[] materials;

        public Vector3 NextPosition => next.position;

        internal void SetColor(BrickType brickType)
        {
            GetComponent<MeshRenderer>().material.color = ChoiceMaterial.SetColor(brickType);
        }
    }
}