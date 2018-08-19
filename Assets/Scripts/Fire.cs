using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour
{
    WeaponManager weapons_manager;
    public GameObject impact;
    InputScript PlayerInput;
    public float firerate;
    private PlayerController cont;
   public  bool isfiring = true;
    public GameObject muzzle;
    Animator anim;
    GameObject crosshair;
    CrossHairController cross;
    GameObject Player;
    public float Damage;
    AnimatinController anim_controller;
    public AudioSource fire;
    // Use this for initialization
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        cross = crosshair.GetComponent<CrossHairController>();
        weapons_manager = weapons_manager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        cont = Player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        PlayerInput = Player.GetComponent<InputScript>();
        fire = GetComponent<AudioSource>();
        impact = cont.particles[0];
        anim_controller = Player.GetComponent<AnimatinController>();
    }
    void Update()
    {
        if (PlayerInput.fire == 1)
        {
            muzzle.SetActive(true);
           if (isfiring)
            {
                anim.SetBool("Shooting", true);
                StartCoroutine(Sound());
            }
            isfiring = false;
        }
        else
        {
            anim.SetBool("Shooting", false);
            muzzle.SetActive(false);
        }
 }
    IEnumerator Sound()
    {
        fire.Play();
        if (!cont.GroundHit.collider)
        {

        }
        else if (cont.GroundHit.collider.gameObject.tag == "Concrete")
        {
            impact = cont.particles[0];
        }
        else if (cont.GroundHit.collider.gameObject.tag == "Woods")
        {
            impact = cont.particles[1];
        }
        else if (cont.GroundHit.collider.gameObject.tag == "Metal")
        {
            impact = cont.particles[2];
        }
        else if (cont.GroundHit.collider.gameObject.tag == "Player")
        {
            anim_controller.Damage = Damage;
            anim_controller.TakeDamage();
            impact = cont.particles[3];
            CmdDealDamage(cont.gameObject);
        }
        if (cont.isLocal)
            Instantiate(impact, cont.GroundHit.point, Quaternion.LookRotation(cont.GroundHit.normal));
        yield return new WaitForSeconds(firerate);
        isfiring = true;
    }
        [Command]
        void CmdDealDamage(GameObject obj)
    {
        print("Damage Dealt");
        obj.GetComponent<PlayerController>().Health -= 10;
    }
}


        
       
   
        
    

