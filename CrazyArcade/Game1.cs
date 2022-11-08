using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using CrazyArcade.Demo1;
using CrazyArcade.Singletons;

using CrazyArcade.Levels;

using CrazyArcade.CAFrameWork.CAGame;

using Microsoft.Xna.Framework.Audio;
using CrazyArcade.UI;

namespace CrazyArcade;

public class Game1 : Game, IGameDelegate
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public GUI gameGUI;
    public IScene scene;
    public LevelSchema Level1;
    public ReadJSON test;
    public SoundEffect backgroundMusic;
    public SoundEffectInstance backgroundMusicInstance;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SpriteSheet.Content = Content;
        //testing bug
        backgroundMusic = Content.Load<SoundEffect>("playground");
        backgroundMusicInstance = backgroundMusic.CreateInstance();

        backgroundMusicInstance.Pitch = 0.2f;
        backgroundMusicInstance.IsLooped = true;
        backgroundMusicInstance.Play();


    }

    protected override void Initialize()
    {
        //scene = new DemoScene(this, "Level_0.json", new Vector2(0,0));
        gameGUI = new GUI();
        TextureSingleton.LoadAllTextures(Content);
        


        test = new ReadJSON("Level_0.json",ReadJSON.fileType.LevelFile);
        Level1 = test.levelObject;


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
        GraphicsDevice.Clear(new Color(Level1.Background[0],Level1.Background[1], Level1.Background[2]));


        _spriteBatch.Begin();
        scene.Draw(gameTime, _spriteBatch);
        gameGUI.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
    }
}

