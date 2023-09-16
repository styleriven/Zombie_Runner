using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.GetComponent<Ammo>().Increase(ammoSlots);
            Debug.Log(other.gameObject.transform.name);
            Destroy(gameObject);
        }

    }
}
