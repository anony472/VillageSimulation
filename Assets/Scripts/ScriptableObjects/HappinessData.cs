using UnityEngine;

[CreateAssetMenu(fileName = "HappinessData", menuName = "Custom/HappinessData")]
public class HappinessData : ScriptableObject
{
    public double startingHappiness;
    public double currentHappiness;
    public void OnEnable()
    {
        currentHappiness = startingHappiness;
    }
}
