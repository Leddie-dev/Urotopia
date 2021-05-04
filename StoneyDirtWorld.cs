using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.IO;


namespace UrotopiaMod
{
    public class StoneyDirtWorld : ModWorld
    {


        #region GENERATION

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(GenPass => GenPass.Name.Equals("Shinies"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Stoney Dirt Spawn", GenerateStoneyDirt));
            }
        }

        private void GenerateStoneyDirt(GenerationProgress progress)
        {
            progress.Message = "Fancying up the dirt";
            for (var i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 500);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6),
                    ModContent.TileType<Tiles.StoneyDirt.StoneyDirt>());
            }
        }

        #endregion
    }
}
