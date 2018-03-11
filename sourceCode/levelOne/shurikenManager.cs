using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bushido
{
    class shurikenManager
    {
        
        static bool MegaSize = false;
        EnemyManager enManager;
        EnemyDeathManager zombieDeath;
        public bool megaSize
        {
            get { return MegaSize; }
            set { MegaSize = value; }
        }
       
        float disappearDistance = 350f;
        float megaDisappearDistance = 400f;
        static Texture2D shurTexture;
        static Texture2D megaShurTexture;
        Rectangle shurRectangle;
        static public List<shuriken> Shurikens;
        static public List<megaShuriken> megaShurikens;
        SFX soundEffects;
        static float RATE_OF_FIRE = 0.5f;
        public float incFireRate
        {
            get { return RATE_OF_FIRE; }
            set { RATE_OF_FIRE = value; }
        }

        bossOne sultanaSuke;
        bossTwo saulMander;

        static TimeSpan previousLaserSpawnTime;
        abilityManager abilities;
       // GraphicsDeviceManager graphics;

       // static Vector2 graphicsInfo;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        public void Initialize(Texture2D texture, Texture2D megaTexture, GraphicsDevice Graphics, ContentManager content, abilityManager abilities,EnemyDeathManager zombieDeath, SFX soundEffects)
        {
            Shurikens = new List<shuriken>();
            megaShurikens = new List<megaShuriken>();
            previousLaserSpawnTime = TimeSpan.Zero;
            shurTexture = texture;
            megaShurTexture = megaTexture;
            this.zombieDeath = zombieDeath;
            this.abilities = abilities;
            MegaSize = false;
            this.soundEffects = soundEffects;
            //graphicsInfo.X = Graphics.Viewport.Width;
            // graphicsInfo.Y = Graphics.Viewport.Height;

        }
        public void giveManager()
        {
            enManager.getDeathManager(zombieDeath);
        }
        
        private void FireLaser(GameTime gameTime, Hero styrax, int direction)
        {
             TimeSpan laserSpawnTime = TimeSpan.FromSeconds(RATE_OF_FIRE);

            if (gameTime.TotalGameTime - previousLaserSpawnTime > laserSpawnTime)
            {
                previousLaserSpawnTime = gameTime.TotalGameTime;
                styrax.fireShurikenAnimation();
                addShuriken(styrax, direction);
            }
         }

        private void addShuriken(Hero styrax, int direction)
        {
           // shurikenAnimation shurAnimation = new shurikenAnimation();
           // shurAnimation.Initialize(shurTexture, styrax.position, 30, 30, 2, 30, Color.White, 1f, true);
           
            var shurPosition = styrax.position;
            if (!MegaSize)
            {
                if (styrax.shootDirection == 1)
                {
                    shurPosition.X += 24;
                }
                else if (styrax.shootDirection == 2)
                {
                    shurPosition.Y += 17;
                    shurPosition.X += 34;
                }
                else if (styrax.shootDirection == 3)
                {
                    shurPosition.Y += 25;
                    shurPosition.X += 24;
                }
                else if (styrax.shootDirection == 4)
                {
                    shurPosition.Y += 17;
                    shurPosition.X += 10;
                }

                 shuriken shuriken = new shuriken(shurPosition);
                 shuriken.Initialize(direction, styrax);
                 shuriken.LoadContent(shurTexture);
                 Shurikens.Add(shuriken);
                 soundEffects.playShuriken(1);

            }
            else
            {
                if (styrax.shootDirection == 1)
                {
                    shurPosition.X += 24;
                }
                else if (styrax.shootDirection == 2)
                {
                    shurPosition.X += 14;
                }
                else if (styrax.shootDirection == 3)
                {
                    shurPosition.Y += 20;
                    shurPosition.X += 2;
                }
                else if (styrax.shootDirection == 4)
                {
                   // shurPosition.Y += 17;
                    shurPosition.X -= 20;
                }



                megaShuriken megashuriken = new megaShuriken(shurPosition);
                megashuriken.Initialize(direction, styrax);
                megashuriken.LoadContent(megaShurTexture);
                megaShurikens.Add(megashuriken);
                soundEffects.playMegaShuriken(1);

            }
           
        }

        public void Update(GameTime gameTime, Hero styrax,Camera camera)
        {


            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            currentKeyboardState = Keyboard.GetState();

            if (!styrax.hasFallen)
            {
                if (!styrax.iAmInACutscene && !styrax.inLevelThreeCutscene)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Triggers.Right == 1.0f)
                    {

                        if (styrax.shootDirection == 1)
                        {
                            int a = 1;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 2)
                        {
                            int a = 2;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 3)
                        {
                            int a = 3;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 4)
                        {
                            int a = 4;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 5)
                        {
                            int a = 5;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 6)
                        {
                            int a = 6;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 7)
                        {
                            int a = 7;
                            FireLaser(gameTime, styrax, a);
                        }
                        else if (styrax.shootDirection == 8)
                        {
                            int a = 8;
                            FireLaser(gameTime, styrax, a);
                        }
                    }
                }
            }
            Random rand = new Random();


         for (var i = 0; i < Shurikens.Count; i++)
            {
                Shurikens[i].Update(gameTime, styrax);
                if (!Shurikens[i].Active || Vector2.Distance(styrax.position, Shurikens[i].Position) >= disappearDistance)
                {
                    Shurikens.Remove(Shurikens[i]);
                }
            }

            for (var i = 0; i < megaShurikens.Count; i++)
            {
                megaShurikens[i].Update(gameTime, styrax);
                if (!megaShurikens[i].Active || Vector2.Distance(styrax.position, megaShurikens[i].Position) >= megaDisappearDistance)
                {
                    megaShurikens.Remove(megaShurikens[i]);
                }
            }
            #region normZombieVSshurikens
            foreach (Enemy z in EnemyManager.enemiesType1)
            {
                Rectangle zombieRectangle = new Rectangle((int)z.EnPOS.X +21, (int)z.EnPOS.Y+20, 21, 23);

                foreach (shuriken s in Shurikens)
                {
                    shurRectangle = new Rectangle((int)s.Position.X+5, (int)s.Position.Y-5, 25, 25);
                    
                    

                    if (shurRectangle.Intersects(zombieRectangle))
                    {    
                        z.Active = false;
                        
                        zombieDeath.AddExplosions(z.EnPOS);
                         s.Actives = false;
                        abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                        if (waveManager.waveOne)
                        {
                           waveManager.waveOneCounter--;
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                    }  
                }

                foreach (megaShuriken s in megaShurikens)
                {
                    

                    shurRectangle = new Rectangle((int)s.Position.X + 8, (int)s.Position.Y +5, 45, 39);

                    if (shurRectangle.Intersects(zombieRectangle))
                    {
                        z.Active = false;
                      
                        if (waveManager.waveOne)
                        {
                     if (levelManager.levelIndicator != levelManager.levels.trainLevel)
                            { waveManager.waveOneCounter--; }
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                        zombieDeath.AddExplosions(z.EnPOS);
                        s.Actives = false;
                        abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                    }
                }
            }
            #endregion

            #region thiefZombiesVSshurikens
            foreach (enemyTwo z in EnemyManager.enemiesType2)
            {
                Rectangle zombieRectangle = new Rectangle((int)z.EnPOS.X + 25, (int)z.EnPOS.Y+17, 15, 26);

                foreach (shuriken s in Shurikens)
                {
                    shurRectangle = new Rectangle((int)s.Position.X + 5, (int)s.Position.Y - 5, 25, 25);



                    if (shurRectangle.Intersects(zombieRectangle))
                    {
                        z.Active = false;

                        zombieDeath.AddExplosions(z.EnPOS);
                        s.Actives = false;
                        abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                        if (waveManager.waveOne)
                        {
                            waveManager.waveOneCounter--;
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                    }
                }

                foreach (megaShuriken s in megaShurikens)
                {


                    shurRectangle = new Rectangle((int)s.Position.X + 8, (int)s.Position.Y + 5, 45, 39);

                    if (shurRectangle.Intersects(zombieRectangle))
                    {
                        z.Active = false;

                        if (waveManager.waveOne)
                        {
                            waveManager.waveOneCounter--;
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                        zombieDeath.AddExplosions(z.EnPOS);
                        s.Actives = false;
                        abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                    }
                }
            }
            #endregion

            #region SamuraiZombiesVSshurikens
            foreach (enemyThree z in EnemyManager.enemiesType3)
            {
                Rectangle zombieRectangle = new Rectangle((int)z.EnPOS.X + 30, (int)z.EnPOS.Y, 1, 32);

                foreach (shuriken s in Shurikens)
                {
                    shurRectangle = new Rectangle((int)s.Position.X + 5, (int)s.Position.Y - 5, 25, 25);



                    if (shurRectangle.Intersects(zombieRectangle))
                    {
                        z.health -= 1;

                        if(z.health <= 0)
                        {
                           z.Active = false;
                           zombieDeath.AddExplosions(z.EnPOS);
                            abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                            if (waveManager.waveOne)
                        {
                            waveManager.waveOneCounter--;
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                       }
                      

                       
                        s.Actives = false;
                        
                    }
                }

                foreach (megaShuriken s in megaShurikens)
                {


                    shurRectangle = new Rectangle((int)s.Position.X + 8, (int)s.Position.Y + 5, 45, 39);

                    if (shurRectangle.Intersects(zombieRectangle))
                    {
                        z.Active = false;

                        if (waveManager.waveOne)
                        {
                            waveManager.waveOneCounter--;
                        }
                        else if (waveManager.waveTwo)
                        {
                            waveManager.waveTwoCounter--;
                        }
                        else if (waveManager.waveThree)
                        {
                            waveManager.waveThreeCounter--;
                        }
                        else if (waveManager.bossBattle)
                        {
                            waveManager.waveBossCount--;
                        }
                        zombieDeath.AddExplosions(z.EnPOS);
                        s.Actives = false;
                        abilities.dropAbility(rand.Next(0, 20), z.EnPOS);

                    }
                }
            }
            #endregion

            #region BossesvsShurikens

            if (EnemyManager.bossIsActive)
            {
                switch (levelManager.levelIndicator)
                {


                    case levelManager.levels.trainLevel:
                        {



                            break;
                        }
                    case levelManager.levels.levelOne:
                        {
                            #region bossOnevsShuriken

                            
                            Rectangle zombieRectangle = new Rectangle((int)sultanaSuke.EnPOS.X + 18, (int)sultanaSuke.EnPOS.Y + 16, 22, 28);


                            foreach (shuriken s in Shurikens)
                            {
                                shurRectangle = new Rectangle((int)s.Position.X + 5, (int)s.Position.Y - 5, 25, 25);



                                if (shurRectangle.Intersects(zombieRectangle))
                                {
                                    if (!sultanaSuke.isScreaming)
                                    {
                                        sultanaSuke.sultanaHealth -= 2;
                                    }



                                    if (sultanaSuke.sultanaHealth <= 0)
                                    {
                                        sultanaSuke.Active = false;
                                        zombieDeath.AddExplosions(sultanaSuke.EnPOS);
                                       
                                        waveManager.bossBattle = false;
                                        enManager.noMoreOne = true;
                                    }

                                    s.Actives = false;

                                }
                            }

                                foreach (megaShuriken s in megaShurikens)
                                {


                                    shurRectangle = new Rectangle((int)s.Position.X + 8, (int)s.Position.Y + 5, 45, 39);

                                    if (shurRectangle.Intersects(zombieRectangle))
                                    {
                                            if (!sultanaSuke.isScreaming)
                                           {
                                               sultanaSuke.sultanaHealth -= 5;
                                           }

                                            if (sultanaSuke.sultanaHealth <= 0)
                                        {
                                            sultanaSuke.Active = false;
                                            zombieDeath.AddExplosions(sultanaSuke.EnPOS);
                                           
                                           waveManager.bossBattle = false;
                                          enManager.noMoreOne = true;

                                    }
                                       s.Actives = false; 
                                    }
                                }
                              
                            
                            #endregion
                            break;
                        }
                    case levelManager.levels.levelTwo:
                        {
                            #region bossTwovsShuriken

                            Rectangle zombieRectangle = new Rectangle((int)saulMander.EnPOS.X + 18, (int)saulMander.EnPOS.Y + 16, 22, 28);


                            foreach (shuriken s in Shurikens)
                            {
                                shurRectangle = new Rectangle((int)s.Position.X + 5, (int)s.Position.Y - 5, 25, 25);



                                if (shurRectangle.Intersects(zombieRectangle))
                                {
                                    if (!saulMander.isTransforming)
                                    {
                                        saulMander.saulManderHealth -= 3;
                                    }



                                    if (saulMander.saulManderHealth <= 0)
                                    {
                                        saulMander.Active = false;
                                        zombieDeath.AddExplosions(saulMander.EnPOS);
                                        EnemyManager.bossIsActive = false;
                                        waveManager.bossBattle = false;
                                       enManager.noMoreTwo = true;
                                    }

                                    s.Actives = false;

                                }
                            }

                            foreach (megaShuriken s in megaShurikens)
                            {


                                shurRectangle = new Rectangle((int)s.Position.X + 8, (int)s.Position.Y + 5, 45, 39);

                                if (shurRectangle.Intersects(zombieRectangle))
                                {
                                    if (!saulMander.isTransforming)
                                    {
                                        saulMander.saulManderHealth -= 8;
                                    }



                                    if (saulMander.saulManderHealth <= 0)
                                    {
                                        saulMander.Active = false;
                                        zombieDeath.AddExplosions(saulMander.EnPOS);
                                        EnemyManager.bossIsActive = false;
                                        waveManager.bossBattle = false;
                                        enManager.noMoreTwo = true;
                                    }

                                    s.Actives = false;
                                }
                            }


                            #endregion

                            break;
                        }
                    case levelManager.levels.levelThree:
                        {


                            break;
                        }
                }
            }



           

            #endregion

            //zombieDeath.updateExplosions(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
            foreach (var item in Shurikens)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in megaShurikens)
            {
                item.Draw(spriteBatch);
            }
        }

        public void getBoss(bossOne sultanaSuke)
        {
            this.sultanaSuke = sultanaSuke;
        }
        public void getBoss(bossTwo saulMander)
        {
            this.saulMander = saulMander;
        }
        public void getEnManager(EnemyManager enManager)
        {
            this.enManager = enManager;
        }
        /*
             public void getBoss(bossOne sultanaSuke)
             {
                 this.sultanaSuke = sultanaSuke;
             }

             public void getBoss(bossOne sultanaSuke)
             {
                 this.sultanaSuke = sultanaSuke;
             }

             */

    }
    
}
