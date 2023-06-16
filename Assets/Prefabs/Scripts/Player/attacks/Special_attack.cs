using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_attack : FireAttacks_SuperClass
{
    // Start is called before the first frame update
     Special_attack() : base(5, 2,false)
     {
        
     }

    // Update is called once per frame
    void Update()
    {
        base.fizzleCalc();

    }
}
