using BuildingCapluse;
using PlayerCapsule;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private BuildingPlacesInitiator _initiator;
    [SerializeField] private Player _player;
    [SerializeField] private UIManager _UI;

    private const int FPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = FPS;

        _initiator.Init();
        _player.Init();
        _UI.Init(ref _player.OnMove, ref _player.OnZoom);
    }
}
