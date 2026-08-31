function AntiCrash::getObjectByTargetIndex( %index )
{
	%tind = 0;
	for(%i=8000;%i<9000;%i++)
	{
		if ( isObject(%i) )
		{
			%data = GameBase::getDataName(%i);
			if ( %data != "" && %data.visibleToSensor )
			{
				if ( %tind == %index )
					return %i;
				%tind++;
			}
		}
	}
	return -1;
}

function showup()
{
	for(%i=0;%i<200;%i++)
	{
		%obj = getObjectByTargetIndex(%i);
		echo(%obj@" "@getObjectType(%obj)@" "@GameBase::getDataName(%obj));
	}
}

function showup3()
{
	for(%i=0;%i<200;%i++)
	{
		%obj = NEWgetObjectByTargetIndex(%i);
		echo(%obj@" "@getObjectType(%obj)@" "@GameBase::getDataName(%obj));
	}
}


function showup4()
{
	for(%i=0;%i<200;%i++)
	{
		%obj = getObjectByTargetIndex(%i);
		%obj2= NEWgetObjectByTargetIndex(%i);
		echo(%obj@" "@%obj2);
	}
}

function showup2()
{
	for(%i=8268;%i<8400;%i++)
	{
		echo(%i@" "@getObjectType(%i)@" "@GameBase::getDataName(%i));
	}
}