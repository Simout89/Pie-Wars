using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "SelfDetonationSkill", menuName = "ScriptableObjects/SelfDetonationSkill", order = 1)]
public class SelfDetonationSkill : SkillBase
{
    [SerializeField] private float damage = 60;
    [SerializeField] private float explosionRadius = 1.5f;
    [SerializeField] private float delay = 5;

    private bool _canUseSkill = true;
    
    private void OnEnable()
    {
        _canUseSkill = true;
    }
    
    public override void UseSkill(Vector3 explosionCenter)
    {
        if (_canUseSkill)
        {
            Debug.Log(1);
            SkillCastAsync(explosionCenter, Application.exitCancellationToken).Forget();
        }
    }

    private async UniTask SkillCastAsync(Vector3 explosionCenter, CancellationToken cancellationToken)
    {
        _canUseSkill = false;
        Debug.Log(2);

        Collider[] hitColliders = Physics.OverlapSphere(explosionCenter, explosionRadius);

        foreach (var hit in hitColliders)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.transform.position != explosionCenter)
            {
                Debug.Log(unit.gameObject.name);
                
                unit.GetDamage(damage);
            }
        }
        
        CreateExplosionEffect(explosionCenter, explosionRadius);

        await UniTask.WaitForSeconds(delay, cancellationToken: cancellationToken);

        _canUseSkill = true;
    }
    
    private void CreateExplosionEffect(Vector3 center, float radius)
    {
        GameObject explosionEffect = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        explosionEffect.transform.position = center;
        explosionEffect.transform.localScale = Vector3.one * radius * 2;
    
        // Сделать полупрозрачным красным
        Renderer renderer = explosionEffect.GetComponent<Renderer>();
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(1f, 0f, 0f, 0.3f);
        material.SetFloat("_Mode", 3); // Transparent mode
        renderer.material = material;
    
        // Удалить через 1 секунду
        Object.Destroy(explosionEffect, 1f);
    }
}
