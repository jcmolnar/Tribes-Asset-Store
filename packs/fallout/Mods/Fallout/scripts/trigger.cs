//%%%%% This is not finished. it's a trigger that grants inventory access when
//%%%%% entered. it is centered around a player who is using the inventory armor
//%%%%% this armor lets people buy any equipment they need, effectively making a
//%%%%% mobile field base. -Floater Eater

TriggerData InvArmorTrigger
{
    className = "Trigger";
    rate = 1.0;
};

function InvArmorTrigger::onEnter(%this, %object)
{
    %type = getObjectType(%object);
    %client = Player::getClient(%object);

    //%%%%% check player's team. section A
    if(GameBase::getTeam(%object) == GameBase::getTeam(%this)){

         if(%type == "Player")//%%%%% Section B
         {
              if(Player::isAiControlled(%client) != "True")//%%%%% section C
              {
                   Fallout::weaponCheck(%client);


              }//%%%%% end section C
         }//%%%%% end section B
    }//%%%%% end section A
}

//----------------------------------------------------------------------------

TriggerData GroupTrigger
{
	className = "Trigger";
	rate = 1.0;
};

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
