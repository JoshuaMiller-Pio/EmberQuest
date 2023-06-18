using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_attack : FireAttacks_SuperClass
{
    
    // Start is called before the first frame update
     Basic_attack():base(2,1,false)
     {
        
     }

    // Update is called once per frame
    void Update()
    {
        base.fizzleCalc();
    }
}
