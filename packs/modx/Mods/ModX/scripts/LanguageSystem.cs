// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
// Language System, not implemented publicly yet because lack of completion...
//
//----------------------------------------------------------------------------

$Language::Total = 0;

function Language::execLocale(%localeFile)
{
    exec(%localeFile);
    echo("Executing ModX Language File: [" @ %localeFile @ "]");
}

function Language::addLocale(%locale)
{
    $Language::LocaleList[$Language::Total] = %locale;
    $Language::Total++;

}

function Language::setLocale(%locale)
{
    if(Language::localeExists(%locale) == true)
    {
        $Language::CurrentLocale = %locale;
        echo("Language set: [" @ %locale @ "]");
    }
    else
    {
        $Language::CurrentLocale = $Language::LocaleList[0];
        echo("Invalid Language File, using default: [" @ $Language::LocaleList[0] @ "]");
    }
}

function Language::localeExists(%locale)
{
    for(%i = 0; (%language = $Language::LocaleList[%i]) != ""; %i++)
    {
        if(%language == %locale)
            return true;
    }
    return false;
}

function Language::getString(%type, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9)
{
    %langString = $Language[$Language::CurrentLocale, %type];
    if(%arg1 != "")
        %langString = String::Replace(%langString, "%1", %arg1);
    if(%arg2 != "")
        %langString = String::Replace(%langString, "%2", %arg2);
    if(%arg3 != "")
        %langString = String::Replace(%langString, "%3", %arg3);
    if(%arg4 != "")
        %langString = String::Replace(%langString, "%4", %arg4);
    if(%arg5 != "")
        %langString = String::Replace(%langString, "%5", %arg5);
    if(%arg6 != "")
        %langString = String::Replace(%langString, "%6", %arg6);
    if(%arg7 != "")
        %langString = String::Replace(%langString, "%7", %arg7);
    if(%arg8 != "")
        %langString = String::Replace(%langString, "%8", %arg8);
    if(%arg9 != "")
        %langString = String::Replace(%langString, "%9", %arg9);
    return %langString;
}

// Automation, remove in final version:

Language::execLocale("languageENG.cs");
Language::setLocale("English");

// Automation end.
