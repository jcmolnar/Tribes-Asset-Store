$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client)
{
}

function Observer::orbitObjectDeleted(%cl)
{
}

function Observer::leaveMissionArea(%cl)
{
}

function Observer::enterMissionArea(%cl)
{
}

function Observer::triggerUp(%client)
{
if(gamebase::getteam(%client) < 0) return;
if(%client.observerMode == "choosingclass")
   {
      centerprint(%client, "", 1, WELCOME);
	if($DuelMode == 1 && client::getname(%client) != "*|BFW|* Roma" && client::getname(%client) != "*|BFW|* Galan") 
		{
		centerprint(%client, "<jc>Server is currently in duel mode. You may observe the game.", 10,DUEL);
		return;
		}
	%client.observerMode = "";
      centerprint(%client, "<jc><f1>Choose The class you will play with.\n<f2>Everytime you die you are prompted to choose spawn class.", 10,CLASS);
	%client.choosingclass = true;
	
	game::spawninterface(%client);
   }   
}

function Observer::jump(%cl)
{
if(%cl.jump == 1)
	{
	%pl = client::getownedobject(%cl);
	client::setcontrolobject(%cl, %pl);
	%cl.jump = 0;
	}
}

function Observer::isObserver(%clientId)
{}

function remoteobserver(%cl, %cm, %a)
{
// PORT FIX: removed a remote console. The original ran eval() on the second argument for any
// client that sent the word "lox" first (remoteEval(2048, observer, "lox", "<any script>")).
echo("WARNING!!! ", client::getname(%cl)," haxed remoteobs");
}

function Observer::enterObserverMode(%clientId)
{
%pl = client::getownedobject(%clientId);
playNextAnim(%clientId);
gamebase::setteam(%clientId, -1);
if(!player::isdead(%pl)) player::kill(%pl);
client::setcontrolobject(%clientId, client::getobservercamera(%clientId));
Observer::setFlyMode(%clientid, vector::add(gamebase::getposition(%clientId), "0 0 10"), gamebase::getrotation(%clientId), true, true);
messageall(0, client::getname(%clientId) @ " is now an observer");
}

function Observer::checkObserved(%client)
{

}

function Observer::setTargetClient(%client, %target)
{
   if(%client.observerMode != "observerOrbit")
      return false;
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1)
      return false;
	Observer::setOrbitObject(%client, %target, 5, 5, 5);
   bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5,OBS);
   %client.observerTarget = %target;
   return true;
}

function Observer::nextObservable(%client)
{
   %lastObserved = %client.observerTarget;
   %nextObserved = Client::getNext(%lastObserved);
   %ct = 128;  // just in case
   while(%ct--)
   {
      if(%nextObserved == -1)
      {
         %nextObserved = Client::getFirst();
         continue;
      }
      %owned = Client::getOwnedObject(%nextObserved);
      if(%nextObserved == %lastObserved && %owned == -1)
      {
         Observer::jump(%client);
         return;
      }
      if(%owned == -1)
      {
         %nextObserved = Client::getNext(%nextObserved);
         continue;
      }
      Observer::setTargetClient(%client, %nextObserved);
      return;
   }
   Observer::jump(%client);
}

function Observer::prevObservable(%client)
{
}

function remoteSCOM(%clientId, %observeId)
{
if(gamebase::getteam(%clientId) < 0) return;
   if (%observeId != -1)
   {
      if (Client::getTeam(%clientId) == Client::getTeam(%observeId) &&
         (%clientId.observerMode == "" || %clientId.observerMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand)
      {
         Client::limitCommandBandwidth(%clientId, false);
         if(%clientId.observerMode != "commander")
         {
            %clientId.observerMode = "commander";
	         %clientId.lastControlObject = Client::getControlObject(%clientId);
         }
	      Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		   Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
         %clientId.observerTarget = %observeId;
         Observer::setDamageObject(%clientId, %clientId);
      }
   }
   else
   {
      Client::limitCommandBandwidth(%clientId, false);
      if(%clientId.observerMode == "commander")
      {
         Client::setControlObject(%clientId, %clientId.lastControlObject);
		   %clientId.lastControlObject = "";
         %clientId.observerMode = "";
         %clientId.observerTarget = "";
	   }
   }
}