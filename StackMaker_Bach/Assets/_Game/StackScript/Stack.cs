using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.StackScript
{
    public class Stack : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "BrickPickup")
            {
                other.gameObject.tag = "Normal";
                PlayerMovement.Instance.PickBrick(other.gameObject);
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<Stack>();
                Destroy(this);
            }
        }
    }
}
