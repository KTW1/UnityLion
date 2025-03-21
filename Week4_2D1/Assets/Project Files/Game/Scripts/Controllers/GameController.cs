using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Watermelon;

namespace Watermelon.JellyMerge
{
    public class GameController : MonoBehaviour
    {
        private static GameController instance;

        [SerializeField] LevelsDatabase levelsDatabase;
        [SerializeField] UIController uiController;
        [SerializeField] MusicSource musicSource;

        [Space(5)]
        public int levelNumberDev = 1;

        private static ParticlesController particlesController;

        private Level currentLevel;

        private SimpleIntSave currentLevelIndexSave;

        public static int CurrentLevelIndex
        {
            get { return instance.currentLevelIndexSave.Value; }
            private set { instance.currentLevelIndexSave.Value = value; }
        }

        private void Awake()
        {
            instance = this;

            CacheComponent(out particlesController);

            currentLevelIndexSave = SaveController.GetSaveObject<SimpleIntSave>("current_level_index");

            musicSource.Init();
            musicSource.Activate();

            levelsDatabase.Init();

            uiController.Init();
            particlesController.Init();

            uiController.InitPages();
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            currentLevel = LevelsDatabase.GetLevel(CurrentLevelIndex);

            LevelController.Load(currentLevel);

            UIController.ShowPage<UIMainMenu>();

            ColorsController.SetRandomPreset();

            if (CurrentLevelIndex < 2)
            {
                StartCoroutine(TutorialCoroutine());
            }

            SavePresets.CreateSave("Level " + (CurrentLevelIndex + 1).ToString("000"), "Levels");
        }

        public static void OnLevelComplete()
        {
            // Play swipe sound
            AudioController.PlaySound(AudioController.AudioClips.gameWinClip);

            UIController.HidePage<UIGame>();
            UIController.ShowPage<UIComplete>();

            CurrentLevelIndex++;
            SaveController.MarkAsSaveIsRequired();

            if (CurrentLevelIndex < 2)
            {
                UIGame gameUI = UIController.GetPage<UIGame>();
                gameUI.HideTutorialPanel();
            }

            Tween.DelayedCall(1.5f, delegate
            {
                AdsManager.ShowInterstitial(delegate
                {
                    UIController.HidePage<UIComplete>();
                    instance.StartGame();
                });
            });
        }

        private IEnumerator TutorialCoroutine()
        {
            UIGame gameUI = UIController.GetPage<UIGame>();
            if (CurrentLevelIndex == 0)
            {
                gameUI.ShowTutorialPanel(false);
                yield break;
            }
            else if (CurrentLevelIndex == 1)
            {
                yield return new WaitForSeconds(4f);
                gameUI.ShowTutorialPanel(true);
            }

            WaitForSeconds delay = new WaitForSeconds(0.5f);

            while (CurrentLevelIndex < 2)
            {
                yield return delay;
            }

            gameUI.HideTutorialPanel();
        }

        public static void OnTapPerformed()
        {
            UIController.HidePage<UIMainMenu>();
            UIController.ShowPage<UIGame>();
        }

        public static void Restart()
        {
            LevelController.Restart();
        }

        [Button("Load level")]
        public void LoadLevelDev()
        {
            CurrentLevelIndex = Mathf.Clamp(levelNumberDev - 1, 0, int.MaxValue);

            currentLevel = LevelsDatabase.GetLevel(CurrentLevelIndex);
            LevelController.Load(currentLevel);

            UIController.ShowPage<UIMainMenu>();
            UIController.HidePage<UIGame>();
            UIController.HidePage<UIComplete>();

            if (CurrentLevelIndex < 2)
            {
                StartCoroutine(TutorialCoroutine());
            }
        }

        public static void LoadLevelDev(int index)
        {
            if (index >= 2)
            {
                UIGame gameUI = UIController.GetPage<UIGame>();
                gameUI.HideTutorialPanel();
            }

            instance.levelNumberDev = index + 1;
            instance.LoadLevelDev();
        }

        #region Extensions
        public bool CacheComponent<T>(out T component) where T : Component
        {
            Component unboxedComponent = gameObject.GetComponent(typeof(T));

            if (unboxedComponent != null)
            {
                component = (T)unboxedComponent;

                return true;
            }

            Debug.LogError(string.Format("Scripts Holder doesn't have {0} script added to it", typeof(T)));

            component = null;

            return false;
        }
        #endregion
    }
}