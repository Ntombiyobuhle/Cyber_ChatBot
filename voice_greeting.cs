﻿using System.IO;
using System.Media;
using System;

namespace Cyber_ChatBot
{
    public  class voice_greeting
    {
        public voice_greeting()
        {
            // get the current directory of the application
            string fill_loction = AppDomain.CurrentDomain.BaseDirectory;

            // replaace the bin\Debug\ with the name of the folder where the audio file is located
          string path = fill_loction.Replace("bin\\Debug\\", "");
            //   Console.WriteLine( path);
            // TRY AND CATCH
            try
            // play the audio file
            {
                string full_path = Path.Combine(path, "voice greeting .wav");
                // create instance of the sound player class
                using (SoundPlayer playVoice = new SoundPlayer(full_path))
                {
                    playVoice.PlaySync();

                }
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }// end of try and catch
        }
    }
}