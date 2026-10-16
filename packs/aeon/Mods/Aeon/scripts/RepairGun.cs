$RepairRateDefault = 0.2;
$RepairSelfRateDef = 0.05;

function Repair::canRepair(%player,%target)
{
	//-coming soon...
	return True;
}

function Repair::getRate(%player,%target)
{
	%client = Player::getClient(%player);
	%data = GameBase::getDataName(%target);
	%name = Repair::getName(%target);
	%PPos = GameBase::getPosition(%player);
	%TPos = GameBase::getPosition(%target);
	%dist = Vector::getDistance(%PPos,%TPos);
	%rMax = RepairBolt.boltLength;
	%rRat = 1-(%dist / %rMax);
	%rate = $RepairRateDefault;
	if($RepairRate[%data])
		%rate = $RepairRate[%data];
	if(%target.dmgVis) {
		//%offVec = %target.dmgVisOffvec;
		//%visPos = GetOffSetRot(%offVec,GameBase::getRotation(%target),%TPos);
		//%visDst = Vector::getDistance(%visPos,...);
	}
	%prog = 100*(1-(GameBase::getDamageLevel(%target) / %data.maxDamage));
	%player.repairRate = %rate * %rRat;
	Bottomprint(%client,"<jc><f1>Repairing <f2>"@%name@"<f1>, Efficiency: <f2>%"@%rRat*100@"<f1>, Completion: <f2>%"@%prog);
}

function Repair::getName(%this)
{
	%data = GameBase::getDataName(%this);
	%name = GameBase::getMapName(%this);
	if(%name == "" || %name == False)
		%name = %data.description;
	return %name;
}

function RepairBolt::onAcquire(%this, %player, %target)
{
	//- %this = what in the hell?
	%client = Player::getClient(%player);
	if(Repair::canRepair(%player,%target) == False) {
		Bottomprint(%client,"<jc><f1>Repair Operations: <f2>Beam transmission malfunction!");
		return;
	}
	if(%target == %player) {
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = $RepairSelfRateDef;
			%player.repairTarget = %player;
			Bottomprint(%client,"<jc><f1>AutoRepair Operations: <f2>Activated");
		}
		else {
			Bottomprint(%client,"<jc><f1>Repair Operations: <f2>Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
		%data = GameBase::getDataName(%target);
		%player.repairTarget = %target;
		Repair::getRate(%player,%target);
		if(getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
			Client::sendMessage(%rclient,0,"Being repaired by "@Client::getName(%client));
		}
		else { 
			%name = Repair::getName(%target);
		}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Bottomprint(%client,"<jc><f1>Repair Operations: <f2>"@%name@" is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(%name == "" || %name == -1 || %name == False)
			%name = "an Unknown Object";
		//Bottomprint(%client,"<jc><f1>Repair Operations: <f2>repairing "@%name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this,%player)
{
	%object = %player.repairTarget;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(%object == %player)
				Bottomprint(%client,"<jc><f1>AutoRepair Operations: <f2>Deactivated");
		else {
			if(GameBase::getDamageLevel(%object) == 0) {
				Bottomprint(%client,"<jc><f1>Repair Operations: <f2>Complete");
				//-
			}
			else
				Bottomprint(%client,"<jc><f1>Repair Operations: <f2>Aborted");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if(%player.repairTarget == -1)
		return;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		%object = %player.repairTarget;
		if(GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		else {
			Repair::getRate(%player,%object);
			//-<more?>
		}
	}
}