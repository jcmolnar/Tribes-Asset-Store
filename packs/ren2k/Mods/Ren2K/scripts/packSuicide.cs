$InvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;

ItemImageData SuicidePackImage 
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = 
  {
    0, -0.5, -0.3 }
  ;
  mountRotation = 
  {
    0, 0, 0 }
  ;
  mass = 2.5;
  firstPerson = false;
}
;
ItemData SuicidePack 
{
  description = "Suicide DetPack";
  shapeFile = "magcargo";
  className = "Backpack";
  heading = $InvHead[ihBac];
  imageType = SuicidePackImage;
  shadowDetailMask = 4;
  mass = 2.5;
  elasticity = 0.2;
  price = 450;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
}
;
function SuicidePack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else 
  {
    Player::deployItem(%player,%item);
  }
  }
function SuicidePack::onUnmount(%player,%item) 
{
  }
function SuicidePack::onDeploy(%player,%item,%pos) 
{
  if (SuicidePack::deployShape(%player,%item)) 
  {
    Player::decItemCount(%player,%item);
  }
  }
function SuicidePack::deployShape(%player,%item) 
{
  Player::unmountItem(%player,$BackpackSlot);
  %obj = newObject("","Mine","Suicidebomb2");
  addToSet("MissionCleanup", %obj);
  %client = Player::getClient(%player);
  GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
  Client::sendMessage(%client,1,"Det Pack will destruct in 5 seconds");
}
