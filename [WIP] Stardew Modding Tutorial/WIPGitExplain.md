## What does Git do?
Imagine you're playing a RPG (casually). Every once in a while, you'll press "Save" to save your current progress. And later on, if you make a mistake, you can always go back to the previous save file and try again.

Git help us with that. It creates a "save point" for your project. The term for save point is **commit**.

- Example: I'm working on my NPC Winnie project. After I'm done with creating her first event, I'll make a commit to "save" my current progress. So if I make a mistake later (like... accidentally permanently delete my Event.json?), I can just use Git to go back time where the first event is created.

## How is Git better than manually back up?
1. Git will *display every differences* between versions - which manually back ups probably can't do. It logs every changes you did compare to the previous version.

    - Example: See this image *show viewing a commit*

2. You can *comment* on every commit. You can see it as "naming your save file" for easier navigation.

    - Example: When I finished my first event, I'll "comment" on that commit something like "add Winnie's 0 heart" event. *show a list of commits* With this, I can easily see what's the main changes for each commit.
    - You can comment anything you want.

3. You can *work on different versions* (SDV 1.5.6 only, or SDV 1.6++) of the same project.
    - Example: See current Stardew Valley. CA have the "main" branch version (1.5.6) that most player use to play his game, and an "alpha" branch version (1.6-alpha) that us modders use to migrate and test our mods.
    - On big SDV framework Git repository (like Content Patcher), they usually have a "main" branch (which is the stable version for 1.5.6), and an "alpha" branch for developing their framework for 1.6. 

## What's GitHub?
Imagine something like cloud storage for Git. When you upload your changes to GitHub, it'll stores all your changes on its web server. GitHub also have its own features (issues, milestones, version releases,...).

## Cool, how do I start?
1. Install Git: https://git-scm.com/
2. Register an account on GitHub: https://github.com/

To start, you can use console commands, using VSC's source control function,... but I personally use TortoiseGit (https://tortoisegit.org/), since it provides an UI to interact with everything.

## Create a repository
1. Create a new folder inside of your Mods folder.
2. Use TortoiseGit to create new repo.
3. Copy your current files to your newly made folder.
4. Commit first commit.

