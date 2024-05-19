using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackMaker
{
    public class WinArea : MonoBehaviour
    {
        public GameObject chestClose;
        public GameObject chestOpen;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                chestClose.SetActive(false);
                chestOpen.SetActive(true);
            }
        }
    }
}

