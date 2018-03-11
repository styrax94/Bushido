using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Bushido;
namespace Bushido
{

    public class trainingLevel

    {
        public bool bossIsActive = false;
        public bool isGameOver = false;
        public bool levelHasFinished;
        SFX soundEffects;

        public static  Vector2 myPosition;

        public Vector2 positionForLabel
        {
            get { return myPosition; }
        }
        Camera camera;
        GraphicsDeviceManager graphics;
        Hero styraxTheHero;
        Texture2D shuriTexture;
        Texture2D megaTexture;
        abilityManager abilities;
        shurikenManager shur = new shurikenManager();
        GUI gui;
        HealthBar healthbar;
        EnemyManager zombies = new EnemyManager();
        GraphicsDevice details;
        lord ayoub = new lord(new Vector2(800, 50));
        EnemyDeathManager zombiesDeath = new EnemyDeathManager();

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
            soundEffects = new SFX();
        

        }

        public void LoadContent(ContentManager Content)
        {
            soundEffects.Initialize(Content);
            
            
            Castle.Content = Content;
            ayoub.LoadContent(Content);
            styraxTheHero = new Hero(new Vector2(800, 1000));
            styraxTheHero.LoadContent(Content);
            abilities.Initialize(Content, styraxTheHero);
            zombiesDeath.initialize(Content);
            megaTexture = Content.Load<Texture2D>("megaShuriken");
            shuriTexture = Content.Load<Texture2D>("shuriken_Final");
            zombiesDeath.initialize(Content);
            shur.Initialize(shuriTexture, megaTexture, details, Content, abilities, zombiesDeath,soundEffects);
            zombies.Initialize(details, styraxTheHero, Content, zombiesDeath);
            #region mapContent

            castletile.Initialize(styraxTheHero);
            gui = new GUI(Content, styraxTheHero);
            camera = new Camera(details.Viewport, gui, healthbar);

            styraxTheHero.getMap3(castletile);
            zombies.getMap3(castletile);
            #endregion



            zombies.getSound(soundEffects);
            styraxTheHero.getManagers(zombies, shur);

           
        }


        public void Update(GameTime gameTime)
        {
            myPosition = camera.centre;
            

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
            


        }


        public void Draw(SpriteBatch spriteBatch)
        {

            castletile.Draw(spriteBatch);
            abilities.Draw(spriteBatch);
            
            styraxTheHero.Draw(spriteBatch);
            abilities.Draw(spriteBatch);
            shur.Draw(spriteBatch);
            zombies.DrawEnemies(spriteBatch);
            zombiesDeath.DrawExplosions(spriteBatch);

        }

        public Matrix transCamera
        {
            get { return camera.Transform; }
        }
    }
}

