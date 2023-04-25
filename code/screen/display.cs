using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GoodFarm.Sprites;
using System;
using System.Collections.Generic;

namespace GoodFarm.code.screen
{
    class display
    {
        public static Texture2D Map { get; set; }
        static Color color;

        static public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Map, new Rectangle(0, 0, 1920, 1080), color);
        }

        static public void Update()
        {
            color = Color.White;
        }
    }

    class Grass
    {
        public static Texture2D TextureGrass { get; set; }
    }
    class Tree
    {
        public static Texture2D TextureTree { get; set; }
    }

    class Rock
    { 
        public static Texture2D TextureRock { get; set; }
    }

    class RandomDrawer
    {
        public static Color color;
        public static Random rnd = new Random();
        public static List<Texture2D> list = new List<Texture2D>()
        {
            Rock.TextureRock,
            Tree.TextureTree,
            Grass.TextureGrass
        };
        private static List<Texture2D> result = new List<Texture2D>();
        public static List<Texture2D> listOfTextures = new List<Texture2D>()
        {
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)],
            list[rnd.Next(list.Count - 1)]
        };
        public static List<Vector2> listOfVectors = new List<Vector2>()
        {
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
            new Vector2(rnd.Next(200, 1850), rnd.Next(0, 800)),
        };
        static public void RandomDraw(SpriteBatch _spriteBatch, int i)
        {
            _spriteBatch.Draw(listOfTextures[i], listOfVectors[i], color);

        }
        static public void Update()
        {
            color = Color.White;
        }
    }
}