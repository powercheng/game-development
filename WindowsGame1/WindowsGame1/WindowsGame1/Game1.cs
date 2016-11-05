// author peng cheng

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        BasicEffect effect;
        public float aspectRatio;
        SpriteBatch spriteBatch;
        KeyboardState oldState;


        Character model_character;
        Camera camera;
        Terrain terrain;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

            base.Initialize();
            oldState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            device = GraphicsDevice;
            effect = new BasicEffect(this.GraphicsDevice);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
            // TODO: use this.Content to load your game content here
            camera = new Camera(this);
            model_character = new Character(camera,this);
            terrain = new Terrain(this, camera, device, effect);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            model_character.update(gameTime);
            camera.update(gameTime, model_character, this);
            processInput();
            base.Update(gameTime);
        }

       private void processInput()
        {
            KeyboardState newState = Keyboard.GetState();
            // keyboard control
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape)) this.Exit();
            if (keyboardState.IsKeyDown(Keys.A))
            {
                model_character.modelPosition.X -= 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                model_character.modelPosition.X += 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                model_character.modelPosition.Y += 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                model_character.modelPosition.Y -= 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                model_character.modelPosition.X -= 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                model_character.modelPosition.X += 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                model_character.modelPosition.Z += 0.1f;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                model_character.modelPosition.Z -= 0.1f;
            }
            /*            if (keyboardState.IsKeyDown(Keys.A))
                        {
                            model_character.modelRotation.Z += 0.05f;

                        }
                        if (keyboardState.IsKeyDown(Keys.D))
                        {
                            model_character.modelRotation.Z -= 0.05f;
                        }
                        if (keyboardState.IsKeyDown(Keys.W))
                        {
                            model_character.modelRotation.Y += 0.05f;
                        }
                        if (keyboardState.IsKeyDown(Keys.S))
                        {
                            model_character.modelRotation.Y -= 0.05f;
                        }
                        if (keyboardState.IsKeyDown(Keys.Y))
                        {
                            LoadContent();
                        }*/
            oldState = newState;

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            terrain.Draw(camera);
            model_character.Draw();
            
            base.Draw(gameTime);
        }
    }
}
