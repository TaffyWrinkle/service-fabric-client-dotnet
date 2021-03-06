# Restart-SFNode
Restarts a Service Fabric cluster node.
## Description

Restarts a Service Fabric cluster node that is already started.



## Required Parameters
#### -NodeName

The name of the node.



#### -NodeInstanceId

The instance ID of the target node. If instance ID is specified the node is restarted only if it matches with the 
current instance of the node. A default value of "0" would match any instance ID. The instance ID can be obtained 
using get node query.



## Optional Parameters
#### -CreateFabricDump

Specify True to create a dump of the fabric node process. This is case-sensitive. Possible values include: 'False', 
'True'



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



