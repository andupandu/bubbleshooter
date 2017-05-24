using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Assets
{
    public class Main : MonoBehaviour
    {
        static float StartX = -0.5f;
        static float StartY = -6f;

        static Vector3 GetStartPosition()
        {
            return new Vector3(StartX, StartY, 0);
        }

        List<Sprite> BallImages;
        public static bool Spawned = false;

        public GameObject ballPrefab;
        public bool test = false;
        // Use this for initialization
        void Start()
        {
            BallImages = Resources.LoadAll<Sprite>("balls").ToList();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Spawned)
            {
                var ball = Instantiate(ballPrefab, GetStartPosition(), Quaternion.identity) as GameObject;
                var ballId = Utils.GetRandom(0, BallImages.Count);

                ball.GetComponent<SpriteRenderer>().sprite = BallImages[ballId];
                ball.transform.tag = DetermineBallInArray(ballId);
                Spawned = true;
            }
        }

        string DetermineBallInArray(int id)
        {
            if (id <= 3)
                return "orangeball";
            else if (id <= 7)
                return "greenball";
            else if (id <= 11)
                return "redball";
            else if (id <= 15)
                return "purpleball";
            else
                return "blueball";

        }
    }
}