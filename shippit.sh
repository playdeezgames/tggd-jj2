rm -rf ./pub-linux
rm -rf ./pub-windows
rm -rf ./pub-mac
dotnet publish ./src/agivarsa/agivarsa.vbproj -o ./pub-linux -c Release --sc -p:PublishSingleFile=true -r linux-x64
dotnet publish ./src/agivarsa/agivarsa.vbproj -o ./pub-windows -c Release --sc -p:PublishSingleFile=true -r win-x64
dotnet publish ./src/agivarsa/agivarsa.vbproj -o ./pub-mac -c Release --sc -p:PublishSingleFile=true -r osx-x64
butler push pub-windows thegrumpygamedev/a-game-in-vbnet-about-requiring-some-assembly:windows
butler push pub-linux thegrumpygamedev/a-game-in-vbnet-about-requiring-some-assembly:linux
butler push pub-mac thegrumpygamedev/a-game-in-vbnet-about-requiring-some-assembly:mac
git add -A
git commit -m "shipped it!"