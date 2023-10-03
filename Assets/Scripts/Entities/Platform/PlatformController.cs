using System.Collections;
using UnityEngine;

using Outscal.UnityFundamentals.Mat2.GenericClasses.MVC;
using Outscal.UnityFundamentals.Mat2.ScriptableObjects;
using Outscal.UnityFundamentals.Mat2.Events;
using Outscal.UnityFundamentals.Mat2.Entities.Player;

namespace Outscal.UnityFundamentals.Mat2.Entities.Platform
{
    public class PlatformController : Controller<PlatformModel, PlatformScriptableObject, PlatformView> 
    {
        protected PlatformService service { get; set; }

        public bool IsActivated { get { return model.isActivated; } private set { model.isActivated = value; } }
        public bool CanActivate { get { return model.ScriptableObject.CanActivate; } }

        public PlatformController(PlatformScriptableObject platformScriptableObject, PlatformService platformService) : base(platformScriptableObject)
        {
            service = platformService;
            view = platformService.gameObject.GetComponent<PlatformView>();
            view.Controller = this;
        }

        internal void Start()
        {
            view.enabled = true;
            view.spriteRenderer.sprite = model.ScriptableObject.InitialSprite;
        }

        internal void OnCollisionEnter2D(Collision2D collision2D)
        {
            if(collision2D.gameObject.GetComponent<IPlayer>() != null) {
                if (model.ScriptableObject.CanActivate && !IsActivated)
                {
                    PlatformActivatedEventHandler.Instance.TriggerPlatformActivateEvent(this);

                    view.spriteRenderer.sprite = model.ScriptableObject.ActivatedSprite;
                    IsActivated = true;
                }
            }
        }

        protected override PlatformModel CreateCharacterModel(PlatformScriptableObject platformScriptableObject)
        {
            return new PlatformModel(platformScriptableObject);
        }
        protected override PlatformView InstantiateCharacterView(PlatformScriptableObject platformScriptableObject)
        {
            return null;
        }
    }
}