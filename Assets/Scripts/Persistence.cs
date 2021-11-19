using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    // Script exists exclusively to allow items to not be destroyed. This SHOULD work. We'll find out.
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
