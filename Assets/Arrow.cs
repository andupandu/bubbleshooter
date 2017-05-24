using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class Arrow : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.transform.up = Utils.V3ToV2(Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position);
        }
    }
}