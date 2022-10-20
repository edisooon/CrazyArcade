using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.Demo1;
using CrazyArcade.Singletons;
using CrazyArcade.BombFeature;
using System;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using CrazyArcade.Enemy;
using CrazyArcade.Items;

namespace CrazyArcade;


public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public IScene scene;
    //private GameWindow window;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SpriteSheet.Content = Content;
        //window = base.Window;
        
    }

    protected override void Initialize()
    {
        scene = new DemoScene(this);
        TextureSingleton.LoadAllTextures(Content);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        scene.Load();
    }

    protected override void Update(GameTime gameTime)
    {

        scene.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.SkyBlue);

        _spriteBatch.Begin();

        scene.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
    }
}

