using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Timer : MonoBehaviour
{
    [Header("Time Scale")]
    private static Timer instance;
    public static Timer Instance { get { return instance; } }
    public bool isSlowMotion { get; private set; }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotionDuration = 0.5f; //슬로우 모션 지속 시간
    private float slowMotionTimer = 0f;   //타이머

    [Header("Post Processing")]
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ColorGrading colorGrading;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (isSlowMotion)
        {
            slowMotionTimer += Time.deltaTime;
            if (slowMotionTimer >= slowMotionDuration)
            {
                SetslowMotion(false);
                slowMotionTimer = 0f;
            }

        }
    }
    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f;
    }

    public void SetslowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            slowMotionTimer = 0f;
            vignette.intensity.value = 0.8f;         // 비네트 강도 대폭 증가
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // 채도 더욱 낮게
            colorGrading.temperature.value = -25f;    // 매우 차가운 색감
            colorGrading.contrast.value = 20f;        // 대비 더 강하게
            colorGrading.postExposure.value = -1.0f;  // 전체적으로 더 어둡게
            colorGrading.tint.value = 10f;           // 약간의 초록빛 추가
        }
        else
        {
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}
