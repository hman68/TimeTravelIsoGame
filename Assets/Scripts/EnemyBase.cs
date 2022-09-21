using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyBase
{
    /*
    This method may appear to be complicated at first glance, but an in depth look may reveal more.
    It acutaly uses an advanced technique called return true, so it will always return true.
    */
    bool isEnemy(){
        return true;
    }

    void takeDamage(float damage);
}
