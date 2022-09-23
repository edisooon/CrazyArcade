using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.Demo1;
using CrazyArcade.Singletons;

namespace CrazyArcade;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IScene scene;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SpriteSheet.LoadAllTextures(Content);
        TextureSingleton.LoadAllTextures(this.Content);
        scene = new DemoScene();
        //scene1.AddEntity(new TestBlock());
        scene.Load();
    }

    protected override void Update(GameTime gameTime)
    {

        scene.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        scene.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
    }
}

