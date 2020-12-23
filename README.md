UO Architect Client 2.6.1 (New)
Programmed & Created by Xandor
Gui & Support by Khaybel

This version of UO Architect is compatible with RunUO Servers 2.0/1.0+; When used with the "UO Architect Server 2.6 Run Script Extension".

2.6.1 Small Update: - ToolBox Release Notes
- Adds UO Architect 9th Age ToolBox ~Special Thanks to 

2.6 RECENT CLIENT CHANGES

(New) Multicache.dat Importer (big addon)

Example Multicache.dat location: C:\Program Files\Ultima Online SE\Desktop\accountname\shardname\charactername\Mul ticache.dat

The Multicache.dat stores all buildings up to 300 buildings that a players runs past in game on any player run shard or osi server. These buildings are store as multi information. UO Architect can now import this data directory into your database for editing, preview or use on personal shards etc. (this doesn't not extract statics only player build housing multis)

- New UOSE Toolbox by MiraLcz, thank you

Building Database Updated:
- New) Double Left Click Building Name, now loads preview of building. 
- Old Way) Double Left Click Building Name, would load build Dialog if connected to runuo.

Right Click Building tree Node, in Database, brings up new commands
- Build (Building Dialog) (Requires connection to RunUO through Uoar Server addon v2.5/2.6) (aka place and move buildings around on map)
- Preview (same as double click building.
- Edit (allows you to edit building design in uoar building editor)
- Delete Building, or catigory node. 
- When deleting catigory new prompt will popup asking if you are sure.
- Export - You can export single building or if in catigory node export group of buildings, decorations or items to .uoa file.

- Ultima Dll Updated to support new roof tops for UOSE.
- Other fixes and file optimations etc made.

OrBSydia Community Site Links: 
Updated to OrBSydia.com, UO Architect Official Home Page, UO Architect Official Forum, OrBSydia Building Forums.

Members are encouraged to post .uoa designs of their buildings to share with other members. 

Note: We have over 2500 buildings in database currently)

UOAR SERVER 2.6 Changes:
- Version Number Updated

Note: If you have 2.5 installed you don't need this updated, its just name change to keep it inline with the uoar 2.6 client release.

2.5 RECENT CHANGES:
- UO Architect Client File Updated to v2.5
- UO Architect Server Changed to v2.5
- Fixed major Issue with Hued Items on Buildings Fixed
- New UOSE Tool box by MiraLcz Added ~ Thank You
- Extracting Buildings on Map4.mul (Tukuno Islands) {Now Works}
- New ultima.dll created by Xandor with UO Samuria Empire Support
- Tons of Misc fixes and Updates

2.4 Client Changes:
- Import Support for World Forge .xml files
- Export to multi data .mul
- Many bug fixes

UOAR Application Features (2.6+) and down.

File ->
- Create New Building
- Choose Size

Importer
- UO Architect Design - .uoa
- Multi.txt (sphere building file)
- World Forge Items - .xml
- NEW - MultiCache.dat

Exporter
- UO Architect Design - .uoa
- Multi.txt (sphere building file)
- Mul Data (mul)

Connect ->
- Uoar Connection Wizard
- Account & Password Tabs, as well as Remember Password
- Account Database
- Add Uoar Svr Account
- Delete Uoar Svr Account
- Edit Uoar Svr Account 

Community ->
- Links to orb community
- Links to runuo 
- Links to pandora's box

Database ->
this section is where buildings are stored when you import .uoa .txt or .xml files from the orbsydia multi template wizard, uo architect client database, or world forge.

See 2.6 changes above for details.
- File Tree, Catigory & Sub Catigory Support
- Name File by Single Clicking Catigory/Sub Cat or FileName
- Abblity to Export to file Groups of Buildings,
- Abblity to Export to file Single Buildings, 

Database Actions ->
- Properties: Change every aspect of building info in the database
- Build: Brings Up Building Dialog movement and placement control in game.
- Note: Double Clicking Building In Database will bring up build dialog as well.
- Patch Multis: You can patch any building in the database to multi.mul See options for path info.
- Delete: Delete Building or Item/Decoration
- Preview: Used to see Preview of building in database, can save screenshots
of all floors, as well as level select.
- Editor: This is where you can editor your building, after you extract it. Change Walls, Decorations etc.

Move Tab ->
Please Note: Items in move tab are items that have been extract to database, and have been placed back on the map.

Select Counter & Group Movement:
- 8 Way Direction control of selected items, # can choose how far to
move items at once.
- Z Level Control Up and Down, # to choose how far to move item up an down.
- Unselect & Wipe Items Selected Group.

Select Item:
- Select Single item left click
- Select Single item right click will keep target up till you hit enter/esc
- Exclude: remove item from selected group

Select Area:
- Same as above: Only you can select a group of items, at any Z Level, this is
good if you want to grab decorations.
- Min Z to move item: Eye Dropper to Auto Get Z
- Max Z to move item: Eye Dropper to Auto Get Z
- Right Click will allow you to move buildings that are an akward shape.

Other Properties:
- Wipe Area: Clear a house or items etc
- Left Click Remove Item to remove one item
- Right Cliuck Remove to auto remove items till you hit escape 
- Teleport: Move around map faster
- Extract: This will extract any selected items in the move tab, to the database, 
this is good if you want to extract decorations from a house that was in your 
database.

Extract Tab ->
Please note you need to be connected to runuo using the UOAR Server & Client Connection Wizard on port 2594. The Extract Tab makes it possible to extract any static item in game, from groups of forest to buildings, to decorations in game. Doesn't matter what map, and we have support for Diff Extractions like Haven.

A new Feature as of UO Architect Client 2.2+ is the ability to extract Custom Houses made in game with the AOS Builder tool. Aka make a house in game decoration it in game then extract it to database and edit it in our database building editor. This is where the main power of this tool kicks in. Cause any building in game can be turned in to player housing, patch to multis etc, and used on custom maps [img]file:///D:/uoar%20backup/OrBSydia%20-%20UO%20Architect%202_4%20Release_files/wink.gif[/img]

Options ->
- On/Off Static Item Extraction
- On/Off non-Static Item Extraction
- On/Off Frozen (mul) Items Extraction
- On/Off Building Hue Extraction
- On/Off Building Has Foundation or Not

Item Z Filter ->
One of the things we ran into when we made the Template Wizard, was if you extracted a building on a mountain to database it would extraxt the building at the Z of the building. To fix this we added Item Z filter, as long as you choose the min Z of the building you want to extract, if the building is at 45 Z when you select the min Z at that level, it will put the building at 0 Z in the database, so the next time you build to map your building will be on ground level not 45 Z up 

- Min Z to Extract item: Eye Dropper to Auto Get Z
- Max Z to Extract item: Eye Dropper to Auto Get Z

Note: If you want to extract a floor in a building, but not the roof, or you want to extract a roof but not the groud levels this comes into play.

Properties ->
- Set Name of building to extract
- Set Catigory Name
- Set Sub Catitory

Set Starting Z for each level, didn't make it into 2.4, but will prob be in the professional version of this tool which xandor is working on at a laterdate.

Other Options:
- Wipe, Teleport, and Extract Building Button after all top filters choosen. 

Options Tab ->
- Set RunUO Prefix: Default [
- Set Ultima Directory: Auto Detect or Path, for custom maps installs of uo.
- Multi Patcher Target Path, if you want to patch buildings to muli.mul

About Tab: Credits etc

Other Features -> 
- In Editor Hold Left Shift Key & Left Mouse to move buildings in Editor
- Added Support to change floors in editor using Wheel Mouse or F# Keys.

Build Dialog ->
- Move Movement Control of building
- Multi Build Dialog Support: Move groups of buildings at the same time.
- Delete Building
- Build With or With Out Hue







UO Architect 9th Age - ToolBox:
This toolbox is built off the ML updated toolbox release. I simply added more to it.
It includes evil deco, 9th crystal & shadow stuff, 9th mini item addons.

Addon by Peoharen


Quote:
Location (99% accute number of items added)
Mondain's Legacy Walls>Tanglewood Walls>Thorn Walls (2)
Floors>Elven Natural Style>Thorn floor (1)
Walls
-Crystal Walls
--Large Crystal Walls (8)
--Medium Crystal Walls (4)
--Small Crystal Walls (4)
--Crystal Roofing (19)
--Crystal Foundation (4)
-Shadow Walls
--Large Shadow Walls (10)
--Medium Shadow Walls (4)
--Small Shadow Walls (4)
--Shadow Archs (4)
--Shadow Roofing (19)
--Shadow Foundation (4)
Doors
-Crystal Doors (18)
-Shadow Doors (23) //Why 23?
Floors
-Crystal Floors (12)
-Shadow Floors (9)
Stairs
-Crystal Stairs (5)
-Shadow Stairs (5)
Extras
-Evil Deco
--Seats (8)
--Paintings (20)
--Bed Of Nails (17)
--Mounted Pixies (10)
--Mirrors (4)
--Alter (5)
-Crystal Deco (32)
-Shadow Deco (26)
-Mini Items
--Mini Trees (3)
--Mini Carpets (7)
--Mini Statue (4)
--Mini Ruined Furniture (10)
--Mini Others(9)