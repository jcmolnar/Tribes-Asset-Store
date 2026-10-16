//----------------------------------------------------------------------------

TriggerData ScriptTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function ScriptTrigger::onEnter(%this,%object)
{
if(%this.enter != "") eval(%this.enter @ "(" @ %this @ "," @ %object @ ");");
}	

function ScriptTrigger::onLeave(%this,%object)
{
if(%this.leave != "") eval(%this.leave @ "(" @ %this @ "," @ %object @ ");");
}

function ScriptTrigger::onContact(%this,%object)
{
if(%this.contact != "") eval(%this.contact @ "(" @ %this @ "," @ %object @ ");");
}

function ScriptTrigger::onActivate(%this)
{
}

function ScriptTrigger::onDeactivate(%this)
{
}


//============================================================
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------

