using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Hp = 100f;


    void Start()
    {
        
    }
    public void kill(float damage){
        Hp -= damage;
        if ( Hp <= 0)
        {
            Hp= 0;
            GetComponent<DeathHangler>().HandleDeath();
        }
    }

    public void health(float blood){
        Hp += blood;
        if(Hp > 100)
        {
            Hp = 100;
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
