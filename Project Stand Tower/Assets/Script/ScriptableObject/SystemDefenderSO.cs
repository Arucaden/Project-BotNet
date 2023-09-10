using UnityEngine;

[CreateAssetMenu(fileName = "New System Defender", menuName = "SystemDefender")]
public class SystemDefenderSO : ScriptableObject
{
    public new string name;
    public string description;

    public int cost;
    public int damage;
    public float range;
    public float attSpeed;
    
}
