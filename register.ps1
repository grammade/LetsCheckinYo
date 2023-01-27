$action = New-ScheduledTaskAction -Execute 'LetsCheckinYo.exe' -WorkingDirectory "D:\LetsCheckinYo\"
$trigger = New-ScheduledTaskTrigger -Daily -At 07:25
$trigger2 = New-ScheduledTaskTrigger -Daily -At 16:35

Register-ScheduledTask -Action $action -Trigger $trigger -TaskName "CheckIn" -Description "Daily Checkin"
Register-ScheduledTask -Action $action -Trigger $trigger2 -TaskName "CheckOut" -Description "Daily Checkout"