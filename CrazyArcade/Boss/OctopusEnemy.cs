using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Enemies;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.GameGridSystems;
using CrazyArcade.Blocks;
using CrazyArcade.BombFeature;
using System.Diagnostics;
using CrazyArcade.PlayerStateMachine;

namespace CrazyArcade.Boss
{
    public class OctopusEnemy : EnemyEntity, IGridable, IPlayerCollidable, IBombCollectable, IBossCollideBehaviour
    {
        //Animation
        private Texture2D texture;
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        public Color tint;
        private Dir[] dirList;
        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        //Life cycle stuff
        public SpriteAnimation deathAnimation;
        public IEnemyState state;
        public int health;
        public Boolean justAttacked = true;
        public Boolean justInjured = false;
        public Boolean useSquare;

        //Background Stuff

        //Spacial Stuff
        protected Vector2 Start;
        public float xDifference;
        public float yDifference;
        public Dir direction;
        protected Rectangle internalRectangle = new Rectangle(12, 18, 75, 105); 
        protected Vector2[] SpeedVector;
        public float speed = 0.10f;
        private int squareSize = 4;
        private int xoffset = 4;
        private int yoffset = 4;


        //I Gridable-------------------
        private Vector2 gamePos;
        private Vector2 pos;
        private float timer;
        protected int fps = 10;

        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
        }
        public Vector2 GameCoord
        {
            get => gamePos;
            set
            {
                gamePos = value;
                ScreenCoord = trans.Trans(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans
        {
            get => trans; set
            {
                trans = value;
                ScreenCoord = value.Trans(GameCoord);
                X = (int)ScreenCoord.X;
                Y = (int)ScreenCoord.Y;
                internalRectangle.X = X;
                internalRectangle.Y = Y;
            }
        }
        //---------------------------------------------------------------------------------
        public OctopusEnemy(int x, int y) : base()
        {
            //Spacial
            X = x;
            Y = y;
            Start = GameCoord;
            GameCoord = new Vector2(x, y);

            //background
            timer = 0;
            health = 100;
            state = new OctopusNormal(this);
            useSquare = true;

            //Animation
            texture = TextureSingleton.GetOctoBoss();
            spriteAnims = new SpriteAnimation[4];
            tint = Color.White;
        }


        public override void Load()
        {
            base.Load();
            //Load Sprites
            texture = TextureSingleton.GetOctoBoss();
            InputFramesRight = new Rectangle[1];
            InputFramesUp = new Rectangle[1];
            InputFramesLeft = new Rectangle[1];
            InputFramesDown = new Rectangle[2];
            InputFramesRight[0] = new Rectangle(803, 21, 104, 148);
            InputFramesLeft[0] = new Rectangle(614, 23, 102, 144);
            InputFramesUp[0] = new Rectangle(421, 26, 107, 138);
            InputFramesDown[0] = new Rectangle(41, 23, 107, 144);
            InputFramesDown[1] = new Rectangle(231, 24, 108, 141);

            //Directional Organization
            direction = Dir.Down;
            dirList = new Dir[4];
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, InputFramesUp, fps);
            this.spriteAnims[(int)Dir.Up].SetColor(tint);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            this.spriteAnims[(int)Dir.Down].SetColor(tint);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            this.spriteAnims[(int)Dir.Left].SetColor(tint);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
            this.spriteAnims[(int)Dir.Right].SetColor(tint);

            //Make animation uniform
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(110, 145);
                anim.Position = new Vector2(X, Y);
            }

            //State Specific Animation
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 1941, 43, 108, 104, 1, 0, 1);
            deathAnimation.setWidthHeight(108, 104);
            deathAnimation.Position = new Vector2(X, Y);

        }

        public override void Update(GameTime time)
        {
            state.Update(time);

        }

        public void defaultUpdate(GameTime time)
        {
            // movement in normal state only
            SpriteAnim.Position = new Vector2(X, Y);
            xDifference = GameCoord.X - Start.X;
            yDifference = GameCoord.Y - Start.Y;
            if (timer > 1f / 6)
            {
                if (state is not EnemyDeathState)
                {
                    move(direction);
                }
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            internalRectangle.X = X;
            internalRectangle.Y = Y;

        }

        public void UpdateAnimation(Dir dir)
        {
            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }

        //IPlayerCollidable Stuff
        public Rectangle boundingBox => internalRectangle;

        public Rectangle hitBox => internalRectangle;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
            //To show the state only, this line of code needs to be moved once bomb -> enemy collision is implemented to CollisionDestroyLogic 
             if (!justInjured && !(collisionPartner is Character))
            {
                health -= 20;
                justInjured = true;
                state = new OctopusWounded(this);
            }
        }

        protected bool ChangeDir(Dir dir)
        {
            switch (dir){
                case Dir.Right:
                    justAttacked = false;
                    useSquare = !useSquare;
                    return xDifference >= squareSize + xoffset;
                case Dir.Up:
                    return yDifference <= yoffset-1;
                case Dir.Down:
                    return yDifference >= squareSize+yoffset-1;
                case Dir.Left:
                    return xDifference <= xoffset;
            }
            return false;
        }
        

        protected void move(Dir dir)
        {
            Vector2[] SpeedVector = new Vector2[] { new Vector2(0.0f, -1.0f * speed), new Vector2(-1.0f * speed, 0.0f), new Vector2(0.0f, speed), new Vector2(speed, 0.0f) };

            if (ChangeDir(dir))
            {
                if(!useSquare)this.shoot();
                direction = (Dir)((((int)dir) + 1) % 4);
                UpdateAnimation(dir);
            }
            if (useSquare) {
            // go to center
                if (dir == Dir.Left && xDifference < squareSize + xoffset-2 && !justAttacked)
                {
                    direction = Dir.Down;
                    UpdateAnimation(dir);
                }
                else if (dir == Dir.Down && xDifference < squareSize + xoffset && yDifference > (squareSize / 2) + yoffset - 1 && !justAttacked)
                {
                    justAttacked = true;
                    this.squareBlast(); 
                    direction = Dir.Up;
                    UpdateAnimation(dir);
                    //changeDir will put it back on course
                }
            }
            GameCoord += SpeedVector[(int)dir];
            justInjured = false;
        }

        public void shoot() {
            //Launch balloons
            Vector2 destination;
            int distance = 2;
            if (this.direction == Dir.Right) { 
                destination = new Vector2(xDifference + distance, yDifference);
            }
            else if (this.direction == Dir.Left)
            {
                destination = new Vector2(xDifference - distance, yDifference);
            }
            else if (this.direction == Dir.Up)
            {
                destination = new Vector2(xDifference, yDifference - distance);
            }
            else {
                destination = new Vector2(xDifference, yDifference + distance);
            }
            WaterBomb projectile = new WaterBomb((destination),1,this);
            this.SceneDelegate.ToAddEntity(projectile);
            Debug.WriteLine("Octo Shoot");
        }

        public void squareBlast()
        {
            //change to attacking state aka make still
            //execute square blast attack
            int squaresize = 6;
            WaterBomb[,] waterExplosionEdges = new WaterBomb[4, squaresize];
            int[,,] edgeCoords = getSquareCoords(squaresize);
            //resume movement if necessary
            for(int side = 0; side < 4; side++){
                for (int spot = 0; spot < squaresize; spot++)
                {
                    waterExplosionEdges[side, spot] = new WaterBomb(new Vector2(edgeCoords[side,spot,0], edgeCoords[side,spot,1]), 0, this, true);
                    this.SceneDelegate.ToAddEntity(waterExplosionEdges[side, spot]);
                }
            }
        }
        public int[,,] getSquareCoords(int squaresize) {
            int[,,] edgeCoords = new int[4, squaresize, 2];
            for (int side = 0; side < 4; side++)
            {
                if (side == 0)
                {
                    //up
                    for (int i = 0; i < squaresize; i++)
                    {
                        edgeCoords[side, i, 0] = xoffset + i;
                        edgeCoords[side, i, 1] = yoffset;
                    }
                }
                else if (side == 1)
                {
                    //left
                    for (int i = 0; i < squaresize; i++)
                    {
                        edgeCoords[side, i, 0] = xoffset;
                        edgeCoords[side, i, 1] = yoffset + i+1;
                    }
                    
                }
                else if (side == 2)
                {
                    //down
                    for (int i = 0; i < squaresize; i++)
                    {
                        edgeCoords[side, i, 0] = xoffset + i+1;
                        edgeCoords[side, i, 1] = yoffset + squaresize;
                    }
                }
                else
                {
                    //right
                    for (int i = 0; i < squaresize; i++)
                    {
                        edgeCoords[side, i, 0] = xoffset + squaresize;
                        edgeCoords[side, i, 1] = yoffset + i;
                    }
                }
            }
            return edgeCoords;
        }
        //IBombCollectable stuff
        public void RecollectBomb()
        {
            //Infinite Bombs
        }

        public void SpendBomb()
        {
            //Infinite Bombs
        }

        public void HurtBoss()
        {
            if (!justInjured)
            {
                health -= 20;
                justInjured = true;
                this.spriteAnims[(int)direction].SetColor(Color.Red);
                state = new OctopusWounded(this);
                this.spriteAnims[(int)direction].SetColor(Color.White);
            }
        }
    }
    //Octopus Specific States
    public class OctopusNormal : IEnemyState
    {
        private OctopusEnemy enemy;

        public OctopusNormal(OctopusEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void ChangeDirection()
        {

        }

        public void Update(GameTime time)
        {
            enemy.defaultUpdate(time);
        }
    }
    public class OctopusWounded : IEnemyState
    {
        private OctopusEnemy enemy;
        private float timer;
        private float startTimeStamp;
        private float timeLength = 150.0f;

        public OctopusWounded(OctopusEnemy enemy)
        {
            this.enemy = enemy;
            timer = timeLength; //in milliseconds
            if (enemy.health <= 0)
            {
                enemy.state = new OctopusDead(enemy);
            }
        }
        public void ChangeDirection()
        {

        }

        public void Update(GameTime time)
        {
            float tollerance = 0.0f;
            if (timer >= timeLength-tollerance && timer <= timeLength+tollerance) {
                startTimeStamp = (float)time.ElapsedGameTime.Milliseconds;
                timer -= 1.0f;
            }
            else{
                timer -= 1.0f;
                if (timer < 1.0f){
                    enemy.state = new OctopusNormal(enemy);
                }
            }
        }
    }
    public class OctopusDead : IEnemyState
    {
        private OctopusEnemy enemy;
        private float timer;
        private float opacity;
        private float fadeTime;

        public OctopusDead(OctopusEnemy enemy) {
            this.enemy = enemy;
            enemy.spriteAnims = new SpriteAnimation[1];
            enemy.spriteAnims[0] = enemy.deathAnimation;
            enemy.spriteAnim = enemy.deathAnimation;
            enemy.UpdateCoord(new Vector2(enemy.xDifference, enemy.xDifference));
            enemy.direction=0;
            enemy.SceneDelegate.Victory();

            timer = 0;
            opacity = 1f;
            fadeTime = 600f;
        }
        public void ChangeDirection()
        {

        }

        public void Update(GameTime time)
        {
            enemy.UpdateAnimation((Dir)0);
            if (timer > fadeTime)
            {
                enemy.SceneDelegate.ToRemoveEntity(enemy);
            }
            else
            {
                opacity = 1f - timer / fadeTime;
                enemy.spriteAnims[0].Color = Color.White * opacity;
                timer += 1.0f;
            }
        }
    }
}