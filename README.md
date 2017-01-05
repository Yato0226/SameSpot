## RimWorld Achtung! Mod 
Command your colonists like a boss!

![alt text](https://raw.githubusercontent.com/pardeike/RimWorld-Achtung-Mod/master/About/Preview.png "Achtung! Mod")

**Achtung! Mod** enhances how you control RimWorld and reduces the number of clicks by half. And almost no dependencies in your save files (read more about this below).

These enhancements can be divided into the following areas:

---

##### Automatic drafting/undrafting of colonists

Wouldn't it be nice to not micro-manage the drafting status of your colonists? With Achtung! you can.

With Achtung! the context menu contains all possible actions regardless of the current drafting status of the selected colonist. Once you select an action **Achtung!** automatically changes the drafting status if necessary to execute the action.

---

##### Control multiple colonists at once

Save time by issuing a command with more than one colonist selected. For example: select three brawlers and right click an enemy, then choose "melee". Done.

Achtung! combines all possible actions into one MultiAction(tm) context menu and shows you how many colonists can execute a certain action by appending a multiplier at the end of the menu item.

---

##### Position your colonists like in the military

This is where the name "Achtung!" comes from. It's the german word used to get the attention of soldiers and which is usually followed by a line-up in front of the commander.

Within RimWorld in combat, you want your colonists neatly positioned along a line or equally spaced in all your door openings. This is really easy with Achtung! Select multiple colonists, and with the right mouse button, drag along a line. Achtung! will move your colonists to equally spaced positions in real time. 10 colonists into 10 doors? No problem!

---

##### Important tasks

Some tasks are too important to be interrupted. Like cleaning that hospital room so nobody gets infected. That's why Achtung! has a few extra commands that will make sure that something is really done well.
For now, this is "Clean Room", "Fight Fire", "Sow Zone/Room" and the new "Auto Combat". More are planned in the future.

When you choose "Clean Room", the colonist(s) will start cleaning the room until you stop them or the room is really clean. They will check the room while cleaning so that it doesn't matter if other colonists might introduce new filth while the cleaning is ongoing.

The command "Fight Fire" works outside the home area and is useful if you don't want to extend the home area just to get rid of a fire.

Choosing "Sow Zone/Room" will make sure that the zone selected or all growing inside a room will be sowed completely. Time consuming tasks like removing other large plants like trees or hauling away objects are not performed to avoid exhaustion.

A completely novel feature is "Auto Combat". Achtung! has its own build in artificial intelligence that controls your colonists for you. All you have to do is to order a few colonists to their targets and they will get there on their own, keep a safe distance and shoot/position themselves intelligently until the job is done. Perfect for those occasions where you are busy dealing with a bigger issue. For now, this is an experimental feature and with more than a handful colonists or opponents will probably force your computer to its knees. But used smart it will be a useful feature!

---

##### Flexibility

A few commands have different way to behave. Achtung! uses both: the ALT and the SHIFT key to modify the way it works. Hold SHIFT to move colonists relative to their current position. Hold ALT while right-clicking to draft your selected colonists before the operation and to suppress the context menu.

---

##### Known errors and bugs

Achtung! is developed with the user in mind. To stay compatible with other mods, Achtung! was developed to stay out of its way and does not overwrite any essential functions. Instead, it reuses existing functionality and probably works with 99% of other mods out of the box.

Here are the current problems and their workarounds for the current version:

- Achtung! usually does not modify save state for saved games to avoid a dependency on it. However, a side effect of the provided custom jobs is that when save the game and your colonists are actively running an Achtung job this will be saved too thus creating a dependency to Achtung. Workaround: open the saved game with Achtung, cancel all Achtung jobs and save it again. This will "clean" the save and remove the dependency.

- The jobs in Achtung have 1st priority (that's the whole point). They all force the colonist to work until done and if you don't keep an eye on them, they become unhappy or injured. Currently, there is a build-in prevention to avoid the worst but this option is not yet configurable and kicks only in as a last resort and cancels the job. But that's how we roll here at Achtung! Workaround: if you want the soft solution just schedule stuff and hope for the best ;-)

- The new "Auto Combat" system is not optimized and will eat your CPU for breakfast. It probably will do stupid things and may not work as expected if you have exotic locations or mods that change the basic combat. Workaround: use it wisely and avoid too many colonists/enemies at the same time.

---

##### Requirements

Achtung! Mod works with RimWorld Alpha 14 and 15 and will get updated tightly with new RimWorld versions. I does not depend on any other mods and is known to work in any mod order you like.

---

##### Installation

The preferred way to install Achtung! is to use Steam Workshop to subscribe to Achtung! Mod updates [here](http://steamcommunity.com/sharedfiles/filedetails/?id=730936602&searchtext=achtung). Doing so will automatically update it anytime a new version comes out.

Alternatively, download the zip file from [GitHub](https://github.com/pardeike/RimWorld-Achtung-Mod/archive/master.zip) and install it by unzipping the "RimWorld-Achtung-Mod-master" directory into the Mods folder (you can rename it but it doesn't matter).

---

##### Feedback

Without feedback, this mod would have never come so far. So please, send me feedback and rate and recommend my mod whenever possible. The three main places to do so are

- [Ludeon Forums](https://ludeon.com/forums/index.php?topic=22130.0)
- [Steam Workshop](http://steamcommunity.com/sharedfiles/filedetails/comments/730936602)
- [GitHub](https://github.com/pardeike/RimWorld-Achtung-Mod)

---

##### FAQ

###### Are there any videos showing Achtung! in action?

Yes, here's a youtube playlist: http://tinyurl.com/achtungmod

###### Does this alter my save files?

No, Achtung! changes only the interface and the user actions. Rimworld will warn you but you can simply ignore the warning. If you later decide to remove Achtung! your saved games will still work as before!

###### Is this mod compatible with other mods?

Most likely. I don't know of any mods altering the selection mechanism. The context menu is created in a general way so it will include actions from other mods without breaking.

###### Why is this called "Achtung!" ?

It's german for "Attention!" and used in the military as a command to line up soldiers.

###### Why do I need Auto Combat? Isn't this just the auto response thing already in the game?

Not at all. For example: Once you get a raid or siege you cannot auto respond to it. First, those raiders are usually out of sight and second even if you get your colonists there they are usually drafted which means that they will just stand still once they're done. All this and a super smart positioning system will beat the living hell out of the build in auto response.

###### I think this should work different/better. Are you open for changes or improvement requests?

Awesome! Please send see the Feedback section or send me email to andreas@pardeike.net

---

##### License

Free. As in free beer. Copy, learn and be respectful.

---

##### Contact

Andreas Pardeike  
Email: andreas@pardeike.net  
Steam: pardeike  
Twitter: @pardeike  
Cell: +46722120680