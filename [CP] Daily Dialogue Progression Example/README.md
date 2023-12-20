# Daily Dialogue Progression Example

## What's this?
A small content pack that ensures all dialogues are seen at least once from a pre-made pool of dialogues, so instead of lost to the Void when the NPC got befriended too fast, low-heart dialogues can still be seen.

## How does it work?
- Uses a flag to track daily NPC conversations.
- Rotates through a pool of dialogues in order.
- After all dialogues are seen at least once, randomizes a dialogue from the pool.

## More detailed explaination?
- I used a vanilla dialogue command `}` to set mail flag `TalkedToday` as seen when my NPC Winnie is being talked to (it just like $1 but better).
- After a new day start, the game will check if that mail flag exists. If it does, it will switches to the next available dialogue in the pool by add a numbered flag called `WinnieNumber` and resets `TalkedToday` to false.
- Inside DynamicTokens, it will check the current dialogue number with "When" conditions, and return the number value as token `TalkNumber`.
- The next time player talk to Winnie, she'll say the next line of dialogue, and it should be different from all previous day's dialogue.
- Repeat until all dialogues are seen at least once.
- After reaching the max number, she'll randomly pick one dialogue in the pool to display.

## How can I test it?
I made a NPC with 5 different dialogues as example. Step outside of the farm house and you'll see my NPC "Winnie". You can talk to her to see how this work. She'll only switch to the next dialogue in the pool if you talk to her, so even if you sleep through days, she won't change to next dialogue if you didn't talk to her. After saying all 5 dialogues, the next time you talk to her she will randomly pick one out of the 5 dialogues that available. 


This kind of implement is expandable, if you add more dialogues later as an update for your mod, the NPC will stop randomly picking - it will start again but at the 6th dialogue and so on.

## How can I expand this?

- Let's say you want to make a pool of 20 dialogues instead.
- Write all the dialogue in i18n first.
- Inside of DynamicTokens, copy, paste and edit the "TalkNumber" token to reach 20. The last token should be more than 20.

```json
{
   "Name": "TalkNumber",
   "Value": "21",
   "When": {
         "HasFlag: currentPlayer": "WinnieNumber20"
   }
},
```
- Change the max number for randomize to 20. See example below.

```json
{
   "Name": "WnS.Winnie.Dialogue.Friendly",
   "Value": "{{i18n:WnS.Winnie.Friendly.{{Random: {{Range: 1, 20}}}}}}", // I changed 5 to 20 here
   "When": {
         "Query: {{TalkNumber}} > 20": true // I changed 5 to 20 here
   }
},
```

## More way to expand this?
- You can also do this with different heart levels/relationship. Copy paste and change the "Friendly" part to heart level or relationship (like Dating/Married) if you want, and change the mail flags so it count different between each heart level/each relationship.

   - Example: I want to make two different dialogue pool, one for Friendly and one for Dating. For Friendly dialogues I'll replace `TalkNumber` with `TalkNumberFriendly`, and replace flag `TalkedToday` to `TalkedTodayFriendly`, as well as `WinnieNumber` to `WinnieNumberFriendly`. Then I can now add `TalkNumberDating`, `TalkedTodayDating` and `WinnieNumberDating` by copy paste. The structure is the same, but now it will count differently between two pool of dialogues. Just remember to change it in all the files.

## Credits?
Feel free to copy, edit and experiment on my files! However, Winnie's sprite and portrait are mine, so don't claim it as your own!