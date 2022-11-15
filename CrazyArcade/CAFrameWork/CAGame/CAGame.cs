using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.Demo1;
using CrazyArcade.Singletons;
using System;
using CrazyArcade.Levels;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.Transition;
using Microsoft.Xna.Framework.Audio;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Loading;
using CrazyArcade.CAFrameWork.GameStates;
using Microsoft.Xna.Framework.Media;

namespace CrazyArcade;

public class CAGame : Game, IGameDelegate, ITransitionCompleteHandler
{
    static Vector2 StageOffset = new Vector2(200, 15);
    static Vector2 transitionDisplacement = new Vector2(800, 0);
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public GUI gameGUI;
    public ISceneState scene;
    public LevelSchema CurrentLevel;
    public ReadJSON test;
    public ReadJSON map;
    public String[] LevelSongTitles;
    public SoundEffect backgroundMusic;
    public SoundEffectInstance backgroundMusicInstance;
    //Random for test purposes and counter
    Random rnd = new Random();
    int newElements = 0;
    //
    private ITransition transition = null;
    string[] levelFileNames;
    //-------test-----------
    int stageNum = 0;
    //----------------------
    public CAGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SpriteSheet.Content = Content;
        //Load it here
        backgroundMusic = Content.Load<SoundEffect>("playground");
        backgroundMusicInstance = backgroundMusic.CreateInstance();

    }
    public ISceneState Scene
    {
        get { return scene; }
        set { scene = value; }
    }
    public void NewInstance()
    {
        this.Initialize();
    }
    public void Quit()
    {
        base.Exit();
    }
    protected override void Initialize()
    {
        gameGUI = new GUI();
        UI_Singleton.internalGUI = gameGUI;
        scene = new DemoScene(this, "Level_0.json", StageOffset);
        TextureSingleton.LoadAllTextures(Content);
        //TestLoad guiLoad = new TestLoad();
        //guiLoad.LoadGUI();
        song = Content.Load<Song>("playground");
        MediaPlayer.Play(song);
        test = new ReadJSON("Level_0.json", ReadJSON.fileType.LevelFile);
        CurrentLevel = test.levelObject;

        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        
        //Load it here
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        _spriteBatch = new SpriteBatch(GraphicsDevice);
        test = new ReadJSON("Level_0.json", ReadJSON.fileType.LevelFile);
        CurrentLevel = test.levelObject;
        map = new ReadJSON("Map.json", ReadJSON.fileType.MapFile);
        levelFileNames = map.mapObject.Levels;
        new TestLoad().LoadGUI();
        UI_Singleton.ChangeComponentText("levelCounter", "text", "Level " + stageNum);
        scene.Load();
    }

    protected override void Update(GameTime gameTime)
    {
        if(scene is not DemoScene)
        {
            scene.Update(gameTime);
            return;
        }
        if (transition != null)
        {
            transition.Update(gameTime);
        } else
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && stageNum > 0)
            {
                stageNum--;
                makeTransition(gameTime, -transitionDisplacement);

                backgroundMusicInstance.Stop();
                backgroundMusic = Content.Load<SoundEffect>(LevelSongTitles[stageNum]);
                backgroundMusicInstance = backgroundMusic.CreateInstance();
                backgroundMusicInstance.Pitch = 0.2f;
                backgroundMusicInstance.IsLooped = true;
                backgroundMusicInstance.Play();
                new TestLoad().LoadGUI();
                UI_Singleton.ChangeComponentText("levelCounter","text", "Level " + stageNum);
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed && stageNum < levelFileNames.Length-1)
            {
                stageNum++;
                makeTransition(gameTime, transitionDisplacement);

                backgroundMusicInstance.Stop();
                backgroundMusic = Content.Load<SoundEffect>(LevelSongTitles[stageNum]);
                backgroundMusicInstance = backgroundMusic.CreateInstance();
                backgroundMusicInstance.Pitch = 0.2f;
                backgroundMusicInstance.IsLooped = true;
                backgroundMusicInstance.Play();
                new TestLoad().LoadGUI();
                UI_Singleton.ChangeComponentText("levelCounter", "text", "Level " + stageNum);
            }
            scene.Update(gameTime);
        }
        base.Update(gameTime);
    }
    private void makeTransition(GameTime gameTime, Vector2 displacement)
    {
        ISceneState newState = new DemoScene(this, levelFileNames[stageNum], StageOffset);
        newState.Load();
        newState.StageOffset += displacement;
        transition = new CATransition(this.scene,
            newState, displacement, gameTime, new TimeSpan(0, 0, 1));
        transition.Handler = this;
        test = new ReadJSON(levelFileNames[stageNum], ReadJSON.fileType.LevelFile);
        CurrentLevel = test.levelObject;
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(CurrentLevel.Background[0], CurrentLevel.Background[1], CurrentLevel.Background[2]));


        _spriteBatch.Begin();
        if (transition != null)
        {
            transition.Draw(gameTime, _spriteBatch);
        } else
        {
            scene.Draw(gameTime, _spriteBatch);
        }
        gameGUI.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
    }

    public void Complete(ISceneState oldState, ISceneState newState)
    {
        scene = newState;
        newState.StageOffset = StageOffset;
        newState.Camera = new Vector2(0, 0);
        transition = null;
    }
}

