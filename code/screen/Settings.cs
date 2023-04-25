using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoodFarm
{
    static class Settings
    {
        public static Texture2D Setting { get; set; }
        static Color color;

        static public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Setting, new Rectangle(500, 250, 896, 504), color);
        }

        static public void Update()
        {
            color = Color.White;
        }
    }
}
