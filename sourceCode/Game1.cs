﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//Susing Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework.Storage;
using Bushido;

namespace bushidoMenu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice details;
        GamePadState gamePad;
        VideoPlayer video;
        Timer videoTimer;

        bool waveComplete = false;
        int b = 0;
        int checknumb = 0;

        bool songStart = false;
        Song song1;
        Song song2;
        Song song3;
        Song song4;
        Song song5;
        Song song6;
        Song song7;
        Song song8;

        private enum Screen
        {
            Presents,
            Title,
            Main,
            levelSelect,
            levelOne,
            levelTwo,
            levelThree,
            pauseMenu,
            GameOver,
            trainingLevel,
            videoPlaying,
            credits
        }
        Screen mCurrentScreen = Screen.Presents;
        private enum menuSelection
        {
            NewGame,
            LevelSelect,
            Credits,
            Exit
        }
        menuSelection optionsForMenu = menuSelection.NewGame;
        private enum pauseMenuOptions
        {
            Resume,
            ExitGameToMain
        }
        pauseMenuOptions pauseOptions = pauseMenuOptions.Resume;
       
        private enum levelSelectOptions
        {
            levelOne,
            levelTwo,
            levelThree,
            TrainingLevel
        }
        levelSelectOptions currentLevelSelected = levelSelectOptions.levelOne;
       
        private enum gameOverOptions
        {
            Retry,
            ExitToMain
        }

        gameOverOptions gameOverSelection = gameOverOptions.Retry;

        Texture2D mTitleScreen;
        Texture2D mMainScreen;
        Texture2D mPause;
        Texture2D mMenuOptions;
        Texture2D mLevelSelect;
        Texture2D mOptionsForMenu;
        Texture2D mlevelOptions;
        Texture2D pauseWords;
        Texture2D gameOver;
        Texture2D itemOptions;
        Texture2D instruction;
        Texture2D pressSpace;
        Texture2D BeCareful;
        Texture2D myGamePad;
        Texture2D retry;
        bool xboxControllers;

        Video presentationVideo;
        Video firstCutscene;
        Video credits;

        KeyboardState mPreviousKeyboardState;
        levelOne one = new levelOne();
        levelTwo two = new levelTwo();
        levelThree three = new levelThree();
        trainingLevel training = new trainingLevel();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferMultiSampling = false;

            // graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

            

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            video = new VideoPlayer();
            videoTimer = new Timer();
            xboxControllers = false;
            gamePad = GamePad.GetState(PlayerIndex.One);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            details = GraphicsDevice;
          
            mTitleScreen = Content.Load<Texture2D>("titleScreen");
            mMainScreen = Content.Load<Texture2D>("mainMenu");
            mLevelSelect = Content.Load<Texture2D>("levelSelection");
            mPause = Content.Load<Texture2D>("pauseMenu");
            mMenuOptions = Content.Load<Texture2D>("MenuOptions");
            mOptionsForMenu = Content.Load<Texture2D>("MainOptions");
            mlevelOptions = Content.Load<Texture2D>("levelSelectOptions");
            pauseWords = Content.Load<Texture2D>("pauseWords");
            presentationVideo = Content.Load<Video>("tsunamiPresents");
            firstCutscene = Content.Load<Video>("firstCutscene");
            credits = Content.Load<Video>("credit");
            gameOver = Content.Load<Texture2D>("GameOver");
            itemOptions = Content.Load<Texture2D>("abilities/itemSelection");
            instruction = Content.Load<Texture2D>("abilities/keys");
            pressSpace = Content.Load<Texture2D>("abilities/space");
            BeCareful = Content.Load<Texture2D>("abilities/Becareful");
            myGamePad = Content.Load<Texture2D>("abilities/thumbstick");
            retry = Content.Load<Texture2D>("retryWords");
            //Gamepad

            //Songs
            song1 = Content.Load<Song>("Drums");
            song2 = Content.Load<Song>("mission");
            song3 = Content.Load<Song>("Nien");
            song4 = Content.Load<Song>("Winning");
            song5 = Content.Load<Song>("Music/Overworld");
            song6 = Content.Load<Song>("Music/Killers");
            song7 = Content.Load<Song>("Music/ayoubScene");
            song8 = Content.Load<Song>("Music/Curse of the Scarab");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (gamePad.IsConnected)
            {
                xboxControllers = true;
            }
            else
            {
                xboxControllers = false;
            }
           
                KeyboardState aKeyboardState = Keyboard.GetState();

            //If user hits the Escape key exit the game
            if (aKeyboardState.IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }


            checkMusic();

            //TimerforVideos
            

            switch (mCurrentScreen)
            {
                case Screen.Presents:
                    {
                        if (video.State == MediaState.Stopped)
                        {
                            video.IsLooped = false;
                            video.Play(presentationVideo);
                            videoTimer.startTimer(10);
                        }
                        videoTimer.update(gameTime);

                        if (videoTimer.checkTimer)
                        {
                            video.Stop();
                        }

                        if (video.State == MediaState.Stopped && videoTimer.checkTimer)
                        {
                            mCurrentScreen = Screen.Title;

                           
                        }


                        break;
                    }


                case Screen.Title:
                    {
                        //If the user presses the "X" key while on the Title screen, start the game
                        //by switching the current state to the Main Screen
                        checknumb = 1;
                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true)
                        {
                            mCurrentScreen = Screen.Main;
                        }
                        break;
                    }
                case Screen.Main:
                    {
                        checknumb = 2;
                        if (aKeyboardState.IsKeyDown(Keys.O) == true && mPreviousKeyboardState.IsKeyDown(Keys.O) == false)
                        {
                            graphics.IsFullScreen = true;
                            this.graphics.ApplyChanges();
                        }
                        if (aKeyboardState.IsKeyDown(Keys.I) == true && mPreviousKeyboardState.IsKeyDown(Keys.I) == false)
                        {
                            graphics.IsFullScreen = false;
                            this.graphics.ApplyChanges();
                        }

                        if (aKeyboardState.IsKeyDown(Keys.Back) == true && mPreviousKeyboardState.IsKeyDown(Keys.Back) == false)
                        {
                            mCurrentScreen = Screen.Title;
                        }

                        if (aKeyboardState.IsKeyDown(Keys.S) == true && mPreviousKeyboardState.IsKeyDown(Keys.S) == false)
                        {
                            switch (optionsForMenu)
                            {
                                case menuSelection.NewGame:
                                    {
                                        
                                        optionsForMenu = menuSelection.LevelSelect;

                                        break;
                                    }

                                case menuSelection.LevelSelect:
                                    {
                                        optionsForMenu = menuSelection.Credits;
                                        break;
                                    }
                                case menuSelection.Credits:
                                    {
                                        optionsForMenu= menuSelection.Exit;
                                        break;
                                    }
                             
                            }
                        }

                        if (aKeyboardState.IsKeyDown(Keys.W) == true && mPreviousKeyboardState.IsKeyDown(Keys.W) == false)
                        {
                            switch (optionsForMenu)
                            {
                                
                                case menuSelection.LevelSelect:
                                    {
                                        optionsForMenu = menuSelection.NewGame;
                                        break;
                                    }
                                case menuSelection.Credits:
                                    {
                                        optionsForMenu = menuSelection.LevelSelect;
                                        break;
                                    }
                                case menuSelection.Exit:
                                    {
                                        optionsForMenu = menuSelection.Credits;
                                        break;
                                    }
                            }
                        }



                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true && mPreviousKeyboardState.IsKeyDown(Keys.Enter) == false)
                        {

                            switch (optionsForMenu)
                            {

                                case menuSelection.NewGame:
                                    {

                                      checknumb = 3;
                                        mCurrentScreen = Screen.videoPlaying;
     
                                        break;
                                    }

                                case menuSelection.LevelSelect:
                                    {
                                        mCurrentScreen = Screen.levelSelect;
                                        break;
                                    }
                                case menuSelection.Credits:
                                    {
                                        mCurrentScreen = Screen.credits;
                                        break;
                                    }
                                case menuSelection.Exit:
                                    {
                                        this.Exit();
                                        break;
                                    }
                            }

                        }


                     
                        break;
                    }
                case Screen.levelSelect:
                    {


                        if (aKeyboardState.IsKeyDown(Keys.Back) == true && mPreviousKeyboardState.IsKeyDown(Keys.Back) == false)
                        {
                            mCurrentScreen = Screen.Main;
                        }


                        if (aKeyboardState.IsKeyDown(Keys.S)==true && mPreviousKeyboardState.IsKeyDown(Keys.S) == false)
                        {
                            switch (currentLevelSelected)
                            {
                                case levelSelectOptions.levelOne:

                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.levelTwo;
                                       
                                        break;
                                    }

                                case levelSelectOptions.levelTwo:
                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.levelThree;
                                        break;
                                    }

                                case levelSelectOptions.levelThree:
                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.TrainingLevel;
                                        break;
                                    }

                             }
                        }

                        if (aKeyboardState.IsKeyDown(Keys.W) == true && mPreviousKeyboardState.IsKeyDown(Keys.W) == false)
                        {
                            switch (currentLevelSelected)
                            {
                                case levelSelectOptions.levelTwo:
                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.levelOne;
                                        break;
                                    }

                                case levelSelectOptions.levelThree:
                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.levelTwo;
                                        break;
                                    }
                                case levelSelectOptions.TrainingLevel:
                                    {
                                        
                                        currentLevelSelected = levelSelectOptions.levelThree;
                                        break;
                                    }
                            }
                        }

                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true && mPreviousKeyboardState.IsKeyDown(Keys.Enter) == false)
                        {
                            switch (currentLevelSelected)
                            {
                                case levelSelectOptions.levelOne:
                                    {
                                        checknumb = 3;
                                        mCurrentScreen = Screen.levelOne;
                                        levelManager.levelIndicator = levelManager.levels.levelOne;
                                        waveComplete = false;
                                        one.Initialize(graphics, details);
                                        one.LoadContent(Content);
                                        
                                        break;
                                    }

                                case levelSelectOptions.levelTwo:
                                    {
                                        checknumb = 3;
                                        mCurrentScreen = Screen.levelTwo;
                                        levelManager.levelIndicator = levelManager.levels.levelTwo;
                                        waveComplete = false;
                                        two.Initialize(graphics, details);
                                        two.LoadContent(Content);
                                       
                                        break;
                                    }

                                case levelSelectOptions.levelThree:
                                    {
                                        checknumb = 3;
                                        mCurrentScreen = Screen.levelThree;
                                        levelManager.levelIndicator = levelManager.levels.levelThree;
                                        waveComplete = false;
                                        three.Initialize(graphics, details);
                                        three.LoadContent(Content);
                                        
                                        break;
                                    }
                                case levelSelectOptions.TrainingLevel:
                                    {
                                        checknumb = 3;
                                        mCurrentScreen = Screen.trainingLevel;
                                        levelManager.levelIndicator = levelManager.levels.trainLevel;
                                        waveComplete = false;
                                        training.Initialize(graphics, details);
                                        training.LoadContent(Content);
                                        break;
                                    }

                            }
                        }


                        break;
                    }
               
                case Screen.pauseMenu:
                    {
                        checknumb = 3;
                        //Move the currently highlighted menu option 
                        //up and down depending on what key the user has pressed

                        if (aKeyboardState.IsKeyDown(Keys.O) == true && mPreviousKeyboardState.IsKeyDown(Keys.O) == false)
                        {
                            graphics.IsFullScreen = true;
                            this.graphics.ApplyChanges();
                        }
                        if (aKeyboardState.IsKeyDown(Keys.I) == true && mPreviousKeyboardState.IsKeyDown(Keys.I) == false)
                        {
                            graphics.IsFullScreen = false;
                            this.graphics.ApplyChanges();
                        }




                        if (aKeyboardState.IsKeyDown(Keys.S) == true && mPreviousKeyboardState.IsKeyDown(Keys.S) == false)
                        {
                            //Move selection down
                            switch (pauseOptions)
                            {
                                case pauseMenuOptions.Resume:
                                    {
                                        pauseOptions = pauseMenuOptions.ExitGameToMain;
                                        break;
                                    }

                            }

                        }

                        if (aKeyboardState.IsKeyDown(Keys.W) == true && mPreviousKeyboardState.IsKeyDown(Keys.W) == false)
                        {
                            //Move selection up
                            switch (pauseOptions)
                            {
                                case pauseMenuOptions.ExitGameToMain:
                                    {
                                        pauseOptions = pauseMenuOptions.Resume;
                                        break;
                                    }

                            }

                        }

                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true && mPreviousKeyboardState.IsKeyDown(Keys.Enter) == false)
                        {
                            switch (pauseOptions)
                            {
                                
                                case pauseMenuOptions.Resume:
                                    {
                                        switch (levelManager.levelIndicator)
                                        {
                                            case levelManager.levels.levelOne:
                                                {
                                                    mCurrentScreen = Screen.levelOne;
                                                    break;
                                                }
                                            case levelManager.levels.levelTwo:
                                                {
                                                    mCurrentScreen = Screen.levelTwo;
                                                    break;
                                                }
                                            case levelManager.levels.levelThree:
                                                {
                                                    mCurrentScreen = Screen.levelThree;
                                                    break;
                                                }
                                            case levelManager.levels.trainLevel:
                                                {
                                                    mCurrentScreen = Screen.trainingLevel;
                                                    break;
                                                }

                                        }
                                    }break;

                                case pauseMenuOptions.ExitGameToMain:
                                    {
                                        mCurrentScreen = Screen.Main;
                                        break;
                                    }
                            }
                        }
                    }
                    {
                        //Move the currently highlighted menu option 
                        //up and down depending on what key the user has pressed
                        if (aKeyboardState.IsKeyDown(Keys.S) == true && mPreviousKeyboardState.IsKeyDown(Keys.S) == false)
                        {
                            //Move selection down
                            switch (pauseOptions)
                            {
                                case pauseMenuOptions.Resume:
                                    {
                                        pauseOptions = pauseMenuOptions.ExitGameToMain;
                                        break;
                                    }
                                
                            }

                        }

                        if (aKeyboardState.IsKeyDown(Keys.Up) == true && mPreviousKeyboardState.IsKeyDown(Keys.Up) == false)
                        {
                            //Move selection up
                            switch (pauseOptions)
                            {

                                case pauseMenuOptions.ExitGameToMain:
                                    {
                                        pauseOptions = pauseMenuOptions.Resume;
                                        break;
                                    }
                            }
                        }

                   
                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true)
                        {
                            switch (pauseOptions)
                            {
                                //Return to the Main game screen and close the menu
                                case pauseMenuOptions.Resume:
                                    {
                                       if(levelManager.levelIndicator == levelManager.levels.levelOne)
                                        {
                                            mCurrentScreen = Screen.levelOne;
                                        }
                                       else if (levelManager.levelIndicator == levelManager.levels.levelTwo)
                                        {
                                            mCurrentScreen = Screen.levelTwo;
                                        }
                                      else if (levelManager.levelIndicator == levelManager.levels.levelThree)
                                        {
                                            mCurrentScreen = Screen.levelThree;
                                        }
                                        else if (levelManager.levelIndicator == levelManager.levels.trainLevel)
                                        {
                                            mCurrentScreen = Screen.trainingLevel;
                                        }
                                        break;
                                    }
                                //Open the Inventory screen
                                case pauseMenuOptions.ExitGameToMain:
                                    {
                                        mCurrentScreen = Screen.Main;
                                        break;
                                    }  
                            }

                            
                        }
                        break;
                    }
                case Screen.levelOne:
                    {

                        if (mCurrentScreen == Screen.levelOne && !waveManager.bossBattle && !waveComplete)
                        {
                            checknumb = 4;
                        }

                        else if (waveManager.bossBattle == true && !EnemyManager.bossIsActive)
                        {
                            checknumb = 5;

                        }

                        else if (EnemyManager.bossIsActive && waveManager.bossBattle)
                        {
                            checknumb = 6;
                            waveComplete = true;
                        }

                        else if (EnemyManager.bossIsActive == false && b == 0)
                        {
                            checknumb = 7;
                            b = 1;
                            //waveComplete = true;
                        }



                        else if ((waveManager.bossBattle == false) && (EnemyManager.bossIsActive == false) && (waveComplete == true))
                        {
                            checknumb = 8;
                        }
                       

                        one.Update(gameTime);

                       if(one.isGameOver)
                        {
                            mCurrentScreen = Screen.GameOver;
                           
                        }
                        if (one.levelHasFinished)
                        {
                            checknumb = 3;
                            checkMusic();
                            waveComplete = false;
                            mCurrentScreen = Screen.levelTwo;
                            levelManager.levelIndicator = levelManager.levels.levelTwo;

                            two.Initialize(graphics, details);
                            two.LoadContent(Content);

                        }
                        if (aKeyboardState.IsKeyDown(Keys.P) == true)
                        {
                            mCurrentScreen = Screen.pauseMenu;
                        }
                        break;
                    }

                case Screen.levelTwo:
                    {
                        if (mCurrentScreen == Screen.levelTwo && !waveManager.bossBattle && !waveComplete)
                        {
                            checknumb = 4;
                        }

                        else if (waveManager.bossBattle == true && !EnemyManager.bossIsActive)
                        {
                            checknumb = 5;

                        }

                        else if (EnemyManager.bossIsActive && waveManager.bossBattle)
                        {
                            checknumb = 6;
                            waveComplete = true;
                        }

                        else if (EnemyManager.bossIsActive == false && b == 0)
                        {
                            checknumb = 7;
                            b = 1;
                            //waveComplete = true;
                        }



                        else if ((waveManager.bossBattle == false) && (EnemyManager.bossIsActive == false) && (waveComplete == true))
                        {
                            checknumb = 8;
                        }


                        two.Update(gameTime);
                        if (two.isGameOver)
                        {
                            mCurrentScreen = Screen.GameOver;
                        }
                        if (two.levelHasFinished)
                        {
                            checknumb = 3;
                            waveComplete = false;
                            checkMusic();
                            levelManager.levelIndicator = levelManager.levels.levelThree;
                            mCurrentScreen = Screen.levelThree;
                            three.Initialize(graphics, details);
                            three.LoadContent(Content);
                        }
                        if (aKeyboardState.IsKeyDown(Keys.P) == true)
                        {
                            mCurrentScreen = Screen.pauseMenu;
                        }
                        break;
                    }
                case Screen.levelThree:
                    {
                        if (mCurrentScreen == Screen.levelThree && !waveManager.bossBattle && !waveComplete)
                        {
                            checknumb = 4;
                            if (!three.firstCutscene)
                            {
                                checknumb = 3;
                                waveComplete = true;
                            }
                            
                        }

                       else if (mCurrentScreen == Screen.levelThree && !three.firstCutscene)
                       {
                            checknumb = 4;
                            if (three.finalCutscene)
                            {
                                waveComplete = false;
                            }
                        }

                      //  else if (EnemyManager.bossIsActive && waveManager.bossBattle)
                      //  {
                      //      checknumb = 6;
                      //      waveComplete = true;
                      //  }

                      //  else if (EnemyManager.bossIsActive == false && b == 0)
                      //  {
                      //      checknumb = 7;
                       //     b = 1;
                            //waveComplete = true;
                      //  }



                       // else if ((waveManager.bossBattle == false) && (EnemyManager.bossIsActive == false) && (waveComplete == true))
                      //  {
                       //     checknumb = 8;
                       // }

                        three.Update(gameTime);

                        if (three.isGameOver)
                        {
                            mCurrentScreen = Screen.GameOver;
                        }
                        if (three.levelHasFinished)
                        {
                            mCurrentScreen = Screen.credits;
                        }

                        if (aKeyboardState.IsKeyDown(Keys.P) == true)
                        {
                            mCurrentScreen = Screen.pauseMenu;
                        }
                        break;
                    }
                case Screen.trainingLevel:
                    {

                        if (training.isGameOver)
                        {
                            mCurrentScreen = Screen.GameOver;
                        }

                        training.Update(gameTime);

                        if (aKeyboardState.IsKeyDown(Keys.P) == true)
                        {
                            mCurrentScreen = Screen.pauseMenu;
                        }
                        break;
                    }
                case Screen.GameOver:
                    {
                        checknumb = 7;
                        waveComplete = false;
                        if (aKeyboardState.IsKeyDown(Keys.S) == true && mPreviousKeyboardState.IsKeyDown(Keys.S) == false)
                        {
                            //Move selection down
                            switch (gameOverSelection)
                            {
                                case gameOverOptions.Retry:
                                    {
                                        gameOverSelection = gameOverOptions.ExitToMain;
                                        break;
                                    }

                            }

                        }

                        if (aKeyboardState.IsKeyDown(Keys.W) == true && mPreviousKeyboardState.IsKeyDown(Keys.W) == false)
                        {
                            //Move selection up
                            switch (gameOverSelection)
                            {
                                case gameOverOptions.ExitToMain:
                                    {
                                        gameOverSelection = gameOverOptions.Retry;
                                        break;
                                    }

                            }


                        }

                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true && mPreviousKeyboardState.IsKeyDown(Keys.Enter) == false)
                        {
                            switch (gameOverSelection)
                            {
                                case gameOverOptions.Retry:
                                    {
                                        if (levelManager.levelIndicator == levelManager.levels.levelOne)
                                        {
                                            mCurrentScreen = Screen.levelOne;
                                            waveComplete = false;
                                            one.Initialize(graphics, details);
                                            one.LoadContent(Content);
                                        }
                                        else if (levelManager.levelIndicator == levelManager.levels.levelTwo)
                                        {
                                            mCurrentScreen = Screen.levelTwo;
                                            waveComplete = false;
                                            two.Initialize(graphics, details);
                                            two.LoadContent(Content);
                                        }
                                        else if (levelManager.levelIndicator == levelManager.levels.levelThree)
                                        {
                                            mCurrentScreen = Screen.levelThree;
                                            waveComplete = false;
                                            three.Initialize(graphics, details);
                                            three.LoadContent(Content);
                                        }
                                        else if (levelManager.levelIndicator == levelManager.levels.trainLevel)
                                        {
                                            mCurrentScreen = Screen.trainingLevel;
                                            waveComplete = false;
                                            training.Initialize(graphics, details);
                                            training.LoadContent(Content);
                                        }
                                        break;
                                    }

                            }

                            switch (gameOverSelection)
                            {
                                case gameOverOptions.ExitToMain:
                                    {
                                        mCurrentScreen = Screen.Main;
                                        break;
                                    }

                            }
                        }

                        break;
                    }

                case Screen.videoPlaying:
                    {

                        if (video.State == MediaState.Stopped)
                        {
                            video.IsLooped = false;
                            video.Play(firstCutscene);
                            videoTimer.startTimer(49);
                        }
                        videoTimer.update(gameTime);

                        if (videoTimer.checkTimer)
                        {
                            video.Stop();
                        }

                        if (video.State == MediaState.Stopped && videoTimer.checkTimer)
                        {
                            mCurrentScreen = Screen.levelOne;

                            levelManager.levelIndicator = levelManager.levels.levelOne;
                            one.Initialize(graphics, details);
                            one.LoadContent(Content);
                        }


                        break;
                    }
                case Screen.credits:
                    {
                        checknumb = 3;
                        if (video.State == MediaState.Stopped)
                        {
                            video.IsLooped = false;
                            video.Play(credits);
                            videoTimer.startTimer(90);
                        }
                        videoTimer.update(gameTime);

                        if (videoTimer.checkTimer)
                        {
                            video.Stop();
                        }
                        if (video.State == MediaState.Stopped && videoTimer.checkTimer)
                        {
                            mCurrentScreen = Screen.Title;
                        }
                            break;
                    }


            }

            //Store the Keyboard state
            mPreviousKeyboardState = aKeyboardState;





            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
          
        
            if (mCurrentScreen == Screen.levelOne)
            {
              spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, one.transCamera);
            }
           else if (mCurrentScreen == Screen.levelTwo)
            {
               spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, two.transCamera);
            }
           else if (mCurrentScreen == Screen.levelThree)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, three.transCamera);
            }
            else if(mCurrentScreen == Screen.trainingLevel)
                {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, training.transCamera);
            }
            else
            {
                spriteBatch.Begin();
                //  spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, makeFullScreen.Transform);
            }

            switch (mCurrentScreen)
            {
                


                case Screen.Title:
                    {
                        spriteBatch.Draw(mTitleScreen, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                        break;
                    }

                case Screen.Main:
                    {
                        spriteBatch.Draw(mMainScreen, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

                        switch (optionsForMenu)
                        {
                            case menuSelection.NewGame:
                                {
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth/2 -150, graphics.PreferredBackBufferHeight /2 - 180,  mOptionsForMenu.Width-100,mOptionsForMenu.Height/4), new Rectangle(0,0, 372, 162), Color.DarkRed);   //772, 374, 380 , 162
                                   spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 100, mOptionsForMenu.Width-100, mOptionsForMenu.Height / 4), new Rectangle(0, 162, 372, 162), Color.White);
                                   spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 -10, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 324, 372, 162), Color.White);
                                   spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 +45, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 486, 372, 162), Color.White);
                                    break;
                                }
                            case menuSelection.LevelSelect:
                                {
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 180, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 0, 372, 162), Color.White);   //772, 374, 380 , 162
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 100, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 162, 372, 162), Color.Red);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 10, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 324, 372, 162), Color.White);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 + 45, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 486, 372, 162), Color.White);
                                    break;
                                }
                            case menuSelection.Credits:
                                {
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 180, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 0, 372, 162), Color.White);   //772, 374, 380 , 162
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 100, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 162, 372, 162), Color.White);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 10, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 324, 372, 162), Color.Red);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 + 45, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 486, 372, 162), Color.White);
                                    break;
                                }
                            case menuSelection.Exit:
                                {
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 180, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 0, 372, 162), Color.White);   //772, 374, 380 , 162
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 100, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 162, 372, 162), Color.White);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 - 10, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 324, 372, 162), Color.White);
                                    spriteBatch.Draw(mOptionsForMenu, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 150, graphics.PreferredBackBufferHeight / 2 + 45, mOptionsForMenu.Width - 100, mOptionsForMenu.Height / 4), new Rectangle(0, 486, 372, 162), Color.Red);
                                    break;
                                }
                        }
                        break;
                    }
                case Screen.levelSelect:
                    {
                        spriteBatch.Draw(mLevelSelect, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                        switch (currentLevelSelected)
                        {
                            case levelSelectOptions.levelOne:
                                {
                                   // spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2, mOptionsForMenu.Width, mOptionsForMenu.Height), new Rectangle(0, 0, mOptionsForMenu.Width, mOptionsForMenu.Height), Color.White);

                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 120, 215, 30), new Rectangle(0, 0, 350, 54), Color.Red);  //612,586
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 60, 215,30), new Rectangle(0, 127, 350, 54), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2  , 215,45 ), new Rectangle(0, 261, 350, 85), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 + 60, 215,60), new Rectangle(0, 397, 350, 99), Color.White); 
                                    break;
                                }
                            case levelSelectOptions.levelTwo:
                                {
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 120, 215, 30), new Rectangle(0, 0, 350, 54), Color.White);  //612,586
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 60, 215, 30), new Rectangle(0, 127, 350, 54), Color.Red);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2, 215, 45), new Rectangle(0, 261, 350, 85), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 + 60, 215, 60), new Rectangle(0, 397, 350, 99), Color.White);
                                    break;
                                }
                            case levelSelectOptions.levelThree:
                                {
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 120, 215, 30), new Rectangle(0, 0, 350, 54), Color.White);  //612,586
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 60, 215, 30), new Rectangle(0, 127, 350, 54), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2, 215, 45), new Rectangle(0, 261, 350, 85), Color.Red);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 + 60, 215, 60), new Rectangle(0, 397, 350, 99), Color.White);
                                    break;
                                }
                            case levelSelectOptions.TrainingLevel:
                                {
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 120, 215, 30), new Rectangle(0, 0, 350, 54), Color.White);  //612,586
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 - 60, 215, 30), new Rectangle(0, 127, 350, 54), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2, 215, 45), new Rectangle(0, 261, 350, 85), Color.White);
                                    spriteBatch.Draw(mlevelOptions, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 110, graphics.PreferredBackBufferHeight / 2 + 60, 215, 60), new Rectangle(0, 397, 350, 99), Color.Red);
                                    break;
                                }

                        }
                        break;
                    }


                case Screen.pauseMenu:
                    {


                        spriteBatch.Draw(mPause, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

                        switch (pauseOptions)
                        {
                            case pauseMenuOptions.Resume:
                                {
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 +50, pauseWords.Width/3, pauseWords.Height / 2 - 150), new Rectangle(0, 0, pauseWords.Width, 204), Color.DarkRed);
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 + 150, pauseWords.Width / 3, pauseWords.Height / 2 - 150), new Rectangle(0, 204, pauseWords.Width, 204), Color.White);

                                    break;
                                }
                            case pauseMenuOptions.ExitGameToMain:
                                {
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 + 50, pauseWords.Width / 3, pauseWords.Height / 2 - 150), new Rectangle(0, 0, pauseWords.Width, 204), Color.White);
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 + 150, pauseWords.Width / 3, pauseWords.Height / 2 - 150), new Rectangle(0, 204, pauseWords.Width, 204), Color.DarkRed);

                                    break;
                                }
                        }
                        break;
                    }
                case Screen.levelOne:
                    {
                        
                        one.Draw(spriteBatch);
                        
                        break;
                    }
                case Screen.levelTwo:
                    {

                        two.Draw(spriteBatch);

                        break;
                    }

                case Screen.levelThree:
                    {

                       three.Draw(spriteBatch);

                        break;
                    }
                case Screen.trainingLevel:
                    {
                       

                        training.Draw(spriteBatch);
                        spriteBatch.Draw(itemOptions, new Rectangle((int)training.positionForLabel.X, (int)training.positionForLabel.Y, itemOptions.Width, itemOptions.Height), Color.White);
                        spriteBatch.Draw(instruction, new Rectangle((int)training.positionForLabel.X, (int)training.positionForLabel.Y + instruction.Height * 2, instruction.Width, instruction.Height), Color.White);
                        spriteBatch.Draw(pressSpace, new Rectangle((int)training.positionForLabel.X, (int)training.positionForLabel.Y + instruction.Height * 1, instruction.Width, instruction.Height), Color.White);
                        spriteBatch.Draw(BeCareful, new Rectangle((int)training.positionForLabel.X + BeCareful.Width * 4, (int)training.positionForLabel.Y, instruction.Width, instruction.Height), Color.White);
                        if (xboxControllers)
                        {
                            spriteBatch.Draw(myGamePad, new Rectangle((int)training.positionForLabel.X + BeCareful.Width + 630, (int)training.positionForLabel.Y + BeCareful.Height * 2, instruction.Width + 100, instruction.Height + 50), Color.White);
                        }
                        break;
                    }

                case Screen.GameOver:
                    {
                        
                        spriteBatch.Draw(gameOver, new Rectangle(0,0,graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

                        switch (gameOverSelection)
                        {
                            case gameOverOptions.Retry:
                                {
                                    spriteBatch.Draw(retry, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 2 + 65, retry.Width / 2 - 80, retry.Height / 4 + 30), Color.DarkRed);
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 + 150, pauseWords.Width / 3, pauseWords.Height / 2 - 150), new Rectangle(0, 204, pauseWords.Width, 204), Color.White);

                                }
                                break;
                            case gameOverOptions.ExitToMain:
                                {
                                    spriteBatch.Draw(retry, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 2 + 65, retry.Width / 2 - 80, retry.Height / 4 + 30), Color.White);
                                    spriteBatch.Draw(pauseWords, new Rectangle(graphics.PreferredBackBufferWidth / 2 - 230, graphics.PreferredBackBufferHeight / 2 + 150, pauseWords.Width / 3, pauseWords.Height / 2 - 150), new Rectangle(0, 204, pauseWords.Width, 204), Color.DarkRed);
                                }
                                break;

                        }


                        break;
                    }

                case Screen.videoPlaying:
                    {
                        Texture2D videoTexture = null;
                        if (video.State != MediaState.Stopped)
                        {
                            videoTexture = video.GetTexture();
                        }



                        if (videoTexture != null)
                        {
                           
                            spriteBatch.Draw(videoTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                            
                            
                        }
                        break;
                    }
                case Screen.Presents:
                    {
                        Texture2D videoTexture = null;
                        if (video.State != MediaState.Stopped)
                        {
                            videoTexture = video.GetTexture();
                        }



                        if (videoTexture != null)
                        {

                            spriteBatch.Draw(videoTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);


                        }
                        break;
                    }
                case Screen.credits:
                    {
                        Texture2D videoTexture = null;
                        if (video.State != MediaState.Stopped)
                        {
                            videoTexture = video.GetTexture();
                        }



                        if (videoTexture != null)
                        {

                            spriteBatch.Draw(videoTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);


                        }
                        break;
                    }


            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public void checkMusic()
        {
            if ((checknumb == 1) && (MediaPlayer.State == MediaState.Stopped))
            {

                MediaPlayer.Play(song1);
            }
            if ((checknumb == 2) && (MediaPlayer.State == MediaState.Stopped))
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(song2);
            }

            if (checknumb == 3)
            {
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Stop();
                }
            }

            if ((checknumb == 4) && (MediaPlayer.State == MediaState.Stopped)&& mCurrentScreen ==Screen.levelOne)
            {
                MediaPlayer.Play(song3);
            }

            if ((checknumb == 4) && (MediaPlayer.State == MediaState.Stopped)&& mCurrentScreen == Screen.levelTwo)
            {
                MediaPlayer.Play(song5);
            }
            if ((checknumb == 4) && (MediaPlayer.State == MediaState.Stopped) && mCurrentScreen == Screen.levelThree && three.firstCutscene)
            {
                   MediaPlayer.Play(song7);
              
                   
                    
               
            }
            else if ((checknumb == 4) && (MediaPlayer.State == MediaState.Stopped) && mCurrentScreen == Screen.levelThree && !three.firstCutscene)
                {
                    MediaPlayer.Play(song6);
                }
            if (checknumb == 5)
            {
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Stop();
                }
            }

            if ((checknumb == 6) && (MediaPlayer.State == MediaState.Stopped) && mCurrentScreen == Screen.levelOne)

            {
                MediaPlayer.Play(song2);
            }
            if ((checknumb == 6) && (MediaPlayer.State == MediaState.Stopped) && mCurrentScreen == Screen.levelTwo)

            {
                MediaPlayer.Play(song8);
            }
            


            if (checknumb == 7)
            {

                MediaPlayer.Stop();

            }

            if ((checknumb == 8) && (MediaPlayer.State == MediaState.Stopped))
            {
                MediaPlayer.Play(song4);
            }
        }
    }
}
