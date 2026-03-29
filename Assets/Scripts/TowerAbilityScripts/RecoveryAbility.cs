using JetBrains.Annotations;
using PlayFab.MultiplayerModels;
using UnityEngine;

public class RecoveryAbility : TowerAbility
{
    [Header("Attributes")]
    [SerializeField] private float repDamping;
    [SerializeField] private float dataDamping;

    public override void OnPlace()
    {
        
    }

    // reduce rep damage, data loss
}
