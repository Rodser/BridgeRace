using UnityEngine;

namespace BridgeRace
{
     public static class Bezier
    {        
        public static Vector3 GetBezier(Vector3 point0, Vector3 point1, Vector3 point2, Vector3 point3, float time)
        {
            Vector3 point01 = Vector3.Lerp(point0, point1, time);
            Vector3 point02 = Vector3.Lerp(point1, point2, time);
            Vector3 point03 = Vector3.Lerp(point2, point3, time);

            Vector3 point12 = Vector3.Lerp(point01, point02, time);
            Vector3 point23 = Vector3.Lerp(point02, point03, time);

            Vector3 point = Vector3.Lerp(point12, point23, time);

            return point;
        }
    }
}
