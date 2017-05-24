using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Ball : MonoBehaviour
    {
        enum Status
        {
            INITIAL, THROWN, FINAL
        }

        Status status = Status.INITIAL;
        Vector3 vectorTO = new Vector3(0, 0, 0);
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (status == Status.INITIAL && Input.GetMouseButton(0))
            {
                {
                    vectorTO = Utils.V3ToV2(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Utils.V3ToV2(transform.position);
                    status = Status.THROWN;
                }
            }

            if (status == Status.THROWN)
            {
                this.transform.Translate(vectorTO * Time.deltaTime);
            }
        }

    }
}