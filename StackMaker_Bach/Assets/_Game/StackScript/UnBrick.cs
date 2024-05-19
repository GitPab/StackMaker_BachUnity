using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.StackScript
{
    public class UnBrick : MonoBehaviour
    {
        public GameObject unBrick;

        private bool isCollect = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isCollect)
            {
                isCollect = true;
                unBrick.SetActive(true);
                other.GetComponent<Player>().RemoveBrick();
            }
        }
    }
}