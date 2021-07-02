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

        private PlayerController player;

        private void OnTriggerEnter(Collider other)
        {            
            if (other.CompareTag("Player"))
            {
                player = other.gameObject.GetComponentInParent<PlayerController>();

                if (player.MyBrickType == brickType)
                {
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

    }
}