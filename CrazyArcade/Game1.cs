using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace CrazyArcade;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ISprite sprite1;
    private ISprite sprite2;
    private ISprite sprite3;
    private ISprite sprite4;
    private ISprite sun;
    
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content"; 
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        TextureSingleton.LoadAllTextures(this.Content);
        sun = new SunEnemySprite(150,150);
        sprite1 = new StarProjectileSprite(100,100,1,1);
        sprite2 = new StarProjectileSprite(100,100,-1,1);
        sprite3 = new StarProjectileSprite(100,100,1,-1);
        sprite4 = new StarProjectileSprite(100,100,-1,-1);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        sun.Load();
        sprite1.Load();
        sprite2.Load();
        sprite3.Load();
        sprite4.Load();

        //scene1.AddEntity(new TestBlock());
      
    }

    protected override void Update(GameTime gameTime)
    {
        sun.Update(gameTime);
        sprite1.Update(gameTime);
        sprite2.Update(gameTime);
        sprite3.Update(gameTime);
        sprite4.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        sun.Draw(gameTime, _spriteBatch);
        sprite1.Draw(gameTime, _spriteBatch);
        sprite2.Draw(gameTime, _spriteBatch);
        sprite3.Draw(gameTime, _spriteBatch);
        sprite4.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
    }
}

