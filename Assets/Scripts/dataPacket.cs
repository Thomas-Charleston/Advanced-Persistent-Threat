using UnityEngine;

public class dataPacket : EnemyAbility
{
    [SerializeField] private int dataValue = 1;

    public override void OnReachEnd()
    {
        DataValue.main.AddData(dataValue);
    }
}
