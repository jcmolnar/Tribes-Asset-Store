function Cybrid::InitFlagFX()
{
	%group = NameToID("MissionGroup");
	ScanGroup(%group);	
}

function Flag::CreateSFX(%this)
{
	if(!IsObject(%this))
		return;
		
	if(%this.carrier == -1)
	{
		GameBase::SetRotation(%this, Vector::Add(GameBase::GetRotation(%this), "0 0 0.05"));
		%pos = GameBase::GetPosition(%this);
	}
	else
		%pos = GameBase::GetPosition(%this.carrier);

	
	%minrad = 0;
	%maxrad = 2;
	
	%tempPos = RandomPositionXY(%minrad, %maxrad);
	
	%xPos = (GetWord(%tempPos, 0)/2) + GetWord(%pos, 0);
	%yPos = (GetWord(%tempPos, 1)/2) + GetWord(%pos, 1);
	%zPos = GetWord(%pos, 2) + ((floor(GetRandom()*10)-2)/2);
	%newPos = %xPos @ " " @ %yPos @ " " @ %zPos;
	
	%obj = newObject("FlagSparkle","Mine", "FlagSparkle");
	addToSet($FlagSFXSet[%this], %obj);
	GameBase::SetPosition(%obj, %newPos);
	
	schedule("Flag::CreateSFX(" @ %this @ ");", 0.07);
}

function ScanGroup(%group)
{
	%count = Group::ObjectCount(%group);
	for(%i = 0; %i < %count; %i++)
	{
		%obj = Group::GetObject(%group, %i);
		if(GetObjectType(%obj) == "SimGroup" || GetObjectType(%obj) == "TeamGroup")
		{
			ScanGroup(%obj);
		}
		if(GameBase::GetDataName(%obj) == "flag")
		{
			%team = GameBase::GetTeam(%obj);
			echo("Flag Found");
			echo("Object: " @ %obj);
			echo("Team:   " @ %team);
			if(%team == -1)
				$FlagSFXSet[%obj] = NewObject("Flag " @ %obj @ ": Find and Retrieve", SimGroup);
			else
				$FlagSFXSet[%obj] = NewObject("Flag " @ %obj @ ": Team " @ %team @ " (" @ $Server::TeamName[%team] @ ")", SimGroup);
			AddToSet($SFXMainSet, $FlagSFXSet[%obj]);
			Flag::CreateSFX(%obj);
		}
	}
}

function Cybrid::InitGroups()
{
	echo("==========Initing Groups");
	$SFXMainSet = NewObject("Special Effects", SimGroup);
	AddToSet("MissionCleanup", $SFXMainSet);

}