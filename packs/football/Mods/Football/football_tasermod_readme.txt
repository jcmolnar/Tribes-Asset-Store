Starsiege: Tribes -- Football Mod Tasermod 
Downloadable from the Tribes Football files archive: http://amishrabbit.com/tribes/football
Original script by JeremyIrons
Modifications by: Spike, Greasey, aRc, LackeyNo2, Taserman
Date 8/31/03

Installation instructions for server admins:

1) back up your existing scripts.vol file from your \Dynamix\Tribes\base folder.
2) extract this zip to your \Dynamix\Tribes\base folder.
3) customize server configuration/map rotation script (optional).
4) start server.

Bug fixes and modifications by taserman -
1.Tackles after touchdowns are disabled
2.Reconnecting in an attempt to dodge a vote will result in being kicked
3.Team changing to spawn yourself back at start is disabled
4.Vote to admin through consol disabled
5.Fix for switched touchdowns at start
6.Admins able to vote
7.Half time length can be set in serverconfig
8.Player bug at mission start fixed
9.Fix for not being able to respawn
10.Silence feature added
11.Hot-Patato mode added
12.Flood crash protection added
13.Smurf detector added (credit goes to Merlin)
14.Freeze feature
15.Private Chat
16.UnAdmin for superadmins
17.Admins can veto any vote if host gives them power (variable set in serverconfig)
18.Redesigned Admin menus (Specially designed menus for admins)
19.Enable team damage lets you fumble/tackle teammates
20.Auto assign team added
21.Random assign teams after number of missions set in serverconfig
22.Admins able to chose ban time
23.Fix for clientmenuselect(*# greater than # of teams*) when in team change menu
24.shows # of players in tab menu
25.Match Mode
26.Auto ball respawn on configured maps (configured in scripts.vol not map.mis file)

The following scripts have been modified in this scripts.vol build

	admin.cs: (contains many mod game rules)

changes in this file disable the enable/disable team damage and disable voting to enter tournament mode.

	comchat.cs: (contains Football-specific administrative commands that begin with # )

enabled the msg to tell everyone when the admin deleted the football.
commands available to all players: #where 
commands available to admins only:
#revert | #kill <playername> | #setteam <playername> <team> | #deletefootball

	game.cs: (contains the bulk of the game rules and logic)

disabled the "C" that brings up the command map mode (this is called "remoteCommandMode") 
disabled the "I" inventory screen command (called "removeInventoryMode") 
disabled remoteToggleCommandMode and remoteToggleInventoryMode (completely disables the inventory area and the command area).

Added the following line after disabled options:

	ClientsendMessage(%clientId, 0, "Sorry, that item has been disabled");
