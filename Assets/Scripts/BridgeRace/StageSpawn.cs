using UnityEngine;

namespace BridgeRace
{
    public class StageSpawn : MonoBehaviour
    {
        [SerializeField]
        private Stage stagePrefab;

        private PlayerController player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.gameObject.GetComponentInParent<PlayerController>();

                if (player.CountDrick > 0)
                {
                    player.RemoveBrick();
                    Spawn();
                }
            }
        }

        private void Spawn()
        {
            var stage = Instantiate(stagePrefab, transform.position, transform.rotation);
            stage.SetColor(player.MyBrickType);
            Destroy(gameObject);
        }
    }
}
