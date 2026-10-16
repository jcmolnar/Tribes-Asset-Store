// ----------------------------------------------------------------------------
// KingTomato Recruit Script
// --
// This file contains the functions used in the recruiting mod. Basically,
// enable recruit mode in the KT_Paintball file, and this will take over. Very
// easy to install >:D
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Enter Recruit mode

function RecruitMode::Enter()
{
	messageAll(0, "Entering recruit mode...");

	// First go through and find all the clients, then put them in
	// observer. From there, admins go through the tab menu to sign
	// up to be a recuiter. From there, the players do the same to
	// sign up to be a recruit.
	for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setInitialTeam(%cl, -2);
		Gamebase::setTeam(%cl, -2);

		if (%cl.isAdmin)
			Client::SendMessage(%cl, 0, "If you wish to recruit, please goto the TAB menu and select so from the recruit menu.");
		else
			Client::sendMessage(%cl, 0, "If you wish to tryout, please goto the TAB menu and select so from the recruit menu.");
	}

	// initialize queue
	$RecruitMode::QueueCount = 0;

	$RecruitMode::LoadFails = 0;

	messageAll(0, "Entered recruit mode.");
}

// ----------------------------------------------------------------------------
// Leave recruit mode

function RecruitMode::Leave()
{
	messageAll(0, "Leaving recruit mode...");

	// auto assign teams
	for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%cl.recruit = "";
		%cl.recruiter = "";
		Gamebase::setTeam(%cl, -1);
	}

	// clear queue list
	deletevariables("$RecruitMode::Queue*");

	deletevariables("$RecruitMode::LoadFails");
}

// ----------------------------------------------------------------------------
// Look for game win

function RecruitMode::CheckGame()
{
	%cl = Client::GetFirst();
	%high = %cl;
	for (%cl = Client::GetNext(%cl); %cl != -1; %cl = Client::GetNext(%cl))
	{
		if (%cl == -1)
			break;
		if (%cl.scoreKills > %high.scoreKills)
			%high = %cl;
	}

	if (%high.scoreKills >= 10) // HS's = 2 points, so 9 + HS(2) = 11
	{
		messageAll(0, "Recruit session winner: " @ Client::GetName(%high));
		for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl))
			if (!Observer::isObserver(%cl))
				Gamebase::setTeam(%cl, -2);
		Game::ResetScores();

		RecruitMode::NextTryout();
	}
}

// ----------------------------------------------------------------------------
// find next in queue

function RecruitMode::NextTryout()
{
	%recruit	= "";
	%recruits	= 0;
	%recruiter	= "";
	%recruiters	= 0;
	for (%cl = Client::GetNext(%cl); %cl != -1; %cl = Client::GetNext(%cl))
	{
		if (%cl.recruiter)
		{
			%recruiter = %cl @ " ";
			%recruiters++;
		}
		else if (%cl.recruit)
		{
			%recruit = %cl @ " ";
			%recruits++;
		}
	}

	if (%recruiter > 0)
	{
		if (%recruits > 0)
		{
			%tester = getWord(%recruiter, floor(getRandom() * %recruiters));
			%testee = getWord(%recruiter, floor(getRandom() * %recruits));

			Gamebase::SetTeam(%tester, -1);
			Gamebase::SetTeam(%testee, -1);

			messageAll(0, "Match has begin.");
			messageAll(0, "First player to reach 10 wins.");

			// reset fail count
			$RecruitMode::LoadFails = 0;
		}
		else
			RecruitMode::Fail("There are no recruits in queue.");
	}
	else
		RecruitMode::Fail("There are no recruiters present.");
}

// ----------------------------------------------------------------------------
// Load Fail
// --
// The idea of this is to basically, every time a recruit end, and a new game
// is supposed to play, it goes through and looks for both a recruiter, and a
// recruit. If neither are found, a 'fail' is called. On a fail, a counter is
// increased, then another attempt to load is done 1 minute later. After 10
// fails, it assums there is no more recruiting, and exits recruit mode.

function RecruitMode::Fail(%reason)
{
	messageAll(0, "Unable to load new game: " @ %reason);
	messageAll(0, "Attempting reload in 1 minute.");

	$RecruitMode::LoadFails++;
	if ($RecruitMode::LoadFails <= 10) // PORT: stray ")" removed
		schedule("RecruitMode::NextTryout();", 60);
	else
	{
		messageAll(0, "Tryout attept has failed 10 times.");
		RecruitMode::Leave();
	}
}
