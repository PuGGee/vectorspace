#!/bin/bash

# Delete the old build
rm -rf Dist/WebGL

# Open Unity in headless mode and execute build script
/opt/Unity/Editor/Unity -quit -batchmode -projectPath "$(pwd)" -executeMethod Build.Perform

# scp build onto server
scp -i /home/golan/Documents/new_key.pem -r Dist/WebGL/ ec2-user@www.lwrigley.com:/data/web/

# ssh onto server and replace old build with new one
ssh -i /home/golan/Documents/new_key.pem ec2-user@www.lwrigley.com "cd /data/web; rm -rf vector-space; mv ./WebGL ./vector-space"
