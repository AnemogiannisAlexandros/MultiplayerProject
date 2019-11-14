using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyMultiplayerProject
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        [SerializeField]
        private float directionDampTime = 0.25f;

        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            if (!animator) 
            {
                Debug.LogError("Player Manager is Missing Animator Component", this);
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (!animator) 
            {
                return;
            }
            AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateinfo.IsName("Base Layer.Run")) 
            {
                if (Input.GetButtonDown("Fire2")) 
                {
                    animator.SetTrigger("Jump");
                }
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0) 
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
        }
    }
}
