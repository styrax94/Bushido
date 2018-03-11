using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
    class EnemyManager
    {
        // Enemy Description 
        ///Texture2D enemyTexture;

        static public List<Enemy> enemiesType1;
        static public List<enemyTwo> enemiesType2;
        static public List<enemyThree> enemiesType3;
        static public bool bossIsActive;
        public bool bossIsInitialized;
        EnemyDeathManager zombieDeath;
        bool alreadyExplodedZombies;
        public bool noMoreZombiesLevelOne;
        public bool noMoreZombiesLevelTwo;
        public bool noMoreZombiesLevelThree;
        public bool soundIsActive;
        public bool noMoreHordes;
        SFX specialEffects;

        public bool noMoreOne
        {
            set { noMoreZombiesLevelOne = value; }
            get { return noMoreZombiesLevelOne; }
        }
        public bool noMoreTwo
        {
            set { noMoreZombiesLevelTwo = value; }
            get { return noMoreZombiesLevelTwo; }
        }
        public bool noMoreThree
        {
            set { noMoreZombiesLevelThree = value; }
            get { return noMoreZombiesLevelThree; }
        }

        public Vector2[] hordePositions = {new Vector2(410,256),new Vector2(410,493),
            new Vector2(410,645),new Vector2(410,803), new Vector2(1297,256),new Vector2(1297,493), new Vector2(1297,645),
            new Vector2(1297,803)
        };
        bossOne sultanaSan;
        HealthBar healthbar;
        bossTwo saulMander;
        EnemyDeathManager deathManager;
        public bool exploInitialized;
        shurikenManager shManager;
        ContentManager content;
        Hero player;
        Map map;
        mapTile maptile;
        explosionDeath death;
        mountainMap mountainMap;
        CastleTile castleMap;
        bool reduceSpeed;
        public bool dontSpawn;
        bool firstSpawn;
        // Handle the graphics info
        GraphicsDeviceManager graphics;
        // Rate at which the enemies will appear
        // Use to determine how fast enemy respwns;
        TimeSpan previousSpawnTime = TimeSpan.Zero;//SET THE TIME KEEPERS TO ZERO
        // A random number generator for position to appear
        Random ran = new Random();
        
        public bool reducespeed
        {
            set { reduceSpeed = value; }
        }
        //Handle Graphics info
        Vector2 graphicsInfo;

        #region testingforflock
        float reactionDistance = 35f;
        float killHeroDistance = 4f;
        #endregion
        public void getSManager(shurikenManager shManager, HealthBar healthbar)
        {
            this.shManager = shManager;
            this.healthbar = healthbar;
        }
        public void Initialize(GraphicsDevice Graphics, Hero player, ContentManager content,EnemyDeathManager zombieDeath)
        {
            //graphicsInfo.X = Graphics.Viewport.Width;
            //  graphicsInfo.Y = Graphics.Viewport.Height;
            //Enemy enemy = new Enemy(new Vector2(200, 300));
            this.player = player;
            this.content = content;
            waveManager.checkLevel();
            enemiesType1 = new List<Enemy>();
            enemiesType2 = new List<enemyTwo>();
            enemiesType3 = new List<enemyThree>();
            bossIsActive = false;
            bossIsInitialized = false;
            noMoreZombiesLevelOne = false;
            noMoreZombiesLevelTwo = false;
            noMoreZombiesLevelThree = false;
            this.zombieDeath = zombieDeath;
            alreadyExplodedZombies = false;
            soundIsActive = false;
            dontSpawn = false;
            firstSpawn = false;
            reduceSpeed = false;
            noMoreHordes = false;
            exploInitialized = false;
        } 
        private void AddEnemy()
        {


            int x = ran.Next(0, 2200);
            int y = ran.Next(0, 1200);
           
            #region levelOne waves
            if (levelManager.levelIndicator == levelManager.levels.levelOne)
            {
                if (waveManager.waveOne)
                {
                    if (waveManager.waveOneEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveOneEnemyOne--;
                    }
                }

                else if (waveManager.waveTwo)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveTwoEnemyTwo > 0)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);

                        waveManager.waveTwoEnemyTwo--;
                    }
                    else if (waveManager.waveTwoEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveTwoEnemyOne--;
                    }
                }
                else if (waveManager.waveThree)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveThreeEnemyTwo > 0)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);

                        waveManager.waveThreeEnemyTwo--;
                    }
                    else if (waveManager.waveThreeEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveThreeEnemyOne--;
                    }
                }
                else if (waveManager.bossBattle)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveBossCount <= waveManager.waveBossMax)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);
                        waveManager.waveBossCount++;
                    }
                    else if (waveManager.waveBossCount <= waveManager.waveBossMax)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);
                        waveManager.waveBossCount++;
                    }
                }
            }
            #endregion

            #region levelTwo Waves
            
           else if (levelManager.levelIndicator == levelManager.levels.levelTwo)
            {
                if (waveManager.waveOne)
                {

                    if (ran.Next(1, 4) == 1 && waveManager.waveOneEnemyTwo > 0)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);

                        waveManager.waveOneEnemyTwo--;
                    }



                    else if (waveManager.waveOneEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveOneEnemyOne--;
                    }
                }

                else if (waveManager.waveTwo)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveTwoEnemyTwo > 0)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);

                        waveManager.waveTwoEnemyTwo--;
                    }
                    else if (ran.Next(1, 10) == 1 && waveManager.waveTwoEnemyThree > 0)
                    {
                        enemyThree enemy3 = new enemyThree(new Vector2(x, y));
                        enemy3.initialize(player);
                        enemy3.LoadContent(content);
                        enemiesType3.Add(enemy3);

                        waveManager.waveTwoEnemyThree--;
                    }
                    else if (waveManager.waveTwoEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveTwoEnemyOne--;
                    }
                }
                else if (waveManager.waveThree)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveThreeEnemyTwo > 0)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);

                        waveManager.waveThreeEnemyTwo--;
                    }
                    else if (ran.Next(1, 10) == 1 && waveManager.waveThreeEnemyThree > 0)
                    {
                        enemyThree enemy3 = new enemyThree(new Vector2(x, y));
                        enemy3.initialize(player);
                        enemy3.LoadContent(content);
                        enemiesType3.Add(enemy3);

                        waveManager.waveThreeEnemyThree--;
                    }
                    else if (waveManager.waveThreeEnemyOne > 0)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);

                        waveManager.waveThreeEnemyOne--;
                    }
                }

                else if (waveManager.bossBattle)
                {
                    if (ran.Next(1, 4) == 1 && waveManager.waveBossCount <= waveManager.waveBossMax)
                    {
                        enemyTwo enemy2 = new enemyTwo(new Vector2(x, y));
                        enemy2.initialize(player);
                        enemy2.LoadContent(content);
                        enemiesType2.Add(enemy2);
                        waveManager.waveBossCount++;

                    }
                    else if (ran.Next(1, 10) == 1 && waveManager.waveBossCount <= waveManager.waveBossMax)
                    {
                        enemyThree enemy3 = new enemyThree(new Vector2(x, y));
                        enemy3.initialize(player);
                        enemy3.LoadContent(content);
                        enemiesType3.Add(enemy3);
                        waveManager.waveBossCount++;

                    }
                    else if (waveManager.waveBossCount <= waveManager.waveBossMax)
                    {
                        Enemy enemy = new Enemy(new Vector2(x, y));
                        enemy.initialize(player);
                        enemy.LoadContent(content);
                        enemiesType1.Add(enemy);
                        waveManager.waveBossCount++;

                    }
                }
            }
            else if(levelManager.levelIndicator == levelManager.levels.trainLevel)
            {
                Enemy enemy = new Enemy(new Vector2(800, 200));
                enemy.initialize(player);
                enemy.LoadContent(content);
                enemiesType1.Add(enemy);
               
            }

            #endregion
        }

        public void UpdateEnemies(GameTime gameTime)
        {
           
            if (!bossIsActive)
            {
                bossIsInitialized = false;
            }

            TimeSpan enemySpawnTime = TimeSpan.FromSeconds(2f);

            //changeEnemySpawnTime
            #region EnemySpawnTime
            switch (levelManager.levelIndicator)
            {
                case levelManager.levels.trainLevel:
                    {

                        enemySpawnTime = TimeSpan.FromSeconds(1.5f);

                        break;
                    }
                case levelManager.levels.levelOne:
                    {
                        //levelOneWaveSpawns
                        #region


                        if (waveManager.waveOne)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(1.3f);
                        }
                        else if (waveManager.waveTwo)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(1f);
                        }
                        else if (waveManager.waveThree)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(.8f);
                        }
                        else if (waveManager.bossBattle)
                        {
                            if (bossIsActive)
                            {
                                if (sultanaSan.screamEffectIsOn)
                                {
                                    enemySpawnTime = TimeSpan.FromSeconds(0.4f);
                                }
                                else
                                {
                                    enemySpawnTime = TimeSpan.FromSeconds(1.5f);
                                }
                            }
                        }



                        #endregion


                        break;
                    }
                case levelManager.levels.levelTwo:
                    {
                        if (waveManager.waveOne)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(1f);
                        }
                        else if (waveManager.waveTwo)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(0.8f);
                        }
                        else if (waveManager.waveThree)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(0.5f);
                        }
                        else if (waveManager.bossBattle)
                        {

                        }


                        break;
                    }
                case levelManager.levels.levelThree:
                    {
                        if (!firstSpawn)
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(1f);
                            firstSpawn = true;
                        }
                        else
                        {
                            enemySpawnTime = TimeSpan.FromSeconds(6.5f);
                        }
                       

                        break;
                    }
            }


            #endregion
            #region spawnEnemiesAccordingToWavesandLevels

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // spawn a new enemy every, time varies on waves

            if (gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime)
            {
                previousSpawnTime = gameTime.TotalGameTime;


                if (waveManager.waveOne)
                {
                    if (waveManager.waveOneCounter > 0)
                    {
                        AddEnemy();
                    }

                    if (waveManager.waveOneCounter <= 0)
                    {
                        waveManager.waveOne = false;
                        waveManager.waveTwo = true;
                    }
                }
                else if (waveManager.waveTwo)
                {
                    if (waveManager.waveTwoCounter > 0)
                    {
                        AddEnemy();
                    }
                    if (waveManager.waveTwoCounter <= 0)
                    {
                        waveManager.waveTwo = false;
                        waveManager.waveThree = true;
                    }

                }
                else if (waveManager.waveThree)
                {
                    if (waveManager.waveThreeCounter > 0)
                    {
                        AddEnemy();
                    }

                    if (waveManager.waveThreeCounter <= 0)
                    {
                        waveManager.waveThree = false;
                        waveManager.bossBattle = true;
                    }
                }
                else if (waveManager.bossBattle)
                {


                    if (bossIsActive)
                    {
                        AddEnemy();


                    }


                    else
                    {
                        if (!bossIsInitialized)
                        {
                            intializeBoss();
                        }
                        bossIsInitialized = true;
                    }

                }

                else if (levelManager.levelIndicator == levelManager.levels.levelThree)
                {
                    if(!dontSpawn)
                        AddHorde();
                      
                
                    
                }

                else if(levelManager.levelIndicator == levelManager.levels.trainLevel)
                {
                    AddEnemy();
                }
            }
            #endregion

            giveMap();


            // Update enemies

           
            //begin,getting direction for zombies


            #region normZombiesDetect  

            for (int i = 0; i < enemiesType1.Count; i++)
            {
                Vector2 coll;



                for (int b = 0; b < enemiesType1.Count; b++)
                {
                    if (i != b)
                    {

                        if ((Vector2.Distance(enemiesType1[i].EnPOS, enemiesType1[b].EnPOS)) <= reactionDistance)
                        {
                            coll = Vector2.Subtract(enemiesType1[i].EnPOS, enemiesType1[b].EnPOS);
                            coll.Normalize();
                            enemiesType1[i].detectCollision();

                            if (!enemiesType1[i].hasCollided)
                            {
                                enemiesType1[i].EnPOS += coll;
                            }
                            else
                            {
                                
                            }


                        }
                    }

                }


                for (int b = 0; b < enemiesType2.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType1[i].EnPOS, enemiesType2[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType1[i].EnPOS, enemiesType2[b].EnPOS);
                        coll.Normalize();
                        enemiesType1[i].detectCollision();

                        if (!enemiesType1[i].hasCollided)
                        {
                            enemiesType1[i].EnPOS += coll;
                        }
                        else
                        {
                            // enemiesType1[i].direction = Vector2.Zero; 
                        }


                    }
                }


                for (int b = 0; b < enemiesType3.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType1[i].EnPOS, enemiesType3[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType1[i].EnPOS, enemiesType3[b].EnPOS);
                        coll.Normalize();
                        enemiesType1[i].detectCollision();
                        if (!enemiesType1[i].hasCollided)
                        {
                            enemiesType1[i].EnPOS += coll;
                        }
                        else
                        {
                           

                        }

                    }
                }

                if (bossIsActive)
                {
                    switch (levelManager.levelIndicator)
                    {
                        case levelManager.levels.trainLevel:
                            {



                                break;
                            }
                        case levelManager.levels.levelOne:
                            {
                                if ((Vector2.Distance(enemiesType1[i].EnPOS, sultanaSan.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType1[i].EnPOS, sultanaSan.EnPOS);
                                    coll.Normalize();
                                    enemiesType1[i].detectCollision();

                                    if (!enemiesType1[i].hasCollided)
                                    {
                                        enemiesType1[i].EnPOS += coll;
                                    }
                                    else
                                    {
                                        //  enemiesType1[i].direction = Vector2.Zero;
                                    }
                                }
                                break;
                            }
                        case levelManager.levels.levelTwo:
                            {
                                if ((Vector2.Distance(enemiesType1[i].EnPOS, saulMander.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType1[i].EnPOS, saulMander.EnPOS);
                                    coll.Normalize();
                                    enemiesType1[i].detectCollision();

                                    if (!enemiesType1[i].hasCollided)
                                    {
                                        enemiesType1[i].EnPOS += coll;
                                    }
                                }

                                break;
                            }
                        case levelManager.levels.levelThree:
                            {


                                break;
                            }
                    }
                }


                if (!player.hasFallen)
                {
                    enemiesType1[i].chaseHero(deltaTime);
                }


                if ((Vector2.Distance(enemiesType1[i].EnPOS, player.position) < killHeroDistance))
                {
                    player.hasFallen = true;
                }

                if (player.hasFallen)
                {
                    if ((Vector2.Distance(enemiesType1[i].EnPOS, player.position) < 50))
                    {
                        coll = Vector2.Subtract(enemiesType1[i].EnPOS, player.position);
                        coll.Normalize();
                        enemiesType1[i].EnPOS += coll;
                    }

                }

            }
            #endregion

            #region thiefZombieDetect
            for (int i = 0; i < enemiesType2.Count; i++)
            {
                Vector2 coll;
                if (!player.hasFallen)
                {
                    enemiesType2[i].chaseHero(deltaTime);
                }


                if ((Vector2.Distance(enemiesType2[i].EnPOS, player.position) < killHeroDistance))
                {
                    player.hasFallen = true;
                }

                if (player.hasFallen)
                {
                    if ((Vector2.Distance(enemiesType2[i].EnPOS, player.position) < 50))
                    {
                        coll = Vector2.Subtract(enemiesType2[i].EnPOS, player.position);
                        coll.Normalize();
                        enemiesType2[i].EnPOS += coll;
                    }

                }

                for (int b = 0; b < enemiesType2.Count; b++)
                {
                    if (i != b)
                    {

                        if ((Vector2.Distance(enemiesType2[i].EnPOS, enemiesType2[b].EnPOS)) <= reactionDistance)
                        {
                            coll = Vector2.Subtract(enemiesType2[i].EnPOS, enemiesType2[b].EnPOS);
                            coll.Normalize();
                            enemiesType2[i].detectCollision();
                            if (!enemiesType2[i].hasCollided)
                            {
                                enemiesType2[i].EnPOS += coll;
                            }
                            else
                            {
                                
                            }


                        }
                    }

                }


                for (int b = 0; b < enemiesType1.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType2[i].EnPOS, enemiesType1[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType2[i].EnPOS, enemiesType1[b].EnPOS);
                        coll.Normalize();
                        enemiesType2[i].detectCollision();
                        if (!enemiesType2[i].hasCollided)
                        {
                            enemiesType2[i].EnPOS += coll;
                        }
                        else
                        {
                           
                        }

                    }
                }


                for (int b = 0; b < enemiesType3.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType2[i].EnPOS, enemiesType3[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType2[i].EnPOS, enemiesType3[b].EnPOS);
                        coll.Normalize();
                        enemiesType2[i].detectCollision();
                        if (!enemiesType2[i].hasCollided)
                        {
                            enemiesType2[i].EnPOS += coll;
                        }
                        else
                        {
                           
                        }

                    }
                }

                if (bossIsActive)
                {
                    switch (levelManager.levelIndicator)
                    {
                        case levelManager.levels.trainLevel:
                            {



                                break;
                            }
                        case levelManager.levels.levelOne:
                            {
                                if ((Vector2.Distance(enemiesType2[i].EnPOS, sultanaSan.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType2[i].EnPOS, sultanaSan.EnPOS);
                                    coll.Normalize();
                                    enemiesType2[i].detectCollision();

                                    if (!enemiesType2[i].hasCollided)
                                    {
                                        enemiesType2[i].EnPOS += coll;
                                    }
                                    else
                                    {
                                        
                                    }
                                }
                                break;
                            }
                        case levelManager.levels.levelTwo:
                            {

                                if ((Vector2.Distance(enemiesType2[i].EnPOS, saulMander.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType2[i].EnPOS, saulMander.EnPOS);
                                    coll.Normalize();
                                    enemiesType2[i].detectCollision();

                                    if (!enemiesType2[i].hasCollided)
                                    {
                                        enemiesType2[i].EnPOS += coll;
                                    }
                                }
                                    break;
                            }
                        case levelManager.levels.levelThree:
                            {


                                break;
                            }
                    }
                }
            }
            #endregion

            #region samuraiZombie

            for (int i = 0; i < enemiesType3.Count; i++)
            {
                Vector2 coll;
                if (!player.hasFallen)
                {
                    enemiesType3[i].chaseHero(deltaTime);
                }


                if ((Vector2.Distance(enemiesType3[i].EnPOS, player.position) < killHeroDistance))
                {
                    player.hasFallen = true;
                }

                if (player.hasFallen)
                {
                    if ((Vector2.Distance(enemiesType3[i].EnPOS, player.position) < 50))
                    {
                        coll = Vector2.Subtract(enemiesType3[i].EnPOS, player.position);
                        coll.Normalize();
                        enemiesType3[i].EnPOS += coll;
                    }

                }
                for (int b = 0; b < enemiesType3.Count; b++)
                {
                    if (i != b)
                    {

                        if ((Vector2.Distance(enemiesType3[i].EnPOS, enemiesType3[b].EnPOS)) <= reactionDistance)
                        {
                            coll = Vector2.Subtract(enemiesType3[i].EnPOS, enemiesType3[b].EnPOS);
                            coll.Normalize();
                            enemiesType3[i].detectCollision();
                            if (!enemiesType3[i].hasCollided)
                            {
                                enemiesType3[i].EnPOS += coll;
                            }

                        }
                    }

                }


                for (int b = 0; b < enemiesType1.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType3[i].EnPOS, enemiesType1[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType3[i].EnPOS, enemiesType1[b].EnPOS);
                        coll.Normalize();
                        enemiesType3[i].detectCollision();
                        if (!enemiesType3[i].hasCollided)
                        {
                            enemiesType3[i].EnPOS += coll;
                        }

                    }
                }


                for (int b = 0; b < enemiesType2.Count; b++)
                {
                    if ((Vector2.Distance(enemiesType3[i].EnPOS, enemiesType2[b].EnPOS)) <= reactionDistance)
                    {
                        coll = Vector2.Subtract(enemiesType3[i].EnPOS, enemiesType2[b].EnPOS);
                        coll.Normalize();
                        enemiesType3[i].detectCollision();
                        if (!enemiesType3[i].hasCollided)
                        {
                            enemiesType3[i].EnPOS += coll;
                        }
                    }
                }

                if (bossIsActive)
                {
                    switch (levelManager.levelIndicator)
                    {
                        case levelManager.levels.trainLevel:
                            {



                                break;
                            }
                        case levelManager.levels.levelOne:
                            {
                                if ((Vector2.Distance(enemiesType3[i].EnPOS, sultanaSan.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType3[i].EnPOS, sultanaSan.EnPOS);
                                    coll.Normalize();
                                    enemiesType3[i].detectCollision();

                                    if (!enemiesType3[i].hasCollided)
                                    {
                                        enemiesType3[i].EnPOS += coll;
                                    }

                                }
                                break;
                            }
                        case levelManager.levels.levelTwo:
                            {
                                if ((Vector2.Distance(enemiesType3[i].EnPOS, saulMander.EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(enemiesType3[i].EnPOS, saulMander.EnPOS);
                                    coll.Normalize();
                                    enemiesType3[i].detectCollision();

                                    if (!enemiesType3[i].hasCollided)
                                    {
                                        enemiesType3[i].EnPOS += coll;
                                    }
                                }

                                break;
                            }
                        case levelManager.levels.levelThree:
                            {


                                break;
                            }
                    }
                }
            }
            #endregion

            #region collisionForBosses
            if (bossIsActive)
            {
                Vector2 coll;
                switch (levelManager.levelIndicator)
                {
                    case levelManager.levels.trainLevel:
                        {



                            break;
                        }
                    case levelManager.levels.levelOne:
                        {

                            if (!alreadyExplodedZombies)
                            {
                               
                                    if (sultanaSan.sultanaHealth <= 0)
                                    {
                                         for (int i = (enemiesType1.Count - 1); i > 0; i--)
                                         {
                                          enemiesType1[i].Actives = false;
                                           deathManager.AddExplosions(enemiesType1[i].EnPOS);
                                          //enemiesType1.RemoveAt(i);
                                          }
                                    for (int i = (enemiesType2.Count-1); i >0; i--)
                                        {
                                           enemiesType2[i].Actives = false;
                                            deathManager.AddExplosions(enemiesType2[i].EnPOS);
                                          //enemiesType2.RemoveAt(i);
                                    }
                                       
                                          alreadyExplodedZombies = true;
                                         bossIsActive = false;
                                    }
                                //updateAll(gameTime);
                            }

                            if (!soundIsActive)
                            {

                            
                              if (sultanaSan.isScreaming)
                                     {
                                       specialEffects.playSultanaScream(1f);
                                       soundIsActive = true;
                                     }
                              
                             }
                            else
                            {
                                if (!sultanaSan.isScreaming)
                                {
                                        soundIsActive = false;
                                }
                            }











                            if (!sultanaSan.isScreaming)
                            {
                                if (!player.hasFallen)
                                {
                                    sultanaSan.chaseHero(deltaTime);
                                }


                                if ((Vector2.Distance(sultanaSan.EnPOS, player.position) < killHeroDistance))
                                {
                                    player.hasFallen = true;
                                }

                                if (player.hasFallen)
                                {
                                    if ((Vector2.Distance(sultanaSan.EnPOS, player.position) < 50))
                                    {
                                        coll = Vector2.Subtract(sultanaSan.EnPOS, player.position);
                                        coll.Normalize();
                                        sultanaSan.EnPOS += coll;
                                    }

                                }

                            }


                            for (int i = 0; i < enemiesType1.Count; i++)
                            {

                                if ((Vector2.Distance(sultanaSan.EnPOS, enemiesType1[i].EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(sultanaSan.EnPOS, enemiesType1[i].EnPOS);
                                    coll.Normalize();
                                    sultanaSan.detectCollision();

                                    if (!sultanaSan.hasCollided)
                                    {
                                        sultanaSan.EnPOS += coll;
                                    }
                                    else
                                    {
                                        //  enemiesType1[i].direction = Vector2.Zero;
                                    }
                                }
                            }

                            for (int i = 0; i < enemiesType2.Count; i++)
                            {

                                if ((Vector2.Distance(sultanaSan.EnPOS, enemiesType2[i].EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(sultanaSan.EnPOS, enemiesType2[i].EnPOS);
                                    coll.Normalize();
                                    sultanaSan.detectCollision();

                                    if (!sultanaSan.hasCollided)
                                    {
                                        sultanaSan.EnPOS += coll;
                                    }
                                    else
                                    {
                                        //  enemiesType1[i].direction = Vector2.Zero;
                                    }
                                }
                            }


                            break;
                        }
                    case levelManager.levels.levelTwo:
                        {

                            if (!alreadyExplodedZombies)
                            {

                                if (saulMander.saulManderHealth <= 0)
                                {
                                    for (int i = (enemiesType1.Count - 1); i > 0; i--)
                                    {
                                        enemiesType1[i].Actives = false;
                                        deathManager.AddExplosions(enemiesType1[i].EnPOS);
                                        //enemiesType1.RemoveAt(i);
                                    }
                                    for (int i = (enemiesType2.Count - 1); i > 0; i--)
                                    {
                                        enemiesType2[i].Actives = false;
                                        deathManager.AddExplosions(enemiesType2[i].EnPOS);
                                        //enemiesType2.RemoveAt(i);
                                    }
                                    for (int i = (enemiesType3.Count - 1); i > 0; i--)
                                    {
                                        enemiesType3[i].Actives = false;
                                        deathManager.AddExplosions(enemiesType3[i].EnPOS);
                                        //enemiesType2.RemoveAt(i);
                                    }

                                    alreadyExplodedZombies = true;
                                    bossIsActive = false;
                                }
                                //updateAll(gameTime);
                            }






                            if (!alreadyExplodedZombies) {
                                if (saulMander.explode)
                                {
                                    if (!saulMander.Actives)
                                    {
                                        for (int i = 0; i < enemiesType1.Count; i++)
                                        {
                                            enemiesType1[i].Actives = false;
                                            deathManager.AddExplosions(enemiesType1[i].EnPOS);
                                        }
                                        for (int i = 0; i < enemiesType2.Count; i++)
                                        {
                                            enemiesType2[i].Actives = false;
                                            deathManager.AddExplosions(enemiesType2[i].EnPOS);
                                        }
                                        for (int i = 0; i < enemiesType3.Count; i++)
                                        {
                                            enemiesType3[i].Actives = false;
                                            deathManager.AddExplosions(enemiesType3[i].EnPOS);
                                        }

                                        alreadyExplodedZombies = true;
                                    }
                                }
                            }
                            
                            if (!saulMander.isTransforming)
                            {
                                if (!player.hasFallen)
                                {
                                    saulMander.chaseHero(deltaTime);
                                }
                                if ((Vector2.Distance(saulMander.EnPOS, player.position) < killHeroDistance))
                                {

                                    if (!exploInitialized)
                                    {
                                        death = new explosionDeath(saulMander.EnPOS);
                                        death.Initialize(saulMander, player);
                                        death.Loadcontent(content);
                                        exploInitialized = true;
                                        death.playAnimation("zombieDeath", false);
                                        specialEffects.playBlast(1f);
                                    }
                                }
                            }
                            if (player.hasFallen)
                            {
                                if ((Vector2.Distance(saulMander.EnPOS, player.position) < 50))
                                {
                                    coll = Vector2.Subtract(saulMander.EnPOS, player.position);
                                    coll.Normalize();
                                    saulMander.EnPOS += coll;
                                }

                            }

                            for (int i = 0; i < enemiesType1.Count; i++)
                            {

                                if ((Vector2.Distance(saulMander.EnPOS, enemiesType1[i].EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(saulMander.EnPOS, enemiesType1[i].EnPOS);
                                    coll.Normalize();
                                    if (!saulMander.explode)
                                        saulMander.detectCollision();

                                    if (!saulMander.hasCollided)
                                    {
                                        saulMander.EnPOS += coll;
                                    }
                                    else
                                    {
                                        //  enemiesType1[i].direction = Vector2.Zero;
                                    }
                                }
                            }

                            for (int i = 0; i < enemiesType2.Count; i++)
                            {

                                if ((Vector2.Distance(saulMander.EnPOS, enemiesType2[i].EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(saulMander.EnPOS, enemiesType2[i].EnPOS);
                                    coll.Normalize();
                                    if (!saulMander.explode)
                                        saulMander.detectCollision();

                                    if (!saulMander.hasCollided)
                                    {
                                        saulMander.EnPOS += coll;
                                    }
                                    else
                                    {
                                        //  enemiesType1[i].direction = Vector2.Zero;
                                    }
                                }
                            }
                            for (int i = 0; i < enemiesType3.Count; i++)
                            {

                                if ((Vector2.Distance(saulMander.EnPOS, enemiesType3[i].EnPOS)) <= reactionDistance)
                                {
                                    coll = Vector2.Subtract(saulMander.EnPOS, enemiesType3[i].EnPOS);
                                    coll.Normalize();
                                    if (!saulMander.explode)
                                        saulMander.detectCollision();

                                    if (!saulMander.hasCollided)
                                    {
                                        saulMander.EnPOS += coll;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            break;
                        }
                    case levelManager.levels.levelThree:
                        {


                            break;
                        }
                }
            }
            #endregion


            #region UpdateEnemies
            if (exploInitialized)
                death.Update(gameTime);

            for (int i = (enemiesType1.Count - 1); i >= 0; i--)
            {
                if (reduceSpeed)
                {
                    enemiesType1[i].basespeed = 65f;

                }

                else
                {
                    enemiesType1[i].baseSpeed = 120f;
                }

                if ((Vector2.Distance(enemiesType1[i].EnPOS, player.position)) <= 1000)
                {
                   // specialEffects.playStep(0.2f);
                }

                else if ((Vector2.Distance(enemiesType1[i].EnPOS, player.position)) <= 500)
                {
                  //  specialEffects.playStep(0.5f);
                }

                else if ((Vector2.Distance(enemiesType1[i].EnPOS, player.position)) <= 200)
                {
                   // specialEffects.playStep(1f);
                }

                enemiesType1[i].Update(gameTime);
                if (enemiesType1[i].Active == false)
                {
                    specialEffects.playZombieDeath(0.9f);
                    enemiesType1.RemoveAt(i);
                   
                }

            }

            for (int i = (enemiesType2.Count - 1); i >= 0; i--)
            {
                if (reduceSpeed)
                {
                    enemiesType2[i].basespeed = 65f;

                }

                else
                {
                    enemiesType2[i].baseSpeed = 125f;
                }

                if ((Vector2.Distance(enemiesType2[i].EnPOS, player.position)) <= 1000)
                {
                  //  specialEffects.playStep(0.2f);
                }

                else if ((Vector2.Distance(enemiesType2[i].EnPOS, player.position)) <= 500)
                {
                   // specialEffects.playStep(0.5f);
                }

                else if ((Vector2.Distance(enemiesType2[i].EnPOS, player.position)) <= 200)
                {
                   // specialEffects.playStep(1f);
                }

                enemiesType2[i].Update(gameTime);
                if (enemiesType2[i].Active == false)
                {
                    enemiesType2.RemoveAt(i);
                    specialEffects.playZombieDeath(0.9f);
                }

            }

            for (int i = (enemiesType3.Count - 1); i >= 0; i--)
            {
                if (reduceSpeed)
                {
                    enemiesType3[i].basespeed = 85f;

                }

                else
                {
                    enemiesType3[i].baseSpeed = 105f;
                }
                if ((Vector2.Distance(enemiesType3[i].EnPOS, player.position)) <= 1000)
                {
                  //  specialEffects.playStep(0.2f);
                    
                }

                else if ((Vector2.Distance(enemiesType3[i].EnPOS, player.position)) <= 500)
                {
                   // specialEffects.playStep(0.2f);
                }

                else if ((Vector2.Distance(enemiesType3[i].EnPOS, player.position)) <= 200)
                {
                   // specialEffects.playStep(0.2f);
                }

                enemiesType3[i].Update(gameTime);
                if (enemiesType3[i].Active == false)
                { enemiesType3.RemoveAt(i);
                    specialEffects.playZombieDeath(0.9f);
                }

            }

            if (bossIsActive)
            {
                if (reduceSpeed)
                {
                    switch (levelManager.levelIndicator)
                    {
                        case levelManager.levels.trainLevel:
                            {



                                break;
                            }
                        case levelManager.levels.levelOne:
                            {
                                sultanaSan.baseSpeed = 68;
                                sultanaSan.Update(gameTime);

                                break;
                            }
                        case levelManager.levels.levelTwo:
                            {
                                saulMander.baseSpeed = 70;
                                saulMander.Update(gameTime);
                                if (saulMander.explode)
                                {
                                    saulMander.baseSpeed = 500;
                                    saulMander.isTransforming = false;
                                }
                            }
                            break;
                        case levelManager.levels.levelThree:
                            {


                                break;
                            }
                    }
                }

                else
                {
                    if (bossIsActive)
                    {
                        switch (levelManager.levelIndicator)
                        {

                            case levelManager.levels.trainLevel:
                                {



                                    break;
                                }
                            case levelManager.levels.levelOne:
                                {
                                    sultanaSan.baseSpeed = 130;
                                    sultanaSan.Update(gameTime);
                                   
                                    break;
                                }
                            case levelManager.levels.levelTwo:
                                {
                                    saulMander.baseSpeed = 100f;
                                    saulMander.Update(gameTime);
                                    if (saulMander.explode)
                                    {
                                        saulMander.baseSpeed = 500;
                                        saulMander.isTransforming = false;
                                    }


                                    break;
                                }
                            case levelManager.levels.levelThree:
                                {


                                    break;
                                }
                        }

                    }
                }
            }
           


            if (levelManager.levelIndicator == levelManager.levels.levelThree)
            {
                if(waveManager.waveHordCounter== 10 && enemiesType3.Count == 0)
                {
                    noMoreZombiesLevelThree = true;
                }
            }

            #endregion
        }







        public void DrawEnemies(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemiesType1.Count; i++)
            { enemiesType1[i].Draw(spriteBatch); }

            for (int i = 0; i < enemiesType2.Count; i++)
            {
                enemiesType2[i].Draw(spriteBatch);
            }


            for (int i = 0; i < enemiesType3.Count; i++)
            {
                enemiesType3[i].Draw(spriteBatch);
            }


            if (bossIsActive)
            {
                switch (levelManager.levelIndicator)
                {
                    case levelManager.levels.trainLevel:
                        {



                            break;
                        }
                    case levelManager.levels.levelOne:
                        {
                            sultanaSan.Draw(spriteBatch);
                            break;
                        }
                    case levelManager.levels.levelTwo:
                        {
                            if (saulMander.explode)
                            {
                                if (exploInitialized)
                                    death.Draw(spriteBatch);
                            }
                            saulMander.Draw(spriteBatch);

                            break;
                        }
                    case levelManager.levels.levelThree:
                        {


                            break;
                        }
                }
            }

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
        public void getMap4(mapTile maptile)
        {
            this.maptile = maptile;
        }
        public void getDeathManager(EnemyDeathManager deathManager)
        {
            this.deathManager = deathManager;
        }

        public void giveMap()
        {
            switch (levelManager.levelIndicator)
            {
                case levelManager.levels.trainLevel:
                    {

                        for (int c = 0; c < enemiesType1.Count; c++)
                        {
                            enemiesType1[c].getMap3(castleMap);
                        }

                        break;
                    }
                case levelManager.levels.levelOne:
                    {

                        for (int c = 0; c < enemiesType1.Count; c++)
                        {
                            enemiesType1[c].getMap(map);
                            enemiesType1[c].getMap4(maptile);
                        }

                        for (int c = 0; c < enemiesType2.Count; c++)
                        {
                            enemiesType2[c].getMap(map);
                            enemiesType2[c].getMap4(maptile);
                        }


                        if (bossIsActive)
                        { sultanaSan.getMap(map);
                            sultanaSan.getMap4(maptile);
                        }


                        break;
                    }
                case levelManager.levels.levelTwo:
                    {
                        for (int c = 0; c < enemiesType1.Count; c++)
                        {
                            enemiesType1[c].getMap2(mountainMap);
                        }


                        for (int c = 0; c < enemiesType2.Count; c++)
                        {
                            enemiesType2[c].getMap2(mountainMap);
                        }


                        for (int c = 0; c < enemiesType3.Count; c++)
                        {
                            enemiesType3[c].getMap2(mountainMap);
                        }

                        if (bossIsActive)
                        {
                            saulMander.getMap(mountainMap);
                        }

                        break;
                    }
                case levelManager.levels.levelThree:
                    {
                        for (int c = 0; c < enemiesType1.Count; c++)
                        {
                            enemiesType1[c].getMap3(castleMap);
                        }


                        for (int c = 0; c < enemiesType2.Count; c++)
                        {
                            enemiesType2[c].getMap3(castleMap);
                        }

                        for (int c = 0; c < enemiesType3.Count; c++)
                        {
                            enemiesType3[c].getMap3(castleMap);
                        }

                        if (bossIsActive)
                        {

                        }

                        break;
                    }
            }
        }


        public void intializeBoss()
        {

            switch (levelManager.levelIndicator)
            {


                case levelManager.levels.trainLevel:
                    {



                        break;
                    }
                case levelManager.levels.levelOne:
                    {

                        sultanaSan = new bossOne(new Vector2(1500, 250));
                        sultanaSan.initialize(player);
                        sultanaSan.LoadContent(content);
                        bossIsActive = true;
                        giveShurikenBoss(sultanaSan);
                        break;
                    }
                case levelManager.levels.levelTwo:
                    {
                        saulMander = new bossTwo(new Vector2(1500, 250));
                        saulMander.initialize(player);
                        saulMander.LoadContent(content);
                        bossIsActive = true;
                        giveShurikenBoss(saulMander);
                        break;
                    }
                case levelManager.levels.levelThree:
                    {


                        break;
                    }
            }

        }
        public void giveShurikenBoss(bossOne sultanasuke)
        {
            shManager.getBoss(sultanasuke);
            healthbar.getBoss(sultanasuke);

        }

        public void giveShurikenBoss(bossTwo saulMander)
        {
            shManager.getBoss(saulMander);
            healthbar.getBoss(saulMander);
        }

        public void updateAll(GameTime gameTime)
        {
            for(int i = 0; i < enemiesType1.Count; i++)
            {
                if (enemiesType1[i].Active == false)
                {
                    specialEffects.playZombieDeath(0.9f);
                    enemiesType1.Remove(enemiesType1[i]);

                }
                else
                {
                    enemiesType1[i].Update(gameTime);
                }
            }
            for (int i = 0; i < enemiesType2.Count; i++)
            {
                if (enemiesType2[i].Active == false)
                {
                    specialEffects.playZombieDeath(0.9f);
                    enemiesType2.Remove(enemiesType2[i]);

                }
                else
                {
                    enemiesType2[i].Update(gameTime);
                }
            }

            for (int i = 0; i < enemiesType3.Count; i++)
            {
                if (enemiesType3[i].Active == false)
                {
                    specialEffects.playZombieDeath(0.9f);
                    enemiesType3.Remove(enemiesType3[i]);

                }
                else
                {
                    enemiesType3[i].Update(gameTime);
                }
            }
        }

        //  public void giveShurikenBoss(bossOne sultanasuke)
        //  {
        //     shManager.getBoss(sultanasuke);
        // }


        public void AddHorde()
        {
            

            if (waveManager.waveHordCounter < 4)
            {
               for (int b = 0; b < 8; b++)
                {
                    Enemy enemy = new Enemy(hordePositions[b]);
                    enemy.initialize(player);
                    enemy.LoadContent(content);
                    enemiesType1.Add(enemy);
                    
                }
                 waveManager.waveHordCounter++;

            }

           else if (waveManager.waveHordCounter < 8 && waveManager.waveHordCounter >=4)
            {
                for (int b = 0; b < 8; b++)
               {
                    enemyTwo enemy = new enemyTwo(hordePositions[b]);
                    enemy.initialize(player);
                    enemy.LoadContent(content);
                    enemiesType2.Add(enemy);    
                }
                 waveManager.waveHordCounter++;
            } 
               
          else if (waveManager.waveHordCounter < 10 && waveManager.waveHordCounter >= 8)
            {
                for (int b = 0; b < 8; b++)
                {
                    enemyThree enemy = new enemyThree(hordePositions[b]);
                    enemy.initialize(player);
                    enemy.LoadContent(content);
                    enemiesType3.Add(enemy); 
                }
                   waveManager.waveHordCounter++;
            }

            if (waveManager.waveHordCounter >= 10)
            {
                if(enemiesType1.Count <=0 && enemiesType2.Count <=0 && enemiesType3.Count <= 0)
                {
                    noMoreHordes = true;
                }
            }
        }



        public void getSound(SFX specialEffects)
        {
            this.specialEffects = specialEffects;

        }
       

    }
    public static class waveManager
    {
        public static bool waveOne = true;
        public static bool waveTwo = false;
        public static bool waveThree = false;
        public static bool bossBattle = false;

        public static int waveOneCounter = 100;
        public static int waveOneEnemyOne = 100;
        public static int waveOneEnemyTwo = 0;
        public static int waveOneEnemyThree = 0;

        public static int waveTwoCounter = 0;
        public static int waveTwoEnemyOne = 0;
        public static int waveTwoEnemyTwo = 0;
        public static int waveTwoEnemyThree = 0;

        public static int waveThreeCounter = 0;
        public static int waveThreeEnemyOne = 0;
        public static int waveThreeEnemyTwo = 0;
        public static int waveThreeEnemyThree = 0;

        public static int waveBossMax = 30;
        public static int waveBossCount = 0;

        public static int waveHordCounter = 0;

        public static void checkLevel()
        {
            switch (levelManager.levelIndicator)
            {
                case levelManager.levels.trainLevel:
                    {
                        waveOneCounter = 50;
                        waveOneEnemyOne = 0;
                        waveTwoCounter = 0;
                        waveTwoEnemyOne = 0;
                        waveTwoEnemyTwo = 0;
                        waveThreeCounter = 0;
                        waveThreeEnemyOne = 0;
                        waveThreeEnemyTwo = 0;

                        waveOne = true;
                        waveTwo = false;
                        waveThree = false;
                       bossBattle = false;


                        break;
                    }
                case levelManager.levels.levelOne:
                    {
                        waveOneCounter = 10;
                        waveOneEnemyOne = 10;
                        waveTwoCounter = 20;
                        waveTwoEnemyOne = 10;
                        waveTwoEnemyTwo = 10;
                        waveThreeCounter = 25;
                        waveThreeEnemyOne = 10;
                        waveThreeEnemyTwo = 15;
                        waveBossMax = 25;
                        waveBossCount = 0;

                        waveOne = true;
                        waveTwo = false;
                        waveThree = false;
                        bossBattle = false;

                        break;
                    }
                case levelManager.levels.levelTwo:
                    {

                        waveOneCounter = 15;
                        waveOneEnemyOne = 10;
                        waveOneEnemyTwo = 5;

                        waveTwoCounter = 20;
                        waveTwoEnemyOne = 5;
                        waveTwoEnemyTwo = 10;
                        waveTwoEnemyThree = 5;

                        waveThreeCounter = 30;
                        waveThreeEnemyOne = 5;
                        waveThreeEnemyTwo = 15;
                        waveThreeEnemyThree =10;


                        waveBossMax = 25;
                        waveBossCount = 0;


                        waveOne = true;
                        waveTwo = false;
                        waveThree = false;
                        bossBattle = false;
                        
                        break;
                    }
                case levelManager.levels.levelThree:
                    {

                        waveOne = false;
                        waveTwo = false;
                        waveThree = false;
                        bossBattle = false;
                        waveHordCounter = 0;

                        break;
                    }
            }
        }
    }
}


