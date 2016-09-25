#! /bin/sh

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="PinballShowcase"
GYM_CODE_SIGNING_IDENTITY="Promopinball Software"
XCODE_SCHEME="Unity-iPhone"
XCODE_PROJECT="Unity-iPhone.xcodeproj"
root = $(pwd)

echo "Creating Build dir"
mkdir -p $(pwd)/Builds/
mkdir -p $(pwd)/Builds/iOS
echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -silent-crashes -logFile /dev/stdout -projectPath $(pwd) -username victorma-fire@hotmail.com -password vic116 -executeMethod Builder.PerformiOSBuild -quit

echo 'Build file dir:'
ls -la $(pwd)/Builds/

cd $(pwd)/Builds/iOS/
ipa build -s $XCODE_SCHEME -m $root/Promopinball_Software.mobileprovision -i $GYM_CODE_SIGNING_IDENTITY --clean
ls -laR $(pwd) | grep ipa
