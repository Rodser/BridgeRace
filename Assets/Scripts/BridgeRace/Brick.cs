using System;
using System.Collections;
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
            Vector3 pos = transform.position;
            Transform newTransform = player.BackpackPoint;
            newTransform.TransformPoint(pos);

            player.PickUp(newTransform);
            Destroy(gameObject);
        }
    }
}