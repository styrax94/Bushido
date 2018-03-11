    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Bushido
    {
       class Hero : spriteAnimation
        {
            private Boolean Attacking = false;
           public float mySpeed = 130;
        public Vector2 endPosition;
            int aimDirection;
            Map map;
        public bool hasFallen;
        mountainMap mountainMap;
        CastleTile castleMap;
        public bool gameIsOver;   
        EnemyManager enManager;
        shurikenManager shManager;
        mapTile maptile;
        Timer timerOne;
        Timer timerTwo; 
        Timer timerThree;
        Timer timerFour;
        Timer timer;
        int looper;
        
        bool walking = false;
        public bool iAmInACutscene = false;
        public bool teleporting = false;
        public Vector2 teleportDistance;
        #region inventory

       public  int fireRateInventory = 0;

        public int inventoryFireRate
        {
            set { fireRateInventory += value; }
        }

       public  int movementSpeedInventory = 0;

        public int inventoryMovementSpeed
        {
            set { movementSpeedInventory += value; }
        }

        public int ninjaInventory = 0;

        public int inventoryNinjaZone
        {
            set { ninjaInventory += value; }
        }
       public  int MegaSize = 0;
        public int megaSize
        {
            set { MegaSize = value; }
        }

        #endregion

        bool abilityOne = false;
        bool abilityTwo = false;
        bool abilityThree = false;
        bool abilityFour = false;
        bool stage1;
        bool stage2;
        bool stage3;
        
        public bool bossCutscene1;
        public bool inLevelThreeCutscene;
       public bool reachedEndPoint;
        public bool endGameScene;
        Vector2 ayoubPos = new Vector2(800, 50);
        public bool chaseAyoub;
        public int Height
        {
            get { return sTexture.Height; }
        }
        public int Width
        {
            get { return sTexture.Width; }
        }

        public Vector2 direction
        {
            set { sDirection = value; }
            get { return sDirection; }
        }
        public int lookingDirection
        {
            get { return aimDirection; }
        }

        public void getManagers(EnemyManager enManager, shurikenManager shManager)
        {
            this.enManager = enManager;
            this.shManager = shManager;
        }

            public Hero(Vector2 position) : base(position)
            {
                framesperSecond = 25;
                AddAnimation(8, 0, 0, "Up", 64, 63, new Vector2(0, 0));
                AddAnimation(9, 65, 0, "Left", 64, 63, new Vector2(0, 0));
                AddAnimation(8, 130, 0, "Down", 64, 64, new Vector2(0, 0));
                AddAnimation(9, 195, 0, "Right", 64, 63, new Vector2(0, 0));
                AddAnimation(1, 0, 0, "idleUp", 64, 63, new Vector2(0, 0));
                AddAnimation(1, 65, 0, "idleLeft", 64, 63, new Vector2(0, 0));
                AddAnimation(1, 130, 0, "idleDown", 64, 63, new Vector2(0, 0));
                AddAnimation(1, 195, 0, "idleRight", 64, 63, new Vector2(0, 0));
                AddAnimation(1, 260, 0, "attackUp", 64, 63, new Vector2(3, 2));
                AddAnimation(1, 325, 0, "attackLeft", 64, 63, new Vector2(0, 4));
                AddAnimation(1, 390, 0, "attackDown", 64, 63, new Vector2(2, 4));
                AddAnimation(1, 455, 0, "attackRight", 64, 63, new Vector2(0, 4));
                AddAnimation(6, 519, 0, "death", 64, 63, new Vector2(0, 0));
                AddAnimation(4, 260, 2, "ninjutsu", 64, 63, new Vector2(0, 0));
               AddAnimation(4, 325, 2, "smoke", 64, 64, new Vector2(0, 0));
               AddAnimation(4, 325, 2, "smoke2", 64, 64, new Vector2(0, 0));

            playAnimation("idleDown",true);
                aimDirection = 3;

                  teleportDistance = new Vector2(1205,407);
            chaseAyoub = false;
            endGameScene = false;
            timerOne = new Timer();
            timerTwo = new Timer();
            timerThree = new Timer();
            timerFour = new Timer();
            timer = new Timer();
           walking = false;
          iAmInACutscene = false;
          teleporting = false;
            abilityOne = false;
             abilityTwo = false;
           abilityThree = false;
            abilityFour = false;
            stage1 = false;
            stage2 = false;
            stage3 = false;
            reachedEndPoint = false;
        }
            public void LoadContent(ContentManager contentOne)
            {

                sTexture = contentOne.Load<Texture2D>("bushidoF");
         
            }
          

            public override void Update(GameTime gameTime)
      {       float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            #region cutsceneForEndLevel
            if (iAmInACutscene)
       {

             if (Vector2.Distance(teleportDistance, endPosition) < Vector2.Distance(sPosition, endPosition))
                {
                    if (!teleporting)
                    {
                        currentDirection = myDirection.none;
                        playAnimation("ninjutsu", false);
                       //currentDirection = myDirection.down;
                        stage1 = true;
                        teleporting = true;
                        framesperSecond = 2;
                    }
                  
                }

                else if(!teleporting)
                {
                    walking = true;
                }

                 if (stage1)
                {
                     if (currentAnimation == "ninjutsu")
                    {
                           
                        if (frameIndex == 3)
                        {
                             playAnimation("smoke", false);
                            framesperSecond = 5;
                        }
                        else
                        {
                          //  timer.startTimer(10);
                          //  timer.update(gameTime);
                          //  if(timer.checkTimer)

                          //  frameIndex++;
                        }
                       
                    }

                        if (currentAnimation == "smoke")
                        {
                            if (frameIndex == 3)
                            {
                                
                                playAnimation("smoke2", false);
                                stage1 = false;
                                stage2 = true;

                            }
                        else
                        {

                                   
                          }
                     }
                    
                }
                else if (stage2)
                {
                    if (currentAnimation == "smoke2")
                    {
                        if(frameIndex == 0)
                        {
                            sPosition = teleportDistance;
                        }


                        if (frameIndex == 3)
                        {
                            stage2 = false;
                            stage3 = true;
                        }
                        else
                        {
                            timer.startTimer(5);
                            timer.update(gameTime);
                            if (timer.checkTimer)

                                frameIndex++;
                        }
                    }
                }    
                else if (stage3)
                {
                    framesperSecond = 20;
                    playAnimation("idleDown", true);
                   
                    if (currentAnimation == "idleDown")
                    {
                        timer.startTimer(2);
                        timer.update(gameTime);
                        if (timer.checkTimer)
                        {
                            playAnimation("Up",true);
                            currentDirection = myDirection.up;
                            
                        }

                        
                    }
                    if(currentAnimation == "Up")
                      {
                        sDirection = Vector2.Zero;
                        sDirection = endPosition - sPosition;
                        sDirection.Normalize();
                        sDirection *= mySpeed;
                        position += (direction * deltaTime);
                        if (reachedEndPoint)
                        {
                            currentDirection = myDirection.none;
                            playAnimation("idleDown", false);
                        }
                    }
                  
                   
                    
                }
            
                  

                if (walking)
                {
                    playAnimation("Up", true);
                    currentDirection = myDirection.up;
                    sDirection = Vector2.Zero;
                    sDirection = endPosition - sPosition;
                    sDirection.Normalize();
                    sDirection *= mySpeed;
                    position += (direction * deltaTime);
                }
              
            }
            #endregion

           


            if (hasFallen)
            {
                playAnimation("death", true);
                
                    if (myCurrentAnimation.Contains("death"))
                    {
                        framesperSecond = 2;
                        if (frameIndex == 5)
                        {

                            frameIndex = 5;
                             looper++;
                           
                           
                        }
                         if(looper == 5)
                    {
                            active = false;
                            gameIsOver = true;
                        looper = 0;
                    }
                        
                           
                        }
                    
                    else
                    {
                        playAnimation("death", false);
                    }
                
            }
            #region lvl3Cutscene

            if (bossCutscene1)
            {
                inLevelThreeCutscene = true;
                if (Vector2.Distance(sPosition, ayoubPos) > 200)
                {
                    sPosition += new Vector2(0, -2);
                    playAnimation("Up", true);
                }

                else
                {
                    playAnimation("idleUp", true);
                }
              
            }

            if (currentAnimation == "idleUp"&& !bossCutscene1)
                {
                   inLevelThreeCutscene = false;
               }


            if (chaseAyoub)
            {
                playAnimation("Up", true);
                currentDirection = myDirection.up;
                sDirection = Vector2.Zero;
                sDirection = ayoubPos - sPosition;
                sDirection.Normalize();
                sDirection *= 300;
                position += (direction * deltaTime);
            }
            if (endGameScene)
            {
                inLevelThreeCutscene = true;
                if (Vector2.Distance(sPosition, ayoubPos) > 200)
                {

                    playAnimation("Up", true);
                currentDirection = myDirection.up;
                sDirection = Vector2.Zero;
                sDirection = ayoubPos - sPosition;
                sDirection.Normalize();
                sDirection *= mySpeed;
                position += (direction * deltaTime);
               }
                else
                {
                    currentDirection = myDirection.none;
                    playAnimation("idleUp", true);
                }
            }
            #endregion
            if (!iAmInACutscene && !inLevelThreeCutscene)
            sDirection = Vector2.Zero;
        

                if (!hasFallen && !iAmInACutscene && !inLevelThreeCutscene)
                {

                    handleInput(Keyboard.GetState(), GamePad.GetState(PlayerIndex.One));
                }

                abilityHandler(gameTime);

               // float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(!iAmInACutscene)
                sDirection += sDirection * mySpeed;

                Rectangle heroRectangle = new Rectangle((int)sPosition.X + 20, (int)sPosition.Y + 12, 22, 53);

                if (levelManager.levelIndicator == levelManager.levels.levelOne)
                {
                    map.checkCollision(heroRectangle);
                   maptile.checkCollision(heroRectangle);

                if (!iAmInACutscene)
                {

                 sPosition += (sDirection * deltaTime);
                    sPosition.X = MathHelper.Clamp(sPosition.X, 0, 2349);
                    sPosition.Y = MathHelper.Clamp(sPosition.Y, 80, 1650);
                }
                   
                }

                else if (levelManager.levelIndicator == levelManager.levels.levelTwo)
                {
                    mountainMap.checkCollision(heroRectangle);
                   sPosition += (sDirection * deltaTime);
                   sPosition.X = MathHelper.Clamp(sPosition.X, 80, 2500);
                   sPosition.Y = MathHelper.Clamp(sPosition.Y, 0, 1490);
                }

                else if (levelManager.levelIndicator == levelManager.levels.levelThree || levelManager.levelIndicator == levelManager.levels.trainLevel)
                {
                    if (!inLevelThreeCutscene)
                        {
                           castleMap.checkCollision(heroRectangle);
                           sPosition += (sDirection * deltaTime);
                        }
                   
                }

                base.Update(gameTime);
            }

            private void handleInput(KeyboardState keyState, GamePadState gamepad)
         {

          
            if ((keyState.IsKeyDown(Keys.D1) || gamepad.Buttons.X == ButtonState.Pressed) && fireRateInventory > 0 && !abilityOne)
            {
                shManager.incFireRate = shManager.incFireRate/2;
                abilityOne = true;
                inventoryFireRate = -1;
                
            }
            if ((keyState.IsKeyDown(Keys.D2) || gamepad.Buttons.Y == ButtonState.Pressed) && movementSpeedInventory > 0 && !abilityTwo)
            {
                mySpeed = 160f;
                abilityTwo = true;
                inventoryMovementSpeed = -1;
            }
            if ((keyState.IsKeyDown(Keys.D3) || gamepad.Buttons.B == ButtonState.Pressed) && ninjaInventory > 0 && !abilityThree)
            {
                enManager.reducespeed = true;
                abilityThree = true;
                inventoryNinjaZone = -1;
            }
            if ((keyState.IsKeyDown(Keys.D4) || gamepad.Buttons.A == ButtonState.Pressed) && MegaSize>0 && !abilityFour)
            {
                shManager.megaSize = true;
                abilityFour = true;
                MegaSize = -1;
            }

            if (currentAnimation.Equals("attackUp")|| currentAnimation.Equals("attackRight")|| currentAnimation.Equals("attackLeft") || currentAnimation.Equals("attackDown"))
            {
                Attacking = true;
            }
            else
            {
                Attacking = false;
            }


                if (Attacking != true)
                {


                    if (keyState.IsKeyDown(Keys.W) || gamepad.ThumbSticks.Left.Y == +1f || keyState.IsKeyDown(Keys.Up))
                    {
                        sDirection += new Vector2(0, -1);
                        playAnimation("Up", true);
                        currentDirection = myDirection.up;
                        aimDirection = 1;

                        // cameraMove.Y = -1;
                    }
                    if (keyState.IsKeyDown(Keys.A) || gamepad.ThumbSticks.Left.X == -1f || keyState.IsKeyDown(Keys.Left))
                    {
                        sDirection += new Vector2(-1, 0);
                        playAnimation("Left", true);
                        currentDirection = myDirection.left;
                        aimDirection = 4;

                        //    cameraMove.X = -1;
                    }
                    if (keyState.IsKeyDown(Keys.S) || gamepad.ThumbSticks.Left.Y == -1f || keyState.IsKeyDown(Keys.Down))
                    {
                        sDirection += new Vector2(0, 1);
                        playAnimation("Down", true);
                        currentDirection = myDirection.down;
                        aimDirection = 3;

                        //  cameraMove.Y = 1;
                    }
                    if (keyState.IsKeyDown(Keys.D) || gamepad.ThumbSticks.Left.X == +1f || keyState.IsKeyDown(Keys.Right))
                    {
                        sDirection += new Vector2(1, 0);
                        playAnimation("Right", true);
                        currentDirection = myDirection.right;
                        aimDirection = 2;

                        // cameraMove.X = 1;
                    }
                }

                 if ((keyState.IsKeyDown(Keys.W) && keyState.IsKeyDown(Keys.D)) ||( gamepad.ThumbSticks.Left.X == +1f && gamepad.ThumbSticks.Left.Y == -1f) || (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Right)))
                    {
                        aimDirection = 5;
                    }
                   else if ((keyState.IsKeyDown(Keys.S) && keyState.IsKeyDown(Keys.D)) || (gamepad.ThumbSticks.Left.X == +1f && gamepad.ThumbSticks.Left.Y == +1f) || (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Right)))
                    {
                        aimDirection = 6;
                    }
                   else if ((keyState.IsKeyDown(Keys.S)  && keyState.IsKeyDown(Keys.A)) || (gamepad.ThumbSticks.Left.X == -1f && gamepad.ThumbSticks.Left.Y == +1f) || (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Left)))
                    {
                        aimDirection = 7;
                    }
                 else if ((keyState.IsKeyDown(Keys.W)  && keyState.IsKeyDown(Keys.A)) || (gamepad.ThumbSticks.Left.X == -1f && gamepad.ThumbSticks.Left.Y == -1f) || (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Up)))
                    {
                        aimDirection = 8;
                    }
                    
                
                //start of idle 
                if (currentDirection == myDirection.none)
                {
                    if (currentAnimation.Contains("Up"))
                    {
                        playAnimation("idleUp",true);
                    }

                    if (currentAnimation.Contains("Down"))
                    {
                        playAnimation("idleDown",true);
                    }

                    if (currentAnimation.Contains("Left"))
                    {
                        playAnimation("idleLeft",true);
                    }

                    if (currentAnimation.Contains("Right"))
                    {
                        playAnimation("idleRight",true);
                    }
                }
                currentDirection = myDirection.none;
            }

            public Vector2 position
            {
                get { return sPosition; }
                set { sPosition = value; }
            }

            public int shootDirection
            {
                get { return aimDirection; }
            }

            public Boolean setAttack
            {
                set { Attacking = value; }
            }

        public void fireShurikenAnimation()
        {
            if (shootDirection == 1)
            {
                playAnimation("attackUp", false);
                currentDirection = myDirection.up;

            }
            else if (shootDirection == 2)
            { 
                playAnimation("attackRight", false);
                currentDirection = myDirection.right;
            }
            else if (shootDirection == 3)
            {
                
                playAnimation("attackDown", false);
                currentDirection = myDirection.down;
            }
            else if (shootDirection == 4)
            {
                playAnimation("attackLeft", false);
                currentDirection = myDirection.down;
            }
            else if (shootDirection == 5)
            {
                playAnimation("attackUp", false);
                currentDirection = myDirection.up;
            }
            else if (shootDirection == 6)
            {
                playAnimation("attackDown", false);
                currentDirection = myDirection.down;
            }
            else if (shootDirection == 7)
            {
                playAnimation("attackDown", false);
                currentDirection = myDirection.down;
            }
            else if (shootDirection == 8)
            {
                playAnimation("attackUp", false);
                currentDirection = myDirection.up;
            }
            currentDirection = myDirection.none;
        }

       public void getMap(Map map, mapTile maptile)
        {
            this.map = map;
            this.maptile = maptile;
        }

        public void getMap2(mountainMap mountainMap)
        {
            this.mountainMap = mountainMap;
        }
        public void getMap3(CastleTile castleMap)
        {
            this.castleMap = castleMap;
        }


        public void abilityHandler(GameTime gameTime)
        {
            if (abilityOne)
            {
                    
                timerOne.startTimer(15);

                timerOne.update(gameTime);

                if (timerOne.checkTimer)
                {
                    
                    abilityOne = false;
                    shManager.incFireRate = 0.5f;
                }
            }
            if (abilityTwo)
            {
               
                timerTwo.startTimer(15);
                timerTwo.update(gameTime);

                if (timerTwo.checkTimer)
                {
                    abilityTwo = false;
                    mySpeed = 120;
                }
            }
            if (abilityThree)
            {
                
                timerThree.startTimer(15);
                timerThree.update(gameTime);

                if (timerThree.checkTimer)
                {
                    abilityThree = false;
                    enManager.reducespeed = false;
                }
            }
            if (abilityFour)
            {
                
                timerFour.startTimer(10);
                timerFour.update(gameTime);

                if (timerFour.checkTimer)
                {
                    abilityFour = false;
                    shManager.megaSize= false;
                }
            }
        }

        public String myCurrentAnimation
        {
            get { return currentAnimation; }
        }

        public int indexFrame
        {
            get { return frameIndex; }
        }

    }
  } 