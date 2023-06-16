using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult_attack : FireAttacks_SuperClass
{
    // Start is called before the first frame update
     Ult_attack() : base(10, 3,true)
     {
        
     }

    // Update is called once per frame
    void Update()
    {
        base.fizzleCalc();

    }
}
