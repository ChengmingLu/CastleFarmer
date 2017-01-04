using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {
    public GameObject bulletPrefabLeft;
    public GameObject bulletPrefabRight;
    public float RoF;
    public float bulletRange;
    public int bulletDamage;
    public float bulletSpeed;
    public Vector3 bulletSpawnOffset;

    private float spawnNext;
    private float fireInterval;
    private const int FIRE_INTERVAL_FACTOR = 10;
	// Use this for initialization
	void Start () {
        spawnNext = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    fireInterval = FIRE_INTERVAL_FACTOR / RoF;
	}

    public void spawnProjectileLeft() {
        if (Time.time > spawnNext) {
            spawnNext = Time.time + fireInterval;
            GameObject bulletObject = Instantiate(bulletPrefabLeft, gameObject.transform.position + bulletSpawnOffset, Quaternion.identity) as GameObject;
            setIdentity(bulletObject);
            bulletObject.GetComponent<Projectile>().range = bulletRange;
            bulletObject.GetComponent<Projectile>().damage = bulletDamage;
            bulletObject.GetComponent<Movable>().speed = bulletSpeed;
            bulletObject.GetComponent<Movable>().moveLeft();
        }
    }
    public void spawnProjectileRight() {
        if (Time.time > spawnNext) {
            spawnNext = Time.time + fireInterval;
            GameObject bulletObject = Instantiate(bulletPrefabRight, gameObject.transform.position + bulletSpawnOffset, Quaternion.identity) as GameObject;
            setIdentity(bulletObject);
            bulletObject.GetComponent<Projectile>().range = bulletRange;
            bulletObject.GetComponent<Projectile>().damage = bulletDamage;
            bulletObject.GetComponent<Movable>().speed = bulletSpeed;
            bulletObject.GetComponent<Movable>().moveRight();
        }
    }
    private void setIdentity(GameObject bulletObject) {
        if (gameObject.transform.parent.gameObject.GetComponent<Player>()) {
            bulletObject.GetComponent<Projectile>().projectileIdentity = Projectile.Identity.Player;
        } else {
            bulletObject.GetComponent<Projectile>().projectileIdentity = Projectile.Identity.Enemy;
        }
    }
}
