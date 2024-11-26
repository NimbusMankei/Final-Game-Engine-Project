using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Foot Steps SFX")]

    [field: SerializeField] public EventReference Steps { get; private set; }

    [field: Header("Jump SFX")]

    [field: SerializeField] public EventReference Jump { get; private set; }

    [field: Header("Fruit Collect SFX")]

    [field: SerializeField] public EventReference CoinCollected { get; private set; }

    public static FMODEvents instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one audio manager in the scene.");
        }
        instance = this;
    }
}
