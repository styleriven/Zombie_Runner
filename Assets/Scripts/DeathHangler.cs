using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathHangler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] StarterAssetsInputs starterAssetsInputs;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    public virtual void HandleDeath()
    {

        gameOverCanvas.enabled=true;
        Time.timeScale = 0;
        FindObjectOfType<Weapon>().enabled = false;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        

    }

}
