using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteor : Meteor
{
    public void Awake()
    {
        base.Awake();
        Destroy(GetComponent<BoxCollider2D>());
    }
    public override void InstanceMeteors(){
    }
}
