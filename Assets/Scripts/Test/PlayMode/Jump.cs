using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Jump
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator JumpWithEnumeratorPasses()
    {

        
        yield return new WaitForSeconds(1f);
    }
    }
