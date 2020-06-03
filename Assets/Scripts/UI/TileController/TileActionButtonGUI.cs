﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileActionButtonGUI : MonoBehaviour
{
    public GameObject tilePrefab;

    [SerializeField]
    private Image myIcon;
    private SelectTile selectTile;


    public void SetTileProperties(GameObject tilePrefabGO)
    {
        selectTile = GameObject.Find("GameManager").GetComponent<SelectTile>();
        tilePrefab = tilePrefabGO;

        SetIcon();

        SetOnClickFunction();
    }


    public void SetIcon()
    {
        myIcon.sprite = tilePrefab.GetComponent<SpriteRenderer>().sprite;
    }


    public void SetOnClickFunction()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry onPointerClickEntry = new EventTrigger.Entry();
        EventTrigger.Entry onPointerEnterEntry = new EventTrigger.Entry();
        EventTrigger.Entry onPointerExitEntry = new EventTrigger.Entry();

        onPointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        onPointerEnterEntry.callback.AddListener((eventData) => { selectTile.Invoke("Get" + tilePrefab.name + "_InfoCosts", 0f); });
        eventTrigger.triggers.Add(onPointerEnterEntry);

        onPointerExitEntry.eventID = EventTriggerType.PointerExit;
        onPointerExitEntry.callback.AddListener((eventDataa) => { selectTile.Invoke("EmptyAndClosePrefabInfo", 0f); });
        eventTrigger.triggers.Add(onPointerExitEntry);

        onPointerClickEntry.eventID = EventTriggerType.PointerClick;
        onPointerClickEntry.callback.AddListener((eventDataaa) => { selectTile.Invoke("Get" + tilePrefab.name, 0f); });
        eventTrigger.triggers.Add(onPointerClickEntry);
    }
}