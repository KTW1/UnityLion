using UnityEngine;
using TMPro;
using Watermelon.JellyMerge;

namespace Watermelon
{
    public class UIComplete : UIPage
    {
        [SerializeField] TMP_Text lableText;
        [SerializeField] UIFadeAnimation backFadeAnimation;
        [SerializeField] UIScaleAnimation lableScaleAnimation;

        public override void Init()
        {
        }

        #region Show/Hide
        public override void PlayShowAnimation()
        {
            lableText.text = "LEVEL " + (GameController.CurrentLevelIndex + 1) + "\nCOMPLETE";

            backFadeAnimation.Show(0.2f);
            lableScaleAnimation.Show(duration: 0.25f);

            UIController.OnPageOpened(this);
        }

        public override void PlayHideAnimation()
        {
            backFadeAnimation.Hide(0.1f);
            lableScaleAnimation.Hide(duration: 0.1f);

            UIController.OnPageClosed(this);
        }
        #endregion
    }
}
