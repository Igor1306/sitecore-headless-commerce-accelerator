function Write-Logo() {
    Write-Host @"
.................::::-....---.-::-......-:::-....---..:::....:::...............
..............-########:.-#########+..*#######*..*########=######+.............
........-*:...*##-...=#=.-##=....##=.:##+...+##:.*##-...=##-...##=...:*-.......
......-***:...=##....=##.-##*....=#=.:##:...+##:.*##-...=##....##=...:***-.....
....:***:.....=##....=##.-##*....=#=..---...+##:.*##-...=##....##=.....:***-...
...***:.......=#########.-##*....=#=...:=######:.*##-...=##....##=.......:***..
...***+.......=##+++++++.-##*....=#=.-###*-.+##:.*##-...=##....##=.......+***..
....-***+.....=##........-##*....=#=.:##+...+##:.*##-...=##....##=.....+***-...
......-***:...=##....*##.-##*....=#=.:##+...+##:.*##-...=##....##=...:***-.....
........-*:...*##:...=#=.-##=-..-##=.:##*...*##:.*##-...=##....##=...:*-.......
..............-=#######-.-##=######:..=#####=##:.*##-...=##....##=.............
..................--.....-##*..--.......--.....................................
.........................-##*..................................................
.........................-##*..................................................
"@
    Write-Host
}

function Set-EnvVariable {
    param([string]$Key, [string]$Value)
    [System.Environment]::SetEnvironmentVariable($Key, $Value, "User")
}
