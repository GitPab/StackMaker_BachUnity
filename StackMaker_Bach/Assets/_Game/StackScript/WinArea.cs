using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.StackScript
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

