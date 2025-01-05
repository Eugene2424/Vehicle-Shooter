using System;
using UnityEngine;

namespace Game.Presentation
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("GroundCheck"))
                transform.position = spawnPoint.position;
        }
    }
}