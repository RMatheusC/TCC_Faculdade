using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject arrow;
    public GameObject OtherProjectile;
    public Transform spawn_bullet;
    private Jogador_status sts;
    private float nextTimeToFire = 0f;
    private float fireRate = 15f;

    public int MaxAmmo = 8;
    public int currentAmmor = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    private void Start()
    {
        sts = FindObjectOfType<Jogador_status>();
        if (currentAmmor == -1) {
            currentAmmor = MaxAmmo;
        }
    }

    void Update()
    {
        if (isReloading) {
            return;
        }

        if (currentAmmor <= 0) {
            StartCoroutine(Reload());
            return;
        }
        Fire();
    }
    public void Fire()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Instantiate(arrow, spawn_bullet.position, transform.rotation);
            currentAmmor--;
        }
    }

    IEnumerator Reload() {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        currentAmmor = MaxAmmo;
        isReloading = false;
    }
}
