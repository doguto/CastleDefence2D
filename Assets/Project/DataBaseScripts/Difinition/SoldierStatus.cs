using MessagePack;
using MasterMemory;

namespace Project.MasterDataScripts
{
    [MemoryTable("soldierstatus"), MessagePackObject(true)]
    public class SoldierStatus
    {
        [PrimaryKey] 
        public int Id { get; }
        public string Name { get; }
        public int Lv { get; }
        public int Hp { get; }
        public int Mp { get; }
        public int Attack { get; }
        public int MagicAttack { get; }
        public int Defense { get; }
        public int MagicDefense { get; }
        public int Agility { get; }

        
        public SoldierStatus(
            int id,
            string name,
            int lv,
            int hp,
            int mp,
            int attack,
            int magicAttack,
            int defense,
            int magicDefense,
            int agility
        )
        {
            Id = id;
            Name = name;
            Lv = lv;
            Hp = hp;
            Mp = mp;
            Attack = attack;
            MagicAttack = magicAttack;
            Defense = defense;
            MagicDefense = magicDefense;
            Agility = agility;
        }
    }
}