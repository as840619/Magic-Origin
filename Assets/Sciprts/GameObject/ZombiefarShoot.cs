using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiefarShoot : EnemyShooting
{
    

    void Start()
    {
    }

    void Update()
    {

        // 在这里执行子类的特定逻辑
        // 例如重写父类的方法或添加新的逻辑

        // 调用父类的 Shoot 方法，并在其基础上添加额外的逻辑
        Shoot();
    }

    // 重写父类的 Shoot 方法
    void Shoot()
    {
        // 使用 base 关键字来调用父类的方法

        // 在这里添加子类特有的逻辑或修改 Shoot 方法的行为
        // 例如，添加子类特有的射击行为
    }
}
