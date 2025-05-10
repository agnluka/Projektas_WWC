using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 25f;
    public int damage = 10;
    public Sprite gunSprite;
    public Vector3 launchOffsetLocalPosition;
    public Vector3 gunScale = Vector3.one;
    public bool automaticFire = false;
    public float fireRate = 0.5f;
}
