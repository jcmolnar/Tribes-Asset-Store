ANARCHY mod by DRONE1000

Drone1000@bigfoot.com
http://www.teamanarchy.com/tribes/

Documentation by ^Plasmatic^ Jan 2001
ziptiezmail@netscape.net
http://plasmatica.cjb.net/

-------------------------------------------------------------------------------
Mod changes by ^plasmatic^ include Admin, Loading game notice, removal of the 'base' in the join server screen, SAD password enabled, and Telnet port/ password added.

-------------------------------------------------------------------------------
Installation:
Unzip to your Tribes directory.
The Anarchy folder goes in your Tribes folder.
The Anarchy.cs, adminuserlist.cs, and ServerPrefs.cs go into your config folder. Edit these to your liking.

Change the $AdminPassword = "BETTERchangeMEidiot";  in the serverprefs.cs folder to something else, or anyone will be able to admin your server by typing 
sad(BETTERchangeMEidiot);

Drop the shortcut onto your servers desktop for easy starting, if your server is installed into a diffrent directory than C:\Dynamix\TRIBES, right click the icon, and edit the properties, and start in lines to suit. 

-------------------------------------------------------------------------------
I do not recommend running the server and game from the same directory at the same time. Install a fresh copy of tribes by right clicking your CDROM icon, explore to the setup icon in the root directory, and install tribes into a diffrent directory than your gaming tribes. DO NOT create a new icon on your desktop when prompted, it will overwrite your gaming shortcut. Of course if you're serious about running a server, it will be a seperate machine anyways...

-------------------------------------------------------------------------------
Besides the admin settings, telnet settings, and passwords, this is the how my server- A HOLE! is set up. 

-------------------------------------------------------------------------------
Jan 2001 written by ^Plasmatic^
ziptiezmail@netscape.net
http://plasmatica.cjb.net/

-------------------------------------------------------------------------------
I have included the server documentation from sierras website here for convienence
http://sierrastudios.com/games/tribesplayers/
You will probably not need to read this, but its here if you have any problems.

-------------------------------------------------------------------------------

 SERVER CORPS - BASIC ADMINISTRATION 

    Hardware Requirements 
    Basic Config File 
    Starting the Server 
    Remote Administration Using the Client 
  

Hardware Requirements 

This is basically a rough guide to give you an idea of how many players your machine will be able to support running a dedicated server.  "Listen" servers impose a much greater CPU load on your host machine, a rough guide for Listen servers would be to divide the number of players in the CPU table by two. The memory requirements are pretty straight forward, any dedicated server should have mnimum of 48 Megs of RAM for any number of players.  The following table gives a rough idea of player counts based on CPU speed: 
  CPU Speed Number of Players 
166 16 
200 20 
266 24 
333 32 
400 32 


Exceeding the player limit for your hardware can overload your machine (your CPU load will reach %100).  When this happens, your machine is no longer able to keep up with the game.  The players connected to your server will experience this as a form of "lag", which reduces the performance of the game.  If players on your server are often complaining of lag, then you may be overloading your system. 

TRIBES has an internal limit of 128 players, but we don't recommend that you exceed 32, even if your server can handle it.  The more players you allow on you server, the more load you are also placing on the clients, who need to process and render all players visible to them.  Clients with lower end processors will not be able to play effectively on games with player counts of over 32. 

Your Internet upstream & downstream rate also have a big impact on lag.  If your Internet bandwidth is not sufficient to support the number of player in the game, the players will experience this as lag.  Using the default $pref::packetRate and $pref::packetSize settings (mentioned below in the Basic Config File, and covered in more detail in the Advanced Administration page) each client to your server will consume 16Kbps.  Some Internet connections do not have equal upload and download rates, use the smaller number in this table: 
  Internet Connection Rate (Kbps) Number of Players 
28.8 1 
56 3 
128 (ISDN) 8 
256 16 
300 (Upload rate for some Cable Modems) 16 
1500 (T1) 32 


All the player numbers are basically the connection rate in Kbps divided by 16. This table does not include the host, so if you are running a listen server on a 56Kbps modem, you could have a 4 player game (3 over the Internet plus yourself).  Bandwidth issues are covered in a little more detail on the a Advanced Administration page under Bandwidth. 

Again, these are just rough numbers to get you started, check your CPU load, the responsivness of the game, reports of lagginess etc. and adjust your player count accordingly. 

Basic Config File 

The server config file consists of a plain text file placed in the tribes\config directory that is used to initialize a number of TRIBES console environment variables. The config file is executed after all the basic TRIBES initialization and will override the default variables declared in the serverPrefs.cs and clientPrefs.cs files also located in the tribes\config directory. The example config file given here declares the basic variables needed to get a dedicated server up and running. You can edit the values directly in the serverPrefs.cs and clientPrefs.cs files, but these files are also shared by the client, and if you are running the client and a dedicated server from the same directory, you should definitely make a separate config  file. 

Save the Basic Config text file into a file called serverConfig.cs in your tribes\config directory.  Make sure to edit the Server::Hostname, Server::Info and AdminPassword fields. 
CLICK HERE FOR basic serverConfig.cs file 
  $Server::HostName This is the name of your host (String) 
$Server::MaxPlayers Maximum number of players on at one time (Int) 
$Server::Info Information displayed about the server in the Game Info screen. Should contain the name and email of the server admin. (String) 
$Server::JoinMOTD Message Of the Day displayed for new clients (String) 
$Server::HostPublicGame Register this game with the master server (Bool) 
$Server::Port The port address to used to communicate with clients (Int) 
$Server::TimeLimit The time limit for a mission in minutes (Int) 
$Server::Password Password required to connect to the server (String) 
$AdminPassword Password to use in conjunction with SAD(password); to obtain admin rights. (String) 
$pref::PacketRate Max packets/sec per client. We recommend setting this to 10. (Int)  
$pref::PacketSize Max packet size per client. We recommend setting this to 200. (Int) 


Starting The Server 

Once your config file is all setup, start the server as follows: open a DOS box, cd into the TRIBES root directory and type the following (assuming your server config file is called serverConfig.cs): 

    infiniteSpawn *tribes +exec serverConfig -dedicated 

The infiniteSpawn program will automatically restart the TRIBES server should it exit prematurely. The * in front of the tribes executable name is an option to display restart and uptime information. Shut the server down by pressing the Quit button on the infiniteSpawn window.  TRIBES can be run without infiniteSpawn program, by simply typing from the TRIBES root directory: 

    tribes +exec serverConfig -dedicated 

If you are running more that a single dedicated server from the same directory, you can create a config file for each one, server1.cs, server2.cs etc., where each config file sets a different $Server::Port address (28001,28002, etc.)  Start them all going: 

    infiniteSpawn *tribes +exec server1 -dedicated 
    infiniteSpawn *tribes +exec server2 -dedicated 
    ... 

Remote Administration Using the Client 

Remote administration of a server is basically handled in two ways, either from a client (while playing the game) using the admin functions available on the server menu, or by connecting directly to a server. You can access the server directly by accessing it's dos box, or through a server's telnet port. Administrating using telnet is the same as operating from the server's DOS box, both are little more complicated than using the client, but do give you full access to the server (see Remote Administration using Telnet & Dos Window Administration). Administrating from the client only provides a minimal set of functions, kicking, changing missions, etc., but is easier to do, almost all of it is done through the server menu. Using the client, you must first get admin privileges by either being voted admin, or by knowing the server's admin password.  Admin yourself with the password by using the SAD command from the console: 

    SAD("password"); 

See the Basic Config File on setting an admin password. Note that if you are connected to a game you are hosting (i.e., not running a dedicated server), you automatically have admin rights. Once you are an admin, the server menu will appear slightly different.  Whereas non-admin clients see options such as "vote to change mission", if you have admim rights, the menu will simply say "change mission".  No vote will be called, and the action will take place immediately. 

There are a few console commands witch require arguments and are therefor not in the server menu.  These functions are client side scripts that effect changes on the server: 
  SAD("password"); Give yourself admin rights. 
SADSetPassword("password"); Set the server password (not the admin password) 
ADSetTimeLimit(time); Set the mission time limit 
ADSetTeamInfo(team#,"teamName",skinBase); Set team information. Team#=0-n (Int), teamName is the name displayed on the score menu and in the objectives, (String), skinBase is the skin set base name, such as beagle or dsword. (String) 

 
-------------------------------------------------------------------------------

 
 Bandwidth 

Server management of client bandwidth consumption  is controlled through two console preferences variables: 
  $pref::PacketRate Number of update packets per sec. (Int) 
$pref::PacketSize Size of each update packet (Int) 


The recommended default values are a packet rate of 10 and a packet size of 200.  Using these defaults values, each client consumes a maximum of about 2000 bytes per sec. or about 16Kbps. 

The clients use the same preference variables (accessed through the Options/Network page) to request bandwidth from the server.  The server always grants bandwidth requests up to it's maximum values, which are it's preference settings. So, if the server has it's packet rate set to 10, and a client requests 15, the client only receives 10 packets per sec. The same for the packet size.  Clients may request less.  The server never allocates more bandwidth than a client has requested, so increasing the server settings does not automatically increase the amount for each client. 

Player's can adjust their client packet rate and packet size settings on the Network/Options page.  This page presents the player with the following settings (TRIBES defaults to Modem settings): 
  Connection Packet Rate Packet Size 
Modem 10 200 
ISDN 15 300 
T1+ 15 400 


Each client can have it's own settings, and the server can be communicating with each client using a different amount of bandwidth. 

Increasing the bandwidth requested by the client, and allocated by the server, can have several effects; smoother motion for enemy players, elevators and doors are the most obvious.  The timing of explosions, projectiles and animation of turrets are also affected.  The more people and activity in a game, the more the increase in bandwidth will be noticeable. Increasing the bandwidth allowed for each client can dramatically increase your total bandwidth requirements, assuming that all the clients are requesting the maximum. Large LAN games is an example of where you may want to increase the bandwidth allowed to each client, without having to worry about your ISP. 

Exceeding the bandwidth of your Internet connection will have detrimental effects on game play.  Clients connected to your server will mainly experience this as lag.  If players on your server are often complaining of lag, then you may be exceeding your bandwidth, (or possibly overloading your CPU with too many players). 

Decreasing the packet rate and packet size to less than 10/200 is not recommended.  Decreasing the bandwidth will increase the perceived lag on your server, and generally have a detrimental effect on game performance for your clients. 

Console Logging 

Console logging is controlled using the $Console::LogMode (Int) variable.  When on, the console logs entries to the console.log file in the TRIBES root directory. The console operates in three modes: 
  $Console::LogMode Value (Int) Mode 
0 Logging off (Default) 
1 Opens and closes the log file for each log entry 
2 Keeps the log file open untill the mode changes 


Operating in mode 1 provides access to the file while the server is operating, at the (negligible) expense of opening and closing the file on each update.  This is the recommended mode of operation.  If you have no intention of accessing the file until the server is down, then use mode 2. 

Remote Administration Using Telnet 

Remote telnet admin basically gives you direct access to the server, the same as if you were typing into the server's DOS box.  The server does not enable telnet by default. Set the following variables in your config file to enable it: 
  $TelnetPort The port address to bind (Int) 
$TelnetPassword The login password, should be quoted (String) 


To connect to the server, simply telnet to the ip/port address you've entered.  You'll be prompted for a password, if entered correctly, you will then have direct access to the server. See the Dos Window Administration section for a list of some of the relevant console commands. 

DOS Window Administration 

This is not all the console commands, but a few to get you started: 
  ListPlayers(); List all the clients connected to the server 
MessageAll(type,"message"); Broadcast a message to all the clients, type (Int) (put 0 for now), message is a String. 
CenterPrintAll("message",timeout=5); Display a message in the center of all client screens, the time-out value, in seconds, defaults to 5 
TopPrintAll("message",timeout=5); Display a message at the top of all client screens, the time-out value, in seconds, defaults to 5 
BottomPrintAll("message",timeout=5); Display a message at the bottom of all the client screens, the time-out value, in seconds, defaults to 5 


Client Specific commands.  The clientId (and integer value) can be found by using the ListPlayers() function, the first field for each player in the list is their client ID. 
  Client::SendMessage(clientId,type,"message"); Send a message to a client, clientId, type (Int) (put 0 for now), message is a String. 
CenterPrint(clientId,"message",timeout=5); Display a message in the center of a client's screen, the time-out value, in seconds, defaults to 5 
TopPrint(clientId,"message",timeout=5); Display a message at the top of a client's screens, the time-out value, in seconds, defaults to 5 
BottomPrint(clientId,"message",timeout=5); Display a message at the bottom of a client's screen, the time-out value, in seconds, defaults to 5 
Net::Kick(clientId, "message"); Kick a client. The message is displayed on the client. 
Server::loadMission(missionName,immediate=false); Load a new mission, missionName (String) (without the .mis extension), if immediate (Bool) is false, then the game pauses to let players read the final objectives screen. 
Server::nextMission(replay=false); Cycle to the next mission. If the replay (Bool) argument is true, or if the server is in tournament mode, the current mission is restarted. 


The naming convention for these functions may seem a little confusing (Client::, Net::, no prefix, etc.)  There actually is a reason for most of it, and as we continue to explain the console language and it's interface with the C++ code, all will become clear. 

When connected directly to a server, server config variables, such as $Server::HostName, $Server::TimeLimit and $Server::MaxPlayes, can be changed with immediate effect.  A few variables, such as $Server::Port, will have no effect unless the server is restarted. Changing $Server::MaxPlayers to a lower number than currently logged in will keep new clients from connecting, but will not disconnect any of the current clients. 

Banning 

Banning keeps a client from both pinging and joining a server.  Clients can be banned with either an explicit transport address or with a transport address that ends in the * wild card.  A transport address is composed of three sections, each separated by a colon: 

    Transport Protocal (IP, IPX) : Address : Port 
Port addresses are ignored for banning purposes, but they can be entered. Example banned IP addresses: 
    "IP:198.34.78.130:28000"        // Ban an explicit address, the port is ignored 
    "IP:198.34.78.130"                   // Works the same as ubove 
    "IP:121.42.45.*"                       // Ban everyone on the 121.42.45 network 
Functions used to manipulate the banlist: 
  BanList::add(address,amount); Ban an address (String) for the given amount of sec (Int). 
BanList::addAbsolute(address,absTime); Ban an address (String) untill absTime (Int) 
BanList::remove(address); Unban an address (String) 
BanList::export(filename); Export the ban list to a file (String) 

The ban list tracks absolute time using the number of seconds since 00:00:00 GMT, January 1, 1970.  It is easier to ban addresses for a specific amount of time using  function BanList::add().  When the server is shutdown normally, the ban list is automatically exported into the tribes\config\banlist.cs file.  This same file is executed when the server starts up, so any entries made during the operation of the server are maintained between sessions.  Since the BanList tracks time internally using absolute time, if you ban someone for a day (86400 seconds), server up or down time will have no effect on the length of this ban. 

Banning does not kick a player.  To do this use the Net::Kick function described in Dos Window Administration 

Mission List 
The mission list is used to control the list of missions presented to the player on both the Host Game screen and the server menu.  It is also used to initialize the next mission array which controls which mission to load after a mission finishes. 

Note: The missionList.cs file was added to simplify mission list management, and will be released in version 1.2 of TRIBES.  If you don't have 1.2 (it hasn't been released at the time that this was written), you can download the missionList.cs file and put it in your tribes\config directory.   Download MissionList.cs Here 

Mission list functions: 
  MissionList::clear(); Clears the list 
MissionList::build(); Builds the mission list by scanning the mission directories of each loaded mod, including the base mod. 
MissionList::addMission(missionName); MissionName (String) is the name of the .dsc file for the mission (without the .dsc extension) 
MissionList::initNextMission(); Initialize the next mission array with the missions currently added. 


The following lines, added to your server config file, will initialize the mission list to contain two missions.  These will be the only mission presented to the players. 
  

    // The exec command is only needed if you've downloade the missionList file 
    // for versions 1.0 or 1.1 of TRIBES (doesn't hurt to leave it) 
    exec(missionList); 
    MissionList::clear(); 
    MissionList::addMission("Broadside"); 
    MissionList::addMission("Raindance"); 
    MissionList::initNextMission(); 
    $pref::lastMission = "Broadside"; 
  
  

Since both of these missions are CTF, your server will be a CTF only server.  The missions will cycle in the order that they are declared.  The $pre::lastMission variable is set to the mission to load when the server is started (dedicated servers always start with the last loaded mission). 

If you want to change the next mission order without affecting the contents of the mission list, you can do so by setting the $nextMission array directly: 
  

    // 
    $nextMission["Broadside"] = "CrissCross"; 
    $nextMission["CrissCross"] = "Raindance"; 
    $nextMission["Raindance"] = "Broadside"; 
  
  

By changing this array manually, you can cycle through any mission of any type.  Make sure to make any changes to the nextMission array after you call the MissionList::initNextMission() function.  By default the nextMission array is intialized by the time the server config file or autoexec files are executed. 

If you change the next mission array directly, make sure that every mission has an entry. If you miss a next mission entry for a mission, the server will fail to load the next mission and the clients will get stuck on a black screen. 

  
 

 
 


 

 



 
