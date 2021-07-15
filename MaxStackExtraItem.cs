using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace MaxStackExtra
{
    public class MaxStackExtraItem : GlobalItem
    {

        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            var cfg = ModContent.GetInstance<MaxStackExtraConfig>();
            if (!(item.type == ItemID.CopperCoin || item.type == ItemID.SilverCoin || item.type == ItemID.GoldCoin || item.type == ItemID.PlatinumCoin))
            {
                if (item.maxStack > 1)
                {
                    if (item.createTile > TileID.Dirt)
                        item.maxStack = cfg.TileStackValue;
                    else
                        item.maxStack = cfg.ItemStackValue;
                }
                else if (item.accessory || item.defense > 0)
                    item.maxStack = cfg.EquipStackValue;
                else if (item.damage > 0)
                    item.maxStack = cfg.WeaponStackValue;
                else
                    item.maxStack = cfg.SpecialStackValue;
            }
        }
    }
}
