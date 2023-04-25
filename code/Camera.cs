using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodFarm.Sprites;

namespace GoodFarm
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(SpriteForCamera target)
        {
            var position = Matrix.CreateTranslation(
              -target.Position.X - (target.Rectangle.Width / 2),
              -target.Position.Y - (target.Rectangle.Height / 2),
              0);

            var offset = Matrix.CreateTranslation(
                1080 / 2,
                1920 / 2,
                0);

            Transform = position * offset;
        }
    }
}
