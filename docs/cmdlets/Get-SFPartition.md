# Get-SFPartition
Gets the list of partitions of a Service Fabric service.
## Description

The response includes the partition ID, partitioning scheme information, keys supported by the partition, status, 
health, and other details about the partition.



## Required Parameters
#### -ServiceId

The identity of the service. This ID is typically the full name of the service without the 'fabric:' URI scheme.
                    Starting from version 6.0, hierarchical names are delimited with the "~" character.
                    For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be 
"myapp~app1~svc1" in 6.0+ and "myapp/app1/svc1" in previous versions.



#### -PartitionId

The identity of the partition.



