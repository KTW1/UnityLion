using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Watermelon
{
    public class UIMainMenu : UIPage
    {
        [SerializeField] CanvasGroup promptToStartGroup;

        private TweenCase fadeTween;

        public override void Init()
        {

        }

        #region Show/Hide

        public override void PlayShowAnimation()
        {
            promptToStartGroup.alpha = 0;

            fadeTween.KillActive();
            fadeTween = promptToStartGroup.DOFade(1f, 0.3f).SetEasing(Ease.Type.SineInOut);

            UIController.OnPageOpened(this);
        }

        public override void PlayHideAnimation()
        {
            fadeTween.KillActive();
            fadeTween = promptToStartGroup.DOFade(0f, 0.3f).SetEasing(Ease.Type.SineInOut);

            UIController.OnPageClosed(this);
        }

        #endregion

        #region Buttons

        public void TapToPlayButton()
        {
            AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        }

        #endregion
    }


}
