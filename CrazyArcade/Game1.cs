using CrazyArcade.CAFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.DemoStage;
using CrazyArcade.CAFrameWork.Singleton;

namespace CrazyArcade;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Stage currentStage;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        Graphics.Content = Content;
        IsMouseVisible = true;
        currentStage = new MyDemoStage();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        currentStage.Batch = _spriteBatch;
        currentStage.Load();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Input.Keyboard = Keyboard.GetState();
        Input.Mouse = Mouse.GetState();
        // TODO: Add your update logic here
        currentStage.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        currentStage.Draw(gameTime);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

