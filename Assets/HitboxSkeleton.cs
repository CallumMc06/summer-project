using UnityEngine;

[CreateAssetMenu(fileName = "NewHitbox", menuName = "HitboxAttributes")]
public class NewScriptableObjectScript : ScriptableObject
{
    public Vector2 size;
    public Vector2 location;
    public float damage;
}
