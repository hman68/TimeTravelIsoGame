using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float Damage;
    public float knockback;
    public float length;
    public float width;
    bool rtm = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MeleeAttack(){
        Debug.Log("melee");
        rtm = false;
        Vector3 pos = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z+1f);
        Collider[] cols = Physics.OverlapBox(pos, new Vector3(length,1f,width), this.gameObject.transform.rotation);
        foreach(Collider col in cols){
            
            if(col.gameObject.GetComponent<EnemyBase>() != null){
                Debug.Log(col);
                col.gameObject.SendMessage("takeDamage",Damage);
                col.attachedRigidbody.AddForce( this.gameObject.transform.rotation * Vector3.forward * knockback );
                col.gameObject.SendMessage("printSpeed");
                col.gameObject.SendMessage("startKnockback");
            }
        }
        yield return new WaitForSeconds(0.5f);
        rtm = true;
        yield break;
    }
}
