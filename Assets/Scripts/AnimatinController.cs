using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnimatinController : NetworkBehaviour {
    private PlayerController player;
    private InputScript PlayerInput;
    private Animator anim;
    public GameObject weaponmanager;
    WeaponManager wep;
    private int state;
    [SyncVar]
    public float Damage;
    private NetworkAnimator netanim;
    public RuntimeAnimatorController pistol, rifle;
	// Use this for initialization
	void Start () {
       anim = GetComponent<Animator>();
        netanim = GetComponent<NetworkAnimator>();
        player = GetComponent<PlayerController>();
        PlayerInput = GetComponent<InputScript>();
        anim.runtimeAnimatorController = rifle;
        wep = weaponmanager.GetComponent<WeaponManager>();

    }
    void ChoseAnimState()
    {
        //GetWeapon()
        state = wep.ChooseState();
        switch(state)
        {
            case 0:
                anim.runtimeAnimatorController = rifle;
                
                break;
            case 1:
                anim.runtimeAnimatorController = pistol;
                break;
                
        }
        if (PlayerInput.Reload == 1)
        {
            anim.SetTrigger("Reload");
            netanim.SetTrigger("Reload");
        }
        else
        {
            anim.ResetTrigger("Reload");
            
        }
        if (PlayerInput.fire == 1)
        {
            anim.SetTrigger("StandShoot");
            netanim.SetTrigger("StandShoot");
         //   anim.ResetTrigger("StandShoot");
     }
        else
        {
            anim.ResetTrigger("StandShoot");
        }
        anim.SetFloat("Front", PlayerInput.Vertical);
        
        anim.SetFloat("Strafe",PlayerInput.Horizontal);
     //   if (player.canCrouch == true) ;
        if (PlayerInput.jump == 1)
            anim.SetBool("Jump", true);
        else
            anim.SetBool("Jump", false);
    }

    // Update is called once per frame
    void Update () {
        ChoseAnimState();
	}
    public void TakeDamage()
    {
        if (!isServer)
            return;
        player.Health -= Damage;
        print("DAMAGE RECEIVED");
        if (player.Health <= 0)
        {
            
            anim.SetTrigger("DeathStand");
            netanim.SetTrigger("DeathStand");
            StartCoroutine("Dead");
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
