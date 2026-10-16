// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$DefStayTime = 3;

function Creator::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
    Tool::onUse(%player,%item);
    if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Deploys an object, configurable through the [TAB] menu or the weapon mode keys.", $DefStayTime);
}

function TargetingLaser::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Shoots a green laser that targets things. Also useful for cleaning light artifacts", $DefStayTime);
}

function StrykerChain::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Pulls you toward an object.", $DefStayTime);
}

function Grabbler::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Allows you to move any object anywhere you like. Use the weapon mode keys to change modes.", $DefStayTime);
}

function Welder::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Allows you to lock objects in place, or copy objects through it's alternate mode.", $DefStayTime);
}

function Destructor::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Deletes objects.", $DefStayTime);
}

function Warper::onUse(%player,%item)
{
    if($LaserTagMode == true)
        return;
	Tool::onUse(%player,%item);
	if(Account::IsWeponHelpOn(Player::getClient(%player)) == true)
	   bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Warps the user to the point specified by what he is looking at with a range of 500m. Warning: You can warp into walls!", $DefStayTime);
}
