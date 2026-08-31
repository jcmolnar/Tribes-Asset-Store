//-----------------------------------------
//GroupTrigger::onEnter()
//-----------------------------------------
function elevator4x5::onCollision(%this,%obj)
{
	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 1200; %zVec = 200;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0)
		{ 
		} 
		else if (%rnd == 1) 
		{
		} 
		else if (%rnd == 2) 
		{ 
		}
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 1200; %zVec = 200;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 1200;
		%zVec = 200;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 
function elevator6x6::onCollision(%this,%obj)
{
	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 500; %zVec = 800;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0)
		{ 
		} 
		else if (%rnd == 1) 
		{
		} 
		else if (%rnd == 2) 
		{ 
		}
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 500; %zVec = 800;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 500;
		%zVec = 800;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 
function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "T1"){
      %positionIn = "174.463 4369.89 68.0853";
      %positionOut = "213.875 6180.21 61.6777";
   }
      else if(%this.num == "T2"){
      %positionIn = "218.716 4389.25 64.3235";
      %positionOut = "133.181 4387.92 64.2929";
   }
%client = Player::getClient(%object);
	if(%this.num == "T3"){
      %positionIn = "255.11 6163.31 64.1697";
      %positionOut = "169.847 6162.09 64.1501";
   }
      else if(%this.num == "B2"){
      %positionIn = "-186.953 230.78 872.832";
      %positionOut = "";
   }


  	if(%this.in){ 
         GameBase::setPosition(%client, %positionIn);
         //messageAll(0, "~wshieldhit.wav");
	   Client::SendMessage(%client,0,"~wshieldhit.wav");
      }
      	else if(%this.out){
         GameBase::setPosition(%client, %positionOut);
         //messageAll(0, "~wshieldhit.wav");
         Client::SendMessage(%client,0,"~wshieldhit.wav");
	}
 
} 

