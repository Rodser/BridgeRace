using UnityEngine;

namespace BridgeRace
{
    public enum BrickType
    {
        Red, Blue, Green
    }

    public class Brick : MonoBehaviour
    {
        [SerializeField]
        private BrickType brickType;
        [SerializeField]
        private Material[] materials;

        private PlayerController player;
        private BrickSpawn brickSpawn;

        public BrickType BrickType => brickType;

        private void Start()
        {
            SetColor();
            brickSpawn = FindObjectOfType<BrickSpawn>();
            player = FindObjectOfType<PlayerController>();
        }
        public void SetBrickType(BrickType type)
        {
            brickType = type;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (player.MyBrickType == brickType)
                {
                    brickSpawn.RespawnBrick();
                    PickUp();
                }
            }
        }

        private void PickUp()
        {
            Vector3 offset = transform.position - player.transform.position;
            Vector3 position = player.transform.position + offset;
            Quaternion quaternion = transform.rotation;

            player.PickUp(position, quaternion);
            Destroy(gameObject);
        }

        private void SetColor()
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
                    gameObject.GetComponent<MeshRenderer>().material = materials[1];
                    break;
            }
        }
    }
}