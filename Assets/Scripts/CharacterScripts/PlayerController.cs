using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public int Speed = 0;
    public LayerMask groundLayer;
    public bool isLocal = false;
   // public GameObject[] Particles;
    private CharacterController Character;
    [SyncVar]
    public float Health;
    public float Maxhealth;
    public bool canCrouch = false;
    InputScript PlayerInput;
    public RaycastHit GroundHit;
    [SerializeField]
    private Vector3 Nextpoint;
    private Vector3 Jumppoint;
    float distToGround;
    public GameObject WeaponHolder, playerHolder;
    public GameObject[] Weapons;
    public GameObject[] particles;
    Camera MainCam;
    public MouseLook points;
    public PlayerLook turns;
  
    void Start()
    {
        WeaponHolder = transform.Find("FPSVIEW").Find("Main Camera").gameObject;
        MainCam = transform.Find("FPSVIEW").Find("Main Camera").GetComponent<Camera>();
        Health = Maxhealth;
        distToGround = GetComponent<Collider>().bounds.extents.y;
        Character = GetComponent<CharacterController>();
        PlayerInput = GetComponent<InputScript>();
        if (!isLocalPlayer)
        {
            isLocal = false;
            playerHolder.layer = LayerMask.NameToLayer("Player");
            foreach (Transform child in playerHolder.transform)
                child.gameObject.layer = LayerMask.NameToLayer("Player");
            for (int i = 0; i < Weapons.Length; i++)
                Weapons[i].layer = LayerMask.NameToLayer("Player");
            WeaponHolder.layer = LayerMask.NameToLayer("Enemy");
            foreach (Transform child in WeaponHolder.transform)
                child.gameObject.layer = LayerMask.NameToLayer("Enemy");
            if(MainCam.isActiveAndEnabled)
            {
                MainCam.enabled = false;
            }
                points.enabled = false;
            turns.enabled = false;
        }

    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 2.0f);
    }

    void Update()
    {

        if (!isLocalPlayer)
        {
            print("not local player");
            return;
        }
        isLocal = true;

            Physics.Raycast(MainCam.transform.position, MainCam.transform.forward, out GroundHit);
         
                WeaponHolder.layer = LayerMask.NameToLayer("Player");
                foreach (Transform child in WeaponHolder.transform)
                    child.gameObject.layer = LayerMask.NameToLayer("Player");
              if (IsGrounded())
                {
                    canCrouch = true;
                
                }
              else
                {
                    PlayerInput.jump = 0;

                    canCrouch = false;
                }
                Jumppoint = (transform.up * Time.deltaTime * Speed * PlayerInput.jump) - (transform.up * Time.deltaTime * Speed / 2);
                Nextpoint = (transform.forward * PlayerInput.Vertical * 2 * Time.deltaTime * Speed) + (transform.right * PlayerInput.Horizontal * Time.deltaTime * Speed);
                Character.Move(Nextpoint * 10);
                Character.Move(Jumppoint * 20);
                points.enabled = true;
                turns.enabled = true;
            }
    }
 

   

