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
using CrazyArcade.Enemies;
using CrazyArcade.Levels;
using System.Diagnostics;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.CAFrameWork.GameStates;

namespace CrazyArcade;

public class CAGame : Game, IGameDelegate, ITransitionCompleteHandler
{
    static Vector2 StageOffset = new Vector2(200, 15);
    static Vector2 transitionDisplacement = new Vector2(800, 0);
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public ISceneState scene;
    public LevelSchema Level1;
    public ReadJSON test;
    private ITransition transition = null;
    string[] levelFileNames = {
        "Level_0.json",
        "Level_1.json",
        "Level_2.json"
    };
    //-------test-----------
    int stageNum = 0;
    //----------------------
    public CAGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SpriteSheet.Content = Content;

    }
    public void NewInstance()
    {
        this.Initialize();
    }
    protected override void Initialize()
    {
        scene = new DemoScene(this, "Level_0.json", StageOffset);
        TextureSingleton.LoadAllTextures(Content);


        test = new ReadJSON("Level_0.json", ReadJSON.fileType.LevelFile);
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
        if (transition != null)
        {
            transition.Update(gameTime);
        } else
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && stageNum > 0)
            {
                stageNum--;
                makeTransition(gameTime, -transitionDisplacement);
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed && stageNum < 2)
            {
                stageNum++;
                makeTransition(gameTime, transitionDisplacement);
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
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(Level1.Background[0], Level1.Background[1], Level1.Background[2]));


        _spriteBatch.Begin();
        if (transition != null)
        {
            transition.Draw(gameTime, _spriteBatch);
        } else
        {
            scene.Draw(gameTime, _spriteBatch);
        }

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

