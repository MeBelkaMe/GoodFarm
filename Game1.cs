using GoodFarm.models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GoodFarm.Sprites;
using System.Threading;
using GoodFarm.code.screen;
using System;

namespace GoodFarm
{
    enum Stat
    {
        Screen,
        Game,
        Exit,
        Pause,
        Settings
    }

    public class Game1 : Game
    {
        public int visota = 1920;
        public int shirina = 1080;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Stat Stat = Stat.Screen;
        private Camera _camera;

        private List<SpriteForPlayer> _sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = visota;
            _graphics.PreferredBackBufferHeight = shirina;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _camera = new Camera();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Screen.Background = Content.Load<Texture2D>("background1");
            display.Map = Content.Load<Texture2D>("map");
            Rock.TextureRock = Content.Load<Texture2D>("Stones/BigStone");
            Grass.TextureGrass = Content.Load<Texture2D>("Grass/Grass");
            Tree.TextureTree = Content.Load<Texture2D>("Trees/Big Tree");
            Settings.Setting = Content.Load<Texture2D>("Set");
            Screen.Bukovki = Content.Load<SpriteFont>("Bukovki");
            Screen.Font = Content.Load<SpriteFont>("SpriteFont");
            var animations = new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Nana/nanaUp1"), 4) },
                { "WalkDown", new Animation(Content.Load<Texture2D>("Nana/nanaDown1"), 4) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Nana/nanaLeft1"), 4) },
                { "WalkRight", new Animation(Content.Load<Texture2D>("Nana/nanaRight1"), 4) },
            };

            _sprites = new List<SpriteForPlayer>()
            {
                new SpriteForPlayer(new Dictionary<string, Animation>()
                {
                    { "WalkUp", new Animation(Content.Load<Texture2D>("Nana/nanaUp1"), 4) },
                    { "WalkDown", new Animation(Content.Load<Texture2D>("Nana/nanaDown1"), 4) },
                    { "WalkLeft", new Animation(Content.Load<Texture2D>("Nana/nanaLeft1"), 4) },
                    { "WalkRight", new Animation(Content.Load<Texture2D>("Nana/nanaRight1"), 4) },
                })
                {
                    Position = new Vector2(350, 350),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,
                    },
                },
            };

        }

        
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            switch (Stat)
            {
                case Stat.Screen:
                    Screen.Update();
                    if (keyboardState.IsKeyDown(Keys.Space))
                        Stat = Stat.Game;
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        Exit();
                    break;
                case Stat.Game:
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        Stat = Stat.Screen;
                        Thread.Sleep(100);
                    }
                    if (keyboardState.IsKeyDown(Keys.Tab))
                    {
                        Stat = Stat.Settings;
                    }
                    foreach (var sprite in _sprites)
                        sprite.Update(gameTime, _sprites);
                    break;
                case Stat.Settings:
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        {
                            Stat = Stat.Game;
                            Thread.Sleep(200);
                        }
                    break;
            }
            Screen.Update();
            display.Update();
            Settings.Update();
            RandomDrawer.Update();
            //_camera.Follow(); дописать камеру
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var rnd = new Random();
            var count = 0;

            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            switch(Stat)
            {
                case Stat.Screen:
                    Screen.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    display.Draw(_spriteBatch);
                    while (count < 10)
                    {
                        RandomDrawer.RandomDraw(_spriteBatch, count);
                        count++;
                    }
                    //_spriteBatch.Begin(transformMatrix: _camera.Transform);
                    foreach (var sprite in _sprites)
                        sprite.Draw(_spriteBatch);
                    break;
                case Stat.Settings:
                    Settings.Draw(_spriteBatch);

                    break;

                case Stat.Exit:
                    Exit();
                    break;
            }

           
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}