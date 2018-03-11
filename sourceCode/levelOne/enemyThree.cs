using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{

    class enemyThree : spriteAnimation
    {
        Map map;
        mountainMap mountainMap;
        CastleTile castleMap;
        public int health = 5;
        public bool Active = true;
        public bool hasCollided = false;
        Hero player;
        int aimingDirection = 4;
        public int lookingDirection
        {
            get { return aimingDirection; }

        }

        public Vector2 player_Position;

        public float baseSpeed = 115f;

        public float basespeed
        {
            get { return baseSpeed; }
            set { baseSpeed = value; }
        }
        public int Width
        {
            get { return sTexture.Width; }

        }

        public int Height
        {
            get { return sTexture.Height; }
        }

        public enemyThree(Vector2 position) : base(position)
        {
            framesperSecond = 10; // this is the value we set in the AnimateSprite set
            AddAnimation(4, 0, 0, "Down", 64, 64, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "idleDown", 64, 64, new Vector2(0, 0));
            AddAnimation(4, 128, 0, "Up", 64, 64, new Vector2(0, 0));
            AddAnimation(1, 128, 0, "idleUp", 64, 64, new Vector2(0, 0));
            AddAnimation(4, 192, 0, "Left", 64, 64, new Vector2(0, 0));
            AddAnimation(1, 192, 0, "idleLeft", 64, 64, new Vector2(0, 0));
            AddAnimation(4, 64, 0, "Right", 64, 64, new Vector2(0, 0));
            AddAnimation(1, 64, 0, "idleRight", 64, 64, new Vector2(0, 0));
        

            playAnimation("idleDown", false);
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("samuraiZombie");

        }

        public void initialize(Hero player)
        {

            this.player = player;

        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }


        private void showAnimation()
        {

            if ((player_Position.Y < sPosition.Y) && ((sPosition.X > player_Position.X - 30) || (sPosition.X < player_Position.X + 30)))
            {

                playAnimation("Up", true);
                currentDirection = myDirection.up;
            }

            if ((player_Position.X < sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
            {
                playAnimation("Left", true);
                currentDirection = myDirection.left;
            }

            if ((player_Position.X > sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
            {
                playAnimation("Right", true);
                currentDirection = myDirection.right;
            }

            if ((player_Position.Y > sPosition.Y) && ((sPosition.X > player_Position.X) || (sPosition.X < player_Position.X + 30)))
            {
                playAnimation("Down", true);
                currentDirection = myDirection.down;

            }

            if (currentAnimation.Contains("Left") && currentDirection == myDirection.none)
            {
                playAnimation("idleLeft", false);
            }
            else if (currentAnimation.Contains("Right"))
            {
                playAnimation("idleRight", false);
            }
            else if (currentAnimation.Contains("Up"))
            {
                playAnimation("idleUp", false);
            }
            else if (currentAnimation.Contains("Down"))
            {
                playAnimation("idleDown", false);
            }

            currentDirection = myDirection.none;

        }

        public Vector2 EnPOS
        {

            get { return sPosition; }
            set { sPosition = value; }
        }

        public float positionY
        {
            get { return sPosition.Y; }
            set { sPosition.Y = value; }
        }
        public float positionX
        {
            get { return sPosition.X; }
            set { sPosition.X = value; }
        }
        public float setDirectionX
        {
            get { return sDirection.X; }
            set { sDirection.X += value; }

        }
        public float setDirectionY
        {
            get { return sDirection.Y; }
            set { sDirection.Y += value; }

        }
        public Vector2 setDirection
        {
            get { return sDirection; }
            set { sDirection = value; }
        }

        public void chaseHero(float deltaTime)
        {

            player_Position = player.position;
            sDirection = Vector2.Zero;

            sDirection = player_Position - sPosition;

            if (sDirection != Vector2.Zero)
            {
                sDirection.Normalize();
            }

           

            if (sDirection.X == 0 && sDirection.Y < 1)
            {
                aimingDirection = 1;
            }
            else if (sDirection.X > 1 && sDirection.Y == 0)
            {
                aimingDirection = 2;
            }
            else if (sDirection.X == 0 && sDirection.Y >= 1)
            {
                aimingDirection = 3;
            }
            else if (sDirection.X < 1 && sDirection.Y == 0)
            {
                aimingDirection = 4;
            }
            else if (sDirection.X >= 1 && sDirection.Y < 1)
            {
                aimingDirection = 5;
            }
            else if (sDirection.X >= 1 && sDirection.Y >= 1)
            {
                aimingDirection = 6;
            }
            else if (sDirection.X < 1 && sDirection.Y >= 1)
            {
                aimingDirection = 7;
            }
            else if (sDirection.X < 1 && sDirection.Y < 1)
            {
                aimingDirection = 8;
            }
          sDirection += sDirection * baseSpeed;
            detectCollision();

            sPosition += (sDirection * deltaTime);

            showAnimation();
        }

        public Vector2 direction
        {
            get { return sDirection; }
            set { sDirection = value; }
        }



        public void getMap(Map map)
        {
            this.map = map;
        }

        public void getMap2(mountainMap mountainMap)
        {
            this.mountainMap = mountainMap;
        }
        public void getMap3(CastleTile castleMap)
        {
            this.castleMap = castleMap;
        }


        public void detectCollision()
        {
            Rectangle zombieRectangle = new Rectangle((int)sPosition.X + 15, (int)sPosition.Y + 14, 35, 49);
            int b = 0;
            switch (levelManager.levelIndicator)
            {
                case levelManager.levels.levelOne:
                    {
                     b = map.checkCollisionforZombies(zombieRectangle);
                        break;
                    }
                case levelManager.levels.levelTwo:
                    {
                        b = mountainMap.checkCollisionforZombies(zombieRectangle);
                        break;
                    }
                case levelManager.levels.levelThree:
                    {
                        b = castleMap.checkCollisionforZombies(zombieRectangle);
                        break;
                    }
            }
          

            if (b == 1 && (lookingDirection == 3 || lookingDirection == 6 || lookingDirection == 7))
            {
                sDirection = Vector2.Zero;
                hasCollided = true;
            }
            if (b == 2 && (lookingDirection == 2 || lookingDirection == 5 || lookingDirection == 6))
            {
                sDirection = Vector2.Zero;
                hasCollided = true;
            }
            if (b == 3 && (lookingDirection == 4 || lookingDirection == 7 || lookingDirection == 8))
            {
                sDirection = Vector2.Zero;
                hasCollided = true;
            }
            if (b == 4 && (lookingDirection == 1 || lookingDirection == 5 || lookingDirection == 8))
            {
                sDirection = Vector2.Zero;
                hasCollided = true;
            }
            if (b == 0)
            {
                hasCollided = false;
            }
        }
    }
}

