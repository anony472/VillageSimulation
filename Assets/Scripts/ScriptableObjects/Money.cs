using UnityEngine;

[CreateAssetMenu(fileName = "Money", menuName = "Custom/Money")]
public class Money : ScriptableObject
{
    public long money;
    public long startingMoney;
    public long incRate;
    public void OnEnable()
    {
        money = startingMoney;
    }
}
