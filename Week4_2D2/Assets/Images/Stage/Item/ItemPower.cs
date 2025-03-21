using UnityEngine;

public class ItemPower : MonoBehaviour
{
    public float ItemVeclocity = 100f;
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVeclocity, ItemVeclocity,0f));
    }

    void Update()
    {
        
    }
}
