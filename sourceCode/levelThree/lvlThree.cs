using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Bushido;
namespace Bushido
{

    public class levelThree
    {
       
        public bool isGameOver = false;
        public bool levelHasFinished;
        Camera camera;
        EnemyDeathManager zombiesDeath;
        GraphicsDeviceManager graphics;
        Hero styraxTheHero;
        Texture2D shuriTexture;
        Texture2D megaTexture;
        abilityManager abilities;
        shurikenManager shur;
        GUI gui;
        HealthBar healthbar;
        EnemyManager zombies;
        GraphicsDevice details;
        lord ayoub;
        SFX soundEffects = new SFX();
       public bool firstCutscene;
        public bool finalCutscene;
        

        #region map

        CastleTile castletile;

        #endregion


        public void Initialize(GraphicsDeviceManager graphics, GraphicsDevice details)
        {

            this.graphics = graphics;
            this.details = details;
            //camera = new Camera(details.Viewport);
            castletile = new CastleTile();
            abilities = new abilityManager();
             isGameOver = false;
            zombiesDeath = new EnemyDeathManager();
            shur = new shurikenManager();
            zombies = new EnemyManager();
            soundEffects = new SFX();
            firstCutscene = true;
            finalCutscene = false;
            ayoub = new lord(new Vector2(800, 50));
        }

        public void LoadContent(ContentManager Content)
        {

            Castle.Content = Content;
            ayoub.LoadContent(Content);
            styraxTheHero = new Hero(new Vector2(800, 1500));
            styraxTheHero.LoadContent(Content);
            abilities.Initialize(Content, styraxTheHero);
            megaTexture = Content.Load<Texture2D>("megaShuriken");
            shuriTexture = Content.Load<Texture2D>("shuriken_Final");

            zombiesDeath.initialize(Content);
            soundEffects.Initialize(Content);
            zombies.getSound(soundEffects);
            ayoub.getSound(soundEffects);
            ayoub.getClasses(styraxTheHero,zombies);
            shur.Initialize(shuriTexture, megaTexture, details, Content, abilities, zombiesDeath, soundEffects);
            zombies.Initialize(details, styraxTheHero, Content,zombiesDeath);
            #region mapContent

            castletile.Initialize(styraxTheHero);
            gui = new GUI(Content, styraxTheHero);
            camera = new Camera(details.Viewport, gui, healthbar);

            styraxTheHero.getMap3(castletile);
            zombies.getMap3(castletile);
            #endregion

          
           

            styraxTheHero.getManagers(zombies, shur);


        }


        public void Update(GameTime gameTime)
        {

            if (firstCutscene)
            {
                styraxTheHero.bossCutscene1= true;
                zombies.dontSpawn = true;
            }
            if (ayoub.finishedSpeaking)
            {
                styraxTheHero.bossCutscene1 = false;
                zombies.dontSpawn =false;
                firstCutscene = false;
            }
            if (zombies.noMoreHordes)
            {
                finalCutscene = true;
                styraxTheHero.endGameScene = true;
                ayoub.endGameScene = true;
            }
            ayoub.Update(gameTime);

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
            abilities.Update(gameTime);
            zombiesDeath.updateExplosions(gameTime);

            if (Vector2.Distance(styraxTheHero.position, new Vector2(800, 50)) <=4)
            {
                levelHasFinished = true;
            }


        }


        public void Draw(SpriteBatch spriteBatch)
        {

            castletile.Draw(spriteBatch);
            abilities.Draw(spriteBatch);
            ayoub.Draw(spriteBatch);
            ayoub.drawSpeech(spriteBatch);
            styraxTheHero.Draw(spriteBatch);
            abilities.Draw(spriteBatch);
            shur.Draw(spriteBatch);
            zombies.DrawEnemies(spriteBatch);
            zombiesDeath.DrawExplosions(spriteBatch);
            gui.Draw(spriteBatch);
          
        }

        public Matrix transCamera
        {
            get { return camera.Transform; }
        }
    }
}

