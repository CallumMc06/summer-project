using UnityEngine;

[CreateAssetMenu(fileName = "newHitbox", menuName = "HitboxAttributes")]
public class HitboxData : ScriptableObject
{
    public Vector2 size;
    public Vector2 location;
    public float damage;
}
