using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEditor.EventSystems;
using Unity.VisualScripting;

public class ThirdPersonShootingController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivty;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletposition;

    private StarterAssetsInputs StarterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    private void Awake()
    {
        StarterAssetsInputs= GetComponent<StarterAssetsInputs>();
        thirdPersonController= GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition =Vector3.zero;
        Vector2 screenCenterPoint = new Vector2 (Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }


        if (StarterAssetsInputs.aim) 
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivitty(aimSensitivty);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetBool("IsPistol",true);
            
                
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget-transform.position).normalized;
        }

        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivitty(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetBool("IsPistol", false);
        }

        if (StarterAssetsInputs.shoot)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletposition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletposition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            StarterAssetsInputs.shoot=false;
            
        }

        
        
      
    }

}
