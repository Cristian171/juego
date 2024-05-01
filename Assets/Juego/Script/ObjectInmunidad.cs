using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInmunidad : PickableItem
{
    // Start is called before the first frame update
    protected override void Pick(GameObject picker)
    {
        MMEventManager.TriggerEvent(new PickableItemEvent(this));
    }
}

