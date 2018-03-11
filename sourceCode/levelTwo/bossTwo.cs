using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{

    class bossTwo : spriteAnimation
    {
        mountainMap mountainMap;

        public int saulManderHealth = 300;
        public bool isTransforming = false;
        public bool Active = true;
        public bool hasCollided = false;
     
        public bool explode = false;
        
        
        
        
        Timer timer = new Timer();
        Hero player;

        bool stage1 = true;
        bool stage2 = false;
        bool stage3 = false;
        bool stage4 = false;

        int effectCounter = 0;
        int effectLimit = 14;
        float effectCount = 1f;
        float currentEffectTime = 0f;

        int aimingDirection = 4;
       int looper;
        public int lookingDirection
        {
            get { return aimingDirection; }

        }

        public Vector2 player_Position;

        public float baseSpeed = 95f;

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

        public bossTwo(Vector2 position) : base(position)
        {
            framesperSecond = 12; // this is the value we set in the AnimateSprite set
            AddAnimation(4, 0, 0, "Down", 64, 64, new Vector2(0, 0)); 
            AddAnimation(4, 64, 0, "Right", 64, 64, new Vector2(0, 0));          
            AddAnimation(4, 128, 0, "Up", 64, 64, new Vector2(0, 0));  
            AddAnimation(4, 192, 0, "Left", 64, 64, new Vector2(0, 0));                  
            AddAnimation(4, 256, 0, "magick", 64, 64, new Vector2(0, 0));
            AddAnimation(4, 320, 0, "smoke", 64, 64, new Vector2(0, 0));

            AddAnimation(4, 384, 0, "Down2", 80, 80, new Vector2(0, 0));
            AddAnimation(4, 464, 0, "Right2", 80, 80, new Vector2(0, 0));
            AddAnimation(4, 544, 0, "Up2", 80, 80, new Vector2(0, 0));
            AddAnimation(4, 624, 0, "Left2", 80, 80, new Vector2(0, 0));
            AddAnimation(4, 704, 0, "magick2", 80, 80, new Vector2(0, 0));
            AddAnimation(4, 784, 0, "smoke2", 80, 80, new Vector2(0, 0));

            AddAnimation(4, 864, 0, "Down3", 96, 96, new Vector2(0, 0));
            AddAnimation(4, 960, 0, "Right3", 96, 96, new Vector2(0, 0));
            AddAnimation(4, 1056, 0, "Up3", 96, 96, new Vector2(0, 0));
            AddAnimation(4, 1152, 0, "Left3", 96, 96, new Vector2(0, 0));
            AddAnimation(4, 1248, 0, "magick3", 96, 96, new Vector2(0, 0));
            AddAnimation(4, 1344, 0, "smoke3", 96, 96, new Vector2(0, 0));

            AddAnimation(4, 1440, 0, "Down4", 112, 112, new Vector2(0, 0));
            AddAnimation(4, 1552, 0, "Right4", 112, 112, new Vector2(0, 0));
            AddAnimation(4, 1664, 0, "Up4", 112, 112, new Vector2(0, 0));
            AddAnimation(4, 1776, 0, "Left4", 112, 112, new Vector2(0, 0));
            AddAnimation(4, 1888, 0, "magick4", 112, 112, new Vector2(0, 0));
            AddAnimation(4, 2000, 0, "smoke4", 112, 112, new Vector2(0, 0));

            playAnimation("Down", false);
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("saulamander");
           
        }

        public void initialize(Hero player)
        {

            this.player = player;

        }
        /// <summary>

        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
                  abilityTimer(gameTime);
            if (stage1)
            {
                if (currentAnimation == "magick")
                {
                   if( frameIndex == 3)
                    {
                        playAnimation("smoke", false);
                    }
                }
                if(currentAnimation == "smoke")
                {
                    if(frameIndex == 3)
                    {
                        isTransforming = false;
                        stage1 = false;
                        stage2 = true;
                    }
                }
            }
            else if (stage2)
            {
                if (currentAnimation == "magick2")
                {
                    if (frameIndex == 3)
                    {
                        playAnimation("smoke2", false);
                    }
                }
                if (currentAnimation == "smoke2")
                {
                    if (frameIndex == 3)
                    {
                        isTransforming = false;
                        stage2 = false;
                        stage3 = true;
                    }
                }
            }
            else if (stage3)
            {
                if (currentAnimation == "magick3")
                {
                    if (frameIndex == 3)
                    {
                        playAnimation("smoke3", false);
                    }
                }
                if (currentAnimation == "smoke3")
                {
                    if (frameIndex == 3)
                    {
                        isTransforming = false;
                        stage3 = false;
                        stage4 = true;
                    }
                }
            }
            else if (stage4)
            {
                if (currentAnimation == "magick4")
                {
                    if (frameIndex == 3)
                    {
                        explode = true;
                    }
                }
            }


            base.Update(gameTime);
        }


        private void showAnimation()
        {
            if (stage1)
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
            }
            else if (stage2)
            {
                if ((player_Position.Y < sPosition.Y) && ((sPosition.X > player_Position.X - 30) || (sPosition.X < player_Position.X + 30)))
                {

                    playAnimation("Up2", true);
                    currentDirection = myDirection.up;
                }

                if ((player_Position.X < sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Left2", true);
                    currentDirection = myDirection.left;
                }

                if ((player_Position.X > sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Right2", true);
                    currentDirection = myDirection.right;
                }

                if ((player_Position.Y > sPosition.Y) && ((sPosition.X > player_Position.X) || (sPosition.X < player_Position.X + 30)))
                {
                    playAnimation("Down2", true);
                    currentDirection = myDirection.down;

                }
            }
            else if (stage3)
            {
                if ((player_Position.Y < sPosition.Y) && ((sPosition.X > player_Position.X - 30) || (sPosition.X < player_Position.X + 30)))
                {

                    playAnimation("Up3", true);
                    currentDirection = myDirection.up;
                }

                if ((player_Position.X < sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Left3", true);
                    currentDirection = myDirection.left;
                }

                if ((player_Position.X > sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Right3", true);
                    currentDirection = myDirection.right;
                }

                if ((player_Position.Y > sPosition.Y) && ((sPosition.X > player_Position.X) || (sPosition.X < player_Position.X + 30)))
                {
                    playAnimation("Down3", true);
                    currentDirection = myDirection.down;

                }
            }
            else if (stage4)
            {
                if ((player_Position.Y < sPosition.Y) && ((sPosition.X > player_Position.X - 30) || (sPosition.X < player_Position.X + 30)))
                {

                    playAnimation("Up4", true);
                    currentDirection = myDirection.up;
                }

                if ((player_Position.X < sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Left4", true);
                    currentDirection = myDirection.left;
                }

                if ((player_Position.X > sPosition.X) && ((sPosition.Y < player_Position.Y + 60) || (sPosition.Y < player_Position.Y - 30)))
                {
                    playAnimation("Right4", true);
                    currentDirection = myDirection.right;
                }

                if ((player_Position.Y > sPosition.Y) && ((sPosition.X > player_Position.X) || (sPosition.X < player_Position.X + 30)))
                {
                    playAnimation("Down4", true);
                    currentDirection = myDirection.down;

                }
            }
            
/*
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
            */
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

            sDirection += sDirection * baseSpeed;

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
            if (!explode)
                detectCollision();

            sPosition += (sDirection * deltaTime);

           
              showAnimation();
            
            
        }

        public Vector2 direction
        {
            get { return sDirection; }
            set { sDirection = value; }
        }



        public void getMap(mountainMap mountainMap)
        {
            this.mountainMap = mountainMap;
        }



        public void detectCollision()
        {
            Rectangle zombieRectangle = new Rectangle((int)sPosition.X + 15, (int)sPosition.Y + 14, 35, 49);


            int b = mountainMap.checkCollisionforZombies(zombieRectangle);

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
        public void abilityTimer(GameTime gametime)
        {


            currentEffectTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentEffectTime >= effectCount)
            {
                effectCounter++;
                currentEffectTime -= effectCount;

            }
             if (effectCounter >= effectLimit)
            {

                if (stage1)
                {
                    playAnimation("magick", false);
                    
                    isTransforming = true;
                     effectCounter = 0;
                }
                else if (stage2)
                {
                   
                    playAnimation("magick2", false);
                    
                    isTransforming = true;
                    effectCounter = 0;

                }
                else if (stage3)
                {
                    
                    playAnimation("magick3", false);
                   
                    isTransforming = true;
                    
                    effectCounter = 0;
                }
                else if (stage4)
                {
                    playAnimation("magick4", false);
                  
                    isTransforming = true;
                    effectCounter = 0;
                }
                
            }
        }
    }
}