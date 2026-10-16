
$modInfo = "\n<f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f2>PlanetTribes.com/UltraVX";

//"<f1>Ultra_RenegadesVX5 Ultra_RenegadesVX5_OGL Ultra_RenegadesVX5_NOTOR\n"@

function vxmode(%mode){

$Ultra_RenegadesVX5::ultravxmod = %mode;
%mode = $Ultra_RenegadesVX5::ultravxmod;

 
if(%mode == "Ultra_RenegadesVX5"){
exec("UltraVX5.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
}
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD v5.01\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                   }

if(%mode == "Ultra_RenegadesVX5_OGL"){
exec("UltraVX5_OGL.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f2>PlanetTribes.com/UltraVX";
//$modInfo = "\n<f1>" @ $ultravxmod @ "\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
}
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD v5.01\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                   }

if(%mode == "Ultra_RenegadesVX5_NOTOR"){
exec("UltraVX5_NOTOR.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
}
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD v5.01\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                  }
export("Ultra_RenegadesVX5::*", "config\\Ultra_RenegadesVX5.cs", False);
}

function vxDIFmode(%mode){
   $Ultra_RenegadesVX5::ultravxDIFmode = %mode;
   %mode = $Ultra_RenegadesVX5::ultravxDIFmode;
   
   if(%mode == "Defaults")
     {
      exec("UltraVX5_EASY.cs");
      //echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
     }
   if(%mode == "MEDIUM")
     {
      exec("UltraVX5_MEDIUM.cs");
     // echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
     }
   if(%mode == "HARD")
     {
      exec("UltraVX5_HARD.cs");
     // echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
     }
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD v5.01\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
echo("Changing UltraVX MODE... Difficulty Mode: " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
export("Ultra_RenegadesVX5::*", "config\\Ultra_RenegadesVX5.cs", False);
}

