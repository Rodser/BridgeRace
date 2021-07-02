using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Joystick joystick;
        [SerializeField]
        private float speedMover = 4f;
        [SerializeField]
        private BrickInPack brickPrefab;
        [SerializeField]
        private BrickType myBrickType;
        [SerializeField]
        private Transform packPointStart;
        [SerializeField]
        private Transform packPointUp;
        [SerializeField]
        private Transform packPointEnd;

        private Rigidbody player;
        private List<BrickInPack> bricks;
        private int countBrick = 0;

        public BrickType MyBrickType => myBrickType;

        private void Start()
        {
            player = GetComponent<Rigidbody>();
            bricks = new List<BrickInPack>();
        }

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical) * speedMover;
            direction = Vector3.ClampMagnitude(direction, speedMover);

            if (direction != Vector3.zero)
            {
                player.MovePosition(transform.position + direction * Time.deltaTime);
                player.MoveRotation(Quaternion.LookRotation(direction));
            }
        }

        internal void PickUp(Vector3 brickPosition, Quaternion quaternion)
        {
            BrickInPack brick = Instantiate(brickPrefab, brickPosition, quaternion, transform);
            countBrick++;
                                   
            brick.MoveBrickInPack(packPointStart.localPosition, packPointUp.localPosition, packPointEnd.localPosition, packPointEnd.localRotation, countBrick);          

            bricks.Add(brick);
        }
    }
}