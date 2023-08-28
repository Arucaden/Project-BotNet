using UnityEngine;

[CreateAssetMenu(fileName = "Virus", menuName = "Virus")]
public class VirusSO : ScriptableObject
{
    public new string name;
    public string description;

    public int health;
    public int shield;
    public int damage;
    public float movSpeed;

}