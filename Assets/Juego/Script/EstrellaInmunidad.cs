using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaInmunidad : PickableItem
{
    protected override void Pick(GameObject picker)
    {
        MMEventManager.TriggerEvent(new PickableItemEvent(this));
    }
}
