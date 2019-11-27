using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyMultiplayerProject
{
    public class PlayerUi : MonoBehaviour
    {
        #region Private Fields
        private PlayerManager target;
        [Tooltip("Pixel Offset from the player target")]
        [SerializeField]
        private Vector3 screenOffset = new Vector3(0f, 30f, 0f);

        [Tooltip("UI Text to display Player's Name")]
        [SerializeField]
        private Text playerNameText;

        [Tooltip("UI Slider to display Player's Health")]
        [SerializeField]
        private Slider playerHealthSlider;

        float characterControllerHeight = 0f;
        Transform targetTransform;
        Renderer targetRenderer;
        CanvasGroup _canvasGroup;
        Vector3 targetPosition;
        #endregion Private Fields

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _canvasGroup = this.GetComponent<CanvasGroup>();
        }
        private void Update()
        {
            if (playerHealthSlider != null) 
            {
                playerHealthSlider.value = target.Health;
            }
            //destroy self if target is null
            if (target == null) 
            {
                Destroy(this.gameObject);
                return;
            }
        }
        private void LateUpdate()
        {
            //Do not show the ui if we are not visible to the camera.
            if (targetRenderer != null) 
            {
                this._canvasGroup.alpha = targetRenderer.isVisible ? 1f : 0f;
            }
            //CRITICAL Follow the target gameObject on screen
            if (target.transform != null) 
            {
                targetPosition = target.transform.position;
                targetPosition.y = characterControllerHeight;
                this.transform.position = Camera.main.WorldToScreenPoint(targetPosition) + screenOffset;
            }
        }
        #endregion
        #region Public Methods
        public void SetTarget(PlayerManager _target) 
        {
            if (_target == null) 
            {
                Debug.LogError("EEEE Xorioooo : Missing Player");
                return;
            }
            target = _target;
            if (playerNameText != null) 
            {
                playerNameText.text = target.photonView.Owner.NickName;
            }
            targetTransform = this.target.GetComponent<Transform>();
            targetRenderer = this.target.GetComponent<Renderer>();
            CharacterController characterController = _target.GetComponent<CharacterController>();

            if (characterController != null) 
            {
                characterControllerHeight = characterController.height;
            }
        }
        #endregion
    }
}
