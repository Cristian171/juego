using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class ManejadorPuerta:MonoBehaviour, MMEventListener<PickableItemEvent>
{
    [SerializeField]
    private GameObject puerta;

    void Start()
    {
        if(puerta != null)
        {
            puerta.SetActive(false);
        }
    }

    void OnEnable()
    {
        this.MMEventStartListening<PickableItemEvent>();
    }
    void OnDisable()
    {
        this.MMEventStopListening<PickableItemEvent>();
    }

    public virtual void OnMMEvent(PickableItemEvent e)
    {
        Debug.Log(e.PickedItem.name + " "+e.PickedItem.tag);
        
        if(e.PickedItem.tag == "Fruta")
        {
            puerta.SetActive(true);
        }

        /*monedas_recolectadas++;
        Debug.Log(monedas_recolectadas);

        if (monedas_recolectadas == 4)
        {
            Debug.Log("Abrir Puerta");
        }*/
    }

}
