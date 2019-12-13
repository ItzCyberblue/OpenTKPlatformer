using System;
using System.Collections.Generic;

namespace OpenTK_RPG
{
    public class Spell
    {
        public string name = string.Empty;
        public DamageRange SpellDamageRange;
        public bool UseAnywhere;
        public string Description;
        public string type;
        public float Speed;
        public float cooldown;
        public float maxcooldown;
        public List<Bullet> Bullets = new List<Bullet>();
        public Spell( string name, string Description, DamageRange SpellDamageRange, bool UseAnywhere, string type, float Speed)
        {
            this.name = name;
            this.SpellDamageRange = SpellDamageRange;
            this.UseAnywhere = UseAnywhere;
            this.Description = Description;
            this.type = type;
            this.Speed = Speed;
        }
    }

    public class DamageRange
    {
        public int min = 0;
        public int max = 0;
        public DamageRange(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public class Bullet
    {
        public FloatCordinateVector2 Velocity;
        public FloatCordinateVector2 Position;
        
        public Bullet(FloatCordinateVector2 Position, string Direction, float Speed)
        {
            this.Position = Position;
            if (Direction == "RIGHT")
            {
                Velocity = new FloatCordinateVector2(Speed, 0.0f);
            }
        }
        
    }
}