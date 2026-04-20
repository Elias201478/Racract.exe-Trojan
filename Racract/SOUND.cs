using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace Racract
{
    internal class SOUND
    {

        public static void play()
        {
            Func<double, double>[] formulas = new Func<double, double>[] //set the formulas here
        {
            // wow so pro code
            t => t * new[]{7,6,5,4,3,2,1,7,6,5,4,3,2,1,7,6,5,4,3,2,1,7,6,5,4,3,2,1}[(((int)t >> (11 - ((int)t >> 18))) % 23)] + 255,
            t => t * (((int)t >> (int)t) >> (int)t),
        };

            int[] drs = new int[] { 105, 30 };  //set the durations for bytebeats, 1st will play 5 seconds, 2nd will play 3...
            int[] sra = new int[] { 16000, 8000 };  //frequency (sample rate)
            for (int i = 0; i < formulas.Length + 1; i++)
            {
                var formula = formulas[i];
                int dr = drs[i];
                int sr = sra[i];
                int bs = sr * dr;

                byte[] buffer = new byte[bs];
                for (int t = 0; t < bs; t++)
                {
                    buffer[t] = (byte)((int)formula(t) & 0xFF);
                }

                using (MemoryStream ms = new MemoryStream())
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(new[] { (byte)'R', (byte)'I', (byte)'F', (byte)'F' });
                    bw.Write(36 + buffer.Length);
                    bw.Write(new[] { (byte)'W', (byte)'A', (byte)'V', (byte)'E' });
                    bw.Write(new[] { (byte)'f', (byte)'m', (byte)'t', (byte)' ' });
                    bw.Write(16);
                    bw.Write((short)1); // PCM
                    bw.Write((short)1); // mono
                    bw.Write(sr);  //sample rate
                    bw.Write(sr * 1 * 8 / 8);
                    bw.Write((short)(1 * 8 / 8));
                    bw.Write((short)8);  //bits per sample
                    bw.Write(new[] { (byte)'d', (byte)'a', (byte)'t', (byte)'a' });
                    bw.Write(buffer.Length);
                    bw.Write(buffer);

                    ms.Position = 0; //set the position in zero, important!

                    using (SoundPlayer player = new SoundPlayer(ms))
                    {
                        player.PlaySync();
                    }
                }
            }
        }
    }
}