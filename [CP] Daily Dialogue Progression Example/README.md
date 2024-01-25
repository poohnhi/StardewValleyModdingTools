# Daily Dialogue Progression Example

## What's this?
A small content pack that ensures all dialogues are seen at least once from a pre-made pool of dialogues, so instead of lost to the Void when the NPC got befriended too fast, low-heart dialogues can still be seen.

## How does it work?
- Uses a flag to track daily NPC conversations.
- Rotates through a pool of dialogues in order.
- After all dialogues are seen at least once, randomizes a dialogue from the pool.

## More detailed explaination?
- I used a vanilla dialogue command `}` to set mail flag `WinnieDialogueProgression` as seen when my NPC Winnie is being talked to (it just like $1 but better).
- After a new day end, the game will check if that mail flag exists. If it does, it will switches to the next available dialogue in the pool by add a numbered flag called `WinnieDialogueProgression1` and resets `WinnieDialogueProgression` to not received.
- Inside DynamicTokens, it will check the current dialogue number already exists, and return the next number value as a CP token `poohnhi.PoohCore/GetMailFlagProgressNumber:WinnieDialogueProgression` to display (as i18n).
- The next time player talk to Winnie, she'll say the next line of dialogue, and it should be different from all previous day's dialogue.
- Repeat until all dialogues are seen at least once.
- After reaching the max number, she'll randomly pick one dialogue in the pool to display.

## How can I test it?
I made a NPC with 5 different dialogues as example. Step outside of the farm house (with the default farm) and you'll see my NPC "Winnie". You can talk to her to see how this work. She'll only switch to the next dialogue in the i18n dialogue pool if you talk to her, so even if you sleep through several days, she won't change to next dialogue if you didn't talk to her. After saying all 5 dialogues, the next time you talk to her she will randomly pick one out of the 5 dialogues that available. 

This kind of implement is expandable, if you add more dialogues later as an update for your mod, the NPC will stop randomly picking - it will start again but at the 6th dialogue and so on.

## How can I expand this?

- Let's say you want to make a pool of 20 dialogues instead.
- Write all the dialogue in i18n first.
- Inside of DynamicTokens, you only need to change "5" (the current maximum number of dialogue) to "20.
```json
   {
      "Name": "WnSWinnie.DailyDialogue",
      "Value": "{{i18n:WnSWinnie.DailyDialogue.{{Random: {{Range: 1, 20}}}}}}"
   },
   {
      "Name": "WnSWinnie.DailyDialogue",
      "Value": "WinnieDialogueProgression}{{i18n:WnSWinnie.DailyDialogue.{{poohnhi.PoohCore/GetMailFlagProgressNumber:WinnieDialogueProgression}}}}",
      "When": {
            "HasMod": "poohnhi.PoohCore",
            "Query: {{poohnhi.PoohCore/GetMailFlagProgressNumber:WinnieDialogueProgression}} <= 20": true
      }
   },
```

## More way to expand this?
- You can also do this with different heart levels/relationship, by replacing "WinnieDialogueProgression" to something like "WinnieDialogueProgression_Friendly" and "WinnieDialogueProgression_Dating" by setting new "When" condition. The game will counts differently between each mail flag for these heart levels/relationship.

## Credits?
Feel free to copy, edit and experiment on my files! However, Winnie's sprite and portrait are mine, so don't claim it as your own!