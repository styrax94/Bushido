using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Bushido
{

    public class levelOne
    {

        public bool isGameOver;
        public bool levelHasFinished;
        Camera camera;
        GraphicsDeviceManager graphics;
        abilityManager abilitiesManager;
        Hero styraxTheHero;
        HealthBar healthbar;
        Texture2D shuriTexture;
        Texture2D megaTexture;
        shurikenManager shur = new shurikenManager();
        bool startCutscene;
        EnemyManager zombies = new EnemyManager();
        EnemyDeathManager zombiesDeath = new EnemyDeathManager();
        GraphicsDevice details;
        GUI gui;
        //sound
        SFX specialEffects = new SFX();
        Timer timer = new Timer();
        private SoundEffect shuriken;
        private SoundEffect walking;
        private SoundEffect zombieDeath;
        private SoundEffect zombieDeath2;
        private SoundEffect sultanaScream;
        

        #region map

        Fog bgLayer1;
        Map map;
        mapTile maptile;
        mapWall mapwall;

        #endregion

        SpriteFont font1;
        Vector2 fontPos;
        Vector2 endGamePos;
        public void Initialize(GraphicsDeviceManager graphics, GraphicsDevice details)
        {

            this.graphics = graphics;
            this.details = details;
           
            map = new Map();
            maptile = new mapTile();
            mapwall = new mapWall();
            bgLayer1 = new Fog();
            styraxTheHero = new Hero(new Vector2(2000, 250));
           
            abilitiesManager = new abilityManager();
            healthbar = new HealthBar();
        isGameOver = false;
        levelHasFinished = false;
            startCutscene = false;
            endGamePos = new Vector2(1183, 51);
    }

        public void LoadContent(ContentManager Content)
        {
           
            styraxTheHero.LoadContent(Content);
            gui = new GUI(Content, styraxTheHero);
            
          zombiesDeath.initialize(Content);
            abilitiesManager.Initialize(Content,styraxTheHero);
            font1 = Content.Load<SpriteFont>("Font/borrowedFont");
            
            shuriTexture = Content.Load<Texture2D>("shuriken_Final");
            megaTexture = Content.Load<Texture2D>("megaShuriken");
           
            zombies.Initialize(details, styraxTheHero, Content,zombiesDeath);
            healthbar.LoadContent(Content, zombies);
          
            #region mapContent

            bgLayer1.initialize(Content, "mapOne/Fog", details.Viewport.Width, details.Viewport.Height, -1);
            TileOfTrees.Content = Content;
            Tile.Content = Content;
            wallTile.Content = Content;
            maptile.Intialize();
            mapwall.Initilize();
            map.Initialize(styraxTheHero,zombies);
            maptile.getManagerAndStyrax(styraxTheHero, zombies);
            #endregion
            styraxTheHero.getMap(map,maptile);
            
            zombies.getMap(map);
            zombies.getMap4(maptile);
            gui = new GUI(Content, styraxTheHero);
           
            
            camera = new Camera(details.Viewport, gui, healthbar);
           


           
            
            specialEffects.Initialize(Content);
            zombies.getSound(specialEffects);
           
          shur.Initialize(shuriTexture,megaTexture, details, Content,abilitiesManager, zombiesDeath,specialEffects);
            zombies.getSManager(shur,healthbar);
            fontPos = styraxTheHero.position;
            fontPos.Y += 50 ;

            styraxTheHero.getManagers(zombies, shur);
            
        }


        public void Update(GameTime gameTime)
        {
           if (zombies.noMoreOne)
            {
               // levelHasFinished = true;
               startCutscene = true;
           }

          if (startCutscene)
           {
                
                styraxTheHero.iAmInACutscene = true;
                styraxTheHero.endPosition = endGamePos;

                 if (Vector2.Distance(styraxTheHero.position, endGamePos) < 10)
                {
                    styraxTheHero.reachedEndPoint = true;
                    timer.startTimer(13);
                    timer.update(gameTime);
                    if(timer.checkTimer)
                    levelHasFinished = true;
                } 



           }
            


            zombiesDeath.updateExplosions(gameTime);
            styraxTheHero.Update(gameTime);
            if (styraxTheHero.hasFallen)
            {
                if (styraxTheHero.gameIsOver)
                {
                    isGameOver = true;
                }

            }
            camera.Update(gameTime, styraxTheHero);

            shur.Update(gameTime, styraxTheHero, camera);
            zombies.UpdateEnemies(gameTime);

            //  map.Update(gameTime, zombies, styraxTheHero, shur);


            abilitiesManager.Update(gameTime);
            shur.getEnManager(zombies);
            shur.giveManager();
            bgLayer1.Update();
            if (waveManager.bossBattle)
                healthbar.Update(gameTime);

        }


        public void Draw(SpriteBatch spriteBatch)
        {

            maptile.Draw(spriteBatch);
            mapwall.Draw(spriteBatch);
            abilitiesManager.Draw(spriteBatch);
          
               
                map.Draw(spriteBatch);
            zombiesDeath.DrawExplosions(spriteBatch);
             
                    styraxTheHero.Draw(spriteBatch);
                    zombies.DrawEnemies(spriteBatch);    
           

              
             
               
            
           
            shur.Draw(spriteBatch);
            
           
          
           
            bgLayer1.Draw(spriteBatch);
            gui.Draw(spriteBatch);
            if (waveManager.bossBattle)
            {
                healthbar.Draw(spriteBatch);
            }
            else { };

        }


        public Matrix transCamera
        {
            get { return camera.Transform; }
        }
    }

   
}
