using BuildingCapluse;
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BuildingPanel _panel;

    public void Init(ref Action OnMove, ref Action OnZoom)
    {
        _panel.Init();

        OnMove += _panel.Hide;
        OnZoom += _panel.AdaptScale;
    }
}
