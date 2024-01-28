using BuildingCapluse;
using PlayerCapsule;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private BuildingPlacesInitiator initiator;
    [SerializeField] private Player _player;

    private const int FPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
        initiator.Init();
        _player.Init();
    }
}
