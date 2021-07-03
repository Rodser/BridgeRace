using UnityEngine;

namespace BridgeRace
{
    public enum BrickType
    {
        Red, Blue, Green
    }

    public static class ChoiceMaterial 
    {
        public static Color SetColor( BrickType brickType)
        {            
            switch (brickType)
            {
                case BrickType.Red:
                    return Color.red;
                case BrickType.Blue:
                    return Color.blue;
                case BrickType.Green:
                    return Color.green;
                default:
                    return Color.grey;
            }
        }
    }
}