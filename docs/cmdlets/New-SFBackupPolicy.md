# New-SFBackupPolicy
Creates a backup policy.
## Description

Creates a backup policy which can be associated later with a Service Fabric application, service or a partition for 
periodic backup.



## Required Parameters
#### -Name

The unique name identifying this backup policy.



#### -AutoRestoreOnDataLoss

Specifies whether to trigger restore automatically using the latest available backup in case the partition experiences 
a data loss event.



#### -MaxIncrementalBackups

Defines the maximum number of incremental backups to be taken between two full backups. This is just the upper limit. 
A full backup may be taken before specified number of incremental backups are completed in one of the following 
conditions
                    - The replica has never taken a full backup since it has become primary,
                    - Some of the log records since the last backup has been truncated, or
                    - Replica passed the MaxAccumulatedBackupLogSizeInMB limit.



#### -Interval

Defines the interval with which backups are periodically taken. It should be specified in ISO8601 format. Timespan in 
seconds is not supported and will be ignored while creating the policy.



#### -ScheduleFrequencyType

Describes the frequency with which to run the time based backup schedule.
                    . Possible values include: 'Invalid', 'Daily', 'Weekly'



#### -RunTimes

Represents the list of exact time during the day in ISO8601 format. Like '19:00:00' will represent '7PM' during the 
day. Date specified along with time will be ignored.



#### -ConnectionString

The connection string to connect to the Azure blob store.



#### -ContainerName

The name of the container in the blob store to store and enumerate backups from.



#### -Path

UNC path of the file share where to store or enumerate backups from.



#### -RetentionDuration

It is the minimum duration for which a backup created, will remain stored in the storage and might get deleted after 
that span of time. It should be specified in ISO8601 format.



## Optional Parameters
#### -RunDays

List of days of a week when to trigger the periodic backup. This is valid only when the backup schedule frequency type 
is weekly.



#### -FriendlyName

Friendly name for this backup storage.



#### -PrimaryUserName

Primary user name to access the file share.



#### -PrimaryPassword

Primary password to access the share location.



#### -SecondaryUserName

Secondary user name to access the file share.



#### -SecondaryPassword

Secondary password to access the share location



#### -MinimumNumberOfBackups

It is the minimum number of backups to be retained at any point of time. If specified with a non zero value, backups 
will not be deleted even if the backups have gone past retention duration and have number of backups less than or 
equal to it.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



