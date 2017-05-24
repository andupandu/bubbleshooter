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
                    var vectorTO = Utils.V3ToV2(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Utils.V3ToV2(transform.position);
                    this.GetComponent<Rigidbody2D>().AddForce(vectorTO.normalized * 0.1f);
                    status = Status.THROWN;
                }
            }


        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.transform.tag != "wall" && status == Status.THROWN)
            {
                if (col.gameObject.transform.tag == this.gameObject.transform.tag)
                {
                    Debug.Log("am gasit abaldasdasd as");
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
                    this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Main.Spawned = false;
                    status = Status.FINAL;
                }
            }        
        }
        

        void OnCollisionExit2D(Collision2D col)
        {
            if(col.gameObject.tag != "wall")
            {
                Destroy(this.gameObject);
            }
        }
    }
}