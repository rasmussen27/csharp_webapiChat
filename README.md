# csharp_webapiChat
This is a test of webapi it is a little REST based chat server/client
Written by John Rasmussen

Created with Visual Studio 2017 Community edition.

This is just a test, for data storage it uses a text file, for a real test it should use 
Sql Server/MySQL/PostGres/SQLLite/Mongo/etc... or another type of DBMS.

Rest based service calls are the following:
example port is debugging in visual studio
http://localhost:53011/api/Chat (returns all the messages)
example output:
```html
<ArrayOfstring><string>0|john: message</string><string>1|john: message</string>...
```

http://localhost:53011/api/Chat/5 (returns the message line at 5 and all subsequent messages ie 5-26)
example output:
```html
<ArrayOfstring><string>5|john: message</string><string>6|john: message</string>...
```

http://localhost:53011/api/Post/testuser/testpass/testmessage (posts a message to the text file where
testuser - can be any string it is the user
testpass - can be any string it is the password (not yet implemented)
testmessage - can be any string, this is the message 
example output:
```html
<long>28</long>
```

ConsoleTest is a little console application that lets you call and retreive json or xml from the service.

(this was just used for a quick test)
Format for the text file is:
id|user: message

File is hardcoded to be located in C:\Temp\messages.txt
ex:
```html
0|john: message
1|john: message
2|john: message
3|john: message
4|john: message
5|john: message
6|john: message
7|john: message
8|john: message
9|john: message
10|john: message
11|john: message
12|john: message
13|john: message
14|john: message
15|john: message
16|john: message
17|john: message
18|john: message
19|john: message
20|john: message
21|john: message
22|john: message
23|1: 3
24|1: 3
25|1: 3
26|john: this is a test
```
