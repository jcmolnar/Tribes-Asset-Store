$modInfoMsg = "<jc><f1>¤§ <f2>Ultra_RenegadesVX5 -Tribute- <f1>§¤\n¤§ Modified By: <f2>UnhOlYAngl <f1>& <f2>[VX]LeGeND <f1>§¤";

$modInfo = "\n<f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>" @ $modInfoMsg;


//"<f1>Ultra_RenegadesVX5 Ultra_RenegadesVX5_OGL Ultra_RenegadesVX5_NOTOR\n"@

function vxmode(%mode){
	if(%mode == "Ultra_RenegadesVX5 -Tribute-"){
		exec("UltraVX5.cs");
	} else if (%mode == "Ultra_RenegadesVX5_OGL"){
		exec("UltraVX5_OGL.cs");
	} else if (%mode == "Ultra_RenegadesVX5_NOTOR"){
		exec("UltraVX5_NOTOR.cs");
	} else if (%mode == "Ultra_RenegadesVXU -Tribute-"){
		exec("UltraVXU.cs");
                     } else if (%mode == "Ultra_RenegadesVXO -Tribute-"){
		exec("UltraVXO.cs");
	}
	if($Ultra_RenegadesVX5::ultravxmod == %mode) {
		echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
		$modInfo = "<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n\n<f1>" @ $modInfoMsg;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
			remoteEval(%cl, MODInfo, $MODInfo);
		}
		bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
	}
	export("Ultra_RenegadesVX5::*", "config\\UltraVXTributeMode.cs", False); // PORT: was config\\Ultra_RenegadesVX5.cs
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
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
echo("Changing UltraVX MODE... Difficulty Mode: " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
export("Ultra_RenegadesVX5::*", "config\\UltraVXTributeMode.cs", False); // PORT: was config\\Ultra_RenegadesVX5.cs
}

