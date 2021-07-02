using System;
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

        private void Start()
        {
            GetColor();
            brickSpawn = GameObject.FindObjectOfType<BrickSpawn>();
        }

        private void OnTriggerEnter(Collider other)
        {            
            if (other.CompareTag("Player"))
            {
                player = other.gameObject.GetComponentInParent<PlayerController>();

                if (player.MyBrickType == brickType)
                {
                    brickSpawn.RespawnBrick(transform);
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

        public void SetBrickType(BrickType brickType)
        {
            this.brickType = brickType;
        }

        private void GetColor()
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