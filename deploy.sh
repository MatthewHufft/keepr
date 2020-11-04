cd wwwsrc
npm run build
cd ..
dotnet publish -c Release
docker build -t keepr ./
docker tag keepr registry.heroku.com/thekeepr/web
docker push registry.heroku.com/thekeepr/web
heroku container:release web -a thekeepr
echo press any key
read end