//----------------------------------------------------------------------------

TriggerData GroupTrigger
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger0
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger1
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger2
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger3
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger4
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger5
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger6
{
	className = "Trigger";
	rate = 1.0;
};
TriggerData FlagTrigger7
{
	className = "Trigger";
	rate = 1.0;
};
function FlagTrigger0::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,0); } 
function FlagTrigger1::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,1); }
function FlagTrigger2::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,2); }
function FlagTrigger3::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,3); }
function FlagTrigger4::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,4); }
function FlagTrigger5::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,5); }
function FlagTrigger6::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,6); }
function FlagTrigger7::onEnter(%this,%object) { FlagTrigger::onEnter(%this,%object,7); }
function FlagTrigger::onEnter(%this,%object,%thisteam)
{
	%type = getObjectType(%object);
	if(%type != "Player")
		return;
	if($teamflag[%thisteam])
	{
		FlagFix::onCollision(%this,%object,%thisteam);
		return;

	}
}

function GroupTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
 		%count = Group::objectCount(%group);
 		for (%i = 0; %i < %count; %i++) 
 			GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
	}
}	

function GroupTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigLeave",%object,%this);
	}
}

function GroupTrigger::onContact(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigger",%object,%this);
	}
}

function GroupTrigger::onActivate(%this)
{
}

function GroupTrigger::onDeactivate(%this)
{
}
