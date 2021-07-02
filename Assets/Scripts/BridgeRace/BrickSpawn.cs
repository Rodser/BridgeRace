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
        private int minX = -1;
        [SerializeField]
        private int maxX = 1;
        [SerializeField]
        private int minZ = -1;
        [SerializeField]
        private int maxZ = 1;
        [SerializeField]
        private int count = 10;
        [SerializeField]
        private float secondRespawn = 5f;

        private void Start()
        {
            for (int i = 0; i < count; i++)
            {
                Spawn();
            }
        }

        private Brick Spawn()
        {
            Brick brick = Instantiate(brickPrefab, GetVectorSpawn(), transform.rotation, transform);
            brick.SetBrickType((BrickType)Random.Range(0, 2));
            return brick;
        }

        private Vector3 GetVectorSpawn()
        {
            Vector3 vector = new Vector3();
            vector.x = Random.Range(minX, maxX);
            vector.y = transform.position.y;
            vector.z = Random.Range(minZ, maxZ);
            return vector;
        }

        public void RespawnBrick(Transform brickTransform)
        {
            StartCoroutine(Respawn(brickTransform));
        }

        private IEnumerator Respawn(Transform brickTransform)
        {
            yield return new WaitForSeconds(secondRespawn);
            Spawn();
        }
    }
}
