using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class RifleEffectsHandler : MonoBehaviour
{
    [Tooltip("List of Transforms representing the small parts of the rifle after a shot")]
    public Transform[] parts;
    [Tooltip("Part offset after the shot is fired")]
    public Vector3 partOffset;
    [Tooltip("Animation curve handling the speed of the parts")]
    public AnimationCurve animationCurve;
    [Tooltip("Speed of the animation on shoot")]
    [Range(0.1f, 10f)]
    public float animationSpeed = 1f;

    WeaponController m_Weapon;
    bool m_IsAnimating;
    float m_AnimationDuration;
    float m_AnimationStartTime;

    void Start()
    {
        m_Weapon = GetComponent<WeaponController>();
        DebugUtility.HandleErrorIfNullGetComponent<WeaponController, WeaponFuelCellHandler>(m_Weapon, this, gameObject);

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].localPosition = Vector3.zero;
        }

        m_Weapon.onShoot += HandleShoot;
    }

    void Update()
    {
        if (m_IsAnimating)
        {
            float timeRatio = (Time.time - m_AnimationStartTime) / m_AnimationDuration;

            for (int i = 0; i < parts.Length; i++)
            {
                Vector3 positionOffset = (parts.Length - i) * partOffset;
                parts[i].localPosition = Vector3.Lerp(Vector3.zero, positionOffset, animationCurve.Evaluate(timeRatio));
            }

            if (timeRatio >= 1f)
            {
                m_IsAnimating = false;
            }
        }
    }

    void HandleShoot()
    {
        m_AnimationStartTime = Time.time;
        var reloadDuration = 1f / Mathf.Max(0.0001f, m_Weapon.ammoReloadRate);
        m_AnimationDuration = m_Weapon.delayBetweenShots + m_Weapon.ammoReloadDelay + reloadDuration;
        m_AnimationDuration = Mathf.Max(0.0001f, m_AnimationDuration) / animationSpeed;
        m_IsAnimating = true;
    }
}
