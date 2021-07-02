using System.Collections;
using UnityEngine;

namespace BridgeRace
{
    public class BrickSpawn : MonoBehaviour
    {
        [SerializeField]
        private Brick brickPrefab;
        [SerializeField]
        private Transform parent;
        [SerializeField]
        private float spawnX = 4;
        [SerializeField]
        private float spawnY = 4;
        [SerializeField]
        private int count = 10;
        [SerializeField]
        private float secondRespawn = 5f;
        [SerializeField]
        private float radius = 4.8f;

        private PlayerController player;
        private Vector2 radiusSpawn;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();

            for (int i = 0; i < count; i++)
            {
                Spawn();
            }
        }

        public void RespawnBrick()
        {
            StartCoroutine(Respawn());
        }

        private Brick Spawn()
        {
            Brick brick = Instantiate(brickPrefab, GetVectorSpawn(), transform.rotation, transform);
            brick.SetBrickType(GetBrickType());
            return brick;
        }

        private BrickType GetBrickType()
        {
            Brick[] bricks = GetComponentsInChildren<Brick>();
            int count = 0;
            foreach (Brick brick in bricks)
            {
                if (brick.BrickType == player.MyBrickType)
                {
                    count++;
                }
            }

            BrickType type;
            if (count < 4)
            {
                type = player.MyBrickType;
            }
            else
            {
                type = (BrickType)Random.Range(0, 3);
            }

            return type;
        }

        private Vector3 GetVectorSpawn()
        {
            radiusSpawn = new Vector2(spawnX, spawnY);
            Vector3 randomVector;
            randomVector = Random.insideUnitCircle * radiusSpawn;
            Vector3 vector = new Vector3(randomVector.x, transform.position.y, randomVector.y);
            return vector;
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(secondRespawn);
            Spawn();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
