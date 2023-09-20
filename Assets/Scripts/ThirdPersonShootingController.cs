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
   // [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletposition;
    [SerializeField] Camera _mainCamera;
    [SerializeField] private GameObject AimImage;
    public float RotationSmoothTime = 0.05f;
    float _rotationVelocity;
    private bool shotdelay=true;
    private StarterAssetsInputs StarterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    private void Awake()
    {
        StarterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
           // debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }


        if (StarterAssetsInputs.aim)
        {
            Aim(mouseWorldPosition);
            if (StarterAssetsInputs.shoot && StarterAssetsInputs.aim&&shotdelay)
            {
                shotdelay = false;
                Vector3 aimDir = (mouseWorldPosition - spawnBulletposition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletposition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                StartCoroutine(WaitForIt());
                StarterAssetsInputs.shoot = false;
                
            }
        }

        else
        {
            StarterAssetsInputs.shoot = false;
            AimImage.gameObject.SetActive(false);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            // animator.SetBool("IsPistol", false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }


    }

    private void Aim(Vector3 mouseWorldPosition)
    {
        //animator.SetBool("IsPistol", true);
        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetSensitivity(aimSensitivty);
        thirdPersonController.SetRotateOnMove(false);
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        AimImage.gameObject.SetActive(true);

        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        float _targetRotation = Mathf.Atan2(0f, 0f) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
             RotationSmoothTime);

        // rotate to face input direction relative to camera position
        transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        shotdelay = true;
        
    }


 
 

}
