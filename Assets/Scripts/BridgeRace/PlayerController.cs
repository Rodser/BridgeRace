using System;
using System.Collections;
using UnityEngine;

namespace BridgeRace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Joystick joystick;
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private Brick brickPrefab;
        [SerializeField]
        private BrickType myBrickType;
        [SerializeField]
        private Transform backpackPoint;

        private Rigidbody player;
        private int countBriks;

        public BrickType MyBrickType => myBrickType;
        public Transform BackpackPoint => backpackPoint;

        private void Start()
        {
            player = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical) * speed;
            direction = Vector3.ClampMagnitude(direction, speed);

            if (direction != Vector3.zero)
            {
                player.MovePosition(transform.position + direction * Time.deltaTime);
                player.MoveRotation(Quaternion.LookRotation(direction));
            }
        }

        internal void PickUp(Transform transform)
        {

            Instantiate(brickPrefab, transform, false);

        }
    }
}