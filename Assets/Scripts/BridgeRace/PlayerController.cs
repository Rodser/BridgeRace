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

        private Animator animatorPlayer;
        private Rigidbody player;
        private List<BrickInPack> bricks;
        private int countBrick = 0;
        private Vector3 brickPosition0;

        public BrickType MyBrickType => myBrickType;
        public int CountDrick => countBrick;

        private void Start()
        {
            player = GetComponent<Rigidbody>();
            animatorPlayer = GetComponent<Animator>();
            bricks = new List<BrickInPack>();
            GetComponentInChildren<Renderer>().material.color = ChoiceMaterial.SetColor(myBrickType);
        }

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical) * speedMover;
            direction = Vector3.ClampMagnitude(direction, speedMover);

            if (direction != Vector3.zero)
            {
                player.MovePosition(transform.position + direction * Time.deltaTime);
                player.MoveRotation(Quaternion.LookRotation(direction));
                animatorPlayer.SetBool("run", true);
            }
            else
            {
                animatorPlayer.SetBool("run", false);
            }
        }

        public void PickUp(Vector3 brickPosition, Quaternion quaternion)
        {
            BrickInPack brick = Instantiate(brickPrefab, brickPosition, quaternion, transform);
            countBrick++;

            brick.MoveBrickInPack(packPointStart, packPointUp, packPointEnd, countBrick);
            brick.SetColor(myBrickType);
            bricks.Add(brick);

            brickPosition0 = brickPosition;
        }

        public void RemoveBrick()
        {
            bricks[countBrick - 1].Destroy();
            bricks.RemoveAt(countBrick - 1);
            countBrick--;
        }


        private void OnDrawGizmos()
        {
            int sigmentsNumber = 20;
            Vector3 preveousePoint = brickPosition0;

            for (int i = 0; i < sigmentsNumber + 1; i++)
            {
                float paremeter = (float)i / sigmentsNumber;
                Vector3 point = Bezier.GetBezier4(brickPosition0, packPointStart.position, packPointUp.position, packPointEnd.position, paremeter);
                Gizmos.DrawLine(preveousePoint, point);
                preveousePoint = point;
            }
        }
    }
}