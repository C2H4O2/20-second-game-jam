using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    public static class ButtonRandomiser
    {
        public static List<KeyCode> RandomiseKeys(List<KeyCode> keyCodes) {
            for (int i = 0; i < keyCodes.Count; i++) {
                int randomInt = Random.Range(0,keyCodes.Count);
                KeyCode key = keyCodes[i];
                keyCodes[i] = keyCodes[randomInt];
                keyCodes[randomInt] = key;
            }
            return keyCodes;
        }
    }
}

