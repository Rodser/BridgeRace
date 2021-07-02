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
            switch (brickType)
            {
                case BrickType.Red:
                    gameObject.GetComponent<MeshRenderer>().material = materials[0];
                    break;
                case BrickType.Blue:
                    gameObject.GetComponent<MeshRenderer>().material = materials[1];
                    break;
                case BrickType.Green:
                    gameObject.GetComponent<MeshRenderer>().material = materials[2];
                    break;
                default:
                    break;
            }
        }
    }
}