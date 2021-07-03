using System;
using UnityEngine;

namespace BridgeRace
{
    class BrickInPack : MonoBehaviour
    {
        [SerializeField]
        private BrickType brickType;
        [SerializeField]
        private float offset = 0.1f;
        [SerializeField]
        private float speed = 1f;

        private Vector3 point0;
        private Vector3 point1;
        private Vector3 point2;
        private Vector3 point3;
        private Quaternion rotationBrick;
        private TrailRenderer trail;

        private float time = 1;

        private void Start()
        {
            trail = GetComponentInChildren<TrailRenderer>();
        }

        private void FixedUpdate()
        {
            if (time < 1)
            {
                trail.enabled = true;
                time = Mathf.Clamp01(time + speed * Time.fixedDeltaTime);
                transform.localPosition = Bezier.GetBezier(point0, point1, point2, point3, time);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationBrick, time);
            }
            else
            {
                trail.enabled = false;
            }
        }

        public void MoveBrickInPack(Vector3 pointStart, Vector3 pointUp, Vector3 pointEnd, Quaternion rotation, int count)
        {
            point0 = transform.position;
            point1 = pointStart;
            point2 = pointUp;
            point3 = pointEnd;
            point3.y += offset * count;

            rotationBrick = rotation;
            rotationBrick.y = 0;
            time = 0;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        internal void SetColor(BrickType type)
        {
            GetComponent<MeshRenderer>().material.color = ChoiceMaterial.SetColor(type);
        }
    }
}
