using UnityEngine;

[System.Flags]
public enum EnemyTag
{
    None = 0,
    Virus = 1 << 0,  // 1
    Worm = 1 << 1,  // 2
    Trojan = 1 << 2,  // 4
    SqlInjection = 1 << 3, // 8
    Dos = 1 << 4,  // 16
    Spyware = 1 << 5,  // 32
    Ddos = 1 << 6,  // 64
    Ransomware = 1 << 7,  // 128
    Polymorphic = 1 << 8, // 256
    SupplyChain = 1 << 9, // 512
    Rootkit = 1 << 10,  // 1024
    ZeroDay = 1 << 11, // 2048
}
