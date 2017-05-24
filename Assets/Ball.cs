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
        Vector2 vectorTO;
        Status status = Status.INITIAL;
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
                    this.GetComponent<Rigidbody>().AddForce(vectorTO.normalized * 0.5f);
                    status = Status.THROWN;
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                }
            }


        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.transform.tag != "wall" && status == Status.THROWN)
            { 
                if (col.gameObject.transform.tag == this.gameObject.transform.tag)
                {
                    Main.Spawned = false;
                    Destroy(col.gameObject);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "death")
                {
                    Main.Spawned = false;
                    Destroy(this.gameObject);
                }
                else
                {
                    
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    Main.Spawned = false;
                    status = Status.FINAL;
                }
            }
            else
            {
                vectorTO = vectorTO.normalized - Utils.V3ToV2(col.transform.position).normalized;
                this.GetComponent<Rigidbody>().AddForce(Utils.V3ToV2(vectorTO.normalized * 0.5f));
            }        
        }
    }
}