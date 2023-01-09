using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { SHORT_RANGE, MEDIUM_RANGE, LONG_RANGE }
    public WeaponType weaponType { get; set; }
    public string Name { get; set; }
    public int Bullets { get; private set; }
    public float BulletSpeed { get; private set; }
    public float Damage { get; private set; }
    public float Dispersion { get; private set; }
    public int Price { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return $"Name: {Name}";
    }


}
