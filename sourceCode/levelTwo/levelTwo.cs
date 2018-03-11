using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Bushido;
namespace Bushido
{

    public class levelTwo
    {
       
        public bool isGameOver;
        public bool levelHasFinished;
        Camera camera;
        GraphicsDeviceManager graphics;
        abilityManager abilitiesManager;
        Hero styraxTheHero;
        Texture2D shuriTexture;
        Texture2D megaTexture;
        shurikenManager shur;
        GUI gui;
        HealthBar healthbar;
        EnemyManager zombies;
        EnemyDeathManager zombieDeath;
        GraphicsDevice details;
        Vector2 endGamePos;
        SFX soundEffects = new SFX();
        bool startCutscene;
       
		#region map
		FogLvl2 clouds;
		FogLvl2 backClouds;
        mountainMap mountains;

        #endregion


        public void Initialize(GraphicsDeviceManager graphics, GraphicsDevice details)
        {

            this.graphics = graphics;
            this.details = details;
      
			clouds = new FogLvl2();
			backClouds = new FogLvl2();
            mountains = new mountainMap();
            healthbar = new HealthBar();
            abilitiesManager = new abilityManager();
            zombieDeath = new EnemyDeathManager();
            zombies = new EnemyManager();
            shur = new shurikenManager();
            styraxTheHero = new Hero(new Vector2(1192.148f,1409.602f));
            isGameOver = false;
        levelHasFinished = false;
            startCutscene = false;
            endGamePos = new Vector2(1190f, 88.67671f);
            

        }

        public void LoadContent(ContentManager Content)
        {
            mountain.Content = Content;
			clouds.initialize(Content, "mapTwo/sky", details.Viewport.Width, details.Viewport.Height, -2);
			backClouds.initialize(Content, "mapTwo/sky2", details.Viewport.Width, details.Viewport.Height, -1);
            soundEffects.Initialize(Content);
            styraxTheHero.LoadContent(Content);
            zombieDeath.initialize(Content);
            abilitiesManager.Initialize(Content, styraxTheHero);
            shuriTexture = Content.Load<Texture2D>("shuriken_Final");
            megaTexture = Content.Load<Texture2D>("megaShuriken");
            shur.Initialize(shuriTexture, megaTexture, details,Content,abilitiesManager,zombieDeath,soundEffects);
            zombies.Initialize(details, styraxTheHero, Content,zombieDeath);
            
            #region mapContent

            mountains.Initialize(styraxTheHero);
            gui = new GUI(Content, styraxTheHero);
            camera = new Camera(details.Viewport, gui, healthbar);
            styraxTheHero.getMap2(mountains);
            #endregion


            healthbar.LoadContent(Content, zombies);

            styraxTheHero.getManagers(zombies, shur);

            zombies.getMap2(mountains);
            zombies.getSManager(shur,healthbar);
            zombies.getSound(soundEffects);
            shur.getEnManager(zombies);
            shur.giveManager();
        }


        public void Update(GameTime gameTime)
        {
            if (zombies.noMoreTwo)
            {
                // levelHasFinished = true;
                startCutscene = true;
            }

            if (startCutscene)
            {

                styraxTheHero.iAmInACutscene = true;
                styraxTheHero.endPosition = endGamePos;

                if (Vector2.Distance(styraxTheHero.position, endGamePos) < 40)
                {
                    levelHasFinished = true;
                }



            }

            zombieDeath.updateExplosions(gameTime);
            styraxTheHero.Update(gameTime);


            if (styraxTheHero.hasFallen)
            {
                if (styraxTheHero.gameIsOver)
                {
                    isGameOver = true;
                }

            }
            shur.Update(gameTime, styraxTheHero, camera);
            zombies.UpdateEnemies(gameTime);
            camera.Update(gameTime, styraxTheHero);
          
            healthbar.Update(gameTime);
            abilitiesManager.Update(gameTime);
            clouds.Update();
			backClouds.Update();

        }


        public void Draw(SpriteBatch spriteBatch)
        {
			backClouds.Draw(spriteBatch);
			clouds.Draw(spriteBatch);
            mountains.Draw(spriteBatch);
            abilitiesManager.Draw(spriteBatch);
            if (!styraxTheHero.hasFallen)
            {
                styraxTheHero.Draw(spriteBatch);
                zombies.DrawEnemies(spriteBatch);
            }


            if (styraxTheHero.hasFallen)
            {
                zombies.DrawEnemies(spriteBatch);
                styraxTheHero.Draw(spriteBatch);
            }
            zombieDeath.DrawExplosions(spriteBatch);
            shur.Draw(spriteBatch);
            gui.Draw(spriteBatch);
            if (waveManager.bossBattle)
            {
                healthbar.Draw(spriteBatch);
            }
            

        }

        public Matrix transCamera
        {
            get { return camera.Transform; }
        }
    

   
}
}
