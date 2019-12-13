using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTK_RPG
{
    public class Player
    {
        public List<Item> Inventory = new List<Item>();
        public List<Spell> AllSpells = new List<Spell>();
        public List<Spell> EquippedSpells = new List<Spell>();
        
        
        public FloatCordinateVector2 PositionVector = new FloatCordinateVector2(400, 300);


        public string directionFacing = "RIGHT";
        
        public Player()
        {
            
        }

        void AddToInventory(Item newItemToAdd)
        {
            this.Inventory.Append(newItemToAdd);
        }

        void ShootSpell(Spell SpellToShoot)
        {
            SpellToShoot.Bullets.Append(new Bullet(this.PositionVector, this.directionFacing, SpellToShoot.Speed));
        }
    }
}