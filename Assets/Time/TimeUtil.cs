using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Util
{
    public static class TimeUtil
    {
        public static string ToTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int miliseconds = Mathf.FloorToInt((time * 1000) % 1000);

            return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, miliseconds);
        }
    }
}
