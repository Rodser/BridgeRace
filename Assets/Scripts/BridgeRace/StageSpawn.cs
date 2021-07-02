using UnityEngine;


namespace BridgeRace
{
    public class StageSpawn : MonoBehaviour
    {
        [SerializeField]
        private Stage stagePrefab;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponentInParent<PlayerController>();

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
            Destroy(gameObject);
        }
    }
}
