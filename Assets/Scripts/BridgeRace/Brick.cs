using UnityEngine;

namespace BridgeRace
{
    public class Brick : MonoBehaviour
    {
        [SerializeField]
        private BrickType brickType;

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
            if (other.gameObject.CompareTag("Player"))
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
            GetComponent<MeshRenderer>().material.color = ChoiceMaterial.SetColor(brickType);            
        }
    }
}