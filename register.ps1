$action = New-ScheduledTaskAction -Execute 'LetsCheckinYo.exe' -Argument "C:\Program Files (x86)\LetsCheckinYo\LetsCheckinYo.exe"
$trigger = New-ScheduledTaskTrigger -Daily -At 7am

Register-ScheduledTask -Action $action -Trigger $trigger -TaskName "CheckIn" -Description "Daily Checkin"