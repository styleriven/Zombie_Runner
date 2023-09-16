using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;



    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;

    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    public void Increase(AmmoSlot[] AmmoSlots)
    {
        foreach(AmmoSlot AmmoSlot in AmmoSlots)
        {
            Increase(AmmoSlot.ammoType,AmmoSlot.ammoAmount);
        }    
    }
    public void Increase(AmmoType ammoType, int number)
    {
          GetAmmoSlot(ammoType).ammoAmount += number; 
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = this.ammoSlots.FirstOrDefault(slot => slot.ammoType == ammoType);
        if (ammoSlot != null)
        {
            return ammoSlot;
        }
        else
        {

            Debug.LogWarning("Ammo type not found: " + ammoType);
            return null;

        }

    }
}
