using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ListofThings
{
    public GameObject Cubes;
    public float randomfloat;
}
public class ClassListThing : MonoBehaviour
{
    public List<ListofThings> Things;
    //TADA LOL

    public float WHATAMIDOING(float Val)
    {
        Val++;
        return Val;
    }
}
