using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int currentWeapon;
    public Weapon[] weapons;

    public float attackBonus;
    public float attack;
    public float attackValue;

    public float knockbackBonus;
    public float knockback;
    public float knockbackValue;

    public bool isAttacking = false;
    public bool canAttack = true;

    public Camera mainCam;
    public Vector3 mousePos;
    public SpriteRenderer playerSprite;
    public SpriteRenderer weaponSprite;

    public static PlayerWeapon instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de PlayerWeapon dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {
        // je ne sais pas pourquoi mais il ne prend pas le sprite au Start
        if (playerSprite == null)
        {
            playerSprite = PlayerClass.instance.classes[PlayerClass.instance.currentClass].sprite;
        }

        ChangeWeaponDirection();

        if (Input.GetMouseButtonDown(0) && !PauseMenu.instance.isGamePaused && canAttack)
        {
            Swing();
        }

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder - 1;
        }
        else
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder + 1;
        }
    }

    public void ChangeCurrentWeapon(string weaponName)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].weaponName == weaponName)
            {
                weapons[i].gameObject.SetActive(true);
                currentWeapon = i;
                weaponSprite = weapons[i].sprite;
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }

        playerSprite = PlayerClass.instance.classes[PlayerClass.instance.currentClass].sprite;
        attack = weapons[currentWeapon].attackValue;
        knockback = weapons[currentWeapon].knockbackForce;
        UpdateValues();
        UIWeapon.instance.UpdateImageCurrentWeapon();
    }

    public void UpdateValues()
    {
        attackValue = attack + attackBonus;
        knockbackValue = knockback + knockbackBonus;
    }

    // augmente l'attaque du joueur
    public void MoreAttackValue(float amount)
    {
        attackBonus += amount;
        UpdateValues();
    }

    // augmente le recul de l'attaque du joueur
    public void MoreKnockbackValue(float amount)
    {
        knockbackBonus += amount;
        UpdateValues();
    }

    // lance l'animation d'attaque
    public void Swing()
    {
        StartCoroutine(AttackDelay(0.001f));
        weapons[currentWeapon].animator.SetTrigger("Swing");
        StartCoroutine(AttackDuration(0.2f));
    }

    public void ChangeWeaponDirection()
    {
        if (!PauseMenu.instance.isGamePaused)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            Vector3 direction = mousePos - transform.position;

            if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, -1, 1);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    // permet de pouvoir réattaquer après la fin d'animation d'attaque
    public IEnumerator AttackDuration(float duration)
    {
        canAttack = false;
        yield return new WaitForSeconds(duration);
        canAttack = true;
    }

    // permet de ne pas infliger plusieurs dégâts par frame
    public IEnumerator AttackDelay(float delay)
    {
        isAttacking = true;
        yield return new WaitForSeconds(delay);
        isAttacking = false;
    }
}
