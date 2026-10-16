
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Grenade (Grenade)
//  By Dynamix modified by Alazane, see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//  Depends on:
//    Only Alliance armor being used (onGrenade support)
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;
$VehicleInvList[Grenade] = 1;
$SellAmmo[Grenade] = 5;

addAmmo("", Grenade, 2);

ItemData Grenade 
{
  description = "Grenade";
  shapeFile = "enbolt";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  price = 5;
  className = "HandAmmo";
};

function Grenade::onUse(%player,%item) 
{
  if ($matchStarted && %player.throwTime < getSimTime()) 
  {
    Player::decItemCount(%player,%item);
    %armor = Player::getArmor(%player);
    eval(%armor @ "::onGrenade(" @ %player @ ");");
  }
}
