$ItemMax[armormSniper, SuicidePack] = 0;
$ItemMax[armorfSniper, SuicidePack] = 0;
$ItemMax[armormScout, SuicidePack] = 0;
$ItemMax[armormMercenary, SuicidePack] = 0;
$ItemMax[armorfMercenary, SuicidePack] = 0;
$ItemMax[armormBurster, SuicidePack] = 1;
$ItemMax[armorCyborg, SuicidePack] = 0;
$ItemMax[armorfScout, SuicidePack] = 0;
$ItemMax[armorfBurster, SuicidePack] = 1;
$ItemMax[armormSpy, SuicidePack] = 0;
$ItemMax[armorfSpy, SuicidePack] = 0;
$ItemMax[armormEngineer, SuicidePack] = 0;
$ItemMax[armorfEngineer, SuicidePack] = 0;
$ItemMax[armormAlien, SuicidePack] = 0;
$ItemMax[armorfAlien, SuicidePack] = 0;
$ItemMax[dmarmor, SuicidePack] = 0;
$ItemMax[dmfemale, SuicidePack] = 0;
$ItemMax[armormLoader, SuicidePack] = 0;
$ItemMax[armorfLoader, SuicidePack] = 0;
$ItemMax[armormSprint, SuicidePack] = 0;
$ItemMax[armorfSprint, SuicidePack] = 0;

$InvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;

ItemImageData SuicidePackImage 
{
  shapeFile = "generator_p";
  mountPoint = 2;
  mountOffset = { 0, -0.5, 0.0 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData SuicidePack 
{
  description = "Nuke DetPack";
  shapeFile = "generator_p";
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
};

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
  Client::sendMessage(%client,1,"Det Pack will destruct in 5 seconds, RUN!!!!!");
}
