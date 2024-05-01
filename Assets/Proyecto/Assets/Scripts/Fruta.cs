using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : PickableItem
{
    protected override void Pick(GameObject picker)
    {
        // we send a new points event for the GameManager to catch (and other classes that may listen to it too)
        PickableItemEvent.Trigger(this);
    }
}
