using System;
using System.Collections;
using UnityEngine;

namespace BridgeRace
{
    class BrickInPack : MonoBehaviour
    {
        [SerializeField]
        private BrickType brickType;
        [SerializeField]
        private float shiftInHeight = 0.1f;
        [SerializeField]
        private float speed = 1f;

        private Vector3 point0;
        private Vector3 point1;
        private Vector3 point2;
        private Vector3 point3;
        private Quaternion rotationBrick;
        private TrailRenderer trail;

        private float time = 1f;

        private void Start()
        {
            point0 = new Vector3(0,0,0);
            trail = GetComponentInChildren<TrailRenderer>();
        }


        public void MoveBrickInPack(Transform pointStart, Transform pointUp, Transform pointEnd, int count)
        {
            point1 = pointStart.localPosition;
            point2 = pointUp.localPosition;
            point3 = pointEnd.localPosition;
            point3.y += shiftInHeight * count;

            rotationBrick = pointEnd.localRotation;
            StartCoroutine(MoverCoroutine());
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        internal void SetColor(BrickType type)
        {
            GetComponent<MeshRenderer>().material.color = ChoiceMaterial.SetColor(type);
        }

        private IEnumerator MoverCoroutine()
        {
            time = 0;

            while (time < 1)
            {
                yield return new WaitForEndOfFrame();
                time += speed * Time.deltaTime;
                transform.localPosition = Bezier.GetBezier4(point0, point1, point2, point3, time);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationBrick, time);
            }

            trail.enabled = false;
        }

        private void OnDrawGizmos()
        {
            int sigmentsNumber = 20;
            Vector3 preveousePoint = point0;
            Gizmos.color = Color.cyan;
            for (int i = 0; i < sigmentsNumber + 1; i++)
            {
                float paremeter = (float)i / sigmentsNumber;
                Vector3 point = Bezier.GetBezier4(point0, point1, point2, point3, paremeter);
                Gizmos.DrawLine(preveousePoint, point);
                preveousePoint = point;
            }
        }
    }
}
