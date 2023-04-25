using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoodFarm.code.screen
{
    static class Screen
    {
        public static Texture2D Background { get; set; }
        static int timecounter = 0;
        static Color color;
        static Color color2;
        public static SpriteFont Font { get; set; }
        public static SpriteFont Bukovki { get; set; }

        static public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Background, new Rectangle(0, 0, 1920, 1080), color);
            _spriteBatch.DrawString(Font, "GOOD FARM", new Vector2(750, 400), Color.LightSteelBlue);
            _spriteBatch.DrawString(Bukovki, "НАЖМИТЕ ПРОБЕЛ ЧТОБЫ НАЧАТЬ", new Vector2(700, 950), color2);
        }

        static public void Update()
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timecounter);
            color2 = Color.FromNonPremultiplied(255, 255, 255, timecounter % 256);
            timecounter++;
        }
    }
}
