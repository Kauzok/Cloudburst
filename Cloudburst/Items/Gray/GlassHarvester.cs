﻿using System;
using System.Collections.Generic;
using System.Text;
using R2API;
using RoR2;
using UnityEngine;

namespace Cloudburst.Items.Gray
{
    internal class GlassHarvester
    {
        public static ItemDef glassHarvesterItem;
        public static void Setup()
        {
            glassHarvesterItem = ScriptableObject.CreateInstance<ItemDef>();
            glassHarvesterItem.tier = ItemTier.Tier1;
            glassHarvesterItem.name = "itemexponhit";
            glassHarvesterItem.nameToken = "ITEM_EXPONHIT_NAME";
            glassHarvesterItem.pickupToken = "ITEM_EXPONHIT_PICKUP";
            glassHarvesterItem.descriptionToken = "ITEM_EXPONHIT_DESCRIPTION";
            glassHarvesterItem.loreToken = "ITEM_EXPONHIT_LORE";
            glassHarvesterItem.pickupIconSprite = Cloudburst.CloudburstAssets.LoadAsset<Sprite>("texGlassHarvester");
            glassHarvesterItem.pickupModelPrefab = Cloudburst.OldCloudburstAssets.LoadAsset<GameObject>("IMDLHarvester");
            glassHarvesterItem.requiredExpansion = Cloudburst.cloudburstExpansion;
            
            ContentAddition.AddItemDef(glassHarvesterItem);

            LanguageAPI.Add("ITEM_EXPONHIT_NAME", "Glass Harvester");
            LanguageAPI.Add("ITEM_EXPONHIT_PICKUP", "Gain experience on hit.");
            LanguageAPI.Add("ITEM_EXPONHIT_DESCRIPTION", "Gain 3 <style=cStack>(+2 per stack)</style> points of <style=cIsUtility>experience</style> on hit.");
            LanguageAPI.Add("ITEM_EXPONHIT_LORE", "Does it harvest glass or does it harvest with glass?\nI don't know and I don't care get out of my house"); ;

            RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private static void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if(sender && sender.inventory)
            {
                int itemCount = sender.inventory.GetItemCount(glassHarvesterItem);
                args.critAdd += itemCount > 0 ? 5 : 0;
                args.critDamageMultAdd += itemCount > 0 ? itemCount * 30 + 10 : 0;
            }
        }

    }
}
