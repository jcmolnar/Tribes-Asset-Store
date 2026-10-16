// Ultra_Renegades 3 Mayhem -- server loader (Modern Tribes client 1.50 port).
//
// createServer() in server.cs execs this file. It replaces the original shitlist.cs, which held
// the same two things behind 220 blank lines and 1400 spaces: the connect handler below with a
// list of 38 hard-coded player names to kick (removed), and the datablock exec list (unchanged,
// same order).

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // the host's own client is the super admin
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
   %clientId.noghost = true;
   %clientId.messageFilter = -1;
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";
   Game::onPlayerConnected(%clientId);
}

exec(admin);
exec(Marker);
exec(Trigger);
exec(NSound);
exec(BaseExpData);
exec(BaseDebrisData);
exec(BaseProjData);
exec(ArmorData);
exec(Mission);
exec(Item);
exec(Player);
exec(Vehicle);
exec(Turret);
exec(Beacon);
exec(StaticShape);
exec(Station);
exec(Moveable);
exec(Sensor);
exec(Mine);
exec(AI);
exec(InteriorLight);
