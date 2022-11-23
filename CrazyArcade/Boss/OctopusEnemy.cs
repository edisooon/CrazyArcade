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
    //TODO:{
    //  Organize code CHK
    //  Add attack methods
    //  Make States
    //  Add wounded animations
    //  Define movement pattern
    //}
    public class OctopusEnemy : CAEntity, IGridable, IPlayerCollidable, IBombCollectable, IBossCollideBehaviour
    {
        //Animation
        private Texture2D texture;
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        //Life cycle stuff
        public SpriteAnimation deathAnimation;
        public IEnemyState state;
        public int health;
        public Boolean justAttacked = true;
        public Boolean justInjured = false;

        //Background Stuff

        //Spacial Stuff
        protected Vector2 Start;
        public float xDifference;
        public float yDifference;
        public Dir direction;
        protected Rectangle internalRectangle = new Rectangle(0, 0, 110, 145); 
        protected Vector2[] SpeedVector;
        public float speed = 0.15f;
        private int squareSize = 4;
        private int xoffSet = 3;
        private int yoffSet = 2;

        //Out of Use
        //public Rectangle outputFrame1;
        private Color tint;//dead
        private Dir[] dirList;//dead
        //protected SpriteEffects effect;
        //public Rectangle inputFrame;

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

            //Animation
            texture = TextureSingleton.GetOctoBoss();
            spriteAnims = new SpriteAnimation[4];
        }

        public override void Load()
        {
            //Load Sprites
            texture = TextureSingleton.GetOctoBoss();
            spriteAnim = spriteAnims[(int)direction];
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
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);

            //Make animation uniform
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(110, 145);
                anim.Position = new Vector2(X, Y);
            }

            //State Specific Animation
            tint = Color.White; // UNUSED

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
            /**
            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = new Vector2(X, Y);
            xDifference = GameCoord.X - Start.X;
            yDifference = GameCoord.Y - Start.Y;
            if (state != null)
            {
                //this.defaultUpdate(time);
            }
            if (timer > 1f / 6)
            {
                if (state is not EnemyDeathState)// or attack state
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
            Debug.WriteLine("Oct XY: ("+this.X+","+this.Y+")" );
            **/
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

            //if(collisionPartner is WaterExplosionCenter || collisionPartner is WaterExplosionEdge){
            if (!justInjured && !(collisionPartner is Character))
            {
                health -= 10;
                justInjured = true;
                state = new OctopusWounded(this);
            }
            //}
        }

        protected bool ChangeDir(Dir dir)
        {
            switch (dir){
                case Dir.Right:
                    justAttacked = false;
                    return xDifference >= squareSize + xoffSet;
                case Dir.Up:

                    return yDifference <= yoffSet;

                case Dir.Down:
                    return yDifference >= squareSize+yoffSet;
                case Dir.Left:
                    if (xDifference <= xoffSet)
                    {
                        if (justAttacked)
                        {
                            //speed *= 2;
                        }
                        return true;
                    }
                    return false;
            }
            return false;
        }
        

        protected void move(Dir dir)
        {
            Vector2[] SpeedVector = new Vector2[] { new Vector2(0.0f, -1.0f * speed), new Vector2(-1.0f * speed, 0.0f), new Vector2(0.0f, speed), new Vector2(speed, 0.0f) };

            if (ChangeDir(dir))
            {
                this.shoot();
                direction = (Dir)((((int)dir) + 1) % 4);
                UpdateAnimation(dir);
            }
            // go to center
            else if (dir == Dir.Left && xDifference < 5 && !justAttacked)
            {
                direction = Dir.Down;
            }
            else if (dir == Dir.Down && xDifference < squareSize + xoffSet && yDifference > (squareSize / 2) + yoffSet - 1 && !justAttacked)
            {
                justAttacked = true;
                state = new OctopusAttack(this,1);
                this.squareBlast();
                direction = Dir.Up;
                //changeDir will put it back on course
            }
            GameCoord += SpeedVector[(int)dir];
            justInjured = false;
        }

        public void shoot() {
            //change to attacking state aka make still
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
            //this.scene.AddSprite(projectile);
            //resume movement if necessary
        }

        public void squareBlast()
        {
            //change to attacking state aka make still
            //execute square blast attack
            WaterBomb[] waterExplosionEdges = new WaterBomb[18];
            int[,] edgeCoords = { { 3, 3}, { 4, 3 }, { 5, 3 }, { 6, 3 }, { 7, 3 },
                                  { 3, 8}, { 4, 8 }, { 5, 8 }, { 6, 8 }, { 7, 8 }, 
                                  { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 },
                                  { 8, 4 }, { 8, 5 }, { 8, 6 }, { 8, 7 }};
            //resume movement if necessary
            for(int i = 0; i < waterExplosionEdges.Length; i++){
                int d;
                if (i < 5) d = 1;//left
                else if (i < 10) d = 3;//right
                else if (i < 14) d = 2;//down
                else d = 0;//up
                waterExplosionEdges[i] = new WaterBomb(new Vector2(edgeCoords[i,0]+1, edgeCoords[i,1]), 0, this, true);
                this.SceneDelegate.ToAddEntity(waterExplosionEdges[i]);
            }
            for (int i = 0; i < waterExplosionEdges.Length; i++)
            {
                this.SceneDelegate.ToAddEntity(waterExplosionEdges[i]);
            }
        }
        public void toggleHurtSprites(Boolean hurt) {
            if (hurt){
                //tint = Color.Red;
                //this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, 1, 1560, 18, 110, 153, fps);
                //InputFramesDown[0] = new Rectangle(991, 26, 107, 135);
               // InputFramesDown[1] = new Rectangle(1181, 22, 108, 145);
                //this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
                //left one doesn't change
                //InputFramesRight[0] = new Rectangle(1371, 17, 108, 153);
                //this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
                //update to show change if necessary
            }
            else {
                //this.Load();
            }
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
            //Debug.WriteLine("Health: " + health);
            if (!justInjured)
            {
                //Debug.WriteLine("IN IF Health: " + health);
                health -= 20;
                justInjured = true;
                state = new OctopusWounded(this);
                //Debug.WriteLine("health: " + health);
            }
        }
    }
    //Octopus Specific States
    public class OctopusAttack : IEnemyState
    {
        private OctopusEnemy enemy;
        private float timer;
        private float startTimeStamp;
        private float timeLength = 300.0f;
        private int attack;

        public OctopusAttack(OctopusEnemy enemy, int attack)
        {
            this.enemy = enemy;
            timer = timeLength; //in milliseconds
            this.attack = attack;
        }
        public void ChangeDirection()
        {

        }

        public void Update(GameTime time)
        {
            float tollerance = 0.0f;
            if (timer >= timeLength - tollerance && timer <= timeLength + tollerance)
            {
                if (attack == 1)
                {
                    enemy.squareBlast();
                }
                else
                {
                    enemy.shoot();
                }
                startTimeStamp = (float)time.ElapsedGameTime.Milliseconds;
                timer -= 1.0f;
            }
            else
            {
                timer -= 1.0f;
                if (timer < 1)
                {
                    enemy.state = new OctopusNormal(enemy);
                }
            }
        }
    }
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
            //enemy.toggleHurtSprites(true);
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
                //timer -= (float)time.ElapsedGameTime.Milliseconds-startTimeStamp;
                timer -= 1.0f;
                if (timer < 1.0f){
                    //enemy.toggleHurtSprites(false);
                    enemy.state = new OctopusNormal(enemy);

                }
            }
            //Debug.WriteLine("Timer: " + timer);
            
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