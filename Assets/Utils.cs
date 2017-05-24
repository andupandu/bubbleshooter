using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    static class Utils
    {
        public static Vector2 V3ToV2(Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static int GetRandom(int min, int max)
        {
            System.Random r = new System.Random();
            return r.Next(min, max);
        }
    }
}
